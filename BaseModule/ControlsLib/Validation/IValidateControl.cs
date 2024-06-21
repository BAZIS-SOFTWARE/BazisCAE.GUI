using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TaskModule.Validation
{
    public interface IControlGroupValidator
    {
        List<Func<bool>> ControlsValidatingMethods { get;}
        void AddControlValidatingMethod(Func<bool> method);
        void AddRangeControlValidatingMethod (IEnumerable<Func<bool>> methods);
        void RemoveControlValidatingMethod(Func<bool> method);
        bool ValidateControls();

        bool ValidateControl_OnClick_IsValuesValid(object sender, CancelEventArgs cea);
    }
}
