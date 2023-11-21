using System;

namespace BaseModule.Console
{
    internal class FindObjectEventArgs : EventArgs
    {
        public uint Number { get; }

        public FindObjectEventArgs(string str)
        {
            uint number;
            if (!uint.TryParse(str, out number))
                throw new Exception("Номер должен быть целым положительным числом!");
            Number = number;
        }
    }
}