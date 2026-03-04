using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterInterface.Interfaces
{
    public interface IMaterialsHandling : IMasterInterface
    {
        /// <summary>
        /// Заполнение материалов мастера
        /// </summary>
        /// <param name="materials">Имена материалов</param>
        void SetMaterials(IEnumerable<string> materials);
    }
}
