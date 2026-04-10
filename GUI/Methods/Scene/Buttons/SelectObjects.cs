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
        //public event Action<string> OnChangeSelectedObjectsEvent;
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
            //OnChangeSelectedObjectsEvent?.Invoke(SelectedObjects);
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
    }
}
