using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace UserControlsEx
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
        private int errorCount = 1;
        private StringBuilder errorMesages;

        public char[] IligalSymbols = new[] { ' ' };

        public bool IsValidating { get; set; } = true;

        public ErrorProvider EP { get; private set; }
        public TXTBoxInputType InputType { get; set; } = TXTBoxInputType.Text;
        public string UserRegExCheck { get; set; }
        public string UserRegExCheckErrorMessage { get; set; }

        public TextBoxEx() { InitializeComponent(); InitializeErrorProvider(); }

        public TextBoxEx(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            InitializeErrorProvider();
        }

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
            errorCount = 1;
            errorMesages = new StringBuilder();

            if (!IsValidating) return GetErrorCheckResult();

            if (Text.Equals(string.Empty))
            {
                if (IsInputTypeChosen(TXTBoxInputType.Empty)) return GetErrorCheckResult();

                if (!Enabled) return GetErrorCheckResult();

                if (!IsInputTypeChosen(TXTBoxInputType.Text) && Text.Equals(string.Empty))
                    errorMesages.AppendLine($"{errorCount++}) Поле оставлено пустым");
            }

            if (IsInputTypeChosen(TXTBoxInputType.Text))
            {
                HandleTextValue();

                if (IsInputTypeChosen(TXTBoxInputType.User))
                    HandleUserCheckValue();

                return GetErrorCheckResult();
            }

            if (IsInputTypeChosen(TXTBoxInputType.Integer))
                HandleIntegerValue();

            if (IsInputTypeChosen(TXTBoxInputType.Float))
                HandleFloatValue();

            if (IsInputTypeChosen(TXTBoxInputType.User))
                HandleUserCheckValue();

            return GetErrorCheckResult();
        }

        private bool GetErrorCheckResult()
        {
            var error = errorMesages.ToString();
            EP.SetError(this, error);
            return (error.Length < 1);
        }

        private bool IsInputTypeChosen(TXTBoxInputType it) =>
            (InputType & it) != 0;

        private void HandleFloatValue()
        {
            if (Text.Contains(","))
                errorMesages.AppendLine($"{errorCount++}) В качестве разделителя целой и дробной части необходимо использовать точку");

            if (IsInputTypeChosen(TXTBoxInputType.Positive))
            {
                if (!IsPassRegExCheck(@"^(([1-9](\d{1,}))|(\d{1}))([.](\d{1,}))?$")
                    && !IsPassRegExCheck(@"^(\d{1})((([.])(\d{1,}))?([e,E])([+]|[-])(\d{1,}))?$"))
                    errorMesages.AppendLine($"{errorCount++}) Поле принимает только положительные числа");
            }

            if (!IsPassRegExCheck(@"^([-]?)(([1-9](\d{1,}))|(\d{1}))([.](\d{1,}))?$")
                && !IsPassRegExCheck(@"^([-]?)(\d{1})((([.])(\d{1,}))?([e,E])([+]|[-])(\d|[1-9]\d{1,}))?$"))
                errorMesages.AppendLine($"{errorCount++}) Присутсвуют неопределимые ошибки записи числа");
        }

        private void HandleIntegerValue()
        {
            if (IsInputTypeChosen(TXTBoxInputType.Positive))
            {
                if (!IsPassRegExCheck(@"^(([1-9]{1})(\d{1,})?)$"))
                    errorMesages.AppendLine($"{errorCount++}) Числовое значение должно быть положительным. Возможно присутсвие других ошибок в записи числа");
            }
            if (!IsPassRegExCheck(@"^([-]?)(([1-9]{1})(\d{1,})?)$"))
                errorMesages.AppendLine($"{errorCount++}) Присутсвуют неопределимые ошибки записи числа ошибки записи числа");
        }

        private void HandleUserCheckValue()
        {
            if (!IsPassRegExCheck(UserRegExCheck))
                if (UserRegExCheckErrorMessage != null)
                    errorMesages.AppendLine(UserRegExCheckErrorMessage);
                else
                    errorMesages.AppendLine($"{errorCount++}) Значение не прошло пользовательскую проверку");
        }

        private void HandleTextValue()
        {
            if (!IsInputTypeChosen(TXTBoxInputType.Empty) && Text.Equals(string.Empty))
                errorMesages.AppendLine($"{errorCount++}) Поле оставлено пустым");

            else if (Text.Any(x => IligalSymbols.Contains(x)))
                errorMesages.AppendLine($"{errorCount++}) Переданная строка содержит неподдерживаемые символы");

            else
            {
                if (IsInputTypeChosen(TXTBoxInputType.Integer))
                    HandleIntegerValue();

                else if (IsInputTypeChosen(TXTBoxInputType.Float))
                    HandleFloatValue();
            }
        }

        private bool IsPassRegExCheck(string regEx) => Regex.IsMatch(Text, regEx);
    }
}
