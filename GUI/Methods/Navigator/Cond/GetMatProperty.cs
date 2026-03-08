using BazisGUI.PropertiesPanel;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using Project.Tasks;
using Project.Tasks.Materials;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public List<RowProperty> GetMatProperty(MatData obj, List<string> mat, IEnumerable<IGroup> groups, List<string> funcTables)
        {
            var rows = GetCondProperty(obj, groups, funcTables);

            rows.Add(new RowProperty("Материал", new DropDownPropertyValue(obj.Material.Name, mat)) 
            { Color = Color.Gainsboro });

            // подумать над этим....
            if (obj is BeamMatData bmat )
            {
                rows.Add(new RowProperty("Диаметр", bmat.Diameter));
            }
            else if (obj is PlateMatData pmat)
            {
                rows.Add(new RowProperty("Толщина", pmat.Thickness));
            }

            return rows;
        }
    }
}
