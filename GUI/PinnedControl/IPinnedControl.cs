using System;
using System.Drawing;

namespace BazisGUI.PinnedControl
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
