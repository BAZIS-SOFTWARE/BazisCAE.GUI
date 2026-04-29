using System;

namespace BazisGUI.Console
{
    public class BeamConnectionEventArgs : EventArgs
    {
        public double Radius { get; }
        public int MaxBeams { get; }

        public string Master { get; }
        public string Slave { get; }

        public BeamConnectionEventArgs(string _radius, string _maxBeams, string v, string v1)
        {
            Master = v;
            Slave = v1;

            double radius;
            if (double.TryParse(_radius, out radius))
                Radius = radius;
            else
                throw new ArgumentException(Localization.Localization.GetStringResourceByName<ConsoleControl>("BeamConnectionEventArgsArgNumExc"), nameof(_radius));
            int maxBeams;
            if (int.TryParse(_maxBeams, out maxBeams))
                MaxBeams = maxBeams;
            else
                throw new ArgumentException(Localization.Localization.GetStringResourceByName<ConsoleControl>("BeamConnectionEventArgsArgNumExc"), nameof(_maxBeams));
        }
    }
}