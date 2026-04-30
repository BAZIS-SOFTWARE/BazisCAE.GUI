using BazisGUI.Properties;
using Model.Interfaces;
using System;

namespace BazisGUI.Console
{
    public class FindObjectEventArgs : EventArgs
    {
        public uint Number { get; }
        public ObjType ObjType { get; }
        public FindObjectEventArgs(string str)
        {
            uint number;

            ObjType objType;
            if(!Enum.TryParse(str.Split(',')[0].Replace(" ",""), out objType))
                throw new Exception(Resources.UnknownTypeException);

            ObjType = objType;

            if (!uint.TryParse(str.Split(',')[1].Replace(" ", ""), out number))
                throw new Exception(Resources.PositiveCellingNumberException);
            Number = number;
        }
    }
}