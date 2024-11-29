using System.Windows.Forms;

namespace BaseModule.Mesh
{
    public partial class GMSH2DMeshControl : UserControl
    {
        public GMSH2DMeshControl()
        {
            InitializeComponent();
        }

        //private void OnAddBoundFilter(object sender, EventArgs e)
        //{
        //    var ierr = 0;
        //    var field = GmshController.ModelMeshFieldAdd("BoundaryLayer", -1, ref ierr);
        //    boundFieldTag = field;
        //    GmshController.ModelMeshFieldSetAsBoundaryLayer(boundFieldTag, ref ierr);
        //    btnFieldAdd.Enabled = false;
        //    chkBeta.Enabled = chkQuad.Enabled = btnFieldDelete.Enabled = chkMetrics.Enabled = true;
        //    grpFieldGeneral.Enabled = grpFieldSize.Enabled = true;
        //    grpFieldLayer.Enabled = grpFieldFan.Enabled = true;
        //    grpFieldBeta.Enabled = chkBeta.Checked;
        //}

        //private void OnRemoveBoundFilter(object sender, EventArgs e)
        //{
        //    var ierr = 0;
        //    GmshController.ModelMeshFieldRemove(boundFieldTag, ref ierr);
        //    btnFieldAdd.Enabled = true;
        //    chkBeta.Enabled = chkQuad.Enabled = btnFieldDelete.Enabled = chkMetrics.Enabled = false;
        //    grpFieldGeneral.Enabled = grpFieldSize.Enabled = false;
        //    grpFieldLayer.Enabled = grpFieldFan.Enabled = false;
        //    grpFieldBeta.Enabled = false;
        //}

        //private void OnBoundFilterCheck(object sender, EventArgs e)
        //{
        //    var control = sender as CheckBox;
        //    var tag = control.Tag.ToString();
        //    var value = Convert.ToDouble(control.Checked);
        //    if (tag == "BetaLaw")
        //        grpFieldBeta.Enabled = control.Checked;
        //    var ierr = 0;
        //    GmshController.ModelMeshFieldSetNumber(boundFieldTag, tag, value, ref ierr);
        //}

        //private void OnFilterListEnter(object sender, EventArgs e)
        //{
        //    var control = sender as TextBox;
        //    var tag = control.Tag.ToString();
        //    var data = control.Text.Split(' ', ',');
        //    var values = new double[data.Length];
        //    for (var i = 0; i < data.Length; ++i)
        //    {
        //        var value = 0;
        //        if (!Int32.TryParse(data[i], out value))
        //            return;
        //        values[i] = value;
        //    }
        //    var ierr = 0;
        //    GmshController.ModelMeshFieldSetNumbers(boundFieldTag, tag, values, (IntPtr)values.Length, ref ierr);
        //}

        //private void OnFilterValueEnter(object sender, EventArgs e)
        //{
        //    var control = sender as TextBox;
        //    var optValue = control.Tag.ToString().Split(' ');
        //    var value = 0.0;
        //    if (!Double.TryParse(control.Text, out value))
        //        return;
        //    var ierr = 0;
        //    GmshController.ModelMeshFieldSetNumber(boundFieldTag, optValue[0], value, ref ierr);
        //}
    }
}
