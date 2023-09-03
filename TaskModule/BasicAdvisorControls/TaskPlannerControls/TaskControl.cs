using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project.TasksData;

namespace AdvisorControls.TaskPlannerControls
{
    public partial class TaskControl : UserControl
    {
        public TaskControl()
        {
            InitializeComponent();
        }
        public virtual string TaskName { get; }

        public event Action<object, EventArgs> ChangeDataEvent;

        public virtual GeneralParameters CollectData()
        {
            throw new NotImplementedException("Не реализован метод!");
        }

        public virtual void InputData(GeneralParameters parameters)
        {
            throw new NotImplementedException("Не реализован метод!");
        }

        public virtual void SetSolver(int solverIndex)
        {
            throw new NotImplementedException("Не реализован метод!");
        }

        public virtual void AllTextBox_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException("Не реализован метод!");
        }

        public virtual void Txb_EnabledChanged(object sender, EventArgs e)
        {
            if (sender is TextBox txb)
            {
                if (txb.Enabled == false)
                    txb.Text = "0";
            }
        }
    }
}
