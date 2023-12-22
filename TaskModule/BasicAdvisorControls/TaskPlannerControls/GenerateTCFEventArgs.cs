using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskModule.BasicAdvisorControls.TaskPlannerControls
{
    public class GenerateTCFEventArgs : EventArgs, IEnumerable<string>
    {
        List<string> inputLines;
        public GenerateTCFEventArgs(List<string> inputLines)
        {
            this.inputLines = inputLines;
        }

        public IEnumerator<string> GetEnumerator()
        {
            foreach (var item in inputLines)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
