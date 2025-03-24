using BaseModule.PropertiesPanel;
using Project.Interfaces.Tasks;
using System.Collections.Generic;

namespace BazisGUI.PropertiesPanel.Control
{
    public class DataControl : PanelConverter
    {
        private readonly IData _data;
        public DataControl(IData obj)
        {
            _data = obj;
        }

        public override List<RowProperty> GetRowProperty()
        {
            return base.GetRowProperty();
        }
        ////Mat   - Материал
        ////Med   - Среда
        ////Heat  - Нагрев
        ////Clamp - Закрепление
        ////Load  - Нагрузка
    }
}
