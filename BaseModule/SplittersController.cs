using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace BaseModule
{
    public class SplittersController
    {
        Control Control;

        public SplittersController(Control control)
        {
            Control = control;
        }
        public Queue<int> GetSplitters()
        {
            var splitters = new Queue<int>();

            PassBySplittersReq(splitters, Control.Controls, true);

            return splitters;
        }

        public void SetSplitters(Queue<int> splitters)
        {
            PassBySplittersReq(splitters, Control.Controls, false);
        }

        private void PassBySplittersReq(Queue<int> splitters, ControlCollection controls, bool isEnqueue)
        {
            foreach (Control item in controls)
            {
                if (item is SplitContainer splCont)
                    if (isEnqueue)
                        splitters.Enqueue(splCont.SplitterDistance);
                    else
                        splCont.SplitterDistance = splitters.Dequeue();

                PassBySplittersReq(splitters, item.Controls, isEnqueue);
            }
        }
    }
}
