using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseModule.PropertiesPanel
{
    [ComVisible(false)]
    public abstract class PanelConverter 
    {
        public virtual List<RowProperty> GetRowProperty()
        {
            return new List<RowProperty>();
        }

        public virtual void UpdateObject(PropertyChangedEventArgs e)
        {
            throw new NotImplementedException("Тип конвертера не определен");
        }
    }
}
