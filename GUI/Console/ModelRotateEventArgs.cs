using BazisGUI.Properties;
using System;
using System.Globalization;
using System.Numerics;

namespace BazisGUI.Console
{
    public class ModelRotateEventArgs : EventArgs
    {
        public Vector3 Axis { get; }

        public float Angle { get; }

        public ModelRotateEventArgs(string v)
        {
            var strAr = v.Split(':');

            if (strAr.Length < 2)
                throw new Exception(Resources.InvalidCommandException);

            var coords = strAr[0].Split(',');

            if (coords.Length < 3)
                throw new Exception(Resources.InvalidCoordinatesException);

            var x = float.Parse(coords[0].Replace(" ",""), NumberStyles.Float);
            var y = float.Parse(coords[1].Replace(" ", ""), NumberStyles.Float);
            var z = float.Parse(coords[2].Replace(" ", ""), NumberStyles.Float);

            Axis = new Vector3(x,y,z);
            Angle = float.Parse(strAr[1].Replace(" ", ""), NumberStyles.Float);
        }
    }
}