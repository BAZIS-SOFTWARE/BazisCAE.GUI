using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TaskModule.BasicAdvisorControls.Events;
using TaskModule.BasicAdvisorControls.Interfaces;

namespace TaskModule.BasicAdvisorControls.BasicControls
{

    public partial class GridViewAdviserControl : UserControl, IDataNamedControl, IGridViewControl
    {
        public GridViewAdviserControl()
        {
            InitializeComponent();
        }

        public int CountSelectedRow { get { return GetDataGrid.SelectedRows.Count; } }

        public int CurentSelectedRowIndex
        {
            get
            {
                var gridView = GetDataGrid;
                if (gridView.SelectedRows.Count == 0)
                    throw new Exception("Выберите строку с данными!");
                return gridView.SelectedRows[gridView.SelectedRows.Count - 1].Index;
            }
        }      

        public DataGridView GetDataGrid
        {
            get
            {
                var searched = new List<DataGridView>();

                SearchControls(this, searched);

                return searched[0];
            }
        }

        public void SearchControls<T>(Control ctrl, List<T> controls) where T : Control
        {
            // Работаем только с элементами искомого типа   
            if (ctrl.GetType() == typeof(T))
            {
                controls.Add((T)ctrl);
            }
            // Проходим через элементы рекурсивно,   
            // чтобы не пропустить элементы,   
            //которые находятся в контейнерах   
            foreach (Control ctrlChild in ctrl.Controls)
            {
                SearchControls(ctrlChild, controls);
            }
        }

        public IEnumerable<int> GetSelectedRowIndexes()
        {
            var gridView = GetDataGrid;
            foreach (DataGridViewRow row in gridView.SelectedRows)
            {
                yield return row.Index;
            }
        }

        public string CurentSelectedRowInfo { get ; set; }
        public virtual int CountRows { get { return GetDataGrid.RowCount; } }

        public virtual string DataName => throw new NotImplementedException("Свойство DataName не реализовано!");

        public event Action<object, AddDataEventArgs> AddDataEvent;
        public event Action<object, DeleteDataEventArgs> DeleteDataEvent;
        public event Action<object, DeleteAllDataEventArgs> DeleteAllDataEvent;
        public event Action<object, ChangeDataEventArgs> ChangeDataEvent;

        public virtual void DataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            throw new Exception("Метод не реализован!");
        }
        
        public virtual bool IsValidated()
        {
            throw new NotImplementedException("Метод \"IsValidated\" не реализован");
        }

        public virtual void RefreshButton_Click(object sender, EventArgs e)
        {
            var gridView = GetDataGrid;
            var count = gridView.SelectedRows.Count;
            ChangeDataEvent(this, new ChangeDataEventArgs(DataName, gridView.SelectedRows[count - 1].Index, CurentSelectedRowInfo));
        }

        public virtual void DataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
               DeleteDataEvent(this, new DeleteDataEventArgs(DataName, e.Row.Index));          
        }

        public virtual string Get_DataGridFillLine(int ind)
        {
            var str = "";

            var gridView = GetDataGrid;

            foreach (DataGridViewCell cell in gridView.Rows[ind].Cells)
            {
                if (cell.ColumnIndex + 1 == gridView.Rows[ind].Cells.Count)
                { str = str + cell.Value.ToString(); }

                else { str = str + cell.Value.ToString() + " "; }
            }
            return str;
        }

        public virtual void Set_DataGridLines(IEnumerable<string> lines)
        {
            var gridView = GetDataGrid;

            gridView.Rows.Clear();

            foreach (var line in lines) gridView.Rows.Add(line.Split(' '));
        }

        public virtual void ClearAllDataButton_Click(object sender, EventArgs e)
        {
                DeleteAllDataEvent(this, new DeleteAllDataEventArgs(DataName));          
        }

        public virtual void AddButton_Click(object sender, EventArgs e)
        {
            AddDataEvent(this, new AddDataEventArgs(DataName, CurentSelectedRowInfo));
        }
    }
}
