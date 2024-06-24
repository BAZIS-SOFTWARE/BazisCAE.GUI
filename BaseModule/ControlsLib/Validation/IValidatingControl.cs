using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskModule.Validation
{
    /// <summary>
    /// Интерфейс валидатора контроллов. Используется для проверки значения после нажатия кнопки
    /// </summary>
    public interface IValidatingControl
    {
        bool IsValueValid(ErrorProvider EP);

        bool IsValidating { get; set; }
    }

    [Flags]
    public enum TXTBoxInputType
    {
        Text = 1,
        SpecialSymbols = 2,
        Integer = 4,
        Float = 8,
        Positive = 16
    }

    [Flags]
    public enum CMBInputType
    {
        Items = 1,
        Integer = 2,
        Float = 4,
        Positive = 8
    }
}
