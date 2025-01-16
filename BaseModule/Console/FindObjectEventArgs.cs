using System;
using static BaseModule.Interfaces.GeneralParams;

namespace BaseModule.Console
{
    public class FindObjectEventArgs : EventArgs
    {
        public uint Number { get; }
        public Objects ObjsType { get; }
        public FindObjectEventArgs(string str)
        {
            uint number;

            Objects objType;
            if(!Enum.TryParse(str.Split(',')[0].Replace(" ",""), out objType))
                throw new Exception("Неизвестный тип объекта!");
            ObjsType = objType;

            if (!uint.TryParse(str.Split(',')[1].Replace(" ", ""), out number))
                throw new Exception("Номер должен быть целым положительным числом!");
            Number = number;
        }
    }
}