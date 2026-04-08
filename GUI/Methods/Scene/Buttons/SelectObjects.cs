using BazisGUI.AdvanceSelection;
using BazisGUI.Extensions;
using BazisGUI.Properties;
using MathNet.Numerics.RootFinding;
using Model.Interfaces;
using Model.MeshObjects;
using Model.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        Dictionary<string, Button> objButtons = new Dictionary<string, Button>();
        public event Action<string> OnChangeSelectedObjectsEvent;
        /// <summary>
        /// Временный выбранный объект для работы со свойствами через сцену
        /// </summary>

        public string SelectedObjects
        {
            get { return btnSelect.Text; }
            set 
            {
                if(objButtons.ContainsKey(value) | value == "_")
                {
                    if(value == "_")
                        btnSelect.Text = "Выбрать";
                    else
                        btnSelect.Text = value;
                    SetBackColorToAllObjects();
                    DisplayObjects();
                }
            }
        }

        public void AddObjectsType(string objsType)
        {
            var btn = CreateButton(objsType);

            btn.MouseDown += Btn_MouseDown;

            btn.Visible = false;
            if(objButtons.Count != 0)
            {
                var last = objButtons.Last().Value;
                btn.Location = 
                    new Point(
                        last.Location.X, 
                        last.Location.Y + last.Height - 1);
            }   
            else
            {
                btn.Location =
                new Point(
                    btnSelect.Location.X,
                    btnSelect.Location.Y + btnSelect.Height - 2);
            }
            splitContainer2.Panel1.Controls.Add(btn);
            btn.BringToFront();

            objButtons.Add(objsType, btn);
        }

        private void Btn_MouseDown(object sender, MouseEventArgs e)
        {
            var btn = sender as Button;
            SelectedObjects = btn.Text;
            OnChangeSelectedObjectsEvent?.Invoke(SelectedObjects);
            btnSelect.Tag = false;

            foreach (var item in objButtons)
                item.Value.Visible = false;
        }

        private void btnSelect_Leave(object sender, EventArgs e)
        {
            btnSelect.Tag = false;
            btnSelect.Image = Resources.arrow_r;
            foreach (var item in objButtons)
                item.Value.Visible = false;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            var flag = bool.Parse(btnSelect.Tag.ToString());
            if (!flag)
            {
                flag = true;
                btnSelect.Image = Resources.arrow_d;
            }
            else
            {
                flag = false;
                btnSelect.Image = Resources.arrow_r;
            }

            btnSelect.Tag = flag;
            foreach (var item in objButtons)
                item.Value.Visible = flag;

        }

        public void PresentModelObjectsForSelection()
        {

            foreach (var item in objButtons)
                splitContainer2.Panel1.Controls.Remove(item.Value);

            objButtons.Clear();

            var objTypes = project.GetAllModelObjects().Select(x => x.ObjType).Distinct();

            if (objTypes.Count() != 0)
            {
                AddObjectsType("Объекты");

                foreach (ObjType item in objTypes)
                    AddObjectsType(item.ToString());
            }
        }


        public Button CreateButton(string name)
        {
            
            var btn = new Button();
            btn.Anchor = btnSelect.Anchor;
            btn.AutoSize = btnSelect.AutoSize;
            btn.Name = name;
            btn.Size = btnSelect.Size;
            btn.Text = name;
            btn.AutoSize = btnSelect.AutoSize;
            btn.FlatStyle = btnSelect.FlatStyle;
            btn.Margin = btnSelect.Margin;

            return btn;
        }

        private SelectInPlainEventArgs SelectionControl_SelectInPlain(SelectInPlainEventArgs arg2, ObjType objType, List<int> numbers, bool isSelected)
        {
            try
            {
                var objsType = arg2.Objects;
                if (objsType == SelectedObjects.ToEnum<ObjType>())
                {
                    if (objsType == ObjType.Узел)
                        arg2 = SelectNodeInPlane(arg2, numbers, isSelected);
                    else
                        SelectE2DInPlane(arg2, objType, numbers, isSelected);

                    DisplayObjects();
                }
            }
            catch (Exception ex) { console.PrintInfo(ex.Message, Color.Red); }
            return arg2;
        }

        private void SelectE2DInPlane(SelectInPlainEventArgs selectInPlainEvent, ObjType objType, List<int> numbers, bool isSelected)
        {
            if (numbers == null || numbers.Count == 0)
            {
                console.PrintInfo("Выберите хотя бы один элемент", Color.Red);
                return;
            }

            var localCache = new HashSet<int>();

            foreach (var selObject in numbers)
            {
                var color = GetColor(objType, selObject, isSelected);
                var objs = project.SelectE2DInPlane(selectInPlainEvent.Angle, selObject, color);

                if (objs == null)
                    continue;

                var newObjs = objs.Where(x => localCache.Add(x)).ToList();

                if (newObjs.Count == 0)
                    continue;

                foreach (var set in newObjs.Select(x => project.GetModelSetInfo(objType, x)).Distinct(new DefaultSetInfoComparer()))
                {
                    var pres = project.CreateModelObjectsPresentor(set);
                    SetVBObjectAttribute(pres, "цвет");
                }
            }
            selectInPlainEvent.SelectedNumbers = localCache.ToList();
            PrintSelectedInfo(objType, localCache.Count);
            DisplayObjects();
        }

        private SelectInPlainEventArgs SelectNodeInPlane(SelectInPlainEventArgs selectInPlainEvent, List<int> numbers, bool isSelected)
        {
            var remainingSlots = new List<int?>();
            if (selectInPlainEvent.FirstNodeForPlane == null) remainingSlots.Add(0);
            if (selectInPlainEvent.SecondNodeForPlane == null) remainingSlots.Add(1);
            if (selectInPlainEvent.ThirdNodeForPlane == null) remainingSlots.Add(2);

            for (int i = 0; i < numbers.Count && i < remainingSlots.Count; i++)
            {
                switch (remainingSlots[i])
                {
                    case 0: selectInPlainEvent.FirstNodeForPlane = numbers[i]; break;
                    case 1: selectInPlainEvent.SecondNodeForPlane = numbers[i]; break;
                    case 2: selectInPlainEvent.ThirdNodeForPlane = numbers[i]; break;
                }
            }

            var selectedNumbers = new[] { selectInPlainEvent.FirstNodeForPlane, selectInPlainEvent.SecondNodeForPlane, selectInPlainEvent.ThirdNodeForPlane }
                                  .Where(n => n.HasValue)
                                  .Select(n => n.Value)
                                  .ToList();

            if (selectedNumbers.Count < 3)
            {
                console.PrintInfo("Не выбрано три узла", Color.Red);
                return selectInPlainEvent;
            }

            var nodes = project.GetAllModelNodes()
                               .Join(selectedNumbers, node => node.Number, num => num, (node, num) => node)
                               .ToArray();

            var plane = new Geometry.Plane(nodes[0].Position, nodes[1].Position, nodes[2].Position);

            var color = GetColor(selectInPlainEvent.Objects, selectedNumbers[0], isSelected);
            project.SelectNodeInPlane(plane, color);
            selectInPlainEvent.FirstNodeForPlane = null;
            selectInPlainEvent.SecondNodeForPlane = null;
            selectInPlainEvent.ThirdNodeForPlane = null;
            
            var pres = project.CreateModelObjectsPresentor(ObjType.Узел);
            SetVBObjectAttribute(pres, "цвет");
            var selectedCount = project.GetAllModelNodes().Count(x => x.Color == settingsConfig.SelectObjectColor);
            PrintSelectedInfo(ObjType.Узел, selectedCount);
            selectInPlainEvent.SelectedNumbers = selectedNumbers;
            return selectInPlainEvent;
        }


        private SelectInDirectionEventArgs SelectionControl_SelectInDirection(SelectInDirectionEventArgs arg2, List<int> numbers, bool isSelected)
        {
            try
            {
                var objsType = arg2.Objects;

                if (objsType == SelectedObjects.ToEnum<ObjType>()) 
                {
                    var temp = arg2;
                    if (numbers.Count >= 2)
                    {
                        arg2.SetNumbers(SelectInDirection(objsType, numbers, arg2.Angle, arg2.Reverse, isSelected));
                        temp.FirstNodeDirection = numbers[0];
                        temp.SecondNodeDirection = numbers[1];
                        return temp;
                    }
                    if (arg2.SecondNodeDirection != null)
                    {
                        temp.FirstNodeDirection = null;
                        temp.SecondNodeDirection = null;
                    }

                    var current = numbers[0];

                    if (temp.FirstNodeDirection == null)
                    {
                        temp.FirstNodeDirection = current;
                        console.PrintInfo("Выберите второй узел...", Color.Black);
                        return temp;
                    }
                    temp.SecondNodeDirection = current;

                    var tempSelectedNumbers = SelectInDirection(objsType, [temp.FirstNodeDirection.Value, temp.SecondNodeDirection.Value], arg2.Angle, arg2.Reverse, isSelected);
                    arg2.SetNumbers(tempSelectedNumbers);

                    return temp;
                }       
            }
            catch (Exception ex)
            { 
                console.PrintInfo(ex.Message, Color.Red); 
                return arg2; 
            }
            return arg2;
        }

        private void OnReverseChanged(SelectInDirectionEventArgs config)
        {
            if (!config.FirstNodeDirection.HasValue || !config.SecondNodeDirection.HasValue)
            {
                console.PrintInfo("Нет данных для перестроения", Color.Red);
                return;
            }

            var first = config.FirstNodeDirection.Value;
            var second = config.SecondNodeDirection.Value;

            if (config.SelectedNumbers.Count != 0)
            {
                var uniqueSets = config.SelectedNumbers.Select(number => project.GetModelSetInfo(config.Objects, number))
                    .GroupBy(setInfo => setInfo.Name)
                    .Select(g => g.First())
                    .ToList();
                foreach (var setInfo in uniqueSets)
                {
                    foreach (var number in config.SelectedNumbers)
                        setInfo.SetBackColor(number);
                    var pres = project.CreateModelObjectsPresentor(setInfo);
                    SetVBObjectAttribute(pres, "цвет");
                }
            }
            var tempSelectedNumbers = SelectInDirection(config.Objects, [first, second], config.Angle, config.Reverse);
            config.SetNumbers(tempSelectedNumbers);
        }

        private List<int> SelectInDirection(ObjType arg2, List<int> numbers, float angle, bool reverse, bool isSelected = true)
        {
            if (numbers.Count < 2)
                return null;

            var first = numbers[0];
            var second = numbers[1];

            List<int> selectedNumbers;
            var color = GetColor(arg2, first, isSelected);
            if (!reverse)
                selectedNumbers = project.SelectNodeInDirection(angle, second, first, color);
            else
                selectedNumbers = project.SelectNodeInDirection(angle, first, second, color);

            var pres = project.CreateModelObjectsPresentor(arg2);
            SetVBObjectAttribute(pres, "цвет");
            
            PrintSelectedInfo(arg2, selectedNumbers.Count);
            DisplayObjects();
            return selectedNumbers;
        }
        private List<int> SelectionControl_SelectInSet(ObjType selectType, List<int> numbers, bool isSelected)
        {
            if (numbers == null || numbers.Count == 0)
            {
                console.PrintInfo("Нет выбранных объектов", Color.Red);
                return null;
            }

            var uniqueSets = numbers.Select(number => project.GetModelSetInfo(selectType, number)).GroupBy(setInfo => setInfo.Name).Select(g => g.First()).ToList();

            foreach (var setInfo in uniqueSets)
            {
                foreach (var number in setInfo.GetNumbers())
                {
                    var element = project.GetModelObject(selectType, number);
                    element.Color = GetColor(selectType, number, isSelected); 
                }

                var pres = project.CreateModelObjectsPresentor(setInfo);
                SetVBObjectAttribute(pres, "цвет");
            }

            var selectedCount = selectType == ObjType.Узел
                ? project.GetAllModelNodes().Where(x => x.Color == settingsConfig.SelectObjectColor).Select(x=>x.Number).ToList()
                : project.GetAllModelElements().Where(x => x.Color == settingsConfig.SelectObjectColor).Select(x=>x.Number).ToList();

            PrintSelectedInfo(selectType, selectedCount.Count);
            DisplayObjects();
            return selectedCount;
        }

        private void SelectionControl_SelectInGeom(int targetDim, List<int> numbers, bool isSelected)
        {

            if (numbers == null || numbers.Count == 0)
            {
                console.PrintInfo("Нет выбранных объектов", Color.Red);
                return;
            }

            var startDim = GetModelObjects(SelectedObjects).Where(x => x.Number == numbers[0]).First().Dim;
            var objType = SelectedObjects.ToEnum<ObjType>();
            var volumes = project.SelectByScope(startDim, numbers, targetDim);

            foreach (var number in volumes)
            {
                var element = project.GetModelObject(objType, number);

                element.Color = GetColor(objType, number, isSelected);
            }

            foreach (var number in numbers)
            {
                var setInfo = project.GetModelSetInfo(objType, number);
                var pres = project.CreateModelObjectsPresentor(setInfo);
                SetVBObjectAttribute(pres, "цвет");
            }

            var selectedCount = project.GetAllModelObjects().Count(x => x.Color == settingsConfig.SelectObjectColor);
            PrintSelectedInfo(objType, selectedCount);
            DisplayObjects();
        }

        private void PrintSelectedInfo(ObjType obj, int count)
        {
            console.PrintInfo($"Количество выбранных элементов {count}, тип: {obj}", Color.Black);
        }

        private Color GetColor(ObjType objType, int number, bool isSelected)
        {
            var color = settingsConfig.SelectObjectColor;
            if (!isSelected)
                color = project.GetModelSetInfo(objType, number).Color;
            return color;
        }
    }
}
