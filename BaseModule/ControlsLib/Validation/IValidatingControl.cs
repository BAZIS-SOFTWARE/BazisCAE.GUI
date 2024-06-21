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
        bool IsValueValid();

        bool IsValidating { get; set; }

        ErrorProvider EP { get; }
    }

    [Flags]
    public enum TextBoxInputType
    {
        AllValues = 0,
        Text = 1,
        SpecialSymbols = 2,
        integet = 4,
        Float = 8,
        Positive = 16
    }

    [Flags]
    public enum ComboBoxInputType
    {
        AllValues = 0,
        Items = 1,
        Integer = 2,
        Float = 4,
        Positive = 8
    }
}
