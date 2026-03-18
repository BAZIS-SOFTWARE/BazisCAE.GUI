using Project.Interfaces.Tasks;
using Project.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserControlsEx;

namespace BazisGUI.GantChart
{
    public partial class cntrГант : UserControl
    {
        float koeff;

        public cntrГант()
        {
            InitializeComponent();
        }

        public void AddConds(IEnumerable<ICondData> conds)
        {
            foreach (var item in conds)
            {
                //1. Создаём и добавляем колонки
                //2. Добавляем строку
                int rowNumber = dataGridView.Rows.Add();
                //3. Заполняем ячейки
                dataGridView.Rows[rowNumber].Cells[0].Value = item.ToString();
                dataGridView.Rows[rowNumber].Cells[1].Value = item;
            }
            var max = conds.Max(x => x.StopTime);
            var min = conds.Min(x => x.StartTime);

            koeff = (max - min) / Width;
        }

        private void dataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                // Get task data for the current row
                var currentCond = (ICondData)dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                // Calculate bar position and width based on dates and column width
                // This is a simplified example; actual calculation would be more complex
                // and depend on the time scale represented by the column.
                int barStartPixel = (int)(currentCond.StartTime / koeff);
                int barWidthPixel = (int)(currentCond.StopTime / koeff);

                e.Graphics.FillRectangle(new SolidBrush(Color.White), e.CellBounds);

                using (SolidBrush barBrush = new SolidBrush(Color.Blue)) // Example color
                {
                    
                    e.Graphics.FillRectangle(barBrush, e.CellBounds.X + barStartPixel, e.CellBounds.Y + 5, 
                        barWidthPixel - barStartPixel, e.CellBounds.Height - 10);
                }

                e.Handled = true; // Prevent default cell painting

            }
        }

        private void dataGridView_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Name == CondTime.Name)
            {
                var value1 = e.CellValue1?.ToString().Split(" : ")[1].Split(' ')[5];
                var value2 = e.CellValue2?.ToString().Split(" : ")[1].Split(' ')[5];

                if (float.TryParse(value1, out float floatValue1) && float.TryParse(value2, out float floatValue2)) 
                {
                    e.SortResult = floatValue1.CompareTo(floatValue2);
                    e.Handled = true;
                }
            }
        }
    }
}
