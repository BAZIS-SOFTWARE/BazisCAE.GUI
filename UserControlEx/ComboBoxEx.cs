using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
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
        private int errorsCount;
        private StringBuilder errorMessages;

        public ErrorProvider EP { get; private set; }
        public CMBInputType InputType { get; set; } = CMBInputType.Items;
        public bool IsValidating { get; set; } = true;
        public string UserRegExCheck { get; set; }
        public string UserRegExCheckErrorMessage { get; set; }

        public ComboBoxEx() { InitializeComponent(); InitializeErrorProvider(); }

        public ComboBoxEx(IContainer container)
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
            errorsCount = 1;
            errorMessages = new StringBuilder();

            if (!IsValidating) return GetErrorCheckResult();

            if (Text.Equals(string.Empty))
            {
                if (IsInputTypeChosen(CMBInputType.Empty)) return GetErrorCheckResult();

                if (!Enabled) return GetErrorCheckResult();

                errorMessages.AppendLine($"{errorsCount++} Поле оставлено пустым");
            }

            if (IsInputTypeChosen(CMBInputType.Items))
            {
                HandleTextValue();

                if (IsInputTypeChosen(CMBInputType.User))
                    HandleUserCheckValue();

                return GetErrorCheckResult();
            }
                

            if (IsInputTypeChosen(CMBInputType.Integer))
                HandleIntegerValue();

            if (IsInputTypeChosen(CMBInputType.Float))
                HandleFloatValue();

            if (IsInputTypeChosen(CMBInputType.User))
                HandleUserCheckValue();

            return GetErrorCheckResult();
        }

        private bool GetErrorCheckResult()
        {
            var error = errorMessages.ToString();
            EP.SetError(this, error);
            return error.Length < 1;
        }

        private bool IsInputTypeChosen(CMBInputType it) =>
            (InputType & it) != 0;

        private void HandleFloatValue()
        {
            if (Text.Contains(","))
                errorMessages.AppendLine($"{errorsCount++}) В качестве разделителя целой и дробной части необходимо использовать точку");

            if (IsInputTypeChosen(CMBInputType.Positive)
                && !IsPassRegExCheck("^(([1-9](\\d{1,}))|(\\d{1}))([.](\\d{1,}))?$")
                && !IsPassRegExCheck("^(\\d{1})(([.])(\\d{1,}))?([e,E])([+]|[-])(\\d|[1-9]\\d{1,})$"))
                errorMessages.AppendLine($"{errorsCount++}) Числовое поле не прошло проверку. Поле принимает только положительные числа");

            if (!IsPassRegExCheck("^([-]?)(([1-9](\\d{1,}))|(\\d{1}))([.](\\d{1,}))?$")
                && !IsPassRegExCheck("^([-]?)(\\d{1})((([.])(\\d{1,}))?([e,E])([+]|[-])(\\d|[1-9]\\d{1,}))?$"))
                errorMessages.AppendLine($"{errorsCount++}) Числовое поле не прошло проверку. Присутсвуют неопределимые ошибки записи числа");
        }

        private void HandleIntegerValue()
        {
            if (IsInputTypeChosen(CMBInputType.Positive)
                && !IsPassRegExCheck("^(([1-9]{1})(\\d{1,})?)$"))
                errorMessages.AppendLine($"{errorsCount++}) Числовое значение должно быть положительным. Возможно присутсвие других ошибок в записи числа");

            if (!IsPassRegExCheck("^([-]?)(([1-9]{1})(\\d{1,})?)$"))
                errorMessages.AppendLine($"{errorsCount++}) Присутсвуют неопределимые ошибки записи числа ошибки записи числа");
        }

        private void HandleUserCheckValue()
        {
            if (!IsPassRegExCheck(UserRegExCheck))
                errorMessages.AppendLine($"{errorsCount++}) {UserRegExCheckErrorMessage}");
        }

        private void HandleTextValue()
        {
            if (!Items.Contains(Text))
            {
                if (IsInputTypeChosen(CMBInputType.Integer))
                    HandleIntegerValue();

                else if (IsInputTypeChosen(CMBInputType.Float))
                    HandleFloatValue();

                else
                    errorMessages.AppendLine($"{errorsCount++}) Выбранный вариант не доступен. Вероятно, допущена ошибка при выборе значения");
            }
        }

        private bool IsPassRegExCheck(string regEx) => Regex.IsMatch(Text, regEx);
    }
}
