using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI.Interfaces
{
    public interface IPinnedControl
    {
        Color UpColor { get; set; }

        Color DownColor { get; set; }

        string HeaderName { get; set; }

        event Action ControlCollapseEvent;
        event Action ControlUnpinnedEvent;
    }
}
