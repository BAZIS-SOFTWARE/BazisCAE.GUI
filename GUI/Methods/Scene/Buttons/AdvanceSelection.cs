using BazisGUI.AdvanceSelection;
using BazisGUI.AdvanceSelection.ControlsForSelect;
using BazisGUI.Extensions;
using Model.Interfaces;
using Model.MeshObjects;
using Model.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static IronPython.Modules.PythonIterTools;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void btnSelection_Paint(object sender, PaintEventArgs e)
        {
            var gr = e.Graphics;
            var button = sender as Button;
            var rectangle = new Rectangle(0, 0, button.Width - 1, button.Height - 1);


            if (bool.Parse(button.Tag.ToString()))
                e.Graphics.DrawRectangle(new Pen(Color.Black, 3.0f), rectangle);
        }

        private void btnAdvSelection_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;

            if (!bool.Parse(btn.Tag.ToString()))
            {
                if(SelectedObjects == "Выбрать" || SelectedObjects == "Объекты")
                    return;
                btn.Tag = true;
                var form = new Form()
                {
                    Name = "selectForm",
                    Text = "Расширенный выбор",
                    AutoSize = false,
                    ShowIcon = false,
                    MinimizeBox = false,
                    MaximizeBox = false,
                    TopMost = true,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Owner = Application.OpenForms[0]
                };
                form.FormClosing += (s1, s2) => 
                {
                    CleanupSelectionControl(form);
                    btn.Tag = false;
                    btn.Invalidate();
                };

                if (IsMesh())
                {
                    var selectionControl = new MeshSelect(SelectedObjects);
                    OnChangeSelectedObjectsEvent += selectionControl.SetAvailableModes;
                    //selectionControl.SelectInDirection += OnReverseChanged;
                    selectionControl.CloseForm += RefreshForm;

                    form.ClientSize = selectionControl.Size;
                    form.Controls.Add(selectionControl);
                }

                else if (IsGeometry())
                {
                    var selectionControl = new GeomSelect(SelectedObjects);
                    OnChangeSelectedObjectsEvent += selectionControl.SetAvailableModes;
                    selectionControl.CloseForm += RefreshForm;

                    form.ClientSize = selectionControl.Size;
                    form.Controls.Add(selectionControl);
                }

                form.Show();
                var location = GetPosition(form.Height);
                form.Location = location;
            }
            else
            {
                CloseAdvancedSelectionForm();
            }
        }

        private void DispatchSelection(List<int> numbers, bool isSelected)
        {
            var forms = Application.OpenForms.Cast<Form>().ToList();
            var form = forms.Find(x => x.Name == "selectForm");
            if(form != null)
            {
                if (IsMesh())
                {
                    var mesh = form.Controls.OfType<MeshSelect>().FirstOrDefault();
                    var additionalMode = mesh.GetSelectedAdditionalMode();
                    var resFlag = false;

                    if (additionalMode is SelectInDirectionEventArgs sdArgs) 
                    {
                        sdArgs.SelectedNumbers.AddRange(numbers);
 
                        if (sdArgs.SelectedNumbers.Count() > 1)
                        {
                            if (SelectInPlain(sdArgs).Count > 0)
                            {
                                resFlag = true;
                                sdArgs.SelectedNumbers.Clear();
                            }    
                        }
                        else
                            console.PrintInfo("Выбранных объектов должно быть больше двух", Color.Orange);
                    }
                    else if (additionalMode is SelectInPlainEventArgs spArgs) 
                    {
                        spArgs.SelectedNumbers.AddRange(numbers);
                        if (spArgs.SelectedNumbers.Count > 2 && SelectedObjects.ToEnum<ObjType>() == ObjType.Узел)
                        {
   
                            if (SelectNodeInPlane(spArgs.SelectedNumbers).Count > 0)
                            {
                                resFlag = true;
                                // отчищаем список
                                spArgs.SelectedNumbers.Clear();
                            }

                        }
                        else
                            console.PrintInfo("Не выбрано три узла", Color.Orange);

                        if(spArgs.SelectedNumbers.Count > 1 && SelectedObjects.ToEnum<ObjType>() == ObjType.Элемент2D)
                        {
                            if(SelectE2DInPlane(spArgs.SelectedNumbers, spArgs.Angle).Count > 0)
                            {
                                resFlag = true;
                                // отчищаем список
                                spArgs.SelectedNumbers.Clear();
                            }
                        }
                        else
                            console.PrintInfo("Не выбрано ни одного элемента", Color.Orange);

                        //DisplayObjects();

                    }
                    else if (additionalMode is ObjType setType)
                        SelectionControl_SelectInSet(setType, numbers, isSelected);

                    if(resFlag)
                    {
                        var objType = SelectedObjects.ToEnum<ObjType>();
                        var pres = project.CreateModelObjectsPresentor(objType);
                        SetVBObjectAttribute(pres, "цвет");
                        DisplayObjects();
                    } 
                }
                else if (IsGeometry())
                {       
                    var geom = form.Controls.OfType<GeomSelect>().FirstOrDefault();
                    SelectionControl_SelectInGeom(geom.GetSelectDimension(), numbers, isSelected);
                }
            }
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
                ? project.GetAllModelNodes().Where(x => x.Color == settingsConfig.SelectObjectColor).Select(x => x.Number).ToList()
                : project.GetAllModelElements().Where(x => x.Color == settingsConfig.SelectObjectColor).Select(x => x.Number).ToList();

            console.PrintInfo($"Количество выбранных элементов {selectedCount}, тип: {selectType}", Color.Black);
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
            
            console.PrintInfo($"Количество выбранных элементов {selectedCount}, тип: {objType}", Color.Black);
            
            DisplayObjects();
        }

        private Color GetColor(ObjType objType, int number, bool isSelected)
        {
            var color = settingsConfig.SelectObjectColor;
            if (!isSelected)
                color = project.GetModelSetInfo(objType, number).Color;
            return color;
        }

        private List<int> SelectE2DInPlane(List<int> selectedE2D, float angle)
        {
                return project.SelectE2DInPlane(
                    angle, selectedE2D.Last(), settingsConfig.SelectObjectColor);           
        }

        private List<int> SelectNodeInPlane(List<int> selectedNodes)
        {
                var n1 = (Node)project.GetModelObject(ObjType.Узел, selectedNodes[0]);
                var n2 = (Node)project.GetModelObject(ObjType.Узел, selectedNodes[1]);
                var n3 = (Node)project.GetModelObject(ObjType.Узел, selectedNodes[2]);

                var plane = new Geometry.Plane(n1.Position, n2.Position, n3.Position);
                return project.SelectNodeInPlane(plane, settingsConfig.SelectObjectColor);
        }

        private List<int> SelectInPlain(SelectInDirectionEventArgs sdArgs)
        {
            if (!sdArgs.Reverse)
            {
                return project.SelectNodeInDirection(sdArgs.Angle, sdArgs.SelectedNumbers[0],
                    sdArgs.SelectedNumbers[1], settingsConfig.SelectObjectColor);
            }

            else
            {
                return project.SelectNodeInDirection(sdArgs.Angle, sdArgs.SelectedNumbers[1],
                    sdArgs.SelectedNumbers[0], settingsConfig.SelectObjectColor);
            }
        }

        private void RefreshForm()
        {
            CloseAdvancedSelectionForm();
            btnAdvSelection_Click(btnAdvSelection, EventArgs.Empty);
        }

        private void BackColorToAllObjects()
        {
            SetBackColorToAllObjects();
            DisplayObjects();
        }

        private void CloseAdvancedSelectionForm()
        {
            var forms = Application.OpenForms.Cast<Form>().ToList();
            var form = forms.Find(x => x.Name == "selectForm");
            if (form != null)
            {
                CleanupSelectionControl(form);
                form.Close();
            }
        }

        private Point GetPosition(int hightForm)
        {
            var scenePosition = scene.PointToScreen(Point.Empty);
            var x = scenePosition.X;
            var y = scenePosition.Y + scene.Height - hightForm;
            return new Point(x, y);
        }
        private void CleanupSelectionControl(Form form)
        {
            var mesh = form.Controls.OfType<MeshSelect>().FirstOrDefault();
            if (mesh != null)
            {
                OnChangeSelectedObjectsEvent -= mesh.SetAvailableModes;
                //mesh.SelectInDirection -= OnReverseChanged;
                mesh.CloseForm -= RefreshForm;
                mesh.Dispose();
                return;
            }

            var geom = form.Controls.OfType<GeomSelect>().FirstOrDefault();
            if (geom != null)
            {
                OnChangeSelectedObjectsEvent -= geom.SetAvailableModes;
                geom.CloseForm -= RefreshForm;
                geom.Dispose();
            }
        }

        private bool IsMesh()
        {
            return SelectedObjects == ObjType.Элемент1D.ToString() ||
                   SelectedObjects == ObjType.Элемент2D.ToString() ||
                   SelectedObjects == ObjType.Элемент3D.ToString() ||
                   SelectedObjects == ObjType.Узел.ToString();
        }

        private bool IsGeometry()
        {
            return SelectedObjects == ObjType.Точка.ToString() ||
                   SelectedObjects == ObjType.Кривая.ToString() ||
                   SelectedObjects == ObjType.Поверхность.ToString() ||
                   SelectedObjects == "Объекты";
        }
    }
}
