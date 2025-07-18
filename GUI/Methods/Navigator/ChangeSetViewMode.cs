using BaseModule.Extensions;
using BaseModule.Navigator;
using BazisGUI.Scene.Interfaces;
using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_ChangeSetViewEvent(string objs, ViewRegime viewRegime)
        {
            var objType = objs.ToEnum<ObjType>();
            switch (viewRegime)
            {
                case ViewRegime.ribbers:
                    VBOController.ChangeViewModeVBObjects(objs, ObjView.Lines);
                    foreach (var item in project.ModelData.ObjectData.GetSetsInfo(objType))
                        item.SetViewMode(ViewMode.Line);
                    break;
                case ViewRegime.surfaces:
                    VBOController.ChangeViewModeVBObjects(objs, ObjView.Surface);
                    foreach (var item in project.ModelData.ObjectData.GetSetsInfo(objType))
                        item.SetViewMode(ViewMode.Surface);
                    break;
                case ViewRegime.ribbersSurfaces:
                    VBOController.ChangeViewModeVBObjects(objType.ToString(), ObjView.LinesSurface);
                    foreach (var item in project.ModelData.ObjectData.GetSetsInfo(objType))
                        item.SetViewMode(ViewMode.LineSurface);
                    break;
                default:
                    break;
            }
            DisplayObjects();
        }
    }
}
