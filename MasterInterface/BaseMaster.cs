using MasterInterface.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasterInterface
{
    public partial class BaseMaster : UserControl, IBaseMasterInterface
    {

        public event Action<string, Color> PrintInfoEvent;
        public event Action<string[]> GenerateConditionsEvent;
        public event Action UpdateSceneEvent;

        public virtual string MasterName { get; } = "BaseMaster";

        protected void RaiseGenerateConditionsEvent(string[] strings)
        {
            GenerateConditionsEvent?.Invoke(strings);
        }

        protected void RaisePrintInfoEvent(string str, Color color)
        {
            PrintInfoEvent?.Invoke(str, color);
        }

        protected void RaiseUpdateSceneEvent()
        {
            UpdateSceneEvent?.Invoke();
        }

        public BaseMaster()
        {
            InitializeComponent();
        }
    }
}
