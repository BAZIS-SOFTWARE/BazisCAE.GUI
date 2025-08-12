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
        private void navigator_SelectGroupEvent(int grIndex)
        {
            try
            {
                var group = project.GetModelGroup(grIndex);

                project.SetModelObjectsBackColor(group.ObjType);

                var pres = project.CreateModelObjectsPresentor(group.ObjType);
                SetVBObjectAttribute(pres, "цвет");

                foreach (var iobj in group)
                    iobj.Color = settingsConfig.SelectGroupColor;

                //pres = CreateObjectsPresentor(project.ModelData, group.ObjType);
                SetVBObjectAttribute(pres, "цвет");
                DisplayObjects();

                var rows = GetGroupProperty(group);
                propertiesPanel.DrawTable(rows);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
    }
}
