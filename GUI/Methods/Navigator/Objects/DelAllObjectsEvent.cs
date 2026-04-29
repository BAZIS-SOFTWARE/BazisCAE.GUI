using BazisGUI.Extensions;
using BazisGUI.Navigator;
using Model.Interfaces;
using System;
using System.Drawing;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_DelAllObjectsEvent()
        {
            try
            {
                // TODO Подумать над очисткой данных геометрии
                if (navigator.SelectedNode.Name == NodeName.Mesh.ToString())
                {
                    project.ClearModelCollection(ObjType.Узел);

                    //PresentGeoData();
                    PresentMeshData();
                    PresentGroupDataOnTree();
                    PresentCondDataOnTree();
                    PresentModelObjectsForSelection();
                    ClearAllDataOnScene();
                }

                DisplayObjects();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }
    }
}
