using BazisGUI.PropertiesPanel;
using Model.Interfaces;
using Project.Tasks;
using Project.Tasks.Functions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public List<RowProperty> GetMediaProperty(MediaData obj, IEnumerable<IGroup> groups, List<string> funcTables)
        {
            var rows = GetCondProperty(obj, groups, funcTables);

            rows.Add(new RowProperty("Вид условия", 
                new DropDownPropertyValue(obj.MediaType, 
                new List<string>() 
                { 
                    MediaType.ConstantTemp.ToString(), 
                    MediaType.HeatFlux.ToString()
                }))
            { Color = Color.Gainsboro });

            return rows;

        }
    }
}
