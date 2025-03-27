using BaseModule.PropertiesPanel;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI.PropertiesPanel.Control.TaskType
{
    public class HeatTaskControl : DataControl
    {
        private readonly List<string> _mat;
        private readonly List<IGroup> _dataObjectType;

        public HeatTaskControl(IData obj, List<string> mat, List<IGroup> groupElement)
        {
            Debug.WriteLine(obj.GetInfo);
            _dataObjectType = groupElement;
            _mat = mat;
            var value = obj.GetInfo.Split(' ');
            dataGroupElement = groupElement;
            selectObj = obj;
            data = new Dictionary<string, string>()
            {
                { "Группа узлов", value[0] },
                { "Вид", value[1]},
                { "Направление", value[2]},
                { "Функция, F(u) , Н.мм - у.ед.(default)", value[3]},
                { "Старт, сек.", value[4]},
                { "Стоп, сек.", value[5]},
                { "Траектория(default)", value[6]}
            };
        }

        public override List<RowProperty> GetRowProperty()
        {
            return base.GetRowProperty();
        }
    }
}
