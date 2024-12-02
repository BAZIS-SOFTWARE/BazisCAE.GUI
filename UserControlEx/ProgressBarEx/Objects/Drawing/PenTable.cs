using System;
using System.Drawing;

namespace MyComponents.Objects.Drawing
{
    public class PenTable : GraphicTable
    {
        public new Pen this[string Key]
        {
            get
            {
                if (base[Key] == null)
                    return null;
                return (Pen)base[Key];
            }
            set
            {
                base[Key] = value;
            }
        }
    }
}
