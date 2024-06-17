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
    public interface IValidatingControl
    {
        ErrorProvider EP { get; }

        bool IsValueValid(out string errorMessage);

        void OnValidating(object sender, CancelEventArgs e);
    }
}
