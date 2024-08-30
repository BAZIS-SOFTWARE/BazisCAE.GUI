using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace BaseModule.Utilities
{
    public class SplittersController
    {

        public void PassBySplittersReq(Queue<int> splitters, ControlCollection controls, bool isEnqueue)
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
