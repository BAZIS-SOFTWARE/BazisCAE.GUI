using Model;
using Model.MeshObjects;
using Model.ObjectsCollections;

namespace TestPropertiesPanel.PropertiesPanel
{
    //public class PropertyDataServise : EventArgs
    //{
    //    public ObjectsSet<Node> nodes;

    //    public PropertyDataServise(ObjectsSet<Node> nodes)
    //    {
    //        this.nodes = nodes;
    //    }
    //}

    public class PropertyDataServise<T> : EventArgs where T : ModelObject
    {
        public ObjectsSet<T> meshObject;

        public PropertyDataServise(ObjectsSet<T> meshObject)
        {
            this.meshObject = meshObject;
        }
    }
}

