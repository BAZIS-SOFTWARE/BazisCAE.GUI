using System.Collections.Generic;
using System.Drawing;

namespace BazisGUI.Scene.Interfaces
{
    /// <summary>
    /// ISceneScale
    /// </summary>
    public interface ISceneScale : IEnumerable<IScaleItem>
    {
        /// <summary>
        /// Title
        /// </summary>
        string Title { get; set; }
        /// <summary>
        /// Info
        /// </summary>
        string Info { get; set; }
        /// <summary>
        /// Precision
        /// </summary>
        decimal Precision { get; set; }
        /// <summary>
        /// Intervals
        /// </summary>
        int Intervals { get; set; }
        /// <summary>
        /// GetValueColor
        /// </summary>
        /// <param name="resValue"></param>
        /// <returns></returns>
        Color GetValueColor(float resValue);
        /// <summary>
        /// FillRange
        /// </summary>
        /// <param name="max"></param>
        /// <param name="min"></param>
        /// <param name="intervals"></param>
        void FillRange(float min, float max, decimal intervals);
        /// <summary>
        /// Display
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="g"></param>
        /// <param name="font"></param>
        void Display(int width, int height, Graphics g, Font font);
        /// <summary>
        /// Max
        /// </summary>
        float MaxValue { get; }
        /// <summary>
        /// Min
        /// </summary>
        float MinValue { get; }
        /// <summary>
        /// X coord
        /// </summary>
        int Coord_X { get; set; }
        /// <summary>
        /// Y coord
        /// </summary>
        int Coord_Y { get; set; }
    }
}