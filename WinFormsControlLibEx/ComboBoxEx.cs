using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlsEx
{
    [Flags]
    public enum CMBInputType
    {
        Items = 1,
        Integer = 2,
        Float = 4,
        Positive = 8,
        User = 16,
        Empty = 32
    }

    public partial class ComboBoxEx : ComboBox, IValidatorControl
    {
        public ComboBoxEx() { InitializeComponent(); InitializeErrorProvider(); }

        public ComboBoxEx(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            InitializeErrorProvider();
        }

        public ErrorProvider EP { get; private set; }
        public CMBInputType InputType { get; set; } = CMBInputType.Items;
        public bool IsValidating { get; set; } = true;
        public string UserRegExCheck { get; set; }
        public string UserRegExCheckErrorMessage { get; set; }

        public void InitializeErrorProvider()
        {
            EP = new ErrorProvider();
            EP.SetIconAlignment(this, ErrorIconAlignment.MiddleRight);
            EP.SetIconPadding(this, 2);
            EP.BlinkRate = 1000;
            EP.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        public bool IsValueValid()
        {
            var errors = new StringBuilder();
            if (!IsValidating) return true;

            if (Text.Equals(string.Empty))
            {
                if (IsInputTypeChosen(CMBInputType.Empty)) return GetErrorCheckResult();
                return Enabled ?
                    GetErrorCheckResult("Поле оставлено пустым") :
                    GetErrorCheckResult();
            }

            if (IsInputTypeChosen(CMBInputType.Integer)) return HandleIntegerValue();

            if (IsInputTypeChosen(CMBInputType.Float))
            {
                var res = HandleFloatValue();
                return !res && IsInputTypeChosen(CMBInputType.Items) ?
                    HandleTextValue() :
                    res;
            }

            if (IsInputTypeChosen(CMBInputType.User)) return HandleUserCheckValue();

            if (IsInputTypeChosen(CMBInputType.Items))
            {
                var res = HandleTextValue();
                return !res && IsInputTypeChosen(CMBInputType.Float) ?
                    HandleFloatValue() :
                    res;
            }
                

            return GetErrorCheckResult("Выбранный вариант не доступен. Вероятно, допущена ошибка при выборе значения");
        }

        private bool GetErrorCheckResult(string errorMessage = "")
        {
            EP.SetError(this, errorMessage);
            return !(errorMessage.Length > 0);
        }

        private bool IsInputTypeChosen(CMBInputType it) =>
            (InputType & it) != 0;

        private bool HandleFloatValue()
        {
            if (Text.Contains(","))
                return GetErrorCheckResult("В качестве разделителя целой и дробной части необходимо использовать точку");

            if (IsInputTypeChosen(CMBInputType.Positive))
                return (IsPassRegExCheck("^(([1-9](\\d{1,}))|(\\d{1}))([.](\\d{1,}))?$")
                    || IsPassRegExCheck("^(\\d{1})(([.])(\\d{1,}))?([e,E])([+]|[-])(\\d|[1-9]\\d{1,})$"))?
                    GetErrorCheckResult():
                    GetErrorCheckResult("Числовое поле не прошло проверку. Поле принимает только положительные числа");

            return (IsPassRegExCheck("^([-]?)(([1-9](\\d{1,}))|(\\d{1}))([.](\\d{1,}))?$")
                || IsPassRegExCheck("^([-]?)(\\d{1})((([.])(\\d{1,}))?([e,E])([+]|[-])(\\d|[1-9]\\d{1,}))?$"))?
                GetErrorCheckResult():
                GetErrorCheckResult("Числовое поле не прошло проверку. Присутсвуют неопределимые ошибки записи числа");
        }

        private bool HandleIntegerValue()
        {
            if (IsInputTypeChosen(CMBInputType.Positive))
                return IsPassRegExCheck("^(([1-9]{1})(\\d{1,})?)$") ?
                    GetErrorCheckResult() :
                    GetErrorCheckResult("Числовое значение должно быть положительным. Возможно присутсвие других ошибок в записи числа");

            return (IsPassRegExCheck("^([-]?)(([1-9]{1})(\\d{1,})?)$")) ?
                GetErrorCheckResult() :
                GetErrorCheckResult("Числовое поле не прошло проверку. Присутсвуют неопределимые ошибки записи числа ошибки записи числа");
        }

        private bool HandleUserCheckValue()
        {
            return IsPassRegExCheck(UserRegExCheck) ?
                GetErrorCheckResult() :
                GetErrorCheckResult(UserRegExCheckErrorMessage);
        }

        private bool HandleTextValue()
        {
            return Items.Contains(Text) ?
                    GetErrorCheckResult() :
                    GetErrorCheckResult("Допущена ошибка при выборе варианта");
        }

        private bool IsPassRegExCheck(string regEx) => Regex.IsMatch(Text, regEx);
    }
}
