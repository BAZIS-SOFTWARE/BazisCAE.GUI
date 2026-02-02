using Model.Interfaces.ObjectsCollections;
using Model.Interfaces;
using System;
using System.Drawing;
using System.Linq;
using Model.Utilities;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_SelectGroupEvent(int grIndex)
        {
            try
            {  
                foreach (var item in project.GetAllModelSetsInfo()) // возврат цвета всем объектам, которые были выделены
                    item.SetBackColor();
                
                ColorObjects("Объекты"); // возврат цвета всем объектам уже на сцене

                /*
                 * TO DO в целях инкапсуляции: 
                 * Group.SetBackColor(Color color);
                 */
                var group = project.GetModelGroup(grIndex); // закраска объектов в выделяемой группе
                foreach (var obj in group)
                    obj.Color = settingsConfig.SelectGroupColor;


                foreach (var set in group.Select(x => project.
                GetModelSetInfo(x.ObjType, x.Number)).
                Distinct(new DefaultSetInfoComparer()))
                {
                    var pres = project.CreateModelObjectsPresentor(set);
                    SetVBObjectAttribute(pres, "цвет");
                }          
                DisplayObjects();

                var rows = GetGroupProperty(group);
                propertiesPanel.DrawTable(rows);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
    }
}
