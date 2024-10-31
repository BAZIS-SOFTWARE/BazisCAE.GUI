using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModelModule.SettingsControls
{
    public partial class GMSHVolSettingsControl : UserControl
    {
        public event Action<object, MeshGradientSettingsEventArgs> setMeshGradientEvent;
        public event Action<object> delMeshGradientEvent;
        public GMSHVolSettingsControl()
        {
            InitializeComponent();
        }

        private void btnSetGradientSettings_Click(object sender, EventArgs e)
        {
            if (!txbLayerThickness.IsValueValid())
                return;
            if (!txbSurfaceMeshSize.IsValueValid())
                return;
            if (!txbCoreMeshSize.IsValueValid())
                return;
            if (!txbMeshGradientPower.IsValueValid())
                return;

            var layerThickness = double.Parse(txbLayerThickness.Text);
            var surfaceMeshSize = double.Parse(txbSurfaceMeshSize.Text);
            var coreMeshSize = double.Parse(txbCoreMeshSize.Text);
            var gradientMeshPower = double.Parse(txbMeshGradientPower.Text);


            setMeshGradientEvent?.Invoke(this,
                new MeshGradientSettingsEventArgs(layerThickness, surfaceMeshSize, coreMeshSize, gradientMeshPower));
        }

        private void btnDelGradient_Click(object sender, EventArgs e)
        {
            delMeshGradientEvent?.Invoke(this);
        }
    }
}
