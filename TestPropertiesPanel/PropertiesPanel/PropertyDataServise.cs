using Model;
using Model.Interfaces;
using Model.MeshObjects;
using Model.ObjectsCollections;

namespace TestPropertiesPanel.PropertiesPanel
{
    public class PropertyDataService<T> : EventArgs where T: IModelObject
    {
        public ObjectsSet<T> meshObject { get; }

        public PropertyDataService(ObjectsSet<T> meshObject)
        {
            this.meshObject = meshObject;
        }
    }
}

