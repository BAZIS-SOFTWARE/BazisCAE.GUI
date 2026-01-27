using System;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void выбратьСопряженныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in GetModelObjects(SelectedObjects).Where(x => x.Color == settingsConfig.SelectObjectColor))
                {
                    var dim = (int)item.ObjType;
                    SelectAdj(dim, item.Number);
                }

                // Обновить отображение после установки цвета у всех сопряжённых
                DisplayObjects();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, System.Drawing.Color.Red);
            }
        }       
    }
}
