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
        /// <summary>
        /// Метод проверки контрола. подписывается на событие, после которого будет проходить проверка
        /// </summary>
        /// <returns></returns>
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

        ErrorProvider EP { get; }

        void InitializeErrorProvider();
    }
}
