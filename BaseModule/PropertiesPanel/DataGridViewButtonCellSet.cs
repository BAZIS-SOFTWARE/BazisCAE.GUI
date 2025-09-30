using System;
using System.Windows.Forms;

namespace BaseModule.PropertiesPanel
{
    public class DataGridViewButtonCellSet
    {
        public string Text { get; set; }
        public Action OnClick { get; set; }

        public DataGridViewButtonCellSet(string text, Action onClick)
        {
            Text = text;
            OnClick = onClick;
        }
    }
}
