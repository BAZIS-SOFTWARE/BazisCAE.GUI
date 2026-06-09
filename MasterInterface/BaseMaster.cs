using BazisGUI.Masters.Args;
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
    public partial class BaseMaster : UserControl, IBaseMaster
    {

        public event EventHandler<PrintInfoEventArgs> PrintInfoEvent;
        public event EventHandler<GenerateConditionsEventArgs> GenerateConditionsEvent;
        public event EventHandler<UpdateSceneEventArgs> UpdateSceneEvent;
        public event EventHandler<EventArgs> OnMasterLoaded;

        public virtual string MasterName { get; } = "BaseMaster";

        protected void RaiseGenerateConditionsEvent(string[] strings)
        {
            GenerateConditionsEvent?.Invoke(this, new GenerateConditionsEventArgs(strings));
        }

        protected void RaisePrintInfoEvent(string str, Color color)
        {
            PrintInfoEvent?.Invoke(this, new PrintInfoEventArgs(str, color));
        }

        protected void RaiseUpdateSceneEvent()
        {
            UpdateSceneEvent?.Invoke(this, new UpdateSceneEventArgs());
        }

        public BaseMaster()
        {
            InitializeComponent();
            OnMasterLoaded?.Invoke(this, new EventArgs());
        }
    }
}
