using System;
using System.Collections.Generic;
//using System.Collections;
using System.Drawing;

namespace MyComponents.Objects.Drawing
{
    public class GraphicTable : Dictionary<string, object>
    {
        public new object this[string Key]
        {
            get
            {
                if (!ContainsKey(Key))
                    return null;
                return (object)base[Key];
            }
            set
            {
                if (this[Key] != null)
                {
                    if (this[Key].GetType().GetInterface("System.IDisposable") != null)
                        ((System.IDisposable)this[Key]).Dispose();
                    base[Key] = value;
                }
                else
                    Add(Key, value);
            }
        }
        public void DisposeAll()
        {
            foreach (object  xObj in Values)
            {
                if (xObj.GetType().GetInterface("System.IDisposable") != null)
                    ((System.IDisposable)xObj).Dispose();
            }
        }

    }
}
