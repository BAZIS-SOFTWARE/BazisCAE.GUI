using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseModule.ControlsLib.Validation
{
    public partial class BtnValidate : Button, IControlGroupValidator
    {
        public BtnValidate()
        {
            InitializeComponent();
            EP = InitializaErrorProvider();
            ControlsValidatingMethods = new List<Func<ErrorProvider, bool>>();
        }

        public BtnValidate(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            EP = InitializaErrorProvider();
            ControlsValidatingMethods = new List<Func<ErrorProvider, bool>>();
        }

        public List<Func<ErrorProvider, bool>> ControlsValidatingMethods { get; }

        public void AddControlValidatingMethod(Func<ErrorProvider, bool> method) => ControlsValidatingMethods.Add(method);

        public void RemoveControlValidatingMethod(Func<ErrorProvider, bool> method) => ControlsValidatingMethods.Remove(method);

        public void AddRangeControlValidatingMethod(IEnumerable<Func<ErrorProvider, bool>> methods) =>
            ControlsValidatingMethods.AddRange(methods);

        public ErrorProvider EP { get; }

        private ErrorProvider InitializaErrorProvider()
        {
            var eP = new ErrorProvider();
            eP.SetIconAlignment(this, ErrorIconAlignment.MiddleRight);
            eP.SetIconPadding(this, 2);
            eP.BlinkRate = 1000;
            eP.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            return eP;
        }

        /// <summary>
        /// Проходит всегда по всем делегатам проверки, проверяя их контролы и выводя ошибку возле контрола.
        /// </summary>
        /// <returns></returns>
        public bool ValidateControls() 
        {
            var result = true;
            foreach(var method in ControlsValidatingMethods)
            {
                if (!method(EP))
                    result = false;
            }
            return result;
        }

        public bool ValidateControl_OnClick_IsValuesValid(object sender, CancelEventArgs cea)
        {
            if (!ValidateControls())
            {
                cea.Cancel = true;
                return false;
            }
            return true;
        }
    }
}
