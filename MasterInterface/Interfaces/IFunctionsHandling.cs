using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterInterface.Interfaces
{
    public interface IFunctionsHandling : IMasterInterface
    {
        /// <summary>
        /// Заполнение функций мастера
        /// </summary>
        /// <param name="functions">Имена функций</param>
        /// 
        [Warning("Изменение набора функций приведет к удалению уже созданных строк для формирования граничных условий")]
        void SetFunctions(IEnumerable<string> functions);
    }
}
