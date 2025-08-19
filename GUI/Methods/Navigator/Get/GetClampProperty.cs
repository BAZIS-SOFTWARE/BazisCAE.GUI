using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using Project.Tasks;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public List<RowProperty> GetClampProperty(ClampData obj, IEnumerable<IGroup> groups)
        {
            var rows = new List<RowProperty>
            {
                new RowProperty("Группа узлов", obj.Group.Name,groups.
                Where(x => x.ObjType == ObjType.Узел).
                Select(x => x.Name).ToList()),
                new RowProperty("Вид", obj.Kind, Converters.GetEnumNames<ClampKind>()),
                new RowProperty("Направление", obj.Direction,  Converters.GetEnumNames<Direction>()),
                new RowProperty("Старт, сек.", obj.StartTime),
                new RowProperty("Стоп, сек.", obj.StopTime)
            };

            var funcNames = new List<string>() { "*", "Custom" };

            if (obj.FrameFunction != null)
            {
                rows.Add(new RowProperty
(
 "Функция, F(v(x,y,z)), F - мм.| Н/мм.", obj.FrameFunction.Name, funcNames
));
                rows.AddRange(GetFrameFunctionProperties(obj.FrameFunction));
                rows.AddRange(GetLocalFrameProperties(obj.FrameFunction.LocalFrame, groups));
            }
            else
            {
                rows.Add(new RowProperty
(
 "Функция, F(v(x,y,z)), F - мм.| Н/мм.", "*", funcNames
));
            }

            return rows;
        }
    }
}
