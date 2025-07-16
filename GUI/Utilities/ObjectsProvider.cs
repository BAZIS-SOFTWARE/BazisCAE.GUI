using BaseModule.Extensions;
using BaseModule.Results.GraphCreation;
using Model;
using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
using Project.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI.Utilities
{
    public static class ObjectsProvider
    {


        public static IEnumerable<IModelObject> GraphPageProvider(IObjectsData objectsData, GraphObjects objects)
        {
            switch (objects)
            {
                case GraphObjects.Узел:
                    return objectsData.NodesSet.Values;
                default:
                    return objectsData.GetAllElements();
            }
        }

        
    }
}
