
using ConnectionController;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace ConnectionControl
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

            var serverLine = ConfigurationManager.AppSettings.Get("Net");
            var keyLine = ConfigurationManager.AppSettings.Get("Local");

            var connectionController = new Controller();

            try
            {
                //Load lic file
                if (keyLine != null)
                {                    
                    var licInfo = connectionController.InfoLocakKey(keyLine);

                    lblCompanyName.Text = licInfo[0];
                    lblProductKey.Text = licInfo[1];
                    lblKeyInfo.Text = licInfo[2];
                    lblLicenseKind.Text = "Локальная";                   
                }
                if(serverLine != null)
                    lblLicenseKind.Text = $"Сетевая : {serverLine}";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
