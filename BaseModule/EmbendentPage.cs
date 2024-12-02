using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserControlsEx;

namespace BaseModule
{
    public partial class EmbendentPage : UserControl
    {
        public BasePage BasePage
        {
            get
            {
                return basePage;
            }
        }

        public SplitContainerEx EmbeddedSplitContainer
        {
            get
            {
                return splitContainerEx;
            }
        }

        public ControlCollection EmbeddedControls
        {
            get
            {
                return splitContainerEx.Panel2.Controls;
            }
        }
        public EmbendentPage()
        {
            InitializeComponent();

            splitContainerEx.Panel2Collapsed = true;
        }

        private void pinnedControl_ControlCollapseEvent()
        {
            splitContainerEx.Panel2Collapsed = true;
        }
    }
}
