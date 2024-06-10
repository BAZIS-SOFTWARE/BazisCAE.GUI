using ModelInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BaseModule.ControlsLib
{
    public partial class SelectToolStrip: ToolStrip
    {
        public Image NodeImage
        {
            get { return btnNodes.Image; }
            set { btnNodes.Image = value; }
        }

        public Image ElementsImage
        {
            get { return btnElems.Image; }
            set { btnElems.Image = value; }
        }

        public Image GeomsImage
        {
            get { return btnObjs.Image; }
            set { btnObjs.Image = value; }
        }

        public Image HelperImage
        {
            get { return btnSelectorHelper.Image; }
            set { btnSelectorHelper.Image = value; }
        }

        public event Action<object, SelectObjectEventArgs> SelectObjectEvent;
        public SelectToolStrip()
        {
            InitializeComponent();

            btnSplitSelector.DropDownItemClicked += SpbtMethod_DropDownItemClicked;
            btnNodes.Click += (ar1, ar2) => { SelectObjectsType = ObjType.Узел; };
            btnElems.Click += (ar1, ar2) => { SelectObjectsType = ObjType.Элемент; };
            btnObjs.Click += (ar1, ar2) => { SelectObjectsType = ObjType.Объект; };
        }

        private void SpbtMethod_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            btnSplitSelector.ToolTipText = e.ClickedItem.Text;

            var objType = GetObjType(e.ClickedItem.Text);
            SelectObjectEvent(this, new SelectObjectEventArgs(objType));
        }

        public int CountObjsTypes()
        {
            return btnSplitSelector.DropDownItems.Count;
        }

        public ObjType SelectObjectsType
        {          

            get 
            {
                var objType = GetObjType(btnSplitSelector.ToolTipText);
                return objType; 
            }
            set
            {
                if(btnSplitSelector.DropDownItems.ContainsKey(value.ToString()))
                {
                    btnSplitSelector.ToolTipText = value.ToString();
                    Invalidate();
                    SelectObjectEvent(this, new SelectObjectEventArgs(value));
                }
            }
        }
            
        public void AddObjectsType(ObjType objsType)
        {
            if (!btnSplitSelector.DropDownItems.ContainsKey(objsType.ToString()))
            {
                var newItem = new ToolStripMenuItem(objsType.ToString()) { Name = objsType.ToString() };
                btnSplitSelector.DropDownItems.Add(newItem);
            }

        }

        public ObjType GetObjType(string objTypeStr)
        {
            ObjType objType;
            Enum.TryParse(objTypeStr, out objType);
            return objType;
        }

    }
}
