using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace InstallerAction
{
    [RunInstaller(true)]
    public partial class CreateGlobalVariables : Installer
    {
        public CreateGlobalVariables()
        {
            InitializeComponent();
        }

        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);

            string fullPath = this.Context.Parameters["assemblypath"];

            var process = new Process();
            var startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Normal,
                FileName = "cmd.exe",
                Verb = "runas",
                ErrorDialog = true
            };
            process.StartInfo = startInfo;

            var gmshPath = Path.GetDirectoryName(fullPath) + "\\Mesh\\gmsh.dll";
            startInfo.Arguments = $@"/C setx /m BazisMeshPath ""{gmshPath}""";

            process.Start();


        }

        protected override void OnAfterInstall(IDictionary savedState)
        {
            base.OnAfterInstall(savedState);

            // checking

            var value = Environment.GetEnvironmentVariable("BazisMeshPath");
            if (value == null | value == "")
                MessageBox.Show($"Возможно возникла проблема автоматического создания переменной среды BazisMeshPath! Создайте ее вручную в случае если она отсутсвует",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
