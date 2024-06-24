using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskModule.Validation
{
    public partial class CMBValidator : ComboBox, IValidatingControl
    {
        public CMBValidator() { InitializeComponent(); }

        public CMBValidator(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public CMBInputType InputType { get; set; } = CMBInputType.Items;

        public bool IsValidating { get; set; } = true;

        public bool IsValueValid(ErrorProvider EP)
        {
            if (Text.Equals(string.Empty))
            {
                if (Enabled == false)
                    return GetErrorCheckResult(EP);
                else
                    return GetErrorCheckResult(EP, "Поле оставлено пустым");
            }

            if (IsInputTypeChosen(CMBInputType.Items) && Items.Contains(Text))
                return GetErrorCheckResult(EP);

            if (IsInputTypeChosen(CMBInputType.Integer) & IsIntegerValuePass())
                return GetErrorCheckResult(EP);

            if (IsInputTypeChosen(CMBInputType.Float) && IsFloatValuePass())
                return GetErrorCheckResult(EP);

            return GetErrorCheckResult(EP, "Выбранный вариант не доступен. Вероятно, допущена ошибка при выборе значения");
        }

        private bool GetErrorCheckResult(ErrorProvider EP, string errorMessage = "")
        {
            EP.SetError(this, errorMessage);
            return errorMessage.Length > 0 ? false : true;
        }

        private bool IsInputTypeChosen(CMBInputType it) =>
            (InputType & it) != 0;

        private bool IsFloatValuePass() =>
            IsInputTypeChosen(CMBInputType.Positive)
            && (IsPassRegExCheck("^(([1-9](\\d{1,}))|(\\d{1}))([.](\\d{1,}))?$")
            || IsPassRegExCheck("^(\\d{1})(([.])(\\d{1,}))?([e,E])([+]|[-])(\\d|[1-9]\\d{1,})$"))
            || IsPassRegExCheck("^([-]?)(([1-9](\\d{1,}))|(\\d{1}))([.](\\d{1,}))?$")
            || IsPassRegExCheck("^([-]?)(\\d{1})(([.])(\\d{1,}))?([e,E])([+]|[-])(\\d|[1-9]\\d{1,})$");

        private bool IsIntegerValuePass() =>
            IsInputTypeChosen(CMBInputType.Integer)
            && IsPassRegExCheck("^([-]?)(([1-9]{1})(\\d{1,})?)$")
            || IsPassRegExCheck("^(([1-9]{1})(\\d{1,})?)$");

        private bool IsPassRegExCheck(string regEx) => Regex.IsMatch(Text, regEx);
    }
}
