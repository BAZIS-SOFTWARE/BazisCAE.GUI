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
    /// Абстрактный класс валидатора контроллов. Используется валидация после ввода
    /// </summary>
    /// <typeparam name="ControlType">Класс контролла, который модифицируется проверкой над значением</typeparam>
    public interface IValidatingControl<ControlType>
        where ControlType : Control
    {
        ErrorProvider EP { get; set; }

        bool IsValueValid(out string errorMessage);

        void Validating(object sender, CancelEventArgs e);
    }
}
