using BaseModule.PropertiesPanel;
using Geometry;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using Project.Tasks;
using Project.Tasks.FrameCreators;
using Project.Tasks.Functions.Welding;
using PropertiesCalculator.FunctionData;
using PropertiesCalculator.MaterialData;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void ChangeGeneralProperties(PropertyChangedEventArgs obj, ICondData cond)
        {
            if (obj.Header.Contains("Группа"))
            {
                var group = project.GetAllModelGroups().First(x => x.Name == obj.NewValue);
                cond.Group = group;
            }
            else if (obj.Header == "Старт, сек.") 
                cond.StartTime = float.Parse(obj.NewValue);
            else if (obj.Header == "Стоп, сек.") 
                cond.StopTime = float.Parse(obj.NewValue);

            else if (obj.Header.Contains("Функция, F(v(x,y,z))"))
            {
                if (obj.NewValue == "*")
                    cond.FrameFunction = null;
                else if (obj.NewValue == "SPH")
                    cond.FrameFunction = new SphereFunction();
                else if (obj.NewValue == "CIL")
                    cond.FrameFunction = new CillindricalFunction();
                // TO DO добавить custom function
            }

            else if(obj.Header == "Система координат")
            {
                if (obj.NewValue == "SRF")
                    cond.FrameFunction.LocalFrame = new StaticFrame();
                else
                    cond.FrameFunction.LocalFrame = new MovedFrame();
            }       

            else if (obj.Header == "Плоскость" && cond.FrameFunction.LocalFrame is StaticFrame srf)
            {
                var group = project.GetAllModelGroups().First(x => x.Name == obj.NewValue);
                srf.BaseGroup = group;
            }

            else if(obj.Header == "Траектория")
            {
                var mrf = cond.FrameFunction.LocalFrame as MovedFrame;
                var group = project.GetAllModelGroups().First(x => x.Name == obj.NewValue);
                mrf.BaseLine = group;
            }
            else if (obj.Header == "Опорная линия")
            {
                var mrf = cond.FrameFunction.LocalFrame as MovedFrame;
                var group = project.GetAllModelGroups().First(x => x.Name == obj.NewValue);
                mrf.RefLine = group;
            }
            else if (obj.Header == "Скорость, мм./сек.")
            {
                var mrf = cond.FrameFunction.LocalFrame as MovedFrame;
                mrf.Velocity = float.Parse(obj.NewValue);
            }

            else if (obj.Header == "Смещение x")
                cond.FrameFunction.LocalFrame.Shifting._x = float.Parse(obj.NewValue);
            else if (obj.Header == "Смещение y")
                cond.FrameFunction.LocalFrame.Shifting._y = float.Parse(obj.NewValue);
            else if (obj.Header == "Смещение z")
                cond.FrameFunction.LocalFrame.Shifting._z = float.Parse(obj.NewValue);
            else if (obj.Header == "Поворот x")
                cond.FrameFunction.LocalFrame.Rotation = float.Parse(obj.NewValue);
        }

        private void ChangeMatProperties(PropertyChangedEventArgs obj, MatData matCond)
        {
            ChangeGeneralProperties(obj, matCond);
            if (obj.Header == "Материал")
            {
                matCond.Material = project.MaterialsDB[obj.NewValue.ToString()];
            }  
        }

        private void ChangeHeatProperties(PropertyChangedEventArgs obj, HeatData heatCond)
        {
            //Мощность, Дж
            ChangeGeneralProperties(obj, heatCond);
            if (obj.Header == "Мощность, Дж")
            {
                heatCond.Heat = float.Parse(obj.NewValue);
            }
        }
    }
}
