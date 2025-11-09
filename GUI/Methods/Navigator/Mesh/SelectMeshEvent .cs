using BaseModule.PropertiesPanel;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

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
