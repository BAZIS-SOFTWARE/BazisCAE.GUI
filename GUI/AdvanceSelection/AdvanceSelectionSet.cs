using Model.Interfaces;
using System;
using System.Windows.Forms;


namespace BazisGUI.AdvanceSelection
{
    public partial class AdvanceSelectionSet : UserControl
    {
        public event Action<object, SelectInDirectionEventArgs> SelectInDirection;
        public event Action<object, SelectInPlainEventArgs> SelectInPlain;

        public event Action<object, EventArgs> SelectNodes;
        public event Action<object, EventArgs> SelectElements;

        public AdvanceSelectionSet(string selectedObjects)
        {
            InitializeComponent();
            FillForm();
        }

        private void FillForm()
        {
            //var select = SelectedObjects;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (rbtInDirection.Checked)
            //        if (rbtNodes.Checked)
            //            SelectInDirection(this, new SelectInDirectionEventArgs(ObjType.Узел, chbChangeDirection.Checked, float.Parse(txbAngle.Text)));
            //        else
            //            MessageBox.Show("Измените объект выбора на \"Узлы\"");
            //    else if (rbtInPlain.Checked)
            //        if (rbtNodes.Checked)
            //            SelectInPlain(this, new SelectInPlainEventArgs(ObjType.Узел, float.Parse(txbAngle.Text)));
            //        else
            //            SelectInPlain(this, new SelectInPlainEventArgs(ObjType.Элемент2D, float.Parse(txbAngle.Text)));
            //}
            //catch (Exception ex)
            //{
            //    //console
            //    //throw;
            //}
  
        }

        private void rbtNodes_Click(object sender, EventArgs e)
        {
            //if (rbtNodes.Checked)
            //    SelectNodes?.Invoke(this, new EventArgs());
        }

        private void rbtElements_Click(object sender, EventArgs e)
        {
            //if (rbtElements.Checked)
            //    SelectElements?.Invoke(this, new EventArgs());
        }
    }
}
