using BaseModule.Extensions;
using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BazisGUI.Scene.VBO;
using BazisGUI.Utilities;
using Geometry;
using GmshApi;
using Model.GeometryObjects;
using Model.Interfaces;
using OperationalController;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_SelectMeshEvent()
        {
            try
            {
                List<RowProperty> rows = new List<RowProperty>();

                rows.Add(new RowProperty("Узлы", project.GetModelObjects(ObjType.Узел).Count(), true));
                rows.Add(new RowProperty("Элементы 1D", project.GetAllModelElements().
                    Where(x => x.ObjType == ObjType.Элемент1D).Count(), true));
                rows.Add(new RowProperty("Элементы 2D", project.GetAllModelElements().
    Where(x => x.ObjType == ObjType.Элемент2D).Count(), true));
                rows.Add(new RowProperty("Элементы 3D", project.GetAllModelElements().
Where(x => x.ObjType == ObjType.Элемент3D).Count(), true));

                //TODO добавить кнопки скрытия элемнентов по типу

                propertiesPanel.DrawTable(rows);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }

        
    }
}
