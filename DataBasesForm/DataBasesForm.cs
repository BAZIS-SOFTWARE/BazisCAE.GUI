using BaseModule.Tasks.DataBases;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DataBasesForm
{
    public partial class DataBasesForm : Form
    {
        public DataBasesForm(string[] args)
        {
            InitializeComponent();

            if (args.Contains("mat"))
            {
                var mDb = new MaterialsDataBasePage();
                mDb.Load(args[1], false);
            }           
        }        
    }
}
