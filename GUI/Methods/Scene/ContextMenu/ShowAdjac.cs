using BazisGUI.Scene.VBO;
using Model.Interfaces;
using Model.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void показатьСопряженныеItem_Click(object sender, EventArgs e)
        {
            try
            {
                var objTypes = new HashSet<ObjType>();
                // TODO подумать над улучшением производительности
                var selObjs = GetModelObjects(SelectedObjects).
                    Where(x => x.Color == settingsConfig.SelectObjectColor).ToList();
                foreach (var item in selObjs)
                {
                    var down = project.GetAdjacentGeometryObjects(item, 1);
                    var up = project.GetAdjacentGeometryObjects(item, 2);

                    if (down.Count() > 0)
                        objTypes.Add(down.First().ObjType);
                    if (up.Count() > 0)
                        objTypes.Add(up.First().ObjType);

                    var temp = up.Concat(down);

                    foreach (var obj in temp)
                        obj.ViewState = true;
                }

                foreach (var objType in objTypes)
                {
                    foreach (var set in project.GetModelSetsInfo(objType))
                    {
                        VBOController.DeleteVBObjects(set.Name);
                        //set.SetBackColor();
                        if (set.ViewState)
                        {
                            var pre = project.CreateModelObjectsPresentor(set);
                            VBObject vb;
                            if (TryCreateVBObject(pre, out vb))
                                VBOController.AddVbo(vb);
                        }
                    }
                }

                DisplayObjects();

            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, System.Drawing.Color.Red);
            }

        }
    }
}
