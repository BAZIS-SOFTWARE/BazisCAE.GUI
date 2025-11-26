using BaseModule;
using BaseModule.Console;
using BaseModule.Extensions;
using BazisGUI.Properties;
using BazisGUI.Utilities;
using Model.Interfaces;
using Model.MeshObjects;
using Model.Utilities;
using Project.Interfaces.Tasks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        Dictionary<string, Button> objButtons = new Dictionary<string, Button>();


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
                    btnSelect.Location.X - 1,
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
            //var btnSelect = sender as Button;
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

        //private void btnSelectObjects_Click(object sender, EventArgs e)
        //{
        //    var btn = sender as ToolStripButton;

        //    if (btn.Tag.ToString() == "1")
        //        spbSelectObject.ToolTipText = "Узел";
        //    else if (btn.Tag.ToString() == "2")
        //        spbSelectObject.ToolTipText = "Элементы";
        //    else
        //        spbSelectObject.ToolTipText = "Фигуры";

        //    spbSelectObject.Invalidate();

        //    SetBackColorToAllObjects();

        //}

        

        private void SelectionControl_SelectInPlain(object arg1, SelectInPlainEventArgs arg2)
        {
            try
            {
                var objsType = Converters.ConvertToObjsType(arg2.Objects);
                if (objsType == SelectedObjects.ToEnum<ObjType>())
                {
                    if (objsType == ObjType.Узел)
                    {
                        SelectNodeInPlane();
                    }
                    else
                    {
                        SelectE2DInPlane(arg2.Angle);
                    }

                    DisplayObjects();
                }
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }

        private void SelectE2DInPlane(float angle)
        {

            var selObjs = project.GetModelObjects(ObjType.Элемент2D).

    Where(x => x.Color == settingsConfig.SelectObjectColor).ToArray();

            if (selObjs?.Count() > 0)
            {
                var element = selObjs.Last();
                var objs = project.SelectE2DInPlane(
                    angle, element.Number, settingsConfig.SelectObjectColor);

                // TO DO исправить метод
                foreach (var set in objs.Select(x => project.
GetModelSetInfo(ObjType.Элемент2D, x)).
Distinct(new DefaultSetInfoComparer()))
                {
                    var pres = project.CreateModelObjectsPresentor(set);
                    SetVBObjectAttribute(pres, "цвет");
                }

                DisplayObjects();

            }
            else console.PrintInfo("Выберите хотя бы один элемент", Color.Red);
        }

        private void SelectNodeInPlane()
        {
            var selObjs = project.ModelData.ObjectData.GetObjects(ObjType.Узел).

    Where(x => x.Color == settingsConfig.SelectObjectColor).ToArray();
            if (selObjs?.Count() > 2)
            {
                var n1 = (Node)selObjs.First();
                var n2 = (Node)selObjs.Skip(1).First();
                var n3 = (Node)selObjs.Skip(2).First();

                var plane = new Geometry.Plane(n1.Position, n2.Position, n3.Position);
                project.SelectNodeInPlane(plane, settingsConfig.SelectObjectColor);

                var pres = project.CreateModelObjectsPresentor(ObjType.Узел);
                SetVBObjectAttribute(pres, "цвет");
            }
            else console.PrintInfo("Не выбрано три узла", Color.Red);
        }

        private void SelectionControl_SelectInDirection(object arg1, SelectInDirectionEventArgs arg2)
        {
            try
            {
                var objsType = Converters.ConvertToObjsType(arg2.Objects);
                if (objsType == SelectedObjects.ToEnum<ObjType>())
                {
                    SelectInDirection(objsType, arg2.Angle, arg2.Reverse);
                }

            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void SelectInDirection(ObjType arg2, float angle, bool reverse)
        {

            var selObjs = project.ModelData.ObjectData.GetObjects(arg2).
    Where(x => x.Color == settingsConfig.SelectObjectColor).ToArray();
            if (selObjs?.Count() > 1)
            {
                if (!reverse)
                {
                    project.SelectNodeInDirection(angle, selObjs.Skip(1).First().Number, 
                        selObjs.First().Number, settingsConfig.SelectObjectColor);
                }

                else
                {
                    project.SelectNodeInDirection(angle, selObjs.First().Number, 
                        selObjs.Skip(1).First().Number, settingsConfig.SelectObjectColor);
                }

                var pres = project.CreateModelObjectsPresentor(arg2);
                SetVBObjectAttribute(pres, "цвет");

                DisplayObjects();
            }
            else
                console.PrintInfo("Выбранных объектов должно быть больше двух", Color.Red);
        }
    }
}
