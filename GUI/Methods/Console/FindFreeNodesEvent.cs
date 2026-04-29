using System;
using System.Linq;
using Model.Interfaces;
using System.Drawing;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void console_FindFreeNodesEvent()
        {
            var freeNodes = project.FindFreeNodes();

            Invoke(new Action(() =>
            {
                console.PrintInfo($"{Localization.Localization.GetStringResourceByName("FindFreeNodesEvent.Found.Message")} {freeNodes.Count()} {Localization.Localization.GetStringResourceByName("FindFreeNodesEvent.FreeNodes.Message")}", Color.Black);

                if(freeNodes.Count() != 0)
                {
                    VBOController.DeleteAllVBObjects();
                    project.GetModelSetsInfo(ObjType.Узел).First().SetViewState(false);

                    foreach (var freeNode in freeNodes)
                        project.GetModelObject(ObjType.Узел, freeNode).ViewState = true;


                    var objsTypeStr = ObjType.Узел.ToString();
                    VBOController.DeleteVBObjects(objsTypeStr);

                    var pres = project.CreateModelObjectsPresentor(ObjType.Узел);

                    var vbo = CreateVBObject(pres);
                    VBOController.AddVbo(vbo);

                    DisplayObjects();
                }
            }));
        }
    }
}
