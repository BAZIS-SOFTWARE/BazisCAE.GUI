using Model.Interfaces.ObjectsCollections;
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
                List<List<(ISetInfo, List<int> Numbers)>> all = new List<List<(ISetInfo, List<int> Numbers)>>();

                foreach (var item in GetModelObjects(SelectedObjects).Where(x => x.Color == settingsConfig.SelectObjectColor))
                {
                    var dim = (int)item.ObjType;
                    var sets = SelectAdj(dim, item.Number);
                    all.Add(sets);
                }
                foreach (var sets in all)
                {
                    foreach(var (set, numbers) in sets)
                    {
                        foreach(var number in numbers)
                            set.SetColor(settingsConfig.SelectObjectColor, number);
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
