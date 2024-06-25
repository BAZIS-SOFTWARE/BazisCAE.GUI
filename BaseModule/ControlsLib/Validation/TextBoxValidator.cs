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
    public partial class TextBoxValidator : TextBox, IValidatorControl
    {
        public char[] IligalSymbols = new[] { ' ' };

        public TextBoxValidator() { InitializeComponent(); }

        public TextBoxValidator(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public bool IsValidating { get; set; } = true;

        public TXTBoxInputType InputType { get; set; } = TXTBoxInputType.Text;
        public string UserRegExCheck { get; set; }
        public string UserRegExCheckErrorMessage { get; set; }

        public bool IsValueValid(ErrorProvider EP)
        {
            if (!IsValidating)
                return true;

            if (Text.Equals(string.Empty))
                return Enabled == false ?
                    GetErrorCheckResult(EP) :
                    GetErrorCheckResult(EP, "Поле оставлено пустым");

            if (IsInputTypeChosen(TXTBoxInputType.Text)
                && Text.Any(x => IligalSymbols.Contains(x)))
                return GetErrorCheckResult(EP, "Переданная строка пуста или содержит неподдерживаемые символы");

            if (IsInputTypeChosen(TXTBoxInputType.Integer))
                return HandleIntegerValue(EP);
                

            if (IsInputTypeChosen(TXTBoxInputType.Float))
                return HandleFloatValue(EP);

            if (IsInputTypeChosen(TXTBoxInputType.User))
                return HandleUserCheckValue(EP);

            return GetErrorCheckResult(EP, $"Поле с валидирующим обработчиком типа {InputType} не было обработано ни одним обработчиком." +
                $"Ошибка в веденном значении или типе обработки");
        }

        private bool GetErrorCheckResult(ErrorProvider EP, string errorMessage = "")
        {
            EP.SetError(this, errorMessage);
            return !(errorMessage.Length > 0);
        }
        private bool IsInputTypeChosen(TXTBoxInputType it) =>
            (InputType & it) != 0;

        private bool HandleFloatValue(ErrorProvider EP)
        {
            if (Text.Contains(","))
                return GetErrorCheckResult(EP, "В качестве разделителя целой и дробной части необходимо использовать точку");

            if (IsInputTypeChosen(TXTBoxInputType.Positive))
            {
                return (IsPassRegExCheck("^(([1-9](\\d{1,}))|(\\d{1}))([.](\\d{1,}))?$")
                    || IsPassRegExCheck("^(\\d{1})((([.])(\\d{1,}))?([e,E])([+]|[-])(\\d|[1-9]\\d{1,}))?$"))?
                    GetErrorCheckResult(EP):
                    GetErrorCheckResult(EP, "Числовое поле не прошло проверку. Поле принимает только положительные числа");
            }

            return (IsPassRegExCheck("^([-]?)(([1-9](\\d{1,}))|(\\d{1}))([.](\\d{1,}))?$")
                || IsPassRegExCheck("^([-]?)(\\d{1})((([.])(\\d{1,}))?([e,E])([+]|[-])(\\d|[1-9]\\d{1,}))?$"))?
                GetErrorCheckResult(EP):
                GetErrorCheckResult(EP, "Числовое поле не прошло проверку. Присутсвуют неопределимые ошибки записи числа");
        }

        private bool HandleIntegerValue(ErrorProvider EP)
        {
            if (IsInputTypeChosen(TXTBoxInputType.Positive))
            {
                return IsPassRegExCheck("^(([1-9]{1})(\\d{1,})?)$") ?
                    GetErrorCheckResult(EP) :
                    GetErrorCheckResult(EP, "Числовое значение должно быть положительным. Возможно присутсвие других ошибок в записи числа");
            }

            return (IsPassRegExCheck("^([-]?)(([1-9]{1})(\\d{1,})?)$"))?
                GetErrorCheckResult(EP):
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
