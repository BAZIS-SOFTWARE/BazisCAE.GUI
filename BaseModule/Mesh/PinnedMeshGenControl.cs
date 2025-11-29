using BazisGUI.PinnedControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazisGUI.Mesh
{
    public partial class PinnedMeshGenControl : PinnedPage
    {
        public GMSHGeneralMeshControl MeshGeneratorControl { get { return gmshGeneralMeshControl; } }
        public PinnedMeshGenControl()
        {
            InitializeComponent();
        }
    }
}
