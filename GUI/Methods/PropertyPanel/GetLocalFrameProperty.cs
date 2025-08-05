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
        public List<RowProperty> GetLocalFrameProperty(LocalFrame frame)
        {
            List<RowProperty> rows = new List<RowProperty>();

            rows.Add(new RowProperty("Смещение по Х", frame.Shifting._x));
            rows.Add(new RowProperty("Смещение по Х", frame.Shifting._y));
            rows.Add(new RowProperty("Смещение по Х", frame.Shifting._z));
            rows.Add(new RowProperty("Поворот вокруг Х", frame.Rotation));
            if (frame is MovedFrame mff)
                rows.Add(new RowProperty("Скорость", mff.Velocity));
            return rows;
        }
    }
}
