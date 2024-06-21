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

    public enum TextBoxInputType
    {
        Text,
        TextAndSpecialSymbols,
        PositiveFloat,
        Float,
        AllValues
    }

    public enum ComboBoxInputType
    {
        Items,
        ItemsAndFloat,
        ItemsAndPositiveFloat,
        AllValues
    }
}
