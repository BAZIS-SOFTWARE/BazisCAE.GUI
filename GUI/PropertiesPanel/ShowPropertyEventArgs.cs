using Model.Interfaces;
using Model.ObjectsCollections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
