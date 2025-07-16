using BaseModule.Mesh;
using BaseModule.Mesh.SettingsControls;
using GmshApi;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void propertiesPanel_OnPropertyUpdate(BaseModule.PropertiesPanel.PropertyChangedEventArgs obj)
        {
            // В зависимости от свойства данных проекта (modelData, TaskData etc
            // вызывать нужный метод в controller
            panelProvider.UpdateObjectValue(obj.Header, obj.NewValue.ToString(), obj.OldValue.ToString());

            // TO DO оптимизировать. Обновлять на дереве только те данные, которые на самом деле изменились
            PresentTaskTypeAndKind();
            PresentObjectsDataOnTree(project.ModelData.ObjectData);
            PresentGroupDataOnTree(project.ModelData.GroupData);

            //if (obj is TaskPage taskPage)
            PresentCondDataOnTree(project.TaskData);

        }

        private void SetCurveAttributeEvent(object arg1, CurveAttribsEventArgs arg2)
        {
            gmshController.Gmsh.Model.SetAttribute($"transfinite {arg2.Tag}", arg2.Attributes);
            if (!string.IsNullOrEmpty(arg2.Attributes[0]) && !string.IsNullOrEmpty(arg2.Attributes[2]))
            {
                MeshType meshtType = (MeshType)Enum.Parse(typeof(MeshType), arg2.Attributes[1], true);
                gmshController.Gmsh.Model.Mesh.SetTransfiniteCurve(arg2.Tag, arg2.Points, meshtType, arg2.Coef);
            }
        }

        private void SetPointSize(object sender, int pointNumber, double[] pointSize)
        {
            var dimTags = new int[] { 0, pointNumber };
            gmshController.Gmsh.Model.Mesh.SetSize(dimTags, pointSize[0]);
        }

        private void SetMinMaxSizes(object sender, double[] sizes)
        {
            gmshController.Gmsh.Option.SetNumber("Mesh.MeshSizeMin", sizes[0]);
            gmshController.Gmsh.Option.SetNumber("Mesh.MeshSizeMax", sizes[1]);
        }

        private void SetMeshGradientSettings(object arg1, MeshGradientSettingsEventArgs arg2)
        {
            gmshController.Gmsh.Model.Mesh.Field.Add(FieldType.Extend);

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
                gmshController.Gmsh.Model.Mesh.SetSize(points, arg2.surfaceMeshSize);
                gmshController.Gmsh.Model.Mesh.Field.SetNumbers(field, ExtendOptions.CurvesList.ToString(), curveTags);
                gmshController.Gmsh.Model.Mesh.Field.SetNumbers(field, ExtendOptions.SurfacesList.ToString(), surfTags);
                gmshController.Gmsh.Model.Mesh.Field.SetNumber(field, ExtendOptions.Power.ToString(), arg2.gradientMeshPower);
                gmshController.Gmsh.Model.Mesh.Field.SetNumber(field, ExtendOptions.DistMax.ToString(), arg2.layerThickness);
                gmshController.Gmsh.Model.Mesh.Field.SetNumber(field, ExtendOptions.SizeMax.ToString(), arg2.coreMeshSize);
                gmshController.Gmsh.Model.Mesh.Field.SetAsBackgroundMesh(field);
                gmshController.Gmsh.Option.SetNumber("Mesh.MeshSizeExtendFromBoundary", -2);
            }
        }

        private void CurveAttribDelete(int obj)
        {
            var dimTags = new int[] { 1, obj };
            gmshController.Gmsh.Model.RemoveAttribute($"transfinite {obj}");
            gmshController.Gmsh.Model.Mesh.RemoveConstraints(dimTags);
        }

        private void GetCurveAttrib(object arg1, int arg2)
        {
            try
            {
                var attributes = gmshController.Gmsh.Model.GetAttribute($"transfinite {arg2}");
                var curveControl = arg1 as GMSHCurveSettingsControl;
                curveControl.SetCurveAttributes(attributes);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }

        private void PointAttribDelete(int obj)
        {
            var dimTags = new int[] { 0, obj };
            gmshController.Gmsh.Model.Mesh.RemoveConstraints(dimTags);
        }

        private void GetPointSize(object arg1, int arg2)
        {
            try
            {
                var dimTags = new int[] { 0, arg2 };
                var meshSize = gmshController.Gmsh.Model.Mesh.GetSizes(dimTags);
                var pointControl = arg1 as GMSHPointSettingsControl;
                pointControl.SetPointSize(meshSize[0]);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }

        private void DelMeshGradient(object arg1)
        {
            var list = gmshController.Gmsh.Model.Mesh.Field.List();
            gmshController.Gmsh.Model.Mesh.Field.Remove(list.First());
            var points = gmshController.Gmsh.Model.GetEntities(0);
            gmshController.Gmsh.Model.Mesh.RemoveConstraints(points);
            gmshController.Gmsh.Option.SetNumber("Mesh.MeshSizeExtendFromBoundary", 1);
        }
    }
}
