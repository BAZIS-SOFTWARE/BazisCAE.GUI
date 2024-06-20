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
    }
}
