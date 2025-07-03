using BazisGUI.Scene.Interfaces;
using System.Drawing;

namespace BazisGUI.Scene
{
    /// <summary>
    /// ScaleItem
    /// </summary>
    public class ScaleItem : IScaleItem
    {
        /// <inheritdoc/>
        public Color Color { get; internal set; }
        /// <inheritdoc/>
        public float Min { get; internal set; }
        /// <inheritdoc/>
        public float Max { get; internal set; }
/// <inheritdoc/>

        public override string ToString()
        {
            return $"{Min} {Max} {Color}";
        }
    }
}