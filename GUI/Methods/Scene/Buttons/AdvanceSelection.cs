using BazisGUI.AdvanceSelection;
using BazisGUI.AdvanceSelection.ControlsForSelect;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

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
                    selectionControl.ChangeRadioButtonSelectEvent += ClearTuple_ChangeRadioButtonSelectEvent;
                    selectionControl.SelectInDirection += OnReverseChanged;
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

        private void ClearTuple_ChangeRadioButtonSelectEvent()
        {
            lastDirectionSelection = (null, null, null);
        }

        private void DispatchSelection(ObjType objType, List<int> numbers)
        {
            var forms = Application.OpenForms.Cast<Form>().ToList();
            var form = forms.Find(x => x.Name == "selectForm");
            if(form != null)
            {
                if (IsMesh())
                {
                    var mesh = form.Controls.OfType<MeshSelect>().FirstOrDefault();
                    var additionalMode = mesh.GetSelectedAdditionalMode();
                    if (additionalMode is SelectInDirectionEventArgs selectInDirectionEventArgs)
                        SelectionControl_SelectInDirection(selectInDirectionEventArgs, numbers);
                    else if (additionalMode is SelectInPlainEventArgs selectInPlain)
                        SelectionControl_SelectInPlain(selectInPlain, objType, numbers);
                    else if (additionalMode is ObjType setType)
                        SelectionControl_SelectInSet(setType, numbers);
                }
                else if (IsGeometry())
                {       
                    var geom = form.Controls.OfType<GeomSelect>().FirstOrDefault();
                    SelectionControl_SelectInGeom(geom.GetSelectDimension(), numbers);
                }
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
                mesh.ChangeRadioButtonSelectEvent -= ClearTuple_ChangeRadioButtonSelectEvent;
                mesh.SelectInDirection -= OnReverseChanged;
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
