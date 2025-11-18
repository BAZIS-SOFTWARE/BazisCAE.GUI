using BaseModule.PropertiesPanel;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using Project.Tasks;
using Project.Tasks.Materials;
using System.Collections.Generic;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public List<RowProperty> GetMatProperty(MatData obj, List<string> mat, IEnumerable<IGroup> groups)
        {
            var rows = new List<RowProperty>
            {
                //RowProperty.CreateTextBox("Имя", NodeType.Материал.ToString(), ValidationType.None, true),
                new RowProperty("Группа элементов", new DropDownPropertyValue(obj.Group.Name, groups.Select(x => x.Name).ToList())),
                new RowProperty("Материал", new DropDownPropertyValue(obj.Material.Name,  mat)),
                new RowProperty("Старт, сек.", obj.StartTime),
                new RowProperty("Стоп, сек.", obj.StopTime),
            };

            // подумать над этим....
            if (obj is BeamMatData bmat )
            {
                rows.Add(new RowProperty("Диаметр", bmat.Diameter));
            }
            else if (obj is PlateMatData pmat)
            {
                rows.Add(new RowProperty("Толщина", pmat.Thickness));
            }

            var funcNames = new List<string>() { "*", "Custom" };

            if (obj.FrameFunction != null)
            {
                rows.Add(new RowProperty
(
"Функция, F(v(x,y,z)), F - у.ед.", new DropDownPropertyValue(obj.FrameFunction.Name, funcNames
)));
                rows.AddRange(GetFrameFunctionProperties(obj.FrameFunction));
                rows.AddRange(GetLocalFrameProperties(obj.FrameFunction.LocalFrame, groups));
            }
            else
            {
                rows.Add(new RowProperty
(
"Функция, F(v(x,y,z)), F - у.ед.", new DropDownPropertyValue("*", funcNames
)));
            }

            return rows;
        }
    }
}
