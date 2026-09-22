using BazisGUI.Properties;
using Model.Interfaces;
using System;
using System.Drawing;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void console_FindFreeNodesEvent()
        {
            var freeNodes = project.FindFreeNodes();

            Invoke(new Action(() =>
            {
                console.PrintInfo($"{Resources.FindFreeNodesEvent_Found_Message} {freeNodes.Count()} {Resources.FindFreeNodesEvent_FreeNodes_Message}", Color.Black);

                if(freeNodes.Count() != 0)
                {
                    using (project.ModelView.BeginUpdate())
                    {
                        foreach (var set in project.GetModelSetsInfo(ObjType.Узел))
                            project.ModelView.SetVisible(ObjType.Узел, set.GetNumbers(), false);

                        project.ModelView.SetVisible(ObjType.Узел, freeNodes, true);
                    }
                }
            }));
        }
    }
}
