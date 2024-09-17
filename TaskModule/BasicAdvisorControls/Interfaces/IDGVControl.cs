using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskModule.BasicAdvisorControls.Events;

namespace TaskModule.BasicAdvisorControls.Interfaces
{
    public interface IDGVControl
    {
        string Get_DataGridFillLine(int ind);

        void Set_DataGridLines(IEnumerable<string> lines);

        int CountSelectedRow { get; }
        int CurentSelectedRowIndex { get; }

        //string CurentSelectedRowInfo { get; set; }

        IEnumerable<int> GetSelectedRowIndexes();
    }
}
