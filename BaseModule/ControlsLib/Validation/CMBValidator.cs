using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseModule.ControlsLib.Validation
{
    public partial class CMBValidator : ComboBox, IValidatorControl
    {
        public CMBValidator() { InitializeComponent(); }

        public CMBValidator(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public CMBInputType InputType { get; set; } = CMBInputType.Items;

        public bool IsValidating { get; set; } = true;
        public string UserRegExCheck { get; set; }
        public string UserRegExCheckErrorMessage { get; set; }

        public bool IsValueValid(ErrorProvider EP)
        {
            if (!IsValidating)
                return true;

            if (Text.Equals(string.Empty))
                return Enabled == false?
                    GetErrorCheckResult(EP):
                    GetErrorCheckResult(EP, "Поле оставлено пустым");

            if (IsInputTypeChosen(CMBInputType.Items))
                return Items.Contains(Text) ?
                    GetErrorCheckResult(EP) :
                    GetErrorCheckResult(EP, "Допущена ошибка при выборе варианта");

            if (IsInputTypeChosen(CMBInputType.Integer))
                return HandleIntegerValue(EP);

            if (IsInputTypeChosen(CMBInputType.Float))
                return HandleFloatValue(EP);

            if (IsInputTypeChosen(CMBInputType.User))
            {

            }

            return GetErrorCheckResult(EP, "Выбранный вариант не доступен. Вероятно, допущена ошибка при выборе значения");
        }

        private bool GetErrorCheckResult(ErrorProvider EP, string errorMessage = "")
        {
            EP.SetError(this, errorMessage);
            return !(errorMessage.Length > 0);
        }

        private bool IsInputTypeChosen(CMBInputType it) =>
            (InputType & it) != 0;

        private bool HandleFloatValue(ErrorProvider EP)
        {
            if (Text.Contains(","))
                return GetErrorCheckResult(EP, "В качестве разделителя целой и дробной части необходимо использовать точку");

            if (IsInputTypeChosen(CMBInputType.Positive))
                return (IsPassRegExCheck("^(([1-9](\\d{1,}))|(\\d{1}))([.](\\d{1,}))?$")
                    || IsPassRegExCheck("^(\\d{1})(([.])(\\d{1,}))?([e,E])([+]|[-])(\\d|[1-9]\\d{1,})$"))?
                    GetErrorCheckResult(EP):
                    GetErrorCheckResult(EP, "Числовое поле не прошло проверку. Поле принимает только положительные числа");

            return (IsPassRegExCheck("^([-]?)(([1-9](\\d{1,}))|(\\d{1}))([.](\\d{1,}))?$")
                || IsPassRegExCheck("^([-]?)(\\d{1})((([.])(\\d{1,}))?([e,E])([+]|[-])(\\d|[1-9]\\d{1,}))?$"))?
                GetErrorCheckResult(EP):
                GetErrorCheckResult(EP, "Числовое поле не прошло проверку. Присутсвуют неопределимые ошибки записи числа");
        }

        private bool HandleIntegerValue(ErrorProvider EP)
        {
            if (IsInputTypeChosen(CMBInputType.Positive))
            {
                return IsPassRegExCheck("^(([1-9]{1})(\\d{1,})?)$") ?
                    GetErrorCheckResult(EP) :
                    GetErrorCheckResult(EP, "Числовое значение должно быть положительным. Возможно присутсвие других ошибок в записи числа");
            }

            return (IsPassRegExCheck("^([-]?)(([1-9]{1})(\\d{1,})?)$")) ?
                GetErrorCheckResult(EP) :
                GetErrorCheckResult(EP, "Числовое поле не прошло проверку. Присутсвуют неопределимые ошибки записи числа ошибки записи числа");
        }

        private bool HandleUserCheckValue(ErrorProvider EP)
        {
            return IsPassRegExCheck(UserRegExCheck) ?
                GetErrorCheckResult(EP) :
                GetErrorCheckResult(EP, UserRegExCheckErrorMessage);
        }

        private bool IsPassRegExCheck(string regEx) => Regex.IsMatch(Text, regEx);
    }
}
