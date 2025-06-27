using BaseModule;
using BaseModule.Console;
using BaseModule.Extensions;
using BazisGUI.Utilities;
using Model.Interfaces;
using Model.MeshObjects;
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

        private void spbSelectObject_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            spbSelectObject.ToolTipText = e.ClickedItem.Text;
            SetBackColorToAllObjectsEvent?.Invoke(this);
        }
        private void btnSelectObjects_Click(object sender, EventArgs e)
        {
            var btn = sender as ToolStripButton;

            if (btn.Tag.ToString() == "1")
                spbSelectObject.ToolTipText = "Узел";
            else if (btn.Tag.ToString() == "2")
                spbSelectObject.ToolTipText = "Элементы";
            else
                spbSelectObject.ToolTipText = "Фигуры";

            spbSelectObject.Invalidate();

            SetBackColorToAllObjectsEvent?.Invoke(this);

        }

        private void btnAdvanceSelection_Click(object sender, EventArgs e)
        {
            var btn = sender as ToolStripButton;
            if (btn.Checked)
            {
                var form = new Form()
                {
                    Name = "selectForm",
                    Text = "Дополненный выбор",
                    AutoSize = false,
                    ShowIcon = false,
                    TopMost = true,
                    Owner = Application.OpenForms[0]
                };

                form.FormClosing += (s1, s2) => { btn.Checked = false; };
                var selectionControl = new AdvanceSelectionSet() { Dock = DockStyle.Fill };
                selectionControl.SelectInDirection += SelectionControl_SelectInDirection;
                selectionControl.SelectInPlain += SelectionControl_SelectInPlain;
                selectionControl.SelectNodes += (s1, s2) =>
                {
                    spbSelectObject.ToolTipText = ObjType.Узел.ToString();
                    spbSelectObject.Invalidate();
                };

                selectionControl.SelectElements += (s1, s2) =>
                {
                    spbSelectObject.ToolTipText = ObjType.Элемент2D.ToString();
                    spbSelectObject.Invalidate();
                };

                form.ClientSize = selectionControl.Size;
                form.Controls.Add(selectionControl);
                form.Show();
                var location = scene.PointToScreen(Point.Empty);
                form.Location = location;
            }
            else
            {
                var forms = Application.OpenForms.Cast<Form>().ToList();
                var form = forms.Find(x => x.Name == "selectForm");
                if (form != null)
                {
                    form.Close();
                    btn.Checked = false;
                }
            }
        }

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

                    scene.SceneControl.DisplayObjects();
                }
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }

        private void SelectE2DInPlane(float angle)
        {

            var selObjs = project.ModelData.ObjectData.GetObjects(ObjType.Элемент2D).

    Where(x => x.Color == scene.SceneControl.SelectionColor).ToArray();

            if (selObjs?.Count() > 0)
            {
                var element = selObjs.Last();
                modelController.SelectionHelper.SelectE2DInPlane(project.ModelData.ObjectData,
                    angle, element.Number, scene.SceneControl.SelectionColor);
                var pres = scene.CreateObjectsPresentor(project.ModelData, ObjType.Элемент2D);
                scene.SetObjectsSceneAttribute(pres, ObjType.Элемент2D.ToString(), "цвет");
            }
            else console.PrintInfo("Выберите хотя бы один элемент", Color.Red);
        }

        private void SelectNodeInPlane()
        {
            var selObjs = project.ModelData.ObjectData.GetObjects(ObjType.Узел).

    Where(x => x.Color == scene.SceneControl.SelectionColor).ToArray();
            if (selObjs?.Count() > 2)
            {
                var n1 = (Node)selObjs.First();
                var n2 = (Node)selObjs.Skip(1).First();
                var n3 = (Node)selObjs.Skip(2).First();

                var plane = new Geometry.Plane(n1.Position, n2.Position, n3.Position);
                modelController.SelectionHelper.SelectNodeInPlane(project.ModelData.ObjectData,
                    plane, scene.SceneControl.SelectionColor);

                var pres = scene.CreateObjectsPresentor(project.ModelData, ObjType.Узел);
                scene.SetObjectsSceneAttribute(pres, ObjType.Узел.ToString(), "цвет");
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
    Where(x => x.Color == scene.SceneControl.SelectionColor).ToArray();
            if (selObjs?.Count() > 1)
            {
                if (!reverse)
                {
                    modelController.SelectionHelper.SelectNodeInDirection(project.ModelData.ObjectData,
                        angle, selObjs.Skip(1).First().Number, selObjs.First().Number, scene.SceneControl.SelectionColor);
                }

                else
                {
                    modelController.SelectionHelper.SelectNodeInDirection(project.ModelData.ObjectData,
                        angle, selObjs.First().Number, selObjs.Skip(1).First().Number, scene.SceneControl.SelectionColor);
                }

                var pres = scene.CreateObjectsPresentor(project.ModelData, arg2);
                scene.SetObjectsSceneAttribute(pres, arg2.ToString(), "цвет");

                scene.SceneControl.DisplayObjects();
            }
            else
                console.PrintInfo("Выбранных объектов должно быть больше двух", Color.Red);
        }
    }
}
