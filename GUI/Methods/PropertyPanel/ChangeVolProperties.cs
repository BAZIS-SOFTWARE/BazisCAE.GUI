using BaseModule.Extensions;
using BaseModule.PropertiesPanel;
using GmshApi;
using Model.GeometryObjects;
using OperationalController;
using OperationalController.GmshController;
using Project.Interfaces.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void ChangeVolProperty(PropertyChangedEventArgs obj, int number, ref bool flag)
        {
            // Тут задаем настройки сетки в объемах геометрии

            if (obj.Header == "Вид сетки")
            {
                flag = true;
                if (obj.NewValue == "регулярная")
                {
    //                GmshController.Gmsh.Model.SetAttribute($"transfinite vol {number}",
    //new string[] { obj.NewValue });

                    // применить трансфиницию объема
                    //GmshController.Gmsh.Model.Mesh.SetTransfiniteVolume(number);
                    GmshController.SetTransfiniteVolume(number);
                }    

                else if (obj.NewValue == "градиентная")
                {
                    GmshController.SetGradientVolume(number, 1, 1, 1, 10);
                    //var attributes = new string[] { obj.NewValue, "1", "1", "1", "10" };
                    //GmshController.Gmsh.Model.
                    //    SetAttribute($"transfinite vol {number}", attributes);
                    //SetMeshGradientSettings(attributes, number);
                }
                else
                {
                    // тут спросить у Николая достаточно ли одной команды для снятия транфиниции объема?
                    GmshController.Gmsh.Model.Mesh.RemoveConstraints(new int[] { 3, number });
                    //удаляем запись из словаря атрибутов
                    GmshController.Gmsh.Model.RemoveAttribute($"transfinite vol {number}");
                    // удаление фильтра градиентной сетки
                    DelMeshGradientSettings(number);
                }
            }
            else
            {
                var attributes = GmshController.GetTransfiniteVolume(number);
                //var attributes = GmshController.Gmsh.Model.GetAttribute($"transfinite vol {number}");

                if (obj.Header == "Степень градиента перехода")
                    attributes[1] = obj.NewValue;

                else if (obj.Header == "Толщина слоя")
                    attributes[2] = obj.NewValue;

                else if (obj.Header == "Размер элементов на поверхности")
                    attributes[3] = obj.NewValue;

                else if (obj.Header == "Размер элементов в центре")
                    attributes[4] = obj.NewValue;
                //SetMeshGradientSettings(attributes, number);
                //GmshController.Gmsh.Model.
                //SetAttribute($"transfinite vol {number}", attributes);
                var power = double.Parse(attributes[1]);
                var distMax = double.Parse(attributes[2]);
                var surfSize = double.Parse(attributes[3]);
                var coreSize = double.Parse(attributes[4]);

                GmshController.SetGradientVolume(number, power, distMax, surfSize, coreSize);
            }

             
        }

        private void DelMeshGradientSettings(int number)
        {
            //var list = gmshController.Gmsh.Model.Mesh.Field.List();
            //var index = Array.IndexOf(list, number);
            GmshController.Gmsh.Model.Mesh.Field.Remove(number);

            // TODO переписать так чтобы снимались ограничения только с узлов объема
            var points = GmshController.Gmsh.Model.GetEntities(0);
            GmshController.Gmsh.Model.Mesh.RemoveConstraints(points);
            GmshController.Gmsh.Option.SetNumber("Mesh.MeshSizeExtendFromBoundary", 1);
        }


    //    private void SetMeshGradientSettings(string[] arguments, int number)
    //    {
    //        var list = GmshController.Gmsh.Model.Mesh.Field.List();

    //        if (!list.Contains(number))
    //            GmshController.Gmsh.Model.Mesh.Field.Add(FieldType.Extend, number);

    //        var vol = project.GetModelVolumes().First(x => x.Number == number);

    //        var curveTags = new List<double>();
    //        var surfTags = vol.GetSurfaceFigures().Select(x => (double)x.Number);

    //        foreach (var item in vol.GetSurfaceFigures())
    //        {
    //            curveTags.AddRange(item.CurveNumbers.Select(x => (double)x));
    //            foreach (var crvNumb in item.CurveNumbers)
    //            {
    //                var curve = (Curve)project.GetModelObject(Model.Interfaces.ObjType.Кривая, crvNumb);
    //                foreach (var pointNumb in curve.PointsNumbers)
    //                    GmshController.Gmsh.Model.Mesh.
    //SetSize(new int[] { 0, pointNumb }, double.Parse(arguments[3]));

    //            }
    //        }
    //        var distCurveTags = curveTags.Distinct();
    //        // тут в linq добавляем индексацию v - значение, i - индекс
    //        //var curveTags = curves.Where((v, i) => (i & 1) != 0)
    //        //                      .Select(v => (double)v).ToArray();
    //        //var surfTags = surfaces.Where((v, i) => (i & 1) != 0)
    //        //                       .Select(v => (double)v).ToArray();

    //        GmshController.Gmsh.Model.Mesh.Field.SetNumbers(number, ExtendOptions.CurvesList.ToString(), distCurveTags.ToArray());
    //        GmshController.Gmsh.Model.Mesh.Field.SetNumbers(number, ExtendOptions.SurfacesList.ToString(), surfTags.ToArray());
    //        GmshController.Gmsh.Model.Mesh.Field.SetNumber(number, ExtendOptions.Power.ToString(), double.Parse(arguments[1]));
    //        GmshController.Gmsh.Model.Mesh.Field.SetNumber(number, ExtendOptions.DistMax.ToString(), double.Parse(arguments[2]));
    //        GmshController.Gmsh.Model.Mesh.Field.SetNumber(number, ExtendOptions.SizeMax.ToString(), double.Parse(arguments[4]));
    //        GmshController.Gmsh.Model.Mesh.Field.SetAsBackgroundMesh(number);
    //        GmshController.Gmsh.Option.SetNumber("Mesh.MeshSizeExtendFromBoundary", -2);

    //    }
    }
}
