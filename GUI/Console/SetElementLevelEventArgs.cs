using Model.Interfaces;
using System;
using BazisGUI.Extensions;

namespace BazisGUI.Console
{
    internal class SetElementLevelEventArgs : EventArgs
    {
        public ObjType ObjType { get; }
        public int Level { get; }

        public SetElementLevelEventArgs(string objType, string level)
        {
            ObjType = objType.ToEnum<ObjType>();
            Level = int.Parse(level);
        }
    }
}