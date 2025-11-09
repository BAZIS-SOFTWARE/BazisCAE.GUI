using BaseModule.Extensions;
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
                var nodeName = navigator.SelectedNode.Name.ToEnum<NodeName>();

                // TODO Подумать над очисткой данных геометрии
                if (nodeName == NodeName.сетка)
                {
                    project.ClearModelCollection(ObjType.Узел);

                    PresentGeoData();
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
