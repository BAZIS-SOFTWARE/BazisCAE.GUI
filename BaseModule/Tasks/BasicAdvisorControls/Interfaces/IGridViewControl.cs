using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TaskModule.BasicAdvisorControls.Events;

namespace TaskModule.BasicAdvisorControls.Interfaces
{
    public interface IGridViewControl : IDataNamedControl
    {
        event Action<object, AddDataEventArgs> AddDataEvent;
        event Action<object, DeleteDataEventArgs> DeleteDataEvent;
        event Action<object, ChangeDataEventArgs> ChangeDataEvent;
        event Action<object, DeleteAllDataEventArgs> DeleteAllDataEvent;

        //DataGridView GetDataGrid { get; }

        void AddButton_Click(object sender, EventArgs e);

        void DataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e);

        void RefreshButton_Click(object sender, EventArgs e);

        void DataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e);

        void ClearAllDataButton_Click(object sender, EventArgs e);


        string Get_DataGridFillLine(int ind);

        void Set_DataGridLines(IEnumerable<string> lines);

        //int CountSelectedRow { get; }
        //int CurentSelectedRowIndex { get; }

        //int CountRows { get;}

        //string CurentSelectedRowInfo { get; set; }
    }
}
