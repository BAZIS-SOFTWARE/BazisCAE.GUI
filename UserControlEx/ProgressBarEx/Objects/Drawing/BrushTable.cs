using System;
using System.Drawing;

namespace MyComponents.Objects.Drawing
{
    public class BrushTable : GraphicTable
    {
        public new Brush this[string Key]
        {
            get
            {
                if (base[Key] == null)
                    return null;
                return (Brush)base[Key];
            }
            set
            {
                base[Key] = value;
            }
        }
    }
}
