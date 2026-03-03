using BazisGUI.AdvanceSelection.ControlsForSelect;
using Model.Interfaces;
using System;
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
                    btn.Tag = false;
                    btn.Invalidate();
                };

                if (SelectedObjects == ObjType.Элемент1D.ToString() ||
                    SelectedObjects == ObjType.Элемент2D.ToString() ||
                    SelectedObjects == ObjType.Элемент3D.ToString() ||
                    SelectedObjects == ObjType.Узел.ToString())
                {
                    var selectionControl = new MeshSelect(SelectedObjects);

                    OnChangeSelectedObjectsEvent += selectionControl.SetAvailableModes;
                    selectionControl.CloseForm += RefreshForm;
                    selectionControl.SelectInDirection += SelectionControl_SelectInDirection;
                    selectionControl.SelectInPlain += SelectionControl_SelectInPlain;
                    selectionControl.SelectInSet += SelectionControl_SelectInSet;
                    AdvanceSelectionError += selectionControl.UnchekAllRadioButton;
                    form.ClientSize = selectionControl.Size;
                    form.Controls.Add(selectionControl);
                }

                else if (SelectedObjects == ObjType.Точка.ToString() ||
                    SelectedObjects == ObjType.Кривая.ToString() ||
                    SelectedObjects == ObjType.Поверхность.ToString() ||
                    SelectedObjects == "Объекты")
                {
                    var selectionControl = new GeomSelect(SelectedObjects);
                    OnChangeSelectedObjectsEvent += selectionControl.SetAvailableModes;
                    selectionControl.CloseForm += RefreshForm;
                    selectionControl.SelectInGeom += SelectionControl_SelectInCurve;
                    AdvanceSelectionError += selectionControl.UnchekAllRadioButton;
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

        private void RefreshForm()
        {
            CloseAdvancedSelectionForm();
            btnAdvSelection_Click(btnAdvSelection, EventArgs.Empty);
        }

        private void CloseAdvancedSelectionForm()
        {
            var forms = Application.OpenForms.Cast<Form>().ToList();
            var form = forms.Find(x => x.Name == "selectForm");
            if (form != null)
            {
                var mesh = form.Controls.OfType<MeshSelect>().FirstOrDefault();
                if (mesh != null)
                {
                    OnChangeSelectedObjectsEvent -= mesh.SetAvailableModes;
                    mesh.CloseForm -= RefreshForm;
                    mesh.Dispose();
                }
                else
                {
                    var geom = form.Controls.OfType<GeomSelect>().FirstOrDefault();
                    OnChangeSelectedObjectsEvent -= geom.SetAvailableModes;
                    geom.CloseForm -= RefreshForm;
                    geom.Dispose();
                }
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
    }
}
