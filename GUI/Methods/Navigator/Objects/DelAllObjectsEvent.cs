using BaseModule.Extensions;
using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    PresentModelOnSelectToolStrip();
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
