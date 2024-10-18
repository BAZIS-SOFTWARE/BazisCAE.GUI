using ModelInterfaces;
using System;

namespace BaseModule.Console.Events
{
    public class ModelRenumberEventArgs : EventArgs
    {
        public uint Number { get; }
        public ObjType ObjsType { get; }

        public ModelRenumberEventArgs(string cmd)
        {
            uint number;

            ObjType objType;
            if (!Enum.TryParse(cmd.Split(':')[0], out objType))
                throw new Exception("Неизвестный тип объекта!");
            ObjsType = objType;

            if (!uint.TryParse(cmd.Split(':')[1], out number))
                throw new Exception("Номер должен быть целым положительным числом!");
            Number = number;
        }
    }
}