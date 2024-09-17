using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskModule.BasicAdvisorControls.Interfaces;

namespace TaskModule.BasicAdvisorControls.BasicControls
{
    public partial class DGVControl : DataGridView, IDGVControl
    {
        public DGVControl()
        {
            InitializeComponent();
        }

        public int CountSelectedRow { get { return SelectedRows.Count; } }

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

        public virtual string Get_DataGridFillLine(int ind)
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

        public virtual void Set_DataGridLines(IEnumerable<string> lines)
        {
            Rows.Clear();

            foreach (var line in lines) Rows.Add(line.Split(' '));
        }
    }
}
