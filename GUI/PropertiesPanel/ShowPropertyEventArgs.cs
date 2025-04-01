using Model.Interfaces;
using Model.ObjectsCollections;
using System;

namespace BazisGUI.PropertiesPanel
{
    public class ShowPropertyEventArgs : EventArgs
    {
        public ObjectsSet<IModelObject> Obj;

        public ShowPropertyEventArgs(ObjectsSet<IModelObject> obj)
        {
            Obj = obj;
        }
    }
}
