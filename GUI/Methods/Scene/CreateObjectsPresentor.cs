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
using Model.Interfaces;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public IObjsPresenter CreateModelObjectsPresentor(IModelData modelData, ObjType objType)
        {
            IObjsPresenter pre;
            switch (objType)
            {
                case ObjType.Узел:
                    pre = presentersCreator.CreatePointObjectsPresenter(modelData.ObjectData.NodesSet.Values);
                    break;
                case ObjType.Кривая:
                    pre = presentersCreator?.CreateLineObjectsPresenter(modelData.ObjectData.CurveCollection.GetObjects());
                    break;
                case ObjType.Поверхность:
                    pre = presentersCreator.CreateSurfaceObjectsPresenter(modelData.ObjectData.SurfaceCollection.GetObjects());
                    break;
                case ObjType.Объем:
                    pre = presentersCreator.CreateSurfaceObjectsPresenter(modelData.ObjectData.VolumeCollection.GetObjects());
                    break;
                case ObjType.Элемент1D:
                    pre = presentersCreator.CreateLineObjectsPresenter(modelData.ObjectData.E1DCollection.GetObjects());
                    break;
                case ObjType.Элемент2D:
                    pre = presentersCreator.CreateSurfaceObjectsPresenter(modelData.ObjectData.E2DCollection.GetObjects());
                    break;
                case ObjType.Элемент3D:
                    if (settingsConfig.IsInsideObjectsShown)
                        changeInsideSurface.HideInsideSurfaces(modelData.ObjectData.E3DCollection.GetObjects());
                    pre = presentersCreator.CreateSurfaceObjectsPresenter(modelData.ObjectData.E3DCollection.GetObjects());
                    break;
                default:
                    pre = presentersCreator.CreatePointObjectsPresenter(modelData.ObjectData.PointsSet.Values);
                    break;
            }
            // изменить в будущем на массив viewMode
            var setInfo = modelData.ObjectData.GetSetsInfo(objType).FirstOrDefault();
            if (setInfo != null)
                pre.ViewMode = setInfo.ViewMode;
            pre.Name = objType.ToString();
            return pre;
        }
    }
}
