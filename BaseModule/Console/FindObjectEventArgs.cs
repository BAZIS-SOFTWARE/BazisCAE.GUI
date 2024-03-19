using ModelInterfaces;
using System;

namespace BaseModule.Console
{
    internal class FindObjectEventArgs : EventArgs
    {
        public uint Number { get; }
        public ObjType ObjsType { get; }
        public FindObjectEventArgs(string str)
        {
            uint number;

            ObjType objType;
            if(!Enum.TryParse(str.Split(':')[0], out objType))
                throw new Exception("Неизвестный тип объекта!");
            ObjsType = objType;

            if (!uint.TryParse(str.Split(':')[1], out number))
                throw new Exception("Номер должен быть целым положительным числом!");
            Number = number;
        }
    }
}