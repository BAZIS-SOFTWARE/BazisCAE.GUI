using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseModule.ControlsLib.Validation
{
    /// <summary>
    /// Интерфейс валидатора контроллов. Используется для проверки значения после нажатия кнопки
    /// </summary>
    public interface IValidatorControl
    {
        bool IsValueValid();

        bool IsValidating { get; set; }

        /// <summary>
        /// UserRegExCheck. Предоставляет пользователю добавить свою проверку ввода с помощью строки регулярного выражения
        /// </summary>
        string UserRegExCheck { get; set; }

        /// <summary>
        /// ErrorMessage, которое появляется при непройденной проверке на соответствие регулярному выражению UserRegExCheck
        /// </summary>
        string UserRegExCheckErrorMessage { get; set; }

        event Action<EventArgs> Validate;

        ErrorProvider EP { get; }

        void InitializeErrorProvider();
    }

    [Flags]
    public enum TXTBoxInputType
    {
        Text = 1,
        SpecialSymbols = 2,
        Integer = 4,
        Float = 8,
        Positive = 16,
        User = 32
    }

    [Flags]
    public enum CMBInputType
    {
        Items = 1,
        Integer = 2,
        Float = 4,
        Positive = 8,
        User = 32
    }
}
