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
    public partial class ValidatingButton : Button, IControlGroupValidator
    {
        public ValidatingButton()
        {
            InitializeComponent();
            EP = InitializaErrorProvider();
            ValidatingControls = new List<IValidatingControl>();
        }

        public ValidatingButton(IContainer container)
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

        public bool ValidateControls() => ValidatingControls.Any(x => x.IsValueValid(EP));

        public void ValidatingButton_OnClick(object sender, CancelEventArgs cea)
        {
            if (!ValidateControls())
                cea.Cancel = true;
        }
    }
}
