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
        public List<RowProperty> GetMatProperty(MatData obj, List<string> mat, List<IGroup> groups)
        {
            var rows = new List<RowProperty>
            {
                //RowProperty.CreateTextBox("Имя", NodeType.Материал.ToString(), ValidationType.None, true),
                new RowProperty("Группа элементов", obj.Group.Name, groups.Select(x => x.Name).ToList()),
                new RowProperty("Материал", obj.MatName,  mat),
                new RowProperty("Старт, сек.", obj.StartTime),
                new RowProperty("Стоп, сек.", obj.StopTime)
            };

            if(obj.FrameFunction != null)
                rows.AddRange(GetLocalFrameProperty(obj.FrameFunction.LocalFrame));

            return rows;
        }
    }
}
