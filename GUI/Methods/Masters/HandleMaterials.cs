using MasterInterface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void HandleMaterialsMaster(IMaterialsHandling mh)
        {
            if (project?.FunctionsDB == null) throw new Exception("Не определена база материалов");

            mh.SetMaterials(project?.FunctionsDB?.Keys?.ToArray() ?? Array.Empty<string>());

            OnChangeFunctions += (s, e) => mh.SetMaterials(e.Functions ?? Array.Empty<string>());
            OnProjectLoaded += () => mh.SetMaterials(project?.FunctionsDB?.Keys?.ToArray() ?? Array.Empty<string>());
        }
    }
}
