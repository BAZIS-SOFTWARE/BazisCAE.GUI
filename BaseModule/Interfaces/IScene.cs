using Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModule.Interfaces
{
    public interface IScene
    {
        void CreateVBObjects(string objType);
        void ChangeViewModeVBObjects(string objName, string objView);

        void ChangeColorsVBObjects(string objName);

        void HideGeometryObj(string geObject);

        void ShowVBObjects(string objName);

        void ShowAllDataOnScene();

        IEnumerable<int> GetSelectedObjects();

        void PresentAllModelObjectsOnScene();

        void ClearAllDataOnScene();

        void DisplayText3D(string info, Color color, Point3D coord);

        void HideText3D();

        void DisplayObjects();

        void CreateScaleObject(int coord_X, int coord_Y, Color[] colors, List<float[]> Values, string title, string comments);


    }
}
