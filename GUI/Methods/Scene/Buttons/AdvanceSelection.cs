using BazisGUI.Scene.Interfaces;
using BazisGUI.Scene.Interfaces;
using System;
using Geometry;
using System.Drawing;
using MathNet.Numerics.LinearAlgebra;
using BaseModule;
using System.Windows.Forms;
using Model.Interfaces;
using System.Linq;

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
                btn.Tag = true;
                var form = new Form()
                {
                    Name = "selectForm",
                    Text = "Дополненный выбор",
                    AutoSize = false,
                    ShowIcon = false,
                    TopMost = true,
                    Owner = Application.OpenForms[0]
                };

                form.FormClosing += (s1, s2) => 
                {
                    btn.Tag = false;
                    btn.Invalidate();
                };
                var selectionControl = new AdvanceSelectionSet() { Dock = DockStyle.Fill };
                selectionControl.SelectInDirection += SelectionControl_SelectInDirection;
                selectionControl.SelectInPlain += SelectionControl_SelectInPlain;
                //selectionControl.SelectNodes += (s1, s2) =>
                //{
                //    spbSelectObject.ToolTipText = ObjType.Узел.ToString();
                //    spbSelectObject.Invalidate();
                //};

                //selectionControl.SelectElements += (s1, s2) =>
                //{
                //    spbSelectObject.ToolTipText = ObjType.Элемент2D.ToString();
                //    spbSelectObject.Invalidate();
                //};

                form.ClientSize = selectionControl.Size;
                form.Controls.Add(selectionControl);
                form.Show();
                var location = PointToScreen(Point.Empty);
                form.Location = location;
            }
            else
            {
                var forms = Application.OpenForms.Cast<Form>().ToList();
                var form = forms.Find(x => x.Name == "selectForm");
                if (form != null)
                {
                    form.Close();
                }
            }
        }
    }
}
