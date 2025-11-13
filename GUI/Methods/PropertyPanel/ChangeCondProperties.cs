using BaseModule.Extensions;
using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using Geometry;
using MathNet.Numerics.RootFinding;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using Project.Tasks;
using Project.Tasks.FrameCreators;
using Project.Tasks.Functions;
using Project.Tasks.Functions.Welding;
using PropertiesCalculator.FunctionData;
using PropertiesCalculator.MaterialData;
using System;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void ChangeGeneralProperties(PropertyChangedEventArgs obj, ICondData cond, ref bool refresh)
        {
            if (obj.Header.Contains("Группа"))
            {
                var group = project.GetAllModelGroups().First(x => x.Name == obj.NewValue);
                cond.Group = group;
            }
            else if (obj.Header == "Старт, сек.")
            {
                var newTime = float.Parse(obj.NewValue);
                newTime = (float)Math.Round(newTime, 2);

                var oldTime = float.Parse(obj.OldValue);
                oldTime = (float)Math.Round(oldTime, 2);

                var delta = newTime - oldTime;
                cond.StartTime = newTime;
                cond.StopTime += delta;
                refresh = true;
            }

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
                else
                    cond.FrameFunction = new CustomFunction();
                // TO DO добавить custom function
                refresh = true;
            }

            else if (obj.Header == "Система координат")
            {
                if (obj.NewValue == "SRF")
                    cond.FrameFunction.LocalFrame = new StaticFrame();
                else
                    cond.FrameFunction.LocalFrame = new MovedFrame();

                refresh = true;
            }

            else if (obj.Header == "Ширина, мм.")
            {
                var func = cond.FrameFunction as SphereFunction;
                func.Width = float.Parse(obj.NewValue);
            }
            else if (obj.Header == "Длина, мм." |
                obj.Header == "Верхний диам., мм." |
                obj.Header == "Нижний диам., мм.")
            {
                var func = cond.FrameFunction as CillindricalFunction;
                if (obj.Header == "Длина, мм.")
                    func.Length = float.Parse(obj.NewValue);
                else if (obj.Header == "Верхний диам., мм.")
                    func.UpperDiam = float.Parse(obj.NewValue);
                else if (obj.Header == "Нижний диам., мм.")
                    func.BottomDiam = float.Parse(obj.NewValue);
            }

            else if (obj.Header == "Плоскость" && cond.FrameFunction.LocalFrame is StaticFrame srf)
            {
                var group = project.GetAllModelGroups().First(x => x.Name == obj.NewValue);
                srf.BaseGroup = group;
            }

            else if (obj.Header == "Траектория")
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

                // добавим корректировку времени остановки, если изменена скорость
                var time = mrf.CalcMotionTime();
                
                cond.StopTime = cond.StartTime + (float)Math.Round(time, 2);
                refresh = true;
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

        private void ChangeClampProperties(PropertyChangedEventArgs obj, ClampData clampCond, ref bool flag)
        {

            ChangeGeneralProperties(obj, clampCond, ref flag);

            if (obj.Header == "Вид")
                clampCond.TrySetKind(obj.NewValue.ToString());
            else if (obj.Header == "Направление")
                clampCond.Direction = obj.NewValue.ToEnum<Direction>();
        }

        private void ChangeMatProperties(PropertyChangedEventArgs obj, MatData matCond, ref bool flag)
        {
            ChangeGeneralProperties(obj, matCond, ref flag);

            if (obj.Header == "Материал")
                matCond.Material = project.MaterialsDB[obj.NewValue.ToString()];
            // TO DO дописать метод, так чтобы изменялись все свойства
        }

        private void ChangeHeatProperties(PropertyChangedEventArgs obj, HeatData heatCond, ref bool flag)
        {
            //Мощность, Дж
            ChangeGeneralProperties(obj, heatCond, ref flag);
            if (obj.Header == "Мощность, Дж")
                heatCond.Heat = float.Parse(obj.NewValue);
            else if (obj.Header == "Функция, F(t), F - Дж.")
                heatCond.TimeFunction = project.FunctionsDB[obj.NewValue];
        }

        private void ChangeLoadProperties(PropertyChangedEventArgs obj, LoadData loadData, ref bool flag)
        {
            ChangeGeneralProperties(obj, loadData, ref flag);
            if (obj.Header == "Направление")
                loadData.Direction = obj.NewValue.ToEnum<Direction>();
            else if (obj.Header == "Величина, Н")
                loadData.Value = float.Parse(obj.NewValue);
            else if (obj.Header == "Функция, F(t), F - Н.")
                loadData.TimeFunction = project.FunctionsDB[obj.NewValue];

            else if (obj.Header == "Вид")
                loadData.LoadKind = obj.NewValue.ToEnum<LoadKind>();
        }

        private void ChangeMediaProperties(PropertyChangedEventArgs obj, MediaData mediaData, ref bool flag)
        {
            ChangeGeneralProperties(obj, mediaData, ref flag);

            if (obj.Header == "Функция, F(t), F - Дж./мм.^2")
            {
                mediaData.HeatExchangeFunc = 
                    obj.NewValue == "*" ?  null : project.FunctionsDB[obj.NewValue];
                flag = true;
            }

            else if (obj.Header == "Коэф. теплоотдачи")
            {
                mediaData.HeatExchangeValue = float.Parse(obj.NewValue);
                flag = true;
            }
                
            else if (obj.Header == "Температура среды")
                mediaData.TemperatureValue = float.Parse(obj.NewValue);
            else if (obj.Header == "Функция, F(t), F - Град.")
            {
                mediaData.TemperatureFunc =
                    obj.NewValue == "*" ? null : project.FunctionsDB[obj.NewValue];
                flag = true;
            }
        }
    }
}
