using BaseModule.Extensions;
using BaseModule.PropertiesPanel;
using GmshApi;
using Project.Interfaces.Tasks;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void ChangeSurfaceProperty(PropertyChangedEventArgs obj, int number)
        {
            var attributes = gmshController.Gmsh.Model.GetAttribute($"transfinite surface {number}");

            if (attributes.Length == 0)
                attributes = new string[] { Arrangement.Left.ToString(), "" }; // тут записать угловые точки

            if (obj.Header == "Ориентировка")
                attributes[1] = obj.NewValue;
            else if (obj.Header == "Угловые точки")
                attributes[0] = obj.NewValue;


            //gmshController.Gmsh.Model.SetAttribute($"transfinite curve {arg3}", attributes);
            gmshController.Gmsh.Model.SetAttribute($"transfinite surface {number}", attributes);
            //if (!string.IsNullOrEmpty(arg2.Attributes[0]) && !string.IsNullOrEmpty(arg2.Attributes[2]))
            //{

            // записываем трансфиницию поверхности
        }
    }
}
