
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

            var local = Environment.GetEnvironmentVariable("BazisLocal", EnvironmentVariableTarget.Machine);
            var net = Environment.GetEnvironmentVariable("BazisNet", EnvironmentVariableTarget.Machine);

            var connectionController = new Controller();

            try
            {
                //Load lic file
                if (local != null)
                {                    
                    var licInfo = connectionController.InfoLocakKey(local);

                    lblCompanyName.Text = licInfo[0];

                    lblKeyInfo.Text = "";
                    for (int i = 1; i < licInfo.Length; i++)
                        lblKeyInfo.Text += $"{licInfo[i]}\n";               
                }
                if(net != null)
                    lblKeyInfo.Text = $"Сетевая : {net}";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
