using Model.Interfaces;
using Model.ObjectsCollections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI.PropertiesPanel
{
    public class PropertyDataService<T> : EventArgs where T : IModelObject
    {
        public ObjectsSet<T> meshObject { get; }

        public PropertyDataService(ObjectsSet<T> meshObject)
        {
            this.meshObject = meshObject;
        }
    }
}
