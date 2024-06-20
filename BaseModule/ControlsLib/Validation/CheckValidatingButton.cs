using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskModule.Validation
{
    public partial class CheckValidatingButton : Button, IControlGroupValidator
    {
        public CheckValidatingButton()
        {
            InitializeComponent();
            EP = InitializaErrorProvider();
            ValidatingControls = new List<IValidatingControl>();
        }

        public CheckValidatingButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            EP = InitializaErrorProvider();
            ValidatingControls = new List<IValidatingControl>();
        }

        public ErrorProvider EP { get; }

        public List<IValidatingControl> ValidatingControls { get; }

        private ErrorProvider InitializaErrorProvider()
        {
            var eP = new ErrorProvider();
            eP.SetIconAlignment(this, ErrorIconAlignment.MiddleRight);
            eP.SetIconPadding(this, 2);
            eP.BlinkRate = 1000;
            eP.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            return eP;
        }

        public void AddControl(IValidatingControl ctrl) => ValidatingControls.Add(ctrl);

        public void RemoveControl(IValidatingControl ctrl) => ValidatingControls.Remove(ctrl);

        /// <summary>
        /// Проходит всегда по всем валидаторам контроллов, проверяя их и выводя ошибку.
        /// </summary>
        /// <returns></returns>
        public bool ValidateControls() 
        {
            var result = true;
            // Обязательно проходить все контроллы, чтобы не пропустить вывод других ошибок, в случае обнаружения
            foreach(var ctrl in ValidatingControls)
            {
                if (!ctrl.IsValueValid(EP))
                    result = false;
            }
            return result;
        }

        public bool ValidatingButton_OnClick_IsValuesValid(object sender, CancelEventArgs cea)
        {
            var isValid = ValidateControls();
            if (!isValid)
            {
                cea.Cancel = true;
                return false;
            }
            return true;
        }
    }
}
