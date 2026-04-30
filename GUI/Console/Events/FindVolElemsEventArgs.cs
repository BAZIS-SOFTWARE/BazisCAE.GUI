using BazisGUI.Properties;
using System;

namespace BazisGUI.Console.Events
{
    public class FindVolElemsEventArgs : EventArgs
    {
        public double Volume { get; }

        public FindVolElemsEventArgs(string v)
        {
            double volume;
            if (double.TryParse(v, out volume))
                Volume = volume;
            else
                throw new ArgumentException(Resources.InvalidArgumentsNumberException, nameof(v));
        }
    }
}