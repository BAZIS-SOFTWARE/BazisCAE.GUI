using System.Collections.Generic;

namespace BaseModule.Tasks.BasicAdvisorControls.Interfaces
{
    public interface IDGVControl
    {
        string Get_DataGridFillLine(int ind);

        void Set_DataGridLines(IEnumerable<string> lines);

        int CurentSelectedRowIndex { get; }

        //string CurentSelectedRowInfo { get; set; }

        IEnumerable<int> GetSelectedRowIndexes();
    }
}
