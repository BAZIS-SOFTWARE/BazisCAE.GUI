using BazisGUI.Scene.Core.Camera;

namespace BazisGUI.Scene.Core.Capture
{
    public interface IFrameGrabber
    {
        byte[] Capture(Viewport viewport);
    }
}
