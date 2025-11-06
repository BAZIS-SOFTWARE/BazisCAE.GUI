using BaseModule.Extensions;
using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using GmshApi;
using Model.GeometryObjects;
using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
using Model.MeshObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void ShowAdjacencies(NodeName nodeName, int number)
        {
            //TODO тут пишем метод который показывает все связанные объекты

            ISetInfo set;

            //var nodeName = navigator.SelectedNode.Name.ToEnum<NodeName>();
            //var number = int.Parse(navigator.SelectedNode.Text.Split(' ')[0]);


                if (nodeName == NodeName.Объем)
                {
                    ShowVolAdg(number);
                    set = project.GetModelSetsInfo(ObjType.Поверхность).First();
                    PresentSet(set);
                    set = project.GetModelSetsInfo(ObjType.Кривая).First();
                    PresentSet(set);
                    set = project.GetModelSetsInfo(ObjType.Точка).First();
                    PresentSet(set);
                }

                else if (nodeName == NodeName.Поверхность)
                {
                    ShowSurfAdg(number);
                    set = project.GetModelSetsInfo(ObjType.Поверхность).First();
                    PresentSet(set);
                    set = project.GetModelSetsInfo(ObjType.Кривая).First();
                    PresentSet(set);
                    set = project.GetModelSetsInfo(ObjType.Точка).First();
                    PresentSet(set);
                }
                else if (nodeName == NodeName.Кривая)
                {
                    ShowCurvAdg(number);
                    set = project.GetModelSetsInfo(ObjType.Кривая).First();
                    PresentSet(set);
                    set = project.GetModelSetsInfo(ObjType.Точка).First();
                    PresentSet(set);
                }
            
            DisplayObjects();
        }

        private void ShowVolAdg(int number)
        {
            var vol = project.GetModelVolumes().First(x => x.Number == number);

            foreach (var surfaceFigure in vol.GetSurfaceFigures())
                ShowSurfAdg(surfaceFigure.Number);      
        }

        private void ShowSurfAdg(int number)
        {
            var surfaceFigure = project.GetModelSurface(number);
            surfaceFigure.ViewState = true;

            var curvTags = GmshController.Gmsh.Model.GetAdjacencies(2, number).Item2;

            foreach (var cNumber in curvTags)
                ShowCurvAdg(cNumber);
        }

        private void ShowCurvAdg(int number)
        {
            var curve = project.GetModelCurve(number);
            curve.ViewState = true;

            var pointsTags = GmshController.Gmsh.Model.GetAdjacencies(1, number).Item2;

            foreach (var pNumber in pointsTags)
                ShowPointAdg(pNumber);
        }

        private void ShowPointAdg(int number)
        {
            var point = project.GetModelPoint(number);
            point.ViewState = true;
        }

        private void PresentSet(ISetInfo set)
        {
            set.SetBackColor();
            VBOController.DeleteVBObjects(set.Name);

            if (set.ViewState)
            {
                var pre = project.CreateModelObjectsPresentor(set);
                var vbo = CreateVBObject(pre);
                VBOController.AddVbo(vbo);
            }
        }
    }
}
