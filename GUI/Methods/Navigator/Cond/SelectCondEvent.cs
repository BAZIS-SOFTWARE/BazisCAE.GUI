using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using Model.Utilities;
using Project.Tasks;
using PropertiesCalculator.FunctionData;
using PropertiesCalculator.MaterialData;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_SelectCondEvent(NodeName arg1, string arg2)
        {
            try
            {
                var data = project.TaskData.First(x => x.ToString() == arg2);

                var _funcs = project.FunctionsDB.Keys.ToList();
                _funcs.Add("*");
                var _mats = project.MaterialsDB.Keys.ToList();

                var groups = project.GetAllModelGroups();

                List<RowProperty> rows;

                if (arg1 == NodeName.Материал)
                    rows = GetMatProperty((MatData)data, _mats, groups);
                else if (arg1 == NodeName.Среда)
                    rows = GetMediaProperty((MediaData)data, groups, _funcs);
                else if (arg1 == NodeName.Нагрев)
                    rows = GetHeatProperty((HeatData)data, groups, _funcs);
                else if (arg1 == NodeName.Закрепление)
                    rows = GetClampProperty((ClampData)data, groups);
                else if (arg1 == NodeName.Нагрузка)
                    rows = GetLoadProperty((LoadData)data, _funcs, groups);
                else throw new NotImplementedException("Вид условия не определен");


                //var _converter = DataConverter.CreateConverter(data, _funcDBNames, _matDBNames, allGroup);
        
                propertiesPanel.DrawTable(rows);

                //if (data.Direction != Direction.None)
                //    DisplayDirection(data.StartTime, data, data.Group);

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
