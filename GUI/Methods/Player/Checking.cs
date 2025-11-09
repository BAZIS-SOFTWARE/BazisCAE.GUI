using BaseModule.Extensions;
using BazisGUI.Navigator;
using Project.Interfaces.Tasks;
using ResultDB.IO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void checkPlayerControl_CheckingEvent(object arg1, int arg2)
        {
            try
            {
                var name = navigator.SelectedNode.Name;

                if (name.TryToEnum(out DataKind dataKind))
                {
                    DisplayGeometryObjectEvent = null;

                    var index = navigator.SelectedNode.Index;
                    var data = project.TaskData[index];
                    var refTime = arg2 + data.StartTime;
                    if (refTime >= data.StartTime & refTime <= data.StopTime)
                    {
                        if (data.FrameFunction != null)
                            DisplayMRF(refTime, data);

                        var group = data.Group;

                        foreach (var iobj in group)
                        {
                            if (data.Kind == DataKind.Материал)
                                iobj.Color = Color.FromArgb(255, 255, 0);
                            else if (data.Kind == DataKind.Среда)
                                iobj.Color = Color.FromArgb(255, 155, 0);
                            else if (data.Kind == DataKind.Закрепление | data.Kind == DataKind.Нагрузка)
                                iobj.Color = Color.FromArgb(255, 0, 0);
                            else if (data.Kind == DataKind.Нагрев)
                                iobj.Color = Color.FromArgb(125, 155, 255, 0);

                            //PresentProjectTaskDataOnScene(arg2.Time, data, modelObj);
                        }
                        if (data.Direction != Direction.None)
                            DisplayDirection(arg2, data, group);
                        var pres = project.CreateModelObjectsPresentor(group.ObjType);
                        SetVBObjectAttribute(pres, "цвет");

                        DisplayObjects();
                    }
                }

                else if (name.TryToEnum(out NodeName result))
                {
                    var loader = new LoadResultsFileDB();

                    var times = resultTimes.ToArray();
                    var tables = new List<string>()
                    {
                        ResultType.nodes.ToString(),
                        ResultType.elements.ToString()
                    };
                    var resName = navigator.SelectedNode.Text;
                    
                    var res = loader.GetResult(ResultDbPath, tables, times[arg2]);
                    ShowResults(res, resName);
                }
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void checkPlayerControl_StopCheckingEvent(object obj)
        {
            DisplayGeometryObjectEvent = null;
            DisplayText3DEvent = null;
            SetBackColorToAllObjects();
            DisplayObjects();
        }

        private void checkPlayerControl_StartCheckingEvent(object obj)
        {
            var name = navigator.SelectedNode.Name;

            var nodeName = name.ToEnum<NodeName>();

            if (nodeName != NodeName.результат &
                nodeName != NodeName.материал &
                    nodeName != NodeName.среда &
                    nodeName != NodeName.нагрев &
                    nodeName != NodeName.нагрузка &
                    nodeName != NodeName.закрепление
                    )
            {
                checkPlayerControl.Cancelation = true;
                console.PrintInfo("Выбранные данные не проверяются", Color.Orange);
            }

        }
    }
}
