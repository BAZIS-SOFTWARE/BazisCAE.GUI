using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlsEx
{
    public partial class DataGridViewEx : DataGridView
    {
        public int CurentSelectedRowIndex
        {
            get
            {
                if (SelectedRows.Count == 0)
                    throw new Exception("Выберите строку с данными!");
                return SelectedRows[SelectedRows.Count - 1].Index;
            }
        }

        public IEnumerable<int> GetSelectedRowIndexes()
        {
            foreach (DataGridViewRow row in SelectedRows)
            {
                yield return row.Index;
            }
        }

        public string Get_DataGridFillLine(int ind)
        {
            var str = "";

            foreach (DataGridViewCell cell in Rows[ind].Cells)
            {
                if (cell.ColumnIndex + 1 == Rows[ind].Cells.Count)
                { str = str + cell.Value.ToString(); }

                else { str = str + cell.Value.ToString() + " "; }
            }
            return str;
        }

        public void Set_DataGridLines(IEnumerable<string> lines)
        {
            Rows.Clear();

            foreach (var line in lines) Rows.Add(line.Split(' '));
        }
        public DataGridViewEx()
        {
            InitializeComponent();
        }

        public DataGridViewEx(IContainer container)
        {
            container.Add(this);
            InitializeComponent();            
        }

        public virtual void DataGridViewEx_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                CopyDataInDataGridView();                
            }
        }

        public void CopyDataInDataGridView()
        {            
            // Считывание текста из буфера обмена
            IDataObject dataInClipboard = Clipboard.GetDataObject();
            string stringInClipboard = (string)dataInClipboard.GetData(DataFormats.Text);

            // Разделение на строки
            string[] rowsInClipboard = stringInClipboard.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // Определение строки и столбца, выбранной ячейки в grid
            int r = SelectedCells[0].RowIndex;
            int c = SelectedCells[0].ColumnIndex;
            int iRow = 0;
            // Разбиение и вставка значений в ячейки
            for (int i = 0; i < rowsInClipboard.Length; i++)
            {
                string[] valuesInRow = rowsInClipboard[i].Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);

                if (valuesInRow.Length + c > ColumnCount)
                {
                    MessageBox.Show("Количество столбцов вставляемых данных превышает допустимое значение!", "Внимание!",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (valuesInRow.Length == 0) continue;
                else
                {
                    if (r + iRow > RowCount - 1)
                    {
                        var table = (DataTable) DataSource;
                        if (table != null) table.Rows.Add();
                        else Rows.Add();
                    }
                    for (int iCol = 0; iCol < valuesInRow.Length; iCol++)
                    {
                        DataGridViewCell cell = Rows[r + iRow].Cells[c + iCol];
                        cell.Value = valuesInRow[iCol];
                    }
                    iRow++;
                }
            }
        }
    }
}
