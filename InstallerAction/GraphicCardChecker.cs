
using System.Collections;
using System.ComponentModel;
using System.Management;
using System.Windows.Forms;

namespace InstallerAction
{
    [RunInstaller(true)]
    public partial class GraphicCardChecker : System.Configuration.Install.Installer
    {
        public GraphicCardChecker()
        {
            InitializeComponent();
        }

        protected override void OnAfterInstall(IDictionary savedState)
        {
            base.OnAfterInstall(savedState);
        }

        protected override void OnBeforeInstall(IDictionary savedState)
        {
            base.OnBeforeInstall(savedState);
        }
    }
}
