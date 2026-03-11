using System;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private string LoadPythonFile()
        {
            using (var fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "Python Files|*.py";
                fileDialog.Title = "Выберите Python файл";

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    return fileDialog.FileName;
                }
            }

            throw new OperationCanceledException("Отменено пользователем");
        }
    }
}



