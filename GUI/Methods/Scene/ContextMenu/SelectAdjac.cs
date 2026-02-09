using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
using Model.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void выбратьСопряженныеToolStripMenuItem_Click(object sender, EventArgs e)
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

                    if(down.Count() > 0)
                        objTypes.Add(down.First().ObjType);
                    if (up.Count() > 0)
                        objTypes.Add(up.First().ObjType);

                    var temp = up.Concat(down);

                    foreach (var obj in temp)
                        if(obj.ViewState)
                            obj.Color = settingsConfig.SelectObjectColor;        
                }

                foreach (var objType in objTypes)
                {
                    foreach (var set in project.GetModelSetsInfo(objType))
                    {
                        var pres = project.CreateModelObjectsPresentor(set);
                        SetVBObjectAttribute(pres, "цвет");
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
