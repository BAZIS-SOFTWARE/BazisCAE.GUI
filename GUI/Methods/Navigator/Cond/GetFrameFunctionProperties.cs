using BazisGUI.PropertiesPanel;
using Project.Interfaces.Tasks;
using Project.Tasks.Functions.FrameFunctions;
using System.Collections.Generic;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private List<RowProperty> GetFrameFunctionProperties(IFrameFunction function)
        {
            var rows = new List<RowProperty>();

            if (function is SPH sph)
            {
                rows.Add(new RowProperty("Ширина, мм.", sph.Width));
            }
            else if (function is CIL cil)
            {
                rows.Add(new RowProperty("Длина, мм.", cil.Length));
                rows.Add(new RowProperty("Верхний диам., мм.", cil.UpperDiam));
                rows.Add(new RowProperty("Нижний диам., мм.", cil.BottomDiam));
            }
            else
            {
                var cf = function as CustomFrameFunction;
                rows.Add(new RowProperty("Файл", cf.ExecutedFile == null ? "*" : cf.ExecutedFile));
            }

            return rows;
        }
    }
}
