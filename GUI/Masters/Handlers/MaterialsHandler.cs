using BazisGUI.Masters.Interfaces;
using MasterInterface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI.Masters.Handlers
{
    public class MaterialsHandler<T> : IMasterInterfaceHandler<T> where T : IMaterialsHandling
    {
        public Action<string[]> SetMaterials;

        public MaterialsHandler(Action<string[]> setMaterials)
        {
            SetMaterials = setMaterials;
        }

        public void Handle(T instance)
        {
            SetMaterials += instance.SetMaterials;
        }
    }
}
