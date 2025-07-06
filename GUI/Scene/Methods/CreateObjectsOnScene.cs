using BazisGUI.Scene.Interfaces;
using BazisGUI.Scene.VBO;
using BazisGUI.Scene;
using Model.Interfaces.ObjectsCollections;
using ModelControllerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public void CreateObjectsOnScene(IObjsPresenter presenter)
        {
            var inds = presenter.CreateIndexes();
            var ptrs = presenter.CreatePointers(inds.Item1);
            var coords = presenter.CreateVertexes(inds.Item2, "координаты");
            var colors = presenter.CreateVertexes(inds.Item3, "цвет");
            var normals = presenter.CreateVertexes(inds.Item2, "нормаль");
            var edges = presenter.CreateEdgeFlags(inds.Item4);
            var objsName = presenter.Name;
            if (ptrs.Length != 0)
            {
                VBObject vb;
                if (presenter.PresenterType == PresenterType.Surface)
                {
                    var pres = (ISurfaceObjsPresenter)presenter;
                    var separs = pres.CreateSeparators();

                    if (presenter.ViewMode == ViewMode.Line)
                        vb = VBOController.CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, objsName, separs, ObjView.Lines);
                    else if (presenter.ViewMode == ViewMode.LineSurface)
                        vb = VBOController.CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, objsName, separs, ObjView.LinesSurface);
                    else
                        vb = VBOController.CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, objsName, separs, ObjView.Surface);
                }

                else if (presenter.PresenterType == PresenterType.Line)
                {
                    vb = VBOController.CreateLineVBObjects(ptrs, coords, colors, normals, edges, objsName);
                }

                else
                    vb = VBOController.CreatePointVBObjects(ptrs, coords, colors, normals, objsName);

                vb.ActiveDrawingObject = AverageColorRenderer.IsEnable ? averageColorRenderer : null;
                VBOController.AddVbo(vb);
            }
        }
    }
}
