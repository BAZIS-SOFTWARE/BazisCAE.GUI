using BazisGUI.AdvanceSelection;
using BazisGUI.Extensions;
using BazisGUI.Properties;
using BazisGUI.Utilities;
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
using UserControlsEx;

namespace BazisGUI
{
    public enum SelectionType { Select, Objects, Figures, Points, Curves, Surfaces, Volumes, Nodes, Elements, Elements1D, Elements2D, Elements3D }
    public partial class BaseForm
    {
        
        Dictionary<SelectionType, Button> objButtons = new();
        //public event Action<string> OnChangeSelectedObjectsEvent;
        /// <summary>
        /// Временный выбранный объект для работы со свойствами через сцену
        /// </summary>
        //public  SelectedType;
        public SelectionType SelectedObjects
        {
            get { return Enum.Parse<SelectionType>(btnSelect.AccessibleName.Split("SelectObjects.btnSelect.")[1]); }
            set 
            {
                btnSelect.AccessibleName = $"SelectObjects.btnSelect.{value.ToString()}";
                btnSelect.Text = Localization.Localization.GetSelectionTypeLocalization(value);
                SetBackColorToAllObjects();
                DisplayObjects();
            }
        }

        public void AddObjectsType(SelectionType select)
        {
            var btn = CreateButton(select);

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

            objButtons.Add(select, btn);
        }

        private void Btn_MouseDown(object sender, MouseEventArgs e)
        {
            var btn = sender as Button;
            //SelectedObjects = Enum.Parse<SelectionType>(btn.Name);
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
                AddObjectsType(SelectionType.Objects);

                foreach (ObjType item in objTypes)
                    AddObjectsType(Converters.ConvertObjTypeToSelectionType(item));
            }
        }

        public Button CreateButton(SelectionType select)
        {
            string localization;

            switch (select)
            {
                case SelectionType.Objects:
                    localization = Localization.Localization.GetStringResourceByName("btnSelect.Text.Objects");
                    break;
                case SelectionType.Points:
                    localization = Localization.Localization.GetStringResourceByName("btnSelect.Text.Points");
                    break;
                case SelectionType.Curves:
                    localization = Localization.Localization.GetStringResourceByName("btnSelect.Text.Curves");
                    break;
                case SelectionType.Surfaces:
                    localization = Localization.Localization.GetStringResourceByName("btnSelect.Text.Serfaces");
                    break;
                case SelectionType.Nodes:
                    localization = Localization.Localization.GetStringResourceByName("btnSelect.Text.Nodes");
                    break;
                case SelectionType.Elements1D:
                    localization = Localization.Localization.GetStringResourceByName("btnSelect.Text.Elements1D");
                    break;
                case SelectionType.Elements2D:
                    localization = Localization.Localization.GetStringResourceByName("btnSelect.Text.Elements2D");
                    break;
                case SelectionType.Elements3D:
                    localization = Localization.Localization.GetStringResourceByName("btnSelect.Text.Elements3D");
                    break;
                default:
                    throw new ArgumentException($"{Localization.Localization.GetStringResourceByName("ConvertFailCaption")}: {select.ToString()} -> string");
            }

            var btn = new Button();
            btn.Anchor = btnSelect.Anchor;
            btn.AutoSize = btnSelect.AutoSize;
            btn.Name = select.ToString();
            btn.AccessibleName = select.ToString();
            btn.Size = btnSelect.Size;
            btn.Text = localization;
            btn.AutoSize = btnSelect.AutoSize;
            btn.FlatStyle = btnSelect.FlatStyle;
            btn.Margin = btnSelect.Margin;

            return btn;
        }
    }
}
