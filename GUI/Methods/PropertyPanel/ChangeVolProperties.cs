using BaseModule.Extensions;
using BaseModule.PropertiesPanel;
using GmshApi;
using Model.GeometryObjects;
using Project.Interfaces.Tasks;
using System;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void ChangeVolProperty(PropertyChangedEventArgs obj, int number)
        {
            // Тут задаем настройки сетки в объемах геометрии
            var vol = project.GetModelVolumes().First(x => x.Number == number);

            if (obj.Header == "Степень градиента перехода")
                vol.GradientMeshPower = double.Parse(obj.NewValue);
            else if (obj.Header == "Толщина слоя")
                vol.LayerThickness = double.Parse(obj.NewValue);
            else if (obj.Header == "Размер элементов на поверхности")
                vol.SurfaceMeshSize = double.Parse(obj.NewValue);
            else if (obj.Header == "Размер элементов в центре")
                vol.CoreMeshSize = double.Parse(obj.NewValue);
            else if (obj.Header == "Применить")
            {
                vol.IsFieldUsed = bool.Parse(obj.NewValue);

                if (vol.IsFieldUsed)
                    SetMeshGradientSettings(vol);
                else
                    DelMeshGradientSettings(vol);
            }
                 
        }

        private void DelMeshGradientSettings(VolumeFigure arg1)
        {
            // TODO тут подумать как связать с номерами объемов
            var list = gmshController.Gmsh.Model.Mesh.Field.List();

            var index = Array.IndexOf(list,arg1.Number);

            gmshController.Gmsh.Model.Mesh.Field.Remove(index);
            var points = gmshController.Gmsh.Model.GetEntities(0);
            gmshController.Gmsh.Model.Mesh.RemoveConstraints(points);
            gmshController.Gmsh.Option.SetNumber("Mesh.MeshSizeExtendFromBoundary", 1);
        }


        private void SetMeshGradientSettings(VolumeFigure arg2)
        {
            var selectedNode = navigator.SelectedNode;
            gmshController.Gmsh.Model.Mesh.Field.Add(FieldType.Extend,arg2.Number);

            var list = gmshController.Gmsh.Model.Mesh.Field.List();
            if (list.Length != 0)
            {
                var field = list.First();
                var points = gmshController.Gmsh.Model.GetEntities(0);
                var curves = gmshController.Gmsh.Model.GetEntities(1);
                var surfaces = gmshController.Gmsh.Model.GetEntities(2);
                var curveTags = curves.Where((v, i) => (i & 1) != 0)
                                      .Select(v => (double)v).ToArray();
                var surfTags = surfaces.Where((v, i) => (i & 1) != 0)
                                       .Select(v => (double)v).ToArray();
                gmshController.Gmsh.Model.Mesh.SetSize(points, arg2.SurfaceMeshSize);
                gmshController.Gmsh.Model.Mesh.Field.SetNumbers(field, ExtendOptions.CurvesList.ToString(), curveTags);
                gmshController.Gmsh.Model.Mesh.Field.SetNumbers(field, ExtendOptions.SurfacesList.ToString(), surfTags);
                gmshController.Gmsh.Model.Mesh.Field.SetNumber(field, ExtendOptions.Power.ToString(), arg2.GradientMeshPower);
                gmshController.Gmsh.Model.Mesh.Field.SetNumber(field, ExtendOptions.DistMax.ToString(), arg2.LayerThickness);
                gmshController.Gmsh.Model.Mesh.Field.SetNumber(field, ExtendOptions.SizeMax.ToString(), arg2.CoreMeshSize);
                gmshController.Gmsh.Model.Mesh.Field.SetAsBackgroundMesh(field);
                gmshController.Gmsh.Option.SetNumber("Mesh.MeshSizeExtendFromBoundary", -2);
            }
        }
    }
}
