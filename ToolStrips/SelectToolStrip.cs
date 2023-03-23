using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolStrips
{
    public partial class SelectToolStrip: ToolStrip
    {

        [Description("Set nodes image")]
        [Category("General properties")]
        public Image NodeImage
        {
            get { return btnNodes.Image; }
            set { btnNodes.Image = value; }
        }

        [Description("Set elements image")]
        [Category("General properties")]
        public Image ElementsImage
        {
            get { return btnElems.Image; }
            set { btnElems.Image = value; }
        }

        [Description("Set geometry image")]
        [Category("General properties")]
        public Image GeomsImage
        {
            get { return btnGeom.Image; }
            set { btnGeom.Image = value; }
        }

        [Description("Set selectionHelper image")]
        [Category("General properties")]
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
            btnNodes.Click += (ar1, ar2) => { SelectObjectsType = "Узлы"; };
            btnElems.Click += (ar1, ar2) => { SelectObjectsType = "Элементы3D"; };
        }

        private void SpbtMethod_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            btnSplitSelector.ToolTipText = e.ClickedItem.Text;

            SelectObjectEvent(this, new SelectObjectEventArgs(e.ClickedItem.Text));
        }

        public int CountObjsTypes()
        {
            return btnSplitSelector.DropDownItems.Count;
        }

        public IEnumerable<string> GetObjsTypes()
        {
            foreach (ToolStripItem item in btnSplitSelector.DropDownItems)
            {
                yield return item.Name;
            }
        }

        public string SelectObjectsType
        {          

            get { return btnSplitSelector.ToolTipText; }
            set
            {
                if(btnSplitSelector.DropDownItems.ContainsKey(value))
                {
                    btnSplitSelector.ToolTipText = value;
                    Invalidate();
                    SelectObjectEvent(this, new SelectObjectEventArgs(value));
                }
            }
        }
            
        public void AddObjectsType(string objsType)
        {
            if (!btnSplitSelector.DropDownItems.ContainsKey(objsType))
            {
                var newItem = new ToolStripMenuItem(objsType) { Name = objsType };
                btnSplitSelector.DropDownItems.Add(newItem);
            }

        }

        public void Clear()
        {
            btnSplitSelector.DropDownItems.Clear();
            btnSplitSelector.Text = "";
        }

        public void RemoveObjectsType(string objsName)
        {
               btnSplitSelector.DropDownItems.RemoveByKey(objsName);
        }



    }
}
