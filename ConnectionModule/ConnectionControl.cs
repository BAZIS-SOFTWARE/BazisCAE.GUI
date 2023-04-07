using ConnectionController;
using System;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;

namespace ConnectionModule
{
    public partial class ConnectionControl : UserControl
    {
        IPAddress ip;
        string action;
        public void AddAction(string action)
        {
            this.action = action;
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
                txbServerAdress.Enabled = false;
                txbServerAdress.Text = "127.0.0.1";
            }
            if (rbtNetLic.Checked)
            {
                txbServerAdress.Enabled = true;
            }
        }    

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                var port = int.Parse(txbPort.Text);
                var ip = IPAddress.Parse(txbServerAdress.Text);

                var licToken = new LicenseToken()
                {
                    Request = action,
                    IPAddress = ip,
                    Port = port
                };

                connectionController.RequestServer(licToken);
                lblAnswer.Text = licToken.Answer;
                LicenseActionEvent(licToken);
            }
            catch (Exception ex)
            {
                lblAnswer.Text = ex.Message;
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

            startInfo.Arguments = $@"/C setx /m BazisServerPath ""{txbServerAdress.Text}:{txbPort.Text}""";

            process.Start();
            // checking

            value = Environment.GetEnvironmentVariable("BazisServerPath");

            if (value != null | value != "")
                lblAnswer.Text = "Настройки сохранены";
            else lblAnswer.Text = "Ошибка сохранения!";
        }

        private void cmbAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
        }
    }
}
