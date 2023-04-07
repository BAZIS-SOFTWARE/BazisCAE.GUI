using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicAdvisorControls.Interfaces
{
    public interface IGridViewControl : IDataNamedControl
    {
        event Action<object, AddDataEventArgs> AddDataEvent;
        event Action<object, DeleteDataEventArgs> DeleteDataEvent;
        event Action<object, ChangeDataEventArgs> ChangeDataEvent;

        DataGridView GetDataGrid { get; }

        void AddButton_Click(object sender, EventArgs e);

        void DataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e);

        void RefreshButton_Click(object sender, EventArgs e);

        void DataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e);

        void ClearAllDataButton_Click(object sender, EventArgs e);

        string Get_DataGridFillLine(int ind);

        void Set_DataGridLines(List<string> lines);

        int CountSelectedRow { get; }
        int CurentSelectedRowIndex { get; }

        int CountRows { get;}

        string CurentSelectedRowInfo { get; set; }
    }
}
