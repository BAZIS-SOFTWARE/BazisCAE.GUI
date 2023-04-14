
using ConnectionController;
using LicenseData;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Windows.Forms;

namespace ConnectionModule
{
    public partial class AboutControl : UserControl
    {
        public AboutControl()
        {
            InitializeComponent();
        }

        const int ProductCode = 1;

        private void frmAbout_Load(object sender, EventArgs e)
        {
            //Get license information from license file

            var net = Environment.GetEnvironmentVariable("BazisServerPath", EnvironmentVariableTarget.Machine);

            var connectionController = new Controller();

            try
            {
                //Load lic file
                if (net != null)
                {
                    var ip = net.Split(':');
                    var token = new LicenseToken()
                    {
                        IPAddress = IPAddress.Parse(ip[0]),
                        Port = int.Parse(ip[1]),
                        Request = "CheckLicenseInfo"
                    };

                    connectionController.RequestServer(token);

                    var licInfo = JsonConvert.DeserializeObject<LicenseInfo>(token.Answer);

                    lblCompanyName.Text = licInfo.CompanyName;

                    lblKeyInfo.Text = "";
                    foreach (var keyInfo in licInfo)
                        lblKeyInfo.Text += $"{keyInfo}\n";               
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
