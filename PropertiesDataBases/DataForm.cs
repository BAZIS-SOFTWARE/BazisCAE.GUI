using PropertiesDataBases.DataBases;
using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace PropertiesDataBases
{
    public partial class DataForm : Form
    {
        public DataForm(string[] args)
        {
            InitializeComponent();
            
            if (args.Contains("--mat"))
            {
                var mDb = new MaterialsDataBasePage();
                mDb.Load(args[1], false);
            }           
        }        
    }
}
