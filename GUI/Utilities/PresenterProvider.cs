using Model.Interfaces;
using ModelController.ModelScenePresentator;
using ModelControllerInterfaces;
using Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI.Utilities
{
    public static class PresenterProvider
    {
        public static IObjsPresenter CreateObjectsPresentor(IPresentersCreator PresentersCreator, IModelData modelData, ObjType objType)
        {
            //IObjsPresenter presenter;

            switch (objType)
            {
                case ObjType.Узел:
                    return PresentersCreator.CreatePointObjectsPresenter(modelData.ObjectData.NodesSet.Values);
                case ObjType.Кривая:
                    return PresentersCreator.CreateLineObjectsPresenter(modelData.ObjectData.CurveCollection.GetObjects());
                case ObjType.Поверхность:
                    return PresentersCreator.CreateSurfaceObjectsPresenter(modelData.ObjectData.SurfaceCollection.GetObjects());
                case ObjType.Объем:
                    return PresentersCreator.CreateSurfaceObjectsPresenter(modelData.ObjectData.VolumeCollection.GetObjects());
                case ObjType.Элемент1D:
                    return PresentersCreator.CreateLineObjectsPresenter(modelData.ObjectData.E1DCollection.GetObjects());

                case ObjType.Элемент2D:
                    return PresentersCreator.CreateSurfaceObjectsPresenter(modelData.ObjectData.E2DCollection.GetObjects());

                case ObjType.Элемент3D:
                    var presenter = PresentersCreator.CreateSurfaceObjectsPresenter(modelData.ObjectData.E3DCollection.GetObjects());
                    //if (!sceneControl.DrawInsideObjects)
                    //    presenter.HideInsideSurfaces();
                    return presenter;
                default:
                    return PresentersCreator.CreatePointObjectsPresenter(modelData.ObjectData.PointsSet.Values);
            }
        }
    }
}
