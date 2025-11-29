using BazisGUI.PropertiesPanel;
using Model.Interfaces;
using Project.Tasks;
using Project.Tasks.FrameCreators;
using System.Collections.Generic;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public List<RowProperty> GetLocalFrameProperties(LocalFrame frame, IEnumerable<IGroup> groups)
        {
            var rows = new List<RowProperty>();

            rows.Add(new RowProperty
 (
     "Система координат", new DropDownPropertyValue(
     frame is MovedFrame == true ? "MRF" : "SRF",
     new List<string>() { "MRF" , "SRF" }
 )));

            if (frame is MovedFrame mf)
            {
                rows.Add(new RowProperty("Траектория",  new DropDownPropertyValue(mf.BaseLine?.Name == null ? "*" : mf.BaseLine.Name, 
                    groups.
                    Where(x=> x.ObjType == ObjType.Узел).
                    Select(x => x.Name).ToList())));
                rows.Add(new RowProperty("Опорная линия", new DropDownPropertyValue(mf.RefLine?.Name == null ? "*" : mf.RefLine.Name,
                    groups.
                    Where(x => x.ObjType == ObjType.Узел).
                    Select(x => x.Name).ToList())));
                rows.Add(new RowProperty("Скорость, мм./сек.", mf.Velocity));
            }
            else
            {
                var sf = frame as StaticFrame;
                rows.Add(new RowProperty("Плоскость", new DropDownPropertyValue
                    (sf.BaseGroup?.Name == null ? "*" : sf.BaseGroup?.Name, groups.Select(x => x.Name).ToList())));
            }
            rows.Add(new RowProperty("Смещение x", frame.Shifting._x));
            rows.Add(new RowProperty("Смещение y", frame.Shifting._y));
            rows.Add(new RowProperty("Смещение z", frame.Shifting._z));
            rows.Add(new RowProperty("Поворот x", frame.Rotation));

            return rows;
        }
    }
}
