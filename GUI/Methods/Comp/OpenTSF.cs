using PreProc.Interfaces;
using PreProc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void открытьИнструкцииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var dialog = new FolderBrowserDialog();

                if (dialog.ShowDialog() == DialogResult.Cancel)
                    return;

                var inputDir = $@"{dialog.SelectedPath}";
                var tsfFiles = Directory.GetFiles(inputDir, "*.tsf");

                var sortedFiles = preProc.SortCompDataByTimeAndType(tsfFiles);

                PresentCompDataOnTree(sortedFiles);

                console.PrintInfo($"{Localization.Localization.GetStringResourceByName("OpenTSF.OpenInstructions.Message")} {inputDir}", Color.Green);

            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
    }
}
