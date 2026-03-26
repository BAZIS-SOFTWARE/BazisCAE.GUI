using BazisGUI.AdvanceSelection;
using BazisGUI.Extensions;
using BazisGUI.Properties;
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
        private (int? first, int? second, int? third) lastDirectionSelection;
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
            //lbl.Location = new System.Drawing.Point(4, 7);
            btn.Name = name;
            btn.Size = btnSelect.Size;
            btn.Text = name;
            btn.AutoSize = btnSelect.AutoSize;
            btn.FlatStyle = btnSelect.FlatStyle;
            btn.Margin = btnSelect.Margin;

            return btn;
        }

        private void SelectionControl_SelectInPlain(SelectInPlainEventArgs arg2, ObjType objType, List<int> numbers)
        {
            try
            {
                var objsType = arg2.Objects;
                if (objsType == SelectedObjects.ToEnum<ObjType>())
                {
                    if (objsType == ObjType.Узел)
                        SelectNodeInPlane(numbers);
                    else
                        SelectE2DInPlane(arg2.Angle, objType, numbers);

                    DisplayObjects();
                }
            }
            catch (Exception ex) { console.PrintInfo(ex.Message, Color.Red); }
        }

        private void SelectE2DInPlane(float angle, ObjType objType, List<int> numbers)
        {
            if (numbers == null || numbers.Count == 0)
            {
                console.PrintInfo("Выберите хотя бы один элемент", Color.Red);
                return;
            }

            var localCache = new HashSet<int>();

            foreach (var selObject in numbers)
            {
                var objs = project.SelectE2DInPlane(angle, selObject, settingsConfig.SelectObjectColor);

                if (objs == null)
                    continue;

                var newObjs = objs.Where(x => localCache.Add(x)).ToArray();

                if (newObjs.Length == 0)
                    continue;

                foreach (var set in newObjs
                    .Select(x => project.GetModelSetInfo(objType, x))
                    .Distinct(new DefaultSetInfoComparer()))
                {
                    var pres = project.CreateModelObjectsPresentor(set);
                    SetVBObjectAttribute(pres, "цвет");
                }
            }

            PrintSelectedInfo(objType, localCache.Count);
            DisplayObjects();
        }

        private void SelectNodeInPlane(List<int> numbers)
        {
            var remainingSlots = new List<int?>();
            if (lastDirectionSelection.first == null) remainingSlots.Add(0);
            if (lastDirectionSelection.second == null) remainingSlots.Add(1);
            if (lastDirectionSelection.third == null) remainingSlots.Add(2);

            for (int i = 0; i < numbers.Count && i < remainingSlots.Count; i++)
            {
                switch (remainingSlots[i])
                {
                    case 0: lastDirectionSelection.first = numbers[i]; break;
                    case 1: lastDirectionSelection.second = numbers[i]; break;
                    case 2: lastDirectionSelection.third = numbers[i]; break;
                }
            }

            var selectedNumbers = new[] { lastDirectionSelection.first, lastDirectionSelection.second, lastDirectionSelection.third }
                                  .Where(n => n.HasValue)
                                  .Select(n => n.Value)
                                  .ToList();

            if (selectedNumbers.Count < 3)
            {
                console.PrintInfo("Не выбрано три узла", Color.Red);
                return;
            }

            var nodes = project.GetAllModelNodes()
                               .Join(selectedNumbers, node => node.Number, num => num, (node, num) => node)
                               .ToArray();

            var plane = new Geometry.Plane(nodes[0].Position, nodes[1].Position, nodes[2].Position);
            project.SelectNodeInPlane(plane, settingsConfig.SelectObjectColor);
            lastDirectionSelection = (null, null, null);
            var selectedCount = project.GetAllModelNodes().Count(x => x.Color == settingsConfig.SelectObjectColor);
            PrintSelectedInfo(ObjType.Узел, selectedCount);

            var pres = project.CreateModelObjectsPresentor(ObjType.Узел);
            SetVBObjectAttribute(pres, "цвет");
        }


        private void SelectionControl_SelectInDirection(SelectInDirectionEventArgs arg2, List<int> numbers)
        {
            try
            {
                var objsType = arg2.Objects;

                if (objsType == SelectedObjects.ToEnum<ObjType>()) 
                {
                    if (numbers.Count >= 2)
                    {
                        lastDirectionSelection = (numbers[0], numbers[1], null);
                        SelectInDirection(objsType, numbers, arg2.Angle, arg2.Reverse);
                        return;
                    }
                    if (lastDirectionSelection.second != null)
                        lastDirectionSelection = (null, null, null);

                    var current = numbers[0];

                    if (lastDirectionSelection.first == null)
                    {
                        lastDirectionSelection.first = current;
                        console.PrintInfo("Выберите второй узел...", Color.Black);
                        return;
                    }
                    lastDirectionSelection.second = current;

                    var first = lastDirectionSelection.first.Value;
                    var second = lastDirectionSelection.second.Value;
                    SelectInDirection(objsType, [first, second], arg2.Angle, arg2.Reverse);
                }
                    
            }
            catch (Exception ex){ console.PrintInfo(ex.Message, Color.Red); }
        }

        private void OnReverseChanged(bool reverse, float angle, ObjType type)
        {
            if (!lastDirectionSelection.first.HasValue || !lastDirectionSelection.second.HasValue)
            {
                console.PrintInfo("Нет данных для перестроения", Color.Red);
                return;
            }

            var first = lastDirectionSelection.first.Value;
            var second = lastDirectionSelection.second.Value;

            SelectInDirection(type, new List<int> { first, second }, angle, reverse);
        }

        private void SelectInDirection(ObjType arg2, List<int> numbers, float angle, bool reverse)
        {
            if (numbers.Count < 2)
                return;

            var first = numbers[0];
            var second = numbers[1];

            int counter;

            if (!reverse)
                counter = project.SelectNodeInDirection(angle, second, first, settingsConfig.SelectObjectColor).Count;
            else
                counter = project.SelectNodeInDirection(angle, first, second, settingsConfig.SelectObjectColor).Count;

            var pres = project.CreateModelObjectsPresentor(arg2);
            SetVBObjectAttribute(pres, "цвет");

            PrintSelectedInfo(arg2, counter);
            DisplayObjects();
        }
        private void SelectionControl_SelectInSet(ObjType selectType, List<int> numbers)
        {
            if (numbers == null || numbers.Count == 0)
            {
                console.PrintInfo("Нет выбранных объектов", Color.Red);
                return;
            }

            var uniqueSets = numbers.Select(number => project.GetModelSetInfo(selectType, number)).GroupBy(setInfo => setInfo.Name).Select(g => g.First()).ToList();

            foreach (var setInfo in uniqueSets)
            {
                foreach (var number in setInfo.GetNumbers())
                {
                    var element = project.GetModelObject(selectType, number);
                    element.Color = settingsConfig.SelectObjectColor;
                }

                var pres = project.CreateModelObjectsPresentor(setInfo);
                SetVBObjectAttribute(pres, "цвет");
            }

            var selectedCount = selectType == ObjType.Узел
                ? project.GetAllModelNodes().Count(x => x.Color == settingsConfig.SelectObjectColor)
                : project.GetAllModelElements().Count(x => x.Color == settingsConfig.SelectObjectColor);

            PrintSelectedInfo(selectType, selectedCount);
            DisplayObjects();
        }

        private void SelectionControl_SelectInGeom(int targetDim, List<int> numbers)
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
                element.Color = settingsConfig.SelectObjectColor;
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
    }
}
