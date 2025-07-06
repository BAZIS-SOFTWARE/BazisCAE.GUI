using BaseModule.Console;
using BazisGUI.Scene.Interfaces;
using BazisGUI.Scene.VBO;
using Model.Interfaces;
using Model.Interfaces.MeshObjects;
using Model.Interfaces.ObjectsCollections;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {

        private void displayToolStrip_ItemClicked(object arg1, ToolStripItemClickedEventArgs arg2)
        {

            try
            {

                if (arg2.ClickedItem.Tag.ToString() == "0")
                {
                    IsInsideObjectsShown = true;
                    ShowInsideObjects();
                }

                else if (arg2.ClickedItem.Tag.ToString() == "1")
                {
                    IsInsideObjectsShown = false;
                    HideInsideObjects();
                }

                else if (arg2.ClickedItem.Tag.ToString() == "2")
                {
                    ChangeViewModeObjects(ViewMode.LineSurface);
                }

                else if (arg2.ClickedItem.Tag.ToString() == "3")
                {
                    ChangeViewModeObjects(ViewMode.Line);
                }

                else if (arg2.ClickedItem.Tag.ToString() == "4")
                {
                    ChangeViewModeObjects(ViewMode.Surface);
                }
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void ChangeViewModeObjects(ViewMode arg2)
        {
            try
            {
                foreach (var item in project.ModelData.ObjectData.GetSetsInfo(ObjType.Поверхность))
                    item.SetViewMode(ViewMode.LineSurface);
                foreach (var item in project.ModelData.ObjectData.GetSetsInfo(ObjType.Элемент2D))
                    item.SetViewMode(ViewMode.LineSurface);
                foreach (var item in project.ModelData.ObjectData.GetSetsInfo(ObjType.Элемент3D))
                    item.SetViewMode(ViewMode.LineSurface);

                var vbobjs = VBOController.GetVBObjs().Where(x => x.GL_ObjType == GLObjType.triangle);

                foreach (var obj in vbobjs)
                    if (arg2 == ViewMode.Line)
                        obj.ViewMode = Scene.Interfaces.ObjView.Lines;
                    else if (arg2 == ViewMode.LineSurface)
                        obj.ViewMode = Scene.Interfaces.ObjView.LinesSurface;
                    else obj.ViewMode = Scene.Interfaces.ObjView.Surface;

                DisplayObjects();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }

        private void HideInsideObjects()
        {
            var objs = project.ModelData.ObjectData.E3DCollection.GetObjects();

            changeInsideSurface.HideInsideSurfaces(objs);

            var presenter = presentersCreator.CreateSurfaceObjectsPresenter(objs);

            PresentObjectsOnScene(presenter, ObjType.Элемент3D.ToString());
            console.PrintInfo("Скрыты внутренние объекты", Color.Black);
        }

        private void ShowInsideObjects()
        {

            var objs = project.ModelData.ObjectData.E3DCollection.GetObjects();

            changeInsideSurface.ShowInsideSurfaces(objs);

            var presenter = presentersCreator.CreateSurfaceObjectsPresenter(objs);

            PresentObjectsOnScene(presenter, ObjType.Элемент3D.ToString());
            console.PrintInfo("Показаны все объекты", Color.Black);
        }

        private void btnShowBasis_Click(object sender, EventArgs e)
        {
            var btn = (ToolStripButton)sender;

            if (btn.Checked)
                DisplayBasis = true;
            else DisplayBasis = false;

            DisplayObjects();
        }

        private void btnShowNormals_Click(object sender, EventArgs e)
        {
            try
            {
                var btn = (ToolStripButton)sender;
                if (btn.Checked)
                {
                    var surfElems = project.ModelData.ObjectData.GetAllElements().Where(x => x is ISurfaceElement);
                    if (surfElems.Count() > 0)
                    {
                        var elemsNormals = modelController.NormalCalculator.CalcElemsNormals(surfElems.Select(x => x as ISurfaceElement));

                        var linePresenter = presentersCreator.CreateLineObjectsPresenter(elemsNormals);

                        CreateObjectsOnScene("Normals", linePresenter);
                        DisplayObjects();
                    }
                    else
                        throw new Exception("Для отображения нормалей модели не заданы объекты типа \"Элемент\"," +
                            "возможно вы пользуетесь модулем Геометрии");
                }
                else
                {
                    VBOController.DeleteVBObjects("Normals");
                    DisplayObjects();
                }
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void btnShowCountours_Click(object sender, EventArgs e)
        {
            try
            {
                var btn = (ToolStripButton)sender;
                if (btn.Checked)
                {
                    var surfElems = project.ModelData.ObjectData.GetAllElements().Where(x => x is ISurfaceElement).
            Select(x => (ISurfaceElement)x);
                    var linesNodes = modelController.BoundaryEdgesFinder.Find(surfElems);
                    var edges = modelController.BoundaryEdgesFinder.CreateBoundaryEdges(linesNodes, project.ModelData);
                    var linePresenter = presentersCreator.CreateLineObjectsPresenter(edges);

                    CreateObjectsOnScene("Boundary", linePresenter);
                    DisplayObjects();
                }
                else
                {
                    VBOController.DeleteVBObjects("Boundary");
                    DisplayObjects();
                }
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }
    }
}
