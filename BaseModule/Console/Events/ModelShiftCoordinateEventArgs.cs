using System;
using System.Globalization;

namespace BaseModule.Console.Events
{
    public class ModelShiftCoordinateEventArgs : EventArgs
    {
        public float X { get; }
        public float Y { get; }
        public float Z { get; }

        public ModelShiftCoordinateEventArgs(string vector)
        {
            var strAr = vector.Split(',');

            if (strAr.Length < 3)
                throw new Exception("Вектор должен содержать три координаты!");
            var X = float.Parse(strAr[0], NumberStyles.Float, CultureInfo.InvariantCulture);
            var Y = float.Parse(strAr[1], NumberStyles.Float, CultureInfo.InvariantCulture);
            var Z = float.Parse(strAr[2], NumberStyles.Float, CultureInfo.InvariantCulture);
        }
    }
}