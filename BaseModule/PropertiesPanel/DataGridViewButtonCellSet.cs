using System;
using System.Windows.Forms;

namespace BaseModule.PropertiesPanel
{
    public class DataGridViewButtonCellSet
    {
        public string Text { get; set; }
        public Action<DataGridViewButtonCell> OnClick { get; set; }

        public DataGridViewButtonCellSet(string text, Action<DataGridViewButtonCell> onClick)
        {
            Text = text;
            OnClick = onClick;
        }
    }
}
