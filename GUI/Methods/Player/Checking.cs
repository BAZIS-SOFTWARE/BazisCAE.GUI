using BazisGUI.Extensions;
using BazisGUI.Navigator;
using BazisGUI.Properties;
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
        private void CheckPlayerControl_CheckingEvent(object arg1, int arg2)
        {
            try
            {
                var name = navigator.SelectedNode.Name;

                if (name.TryToEnum(out NodeName nodeName))
                {
                    if (nodeName == NodeName.Heat | 
                        nodeName == NodeName.Clamp |
                        nodeName == NodeName.Load |
                        nodeName == NodeName.Material |
                        nodeName == NodeName.Media )
                    {
                        DisplayGeometryObjectEvent = null;
                        DisplayText3DEvent = null;

                        var index = navigator.SelectedNode.Index;
                        var data = project.GetCondData(index);
                        var refTime = arg2 + data.StartTime;
                        if (refTime >= data.StartTime & refTime <= data.StopTime)
                        {
                            if (data.LocalFrame != null)
                                DisplayMRF(refTime, data);

                            var group = data.Group;

                            var lf = data.LocalFrame;

                            foreach (var iobj in group)
                            {
                                if(settingsConfig.CheckCondValue)
                                    if (data.Function != null)
                                    {
                                        //if (data.Function.FunctionType == Project.Tasks.Functions.FuncType.CPF)
                                        //{
                                            if (lf != null)
                                            {
                                                var pos = lf.Frame.GetCoordsInFrame(iobj.CalcCentr());
                                                data.Function["X"].SetValue(pos._x);
                                                data.Function["Y"].SetValue(pos._y);
                                                data.Function["Z"].SetValue(pos._z);

                                                var val = data.Value * data.Function.CalcValue();
                                                DisplayText3D(val.ToString(), Color.Black, iobj.CalcCentr());
                                            }
                                        //}
                                    }

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
                    else if (nodeName == NodeName.Result)
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
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void CheckPlayerControl_StopCheckingEvent(object obj)
        {
            DisplayGeometryObjectEvent = null;
            DisplayText3DEvent = null;
            SetBackColorToAllObjects();
            DisplayObjects();
        }

        private void CheckPlayerControl_StartCheckingEvent(object obj)
        {
            var name = navigator.SelectedNode.Name;

            var nodeName = name.ToEnum<NodeName>();

            if (nodeName != NodeName.Result &
                nodeName != NodeName.Material &
                    nodeName != NodeName.Media &
                    nodeName != NodeName.Heat &
                    nodeName != NodeName.Load &
                    nodeName != NodeName.Clamp
                    )
            {
                checkPlayerControl.Cancelation = true;
                console.PrintInfo(Resources.Checking_StartCheckingEvent_SelectedDataIsNotCheckable_Message, Color.Orange);
            }

        }
    }
}
