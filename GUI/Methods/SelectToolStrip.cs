using BaseModule;
using BaseModule.Console;
using BaseModule.Extensions;
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
            //set { tblSelectObject.Controls[0].Text = value; }
        }

        public void AddObjectsType(string objsType)
        {
            var btn = CreateButton(objsType);
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
            scene.Controls.Add(btn);
            objButtons.Add(objsType, btn);
        }

        private void spbSelectObject_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            spbSelectObject.ToolTipText = e.ClickedItem.Text;

            //ObjType objType;
            //Enum.TryParse(spbSelectObject.ToolTipText, out objType);
            foreach (ObjType item in Enum.GetValues(typeof(ObjType)))
            {
                project.ModelData.ObjectData.SetBackColor(item);
                var pres = project.CreateModelObjectsPresentor(item);
                SetVBObjectAttribute(pres, "цвет");
            }

            DisplayObjects();
        }

        //public void PresentModelOnSelectToolStrip()
        //{
        //    spbSelectObject.DropDownItems.Clear();
        //    var objTypes = project.GetAllModelObjects().Select(x => x.ObjType).Distinct();

        //    foreach (ObjType item in objTypes)
        //        AddObjectsType(item.ToString());

        //    if(objTypes.Count() != 0)
        //    {
        //        AddObjectsType("Объекты");
        //        spbSelectObject.ToolTipText = "Объекты";
        //    }

        //    spbSelectObject.Invalidate();
        //}

        private void btnSelect_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var flag = bool.Parse(btn.Tag.ToString());
            if (!flag)
            {
                btn.Tag = true;
                foreach (var item in objButtons)
                {
                    item.Value.Visible = true;
                }
            }
            else
            {
                btn.Tag = false;
                foreach (var item in objButtons)
                {
                    item.Value.Visible = false;
                }
            }

        }

        public void PresentModelOnSelectToolStrip()
        {
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
                if (objsType == spbSelectObject.ToolTipText.ToEnum<ObjType>())
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
                if (objsType == spbSelectObject.ToolTipText.ToEnum<ObjType>())
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
