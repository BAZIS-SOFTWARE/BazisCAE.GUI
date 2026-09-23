using Geometry;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public Point3D GetSceneCoordOfScreenVector(float x, float y) =>
            sceneController.GetCamera().GetSceneCoordOfScreenVector(x, y);
    }
}
