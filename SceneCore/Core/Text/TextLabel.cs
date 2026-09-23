using System.Drawing;
using Geometry;

namespace BazisGUI.Scene.Core.Text
{
    public class TextLabel
    {
        public string Text { get; set; }
        public Color Color { get; set; }
        public Point3D Position3D { get; set; }
        public Point2D Position2D { get; set; }
        public bool IsScreenSpace { get; set; }
    }
}
