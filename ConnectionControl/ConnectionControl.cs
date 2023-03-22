using ConnectionController;
using System;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;

namespace ConnectionControl
{
    public partial class ConnectionControl : UserControl
    {
        public void AddAction(string action)
        {
            cmbAction.Items.Add(action);
        }

        Controller connectionController;

        public ConnectionControl()
        {
            InitializeComponent();
            connectionController = new Controller();
        }


        //public event Action<object, StartLicenseEventArgs> SaveLicenseSettingsEvent;
        public event Action<LicenseToken> LicenseActionEvent;

        private void rbt_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtLocalLic.Checked)
            {
                txbKey.Enabled = true;

                txbServerAdress.Enabled = false;
                txbPort.Enabled = false;
            }
            if (rbtNetLic.Checked)
            {
                txbKey.Enabled = false;

                txbServerAdress.Enabled = true;
                txbPort.Enabled = true;
            }
        }

        private void txbKey_Click(object sender, EventArgs e)
        {
            var openDialog = new OpenFileDialog();

            if (openDialog.ShowDialog(this) == DialogResult.Cancel)
                return;

            txbKey.Text = openDialog.FileName;
        }       

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                var licToken = new LicenseToken();

                if (rbtLocalLic.Checked)
                {
                    var locToken = new LocalToken()
                    {
                        Path = txbKey.Text,
                        Request = cmbAction.Text
                    };
                    connectionController.RequestLocakKey(locToken);
                    licToken = locToken;
                }

                else if (rbtNetLic.Checked)
                {
                    var ip = IPAddress.Parse(txbServerAdress.Text);
                    var port = int.Parse(txbPort.Text);

                    var netToken = new NetToken()
                    {
                        IPAddress = ip,
                        Port = port,
                        Request = cmbAction.Text
                    };
                    connectionController.RequestServer(netToken);
                    licToken = netToken;
                }
                
                LicenseActionEvent(licToken);
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            var value = string.Empty;

            // If necessary, create it.
            var process = new Process();
            var startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Normal,
                FileName = "cmd.exe",
                Verb = "runas",
                ErrorDialog = true
            };
            process.StartInfo = startInfo;

            if (rbtLocalLic.Checked)
                startInfo.Arguments = $@"/C setx /m BazisLocal {txbKey.Text}";

            else
                startInfo.Arguments = $@"/C setx /m BazisNet ""{txbServerAdress.Text}:{txbPort.Text}""";

            process.Start();
            // checking

            if (rbtLocalLic.Checked)
                value = Environment.GetEnvironmentVariable("BazisLocal");
            else value = Environment.GetEnvironmentVariable("BazisNet");

            if (value != null | value != "")
                lblStatus.Text = "Настройки сохранены";
            else lblStatus.Text = "Ошибка сохранения!";
        }

        private void cmbAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
        }
    }
}
