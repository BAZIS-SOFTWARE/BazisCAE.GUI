using BaseModule.PropertiesPanel;
using Model.Interfaces;
using Project.Tasks;
using Project.Tasks.FrameCreators;
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
                new RowProperty("Группа элементов", obj.Group.Name, groups.Select(x => x.Name).ToList()),
                new RowProperty("Материал", obj.MatName,  mat),
                new RowProperty("Старт, сек.", obj.StartTime),
                new RowProperty("Стоп, сек.", obj.StopTime),
            };

            var funcNames = new List<string>() { "*", "Custom" };

            if (obj.FrameFunction != null)
            {
                rows.Add(new RowProperty
(
"Функция, F(v(x,y,z)), F - у.ед.", obj.FrameFunction.Name, funcNames
));
                rows.AddRange(GetFrameFunctionProperties(obj.FrameFunction));
                rows.AddRange(GetLocalFrameProperties(obj.FrameFunction.LocalFrame, groups));
            }
            else
            {
                rows.Add(new RowProperty
(
"Функция, F(v(x,y,z)), F - у.ед.", "*", funcNames
));
            }

            return rows;
        }
    }
}
