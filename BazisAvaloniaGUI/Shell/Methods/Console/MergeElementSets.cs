using Model.Interfaces;
using System;
using System.Drawing;

namespace BazisAvaloniaGUI.Shell
{
    internal partial class MainWindow
    {
        private async void MergeEventSets(string objTypeStr, string masterSet, string slaveSet)
        {
            try
            {
                // выбор объектов
                ObjType objType;
                if (!ObjType.TryParse(objTypeStr, out objType))
                    throw new Exception("Неизвестный тип объектов");

                // Выделение снимается до слияния: событие Changed от ClearSelection
                // перекрашивает буферы наборов по их текущему составу, а состав
                // master/slave меняется только ниже, явным пересозданием буферов.
                project.ModelView.ClearSelection();

                project.MergeElements(objType, masterSet, slaveSet);

                PresentMeshData();

                VBOController.DeleteVBObjects(slaveSet);
                VBOController.DeleteVBObjects(masterSet);

                var set = project.GetModelSetInfo(objType, masterSet);
                var pre = project.CreateModelObjectsPresentor(set);
                RefreshModelSetBuffer(set);
                RequestRedraw();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
    }
}
