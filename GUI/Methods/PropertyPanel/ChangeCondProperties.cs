using BazisGUI.Extensions;
using BazisGUI.PropertiesPanel;
using Project.Interfaces.Tasks;
using Project.Tasks;
using Project.Tasks.FrameCreators;
using Project.Tasks.Functions;
using Project.Tasks.Functions.FrameFunctions;
using Project.Tasks.Materials;
using System;
using System.Linq;

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

            else if (obj.Header.Contains("Функция"))
            {
                if (obj.NewValue == "*")
                    cond.Function = null;
                else if (obj.NewValue == "SPH")
                    cond.Function = new SPH();
                else if (obj.NewValue == "CIL")
                    cond.Function = new CIL();
                else if (obj.NewValue == "FHEX")
                    cond.Function = new FHEX();
                else if (obj.NewValue == "DHEX")
                    cond.Function = new DHEX();
                else if (obj.NewValue == "TT")
                    cond.Function = new TT();
                else if (obj.NewValue == "PT")
                    cond.Function = new PT();
                else
                    cond.Function = new CustomFrameFunction();
                
                // TO DO добавить диалоговое окно выбора файла функции

                refresh = true;
            }

            else if (obj.Header.Contains("Параметр"))
            {
                var ar = obj.Header.Split(" ");

                if (obj.NewValue == "Constant")
                    cond.Function[ar[1]] = new Parameter(ar[1], ParameterType.Constant, 0);
                else if (obj.NewValue == "Table")
                    cond.Function[ar[1]] = new TableParameter(project.FunctionsDB.First().Value,
                        ar[1],
                        cond.Function.GetParameters().
                        First(x => x.ParameterType == ParameterType.Variable));
                else
                    cond.Function[ar[1]].SetValue(double.Parse(obj.NewValue));
                refresh = true;
            }
            // подумать про регулярные выражения для поиска
            else if (obj.Header.Contains("Таблица"))
            {
                var ar = obj.Header.Split(" ");

                var tableParam = cond.Function.GetTableParameters().
                    First(x => x.Table.Name == ar[1]);
                var setParam = cond.Function.GetParameters().First(x => x.Name == obj.NewValue);

                if(setParam.Name != tableParam.Name)
                    tableParam.Parameter = setParam;
                
                refresh = true;
            }

            else if (obj.Header == "Система координат")
            {
                if (obj.NewValue == "SRF")
                    cond.LocalFrame = new StaticFrame();
                else if (obj.NewValue == "MRF")
                    cond.LocalFrame = new MovedFrame();
                else
                    cond.LocalFrame = null;

                refresh = true;
            }

            else if (obj.Header == "Файл")
            {
                var cf = cond.Function as CustomFrameFunction;
                cf.CreateEngine(obj.NewValue);
            }

            else if (obj.Header == "Плоскость" && cond.LocalFrame is StaticFrame srf)
            {
                var group = project.GetAllModelGroups().First(x => x.Name == obj.NewValue);
                srf.BaseGroup = group;
            }

            else if (obj.Header == "Траектория")
            {
                var mrf = cond.LocalFrame as MovedFrame;
                var group = project.GetAllModelGroups().First(x => x.Name == obj.NewValue);
                mrf.BaseLine = group;
            }
            else if (obj.Header == "Опорная линия")
            {
                var mrf = cond.LocalFrame as MovedFrame;
                var group = project.GetAllModelGroups().First(x => x.Name == obj.NewValue);
                mrf.RefLine = group;
            }
            else if (obj.Header == "Скорость, мм./сек.")
            {
                var mrf = cond.LocalFrame as MovedFrame;
                mrf.Velocity = float.Parse(obj.NewValue);

                // добавим корректировку времени остановки, если изменена скорость
                var time = mrf.CalcMotionTime();
                
                cond.StopTime = cond.StartTime + (float)Math.Round(time, 2);
                refresh = true;
            }

            else if (obj.Header == "Смещение x")
                cond.LocalFrame.Shifting._x = float.Parse(obj.NewValue);
            else if (obj.Header == "Смещение y")
                cond.LocalFrame.Shifting._y = float.Parse(obj.NewValue);
            else if (obj.Header == "Смещение z")
                cond.LocalFrame.Shifting._z = float.Parse(obj.NewValue);
            else if (obj.Header == "Поворот x")
                cond.LocalFrame.Rotation_X = float.Parse(obj.NewValue);
            else if (obj.Header == "Поворот y")
                cond.LocalFrame.Rotation_Y = float.Parse(obj.NewValue);
            else if (obj.Header == "Поворот z")
                cond.LocalFrame.Rotation_Z = float.Parse(obj.NewValue);
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
            else if (obj.Header == "Диаметр")
                (matCond as BeamMatData).Diameter = double.Parse(obj.NewValue);
            else if (obj.Header == "Толщина")
                (matCond as PlateMatData).Thickness = double.Parse(obj.NewValue);
            // TO DO дописать метод, так чтобы изменялись все свойства
        }

        private void ChangeHeatProperties(PropertyChangedEventArgs obj, HeatData heatCond, ref bool flag)
        {
            //Мощность, Дж
            ChangeGeneralProperties(obj, heatCond, ref flag);
            if (obj.Header == "Мощность, Дж")
                heatCond.Value = float.Parse(obj.NewValue);
            //else if (obj.Header == "Функция, F(t), F - Дж.")
            //    heatCond.TimeFunction = project.FunctionsDB[obj.NewValue];
        }

        private void ChangeLoadProperties(PropertyChangedEventArgs obj, LoadData loadData, ref bool flag)
        {
            ChangeGeneralProperties(obj, loadData, ref flag);
            if (obj.Header == "Направление")
                loadData.Direction = obj.NewValue.ToEnum<Direction>();
            else if (obj.Header == "Величина, Н")
                loadData.Value = float.Parse(obj.NewValue);
            //else if (obj.Header == "Функция, F(t), F - Н.")
            //    loadData.TimeFunction = project.FunctionsDB[obj.NewValue];

            else if (obj.Header == "Вид")
                loadData.LoadKind = obj.NewValue.ToEnum<LoadKind>();
        }

        private void ChangeMediaProperties(PropertyChangedEventArgs obj, MediaData mediaData, ref bool flag)
        {
            ChangeGeneralProperties(obj, mediaData, ref flag);
        }
    }
}
