using BaseModule.Mesh.SettingsControls;
using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BazisGUI.Scene;
using BazisGUI.Scene.VBO;
using BazisGUI.SettingsControls;
using BazisGUI.Utilities;
using GmshApi;
using Model.GeometryObjects;
using Model.Interfaces;
using Model.Interfaces.ObjectsFinders;
using Model.MeshObjects;
using OperationalController.GmshController;
using Project.Interfaces.Tasks;
using Project.Results;
using Project.Results.IO;
using Project.Tasks;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_SelectObjectEvent(NodeName arg1, string arg2, int arg3)
        {
            try
            {
                var objType = Converters.ConvertNavigatorNodeNameToObjType(arg1);
                //var setName = arg2.Split(' ')[0]; // Деление по пробелу перед :
                var objects = project.GetModelObjects(objType);
                var item = objects.FirstOrDefault(x => x.Number == arg3);


                // TO DO
                var rows = new List<RowProperty>();
                if (objType == ObjType.Точка)
                {
                    var dimTags = new int[] { 0, arg3 };
                    var meshSize = gmshController.Gmsh.Model.Mesh.GetSizes(dimTags);

                    var row = new RowProperty("Размер элементов", meshSize[0]);
                    rows.Add(row);
                }

                else if(objType == ObjType.Кривая)
                {
                    rows.AddRange(GetCurveProperties(arg3));
                }
                //var _converter = new ModelObjectConverter(item);
                propertiesPanel.DrawTable(rows);

            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        

        private void GetPointSize(object arg1, int arg2)
        {
            try
            {
                var dimTags = new int[] { 0, arg2 };
                var meshSize = gmshController.Gmsh.Model.Mesh.GetSizes(dimTags);
                var pointControl = arg1 as GMSHPointSettingsControl;
                pointControl.SetPointSize(meshSize[0]);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }
    }
}
