using BaseModule.Console.Events;
using BaseModule.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BazisGUI.Utilities;
using Model.Interfaces;
using Geometry;
using System.Drawing;
using BaseModule.Navigator;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void console_FindFreeNodesEvent()
        {
            var freeNodes = project.FindFreeNodes();

            Invoke(new Action(() =>
            {
                console.PrintInfo($"Найдено {freeNodes.Count()} свободных узлов", Color.Black);

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
