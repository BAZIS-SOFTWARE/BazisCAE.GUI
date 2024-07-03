using BaseModule.ControlsLib.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseModule.ControlsLib
{
    [Flags]
    public enum TXTBoxInputType
    {
        Text = 1,
        SpecialSymbols = 2,
        Integer = 4,
        Float = 8,
        Positive = 16,
        User = 32,
        Empty = 64
    }

    public partial class TextBoxEx : TextBox, IValidatorControl
    {
        public char[] IligalSymbols = new[] { ' ' };

        public TextBoxEx() { InitializeComponent(); InitializeErrorProvider(); }

        public TextBoxEx(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            InitializeErrorProvider();
        }

        public bool IsValidating { get; set; } = true;

        public ErrorProvider EP { get; private set; }
        public TXTBoxInputType InputType { get; set; } = TXTBoxInputType.Text;
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
            if (!IsValidating) return true;

            if (Text.Equals(string.Empty))
            {
                if (IsInputTypeChosen(TXTBoxInputType.Empty)) return GetErrorCheckResult();

                if (Enabled) return GetErrorCheckResult("Поле оставлено пустым");
            }

            if (IsInputTypeChosen(TXTBoxInputType.Integer)) return HandleIntegerValue();

            if (IsInputTypeChosen(TXTBoxInputType.Float)) return HandleFloatValue();

            if (IsInputTypeChosen(TXTBoxInputType.User)) return HandleUserCheckValue();

            if (IsInputTypeChosen(TXTBoxInputType.Text)) return HandleTextValue();

            return GetErrorCheckResult();
        }

        private bool GetErrorCheckResult(string errorMessage = "")
        {
            EP.SetError(this, errorMessage);
            return !(errorMessage.Length > 0);
        }
        private bool IsInputTypeChosen(TXTBoxInputType it) =>
            (InputType & it) != 0;

        private bool HandleFloatValue()
        {
            if (Text.Contains(","))
                return GetErrorCheckResult("В качестве разделителя целой и дробной части необходимо использовать точку");

            if (IsInputTypeChosen(TXTBoxInputType.Positive))
            {
                return (IsPassRegExCheck("^(([1-9](\\d{1,}))|(\\d{1}))([.](\\d{1,}))?$")
                    || IsPassRegExCheck("^(\\d{1})((([.])(\\d{1,}))?([e,E])([+]|[-])(\\d|[1-9]\\d{1,}))?$"))?
                    GetErrorCheckResult():
                    GetErrorCheckResult("Числовое поле не прошло проверку. Поле принимает только положительные числа");
            }

            return (IsPassRegExCheck("^([-]?)(([1-9](\\d{1,}))|(\\d{1}))([.](\\d{1,}))?$")
                || IsPassRegExCheck("^([-]?)(\\d{1})((([.])(\\d{1,}))?([e,E])([+]|[-])(\\d|[1-9]\\d{1,}))?$"))?
                GetErrorCheckResult():
                GetErrorCheckResult("Числовое поле не прошло проверку. Присутсвуют неопределимые ошибки записи числа");
        }

        private bool HandleIntegerValue()
        {
            if (IsInputTypeChosen(TXTBoxInputType.Positive))
            {
                return IsPassRegExCheck("^(([1-9]{1})(\\d{1,})?)$") ?
                    GetErrorCheckResult() :
                    GetErrorCheckResult("Числовое значение должно быть положительным. Возможно присутсвие других ошибок в записи числа");
            }

            return (IsPassRegExCheck("^([-]?)(([1-9]{1})(\\d{1,})?)$"))?
                GetErrorCheckResult():
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
            return Text.Any(x => IligalSymbols.Contains(x)) ?
                GetErrorCheckResult("Переданная строка содержит неподдерживаемые символы") :
                HandleIntegerValue();
        }

        private bool IsPassRegExCheck(string regEx) => Regex.IsMatch(Text, regEx);
    }
}
