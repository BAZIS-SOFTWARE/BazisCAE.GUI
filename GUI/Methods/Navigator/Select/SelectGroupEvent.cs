using System;
using System.Drawing;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_SelectGroupEvent(int grIndex)
        {
            try
            {
                var group = project.GetModelGroup(grIndex);

                project.SetModelObjectsBackColor(group.ObjType);

                var pres = project.CreateModelObjectsPresentor(group.ObjType);
                SetVBObjectAttribute(pres, "цвет");

                foreach (var iobj in group)
                    iobj.Color = settingsConfig.SelectGroupColor;

                //pres = CreateObjectsPresentor(project.ModelData, group.ObjType);
                SetVBObjectAttribute(pres, "цвет");
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
