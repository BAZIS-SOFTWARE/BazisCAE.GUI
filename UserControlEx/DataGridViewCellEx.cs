using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlsEx
{
    public partial class DataGridViewCellEx : DataGridViewCell
    {
        public string Key { get; set; }
        public DataGridViewCellEx()
        {
            InitializeComponent();
        }
    }
}
