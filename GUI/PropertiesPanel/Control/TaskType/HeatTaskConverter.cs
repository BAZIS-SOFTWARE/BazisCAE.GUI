using BaseModule.PropertiesPanel;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using Project.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace BazisGUI.PropertiesPanel.Control.TaskType
{
    public class HeatTaskConverter : DataConverter
    {
        private HeatData _objAsHeat;
        private List<IGroup> _groupElement;

        public HeatTaskConverter(IData obj, List<IGroup> groupElement)
        {
            selectObj = obj;
            dataGroupElement = groupElement;
            _objAsHeat = obj as HeatData;
            _groupElement = groupElement;
#if false
            if (objAsHeat.FrameFunction.Name == HeatSources.ARC.ToString())
            {

            }
            else if (objAsHeat.FrameFunction.Name == HeatSources.LW.ToString())
            {

            }
            else if (objAsHeat.FrameFunction.Name == HeatSources.FSWPin.ToString())
            {

            }
            else if (objAsHeat.FrameFunction.Name == HeatSources.FSWShoulder.ToString())
            {

            }
            else throw new InvalidOperationException("Имя FrameFunction не известно");
#endif
        }

        public override List<RowProperty> GetRowProperty()
        {
            return new List<RowProperty>
            {
                RowProperty.CreateComboBox("Группа элементов", _objAsHeat.Group.Name, _groupElement.Select(x => x.Name).ToList()),
                RowProperty.CreateTextBox("Старт, сек.", _objAsHeat.StartTime.ToString() ),
                RowProperty.CreateTextBox("Стоп, сек.", _objAsHeat.StopTime.ToString(), true)
            };
        }

        public override void UpdateObject(string header, string newValue, string oldValue)
        {
            if (header == "Группа элементов")
            {
                var k = selectObj as IValuableData;
                var group = dataGroupElement.Find(x => x.Name == newValue.ToString());
                k.Group = group;

                _objAsHeat.Group.Name = newValue;
            }
            else if (header == "Старт, сек.")
            {
                _objAsHeat.StartTime = float.Parse(newValue);
            }
            selectObj = _objAsHeat as IData;
        }
    }
}
