using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskModule.Validation
{
    public class ValidationEventArgs : CancelEventArgs
    {
        public ErrorProvider EP { get; }
        public object component { get; }

        public ValidationEventArgs(ErrorProvider eP, object component)
        {
            EP = eP;
            this.component = component;
        }
    }
}
