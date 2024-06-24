using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace BaseModule.ControlsLib.Validation
{
    public interface IControlGroupValidator
    {
        List<Func<ErrorProvider, bool>> ControlsValidatingMethods { get;}
        void AddControlValidatingMethod(Func<ErrorProvider, bool> method);
        void AddRangeControlValidatingMethod (IEnumerable<Func<ErrorProvider, bool>> methods);
        void RemoveControlValidatingMethod(Func<ErrorProvider, bool> method);
        bool ValidateControls();

        bool ValidateControl_OnClick_IsValuesValid(object sender, CancelEventArgs cea);
    }
}
