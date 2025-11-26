using BaseModule.PropertiesPanel;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using Project.Tasks;
using Project.Tasks.FrameCreators;
using Project.Tasks.Functions;
using Project.Tasks.Functions.Welding;
using System.Collections.Generic;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private List<RowProperty> GetFrameFunctionProperties(IFrameFunction function)
        {
            var rows = new List<RowProperty>();

            if (function is SphereFunction sph)
            {
                rows.Add(new RowProperty("Ширина, мм.", sph.Width));
            }
            else if (function is CillindricalFunction cil)
            {
                rows.Add(new RowProperty("Длина, мм.", cil.Length));
                rows.Add(new RowProperty("Верхний диам., мм.", cil.UpperDiam));
                rows.Add(new RowProperty("Нижний диам., мм.", cil.BottomDiam));
            }
            else
            {
                var cf = function as CustomFunction;
                rows.Add(new RowProperty("Файл", cf.ExecutedFile == null ? "*" : cf.ExecutedFile));
            }

            return rows;
        }
    }
}
