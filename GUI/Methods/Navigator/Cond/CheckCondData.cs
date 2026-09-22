
using BazisGUI.Utilities;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using Project.Tasks.LocalFrames;
using System;
using System.Drawing;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public void navigator_CheckConditionsEvent(ITaskData taskData, IModelData modelData, CheckDataEventArgs arg2)
        {
            try
            {
                DisplayGeometryObjectEvent = null;
                var dataKind = Converters.ConvertToDataKind(arg2.DataName);
                var selectedData = taskData.Find(dataKind);

                foreach (var data in selectedData)
                {
                    if (arg2.Time >= data.StartTime & arg2.Time <= data.StopTime)
                    {
                        if (data.LocalFrame != null)
                            DisplayMRF(arg2.Time, data);

                        var group = data.Group;

                        var lf = data.LocalFrame;

                        foreach (var iobj in group)
                        {
                            if(data.Function != null)
                            {
                                if (data.Function.FunctionType == Project.Tasks.Functions.FuncType.CPF)
                                {
                                    if (lf != null)
                                    {
                                        var pos = lf.Frame.GetCoordsInFrame(iobj.CalcCentr());
                                        data.Function["X"].SetValue(pos._x);
                                        data.Function["Y"].SetValue(pos._y);
                                        data.Function["Z"].SetValue(pos._z);

                                        var val = data.Function.CalcValue();
                                        DisplayText3D(val.ToString(),Color.Black, iobj.CalcCentr());
                                    }
                                }
                            }

                            //PresentProjectTaskDataOnScene(arg2.Time, data, modelObj);
                        }
                        if (data.Direction != Direction.None)
                            DisplayDirection(arg2.Time, data, group);
                        project.ModelView.SelectionColor = GetConditionColor(data.Kind);
                        project.ModelView.SetSelection(group.ObjType, group.Select(x => x.Number));
                    }
                }
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
    }
}
