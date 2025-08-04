using BaseModule.Extensions;
using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BaseModule.Tasks.BasicAdvisorControls.Events;
using BazisGUI.PropertiesPanel.Control;
using BazisGUI.PropertiesPanel.Control.TaskType;
using BazisGUI.Utilities;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using Project.Tasks;
using PropertiesCalculator.FunctionData;
using PropertiesCalculator.MaterialData;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Resources.ResXFileRef;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_SelectCondEvent(NodeName arg1, string arg2)
        {
            try
            {
                var data = project.TaskData.First(x => x.ToString() == arg2);

                var _funcs =
                    GetDataBase<FunctionDBData>(project.FunctionsDB, project.Path).Keys.ToList();
                var _mats =
                GetDataBase<MaterialDBData>(project.MaterialsDB, project.Path).Keys.ToList();

                DataConverter _converter;

                var groups = project.GetAllModelGroups().Where(x => x.ObjType == data.Group.ObjType).ToList();

                if (arg1 == NodeName.Материал) 
                    _converter = new MatTaskConverter((MatData)data, _mats, groups);
                else if (arg1 == NodeName.Среда) _converter = new EnvironmentTaskConverter((MediaData)data, groups, _funcs);
                else if (arg1 == NodeName.Нагрев) _converter = new HeatTaskConverter((HeatData)data, groups, _funcs);
                else if (arg1 == NodeName.Закрепление) _converter = new ClampTaskConverter((ClampData)data, groups);
                else if (arg1 == NodeName.Нагрузка) _converter = new LoadTaskConverter((LoadData)data, _funcs, groups);
                else throw new NotImplementedException("Тип задачи не определен");


                //var _converter = DataConverter.CreateConverter(data, _funcDBNames, _matDBNames, allGroup);
                var rows = _converter.GetRowProperty();
                propertiesPanel.DrawTable(rows);

                //if (data.Direction != Direction.None)
                //    DisplayDirection(data.StartTime, data, data.Group);

                project.SetModelObjectsBackColor(data.Group.ObjType);
                var pres = project.CreateModelObjectsPresentor(data.Group.ObjType);

                SetVBObjectAttribute(pres, "цвет");

                foreach (var iobj in data.Group)
                    iobj.Color = settingsConfig.SelectGroupColor;

                pres = project.CreateModelObjectsPresentor(data.Group.ObjType);
                SetVBObjectAttribute(pres, "цвет");


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
