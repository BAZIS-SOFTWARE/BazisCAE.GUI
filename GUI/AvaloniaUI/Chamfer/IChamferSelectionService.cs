using System;
using System.Collections.Generic;

namespace BazisGUI.AvaloniaUI.Chamfer
{
    /// <summary>
    /// Boundary between the chamfer UI and the application's scene selection.
    /// A scene adapter can be supplied later without coupling the window to BaseForm.
    /// </summary>
    public interface IChamferSelectionService
    {
        IReadOnlyList<object> SelectedObjects { get; }

        event EventHandler SelectionChanged;
    }
}
