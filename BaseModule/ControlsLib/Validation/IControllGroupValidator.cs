using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskModule.Validation
{
    public interface IControlGroupValidator
    {
        ErrorProvider EP {get;}
        List<IValidatingControl> ValidatingControls { get;}
        void AddControl(IValidatingControl ctrl);
        void RemoveControl(IValidatingControl ctrl);
        bool ValidateControls();

        bool ValidatingButton_OnClick_IsValuesValid(object sender, CancelEventArgs cea);
    }
}
