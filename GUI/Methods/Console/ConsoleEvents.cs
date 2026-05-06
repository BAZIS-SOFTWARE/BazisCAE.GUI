using BazisGUI.Console;
using BazisGUI.Extensions;
using BazisGUI.Properties;
using Geometry;
using Model.Interfaces;
using Model.Interfaces.MeshObjects;
using Model.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void CreateMesh2DPoligon(string v1, string v2, string v3, string v4, string numberOfElems)
        {
            var c1 = v1.Split(',').Select(x => float.Parse(x)).ToArray();
            var p1 = new Point2D(c1[0], c1[1]);
            var c2 = v2.Split(',').Select(x => float.Parse(x)).ToArray();
            var p2 = new Point2D(c2[0], c2[1]);
            var c3 = v3.Split(',').Select(x => float.Parse(x)).ToArray();
            var p3 = new Point2D(c3[0], c3[1]);
            var c4 = v4.Split(',').Select(x => float.Parse(x)).ToArray();
            var p4 = new Point2D(c4[0], c4[1]);
            var numberOfElemsInt = int.Parse(numberOfElems);

            project.CreateQuadMeshOnPoligon(new List<Point2D>() { p1, p2, p3, p4 }, numberOfElemsInt);
            PresentMeshData();
            PresentModelObjectsForSelection();

            var set = project.GetModelSetsInfo(ObjType.Элемент2D).Last();
            var pres = project.CreateModelObjectsPresentor(set);
            var vbo = CreateVBObject(pres);

            VBOController.AddVbo(vbo);
            DisplayObjects();
        }

        private async void FindObject(string str)
        {
            if (!Enum.TryParse(str.Split(',')[0].Replace(" ", ""), out ObjType objType))
                throw new Exception(Resources.UnknownTypeException);

            if (!uint.TryParse(str.Split(',')[1].Replace(" ", ""), out uint number))
                throw new Exception(Resources.PositiveCellingNumberException);

            Invoke(new Action(() =>
            {
                var obj = project.GetAllModelObjects().
                FirstOrDefault(x => x.ObjType == objType & x.Number == number);

                if (obj != null)
                {
                    foreach (var item in project.GetModelSetsInfo(objType))
                        item.SetViewState(false);
                    obj.ViewState = true;

                    var set = project.GetModelSetInfo(objType, ((int)number));
                    var pres = project.CreateModelObjectsPresentor(set);
                    var vbo = CreateVBObject(pres);

                    ClearAllDataOnScene();

                    VBOController.AddVbo(vbo);
                    DisplayObjects();
                }
                else
                    console.PrintInfo(Resources.ConsoleEvents_ConsoleInEvent_ObjectNotFound_Message, Color.Orange);
            }));
        }

        private void FindVolElems(string v)
        {
            if (!double.TryParse(v, out double volume))
                throw new ArgumentException(Resources.InvalidArgumentsNumberException, nameof(v));


            var e3ds = project.GetAllModelElements().
                        Where(x => x.ObjType == ObjType.Элемент3D).
                        Select(x => (IElement3D)x);

            var findElmems = e3ds.Where(
                e3d => e3d.CalcVolume() < volume);

            if (findElmems.Count() > 0)
            {
                // TO DO потом можно поискать способ более быстрый и
                // технологичный для отображения найденных элементов
                foreach (var item in findElmems)
                    item.Color = settingsConfig.SelectObjectColor;

                foreach (var set in findElmems.Select(x => project.
                GetModelSetInfo(x.ObjType, x.Number)).
                Distinct(new DefaultSetInfoComparer()))
                {
                    var pres = project.CreateModelObjectsPresentor(set);
                    SetVBObjectAttribute(pres, "цвет");
                }
                DisplayObjects();
            }
            Invoke(new Action(() => { console.PrintInfo($"{Resources.ConsoleEvents_ConsoleInEvent_ObjectFound_Message} {findElmems.Count()} {Resources.ConsoleEvents_ConsoleInEvents_VolumeElements_Message}", Color.Black); }));
        }

        private void SetLevel(string objTypeStr, string levelStr)
        {
            var objType = objTypeStr.ToEnum<ObjType>();
            var level = int.Parse(levelStr);
            foreach (var item in project.GetAllModelElements().Where(x => x.ObjType == objType))
                item.Level = level;
        }

        private void console_RenumberMeshEvent(string cmd)
        {
            if (!Enum.TryParse(cmd.Split(':')[0], out ObjType objType))
                throw new Exception(Resources.UnknownTypeException);

            if (!uint.TryParse(cmd.Split(':')[1], out uint number))
                throw new Exception(Resources.PositiveCellingNumberException);

            //project.Renumber(project.ModelData.ObjectData, objType);
        }

        private void console_ModelShiftCoordinateEvent(string vector)
        {

            var strAr = vector.Split(',');

            if (strAr.Length < 3)
                throw new Exception(Resources.ModelShiftCoordinateEventArgsVectorExc);
            var x = float.Parse(strAr[0], NumberStyles.Float, CultureInfo.InvariantCulture);
            var y = float.Parse(strAr[1], NumberStyles.Float, CultureInfo.InvariantCulture);
            var z = float.Parse(strAr[2], NumberStyles.Float, CultureInfo.InvariantCulture);
            project.MoveMesh(ObjType.Узел, new Point3D(x, y, z));

            DisplayGeometryObjectEvent = null;
            DisplayText2DEvent = null;

            foreach (var set in project.GetAllModelSetsInfo())
            {
                var pres = project.CreateModelObjectsPresentor(set);
                SetVBObjectAttribute(pres, "координаты");
            }

            DisplayObjects();
        }

        private void console_ModelRotateEvent(string v)
        {
            var strAr = v.Split(':');

            if (strAr.Length < 2)
                throw new Exception(Resources.InvalidCommandException);

            var coords = strAr[0].Split(',');

            if (coords.Length < 3)
                throw new Exception(Resources.InvalidCoordinatesException);

            var x = float.Parse(coords[0].Replace(" ", ""), NumberStyles.Float);
            var y = float.Parse(coords[1].Replace(" ", ""), NumberStyles.Float);
            var z = float.Parse(coords[2].Replace(" ", ""), NumberStyles.Float);

            var angle = float.Parse(strAr[1].Replace(" ", ""), NumberStyles.Float);
            var point = new Point3D(x,y,z);

            project.RotateMesh(ObjType.Узел, point, angle);

            DisplayGeometryObjectEvent = null;
            DisplayText2DEvent = null;
            DisplayText3DEvent = null;

            foreach (ObjType item in Enum.GetValues(typeof(ObjType)))
            {
                var pres = project.CreateModelObjectsPresentor(item);
                SetVBObjectAttribute(pres, "координаты");
            }
            DisplayObjects();
        }
    }
}
