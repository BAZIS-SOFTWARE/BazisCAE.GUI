using BazisGUI.Properties;
using BazisGUI.PropertiesPanel;
using Model.Utilities;
using Project.Interfaces.Tasks;
using Project.Tasks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void Navigator_SelectCondEvent(int arg1)
        {
            try
            {
                var data = project.GetCondData(arg1);

                var _funcs = project.FunctionsDB.Keys.ToList();
                _funcs.Add("*");
                var _mats = project.MaterialsDB.Keys.ToList();

                var groups = project.GetAllModelGroups();

                List<RowProperty> rows;

                switch (data.Kind)
                {
                    case DataKind.Материал:
                        rows = GetMatProperty((MatData)data, _mats, groups, _funcs);
                        break;

                    case DataKind.Среда:
                        rows = GetMediaProperty((MediaData)data, groups, _funcs);
                        break;

                    case DataKind.Нагрев:
                        rows = GetCondProperty((HeatData)data, groups, _funcs);
                        break;

                    case DataKind.Закрепление:
                        rows = GetClampProperty((ClampData)data, groups, _funcs);
                        break;

                    case DataKind.Нагрузка:
                        rows = GetLoadProperty((LoadData)data, _funcs, groups);
                        break;

                    default:
                        throw new NotImplementedException(Resources.UndefinedConditionTypeExc);
                }

                propertiesPanel.DrawTable(rows);

                foreach (var item in project.GetAllModelSetsInfo()) // возврат цвета всем объектам, которые были выделены
                    item.SetBackColor();

                ColorObjects("Объекты"); // возврат цвета всем объектам уже на сцене

                /*
                 * TO DO в целях инкапсуляции: 
                 * Group.SetBackColor(Color color);
                 */
                
                foreach (var obj in data.Group) // закраска объектов в выделяемой группе
                    obj.Color = settingsConfig.SelectGroupColor;


                foreach (var set in data.Group.Select(x => project.
                GetModelSetInfo(x.ObjType, x.Number)).
                Distinct(new DefaultSetInfoComparer()))
                {
                    var pres = project.CreateModelObjectsPresentor(set);
                    SetVBObjectAttribute(pres, "цвет");
                }
                DisplayObjects();


                checkPlayerControl.StartValue = 0;
                checkPlayerControl.StopValue = (int)(data.StopTime - data.StartTime);

                DisplayObjects();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }
    }
}
