using BaseModule.Extensions;
using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using GmshApi;
using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
using OperationalController;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public void DeleteElems(ObjType objType,string name)
        {
            project.DeleteModelSet(objType, name);
            VBOController.DeleteVBObjects(name);
        }
        private void navigator_DelElementsEvent(int obj)
        {
            try
            {
                ObjType objType;
                if (obj == 1)
                    objType = ObjType.Элемент1D;
                else if (obj == 2)
                    objType = ObjType.Элемент2D;
                else
                    objType = ObjType.Элемент3D;

                var names = project.GetModelSetsInfo(objType).
    Select(x => x.Name).ToList();
                foreach (var item in names)
                    DeleteElems(objType, item);
                DisplayObjects();
                PresentMeshData();
                PresentModelObjectsForSelection();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
    }
}
