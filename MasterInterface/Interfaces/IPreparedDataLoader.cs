using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterInterface.Interfaces
{
    public interface IPreparedDataLoader : IMasterInterface
    {
        /// <summary>
        /// Заполнение мастера данными условий из проекта
        /// </summary>
        /// <param name="conditions">Набор строковых представлений условий</param>
        void SetDataFromConditionsStrings(IEnumerable<string> conditions);
    }
}
