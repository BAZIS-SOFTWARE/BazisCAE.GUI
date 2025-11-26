using BaseModule.Extensions;
using BaseModule.PropertiesPanel;
using GmshApi;
using Model.GeometryObjects;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using System.Collections.Generic;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void ChangeSurfaceProperty(PropertyChangedEventArgs obj, int number,ref bool flag)
        {
            //var attribut = GmshController.Gmsh.Model.GetAttribute($"transfinite surface {number}");

            //if (attributes.Length == 0)
            //attributes = new string[] { Arrangement.Left.ToString(), "" }; // тут записать угловые точки

            if (obj.Header == "Вид сетки")
            {
                flag = true;
                if (obj.NewValue == "регулярная")
                {
                    var surfPoints = project.GmshController.GetSurfaceNodes(number);
                    project.GmshController.SetTransfiniteSurface(number, Arrangement.Left, surfPoints);
                }
                else
                {
                    // тут спросить у Николая достаточно ли одной команды для снятия транфиниции объема?
                    GmshController.Gmsh.Model.Mesh.RemoveConstraints(new int[] { 2, number });
                    //удаляем запись из словаря атрибутов
                    GmshController.Gmsh.Model.RemoveAttribute($"transfinite surface {number}");
                }
            }
            else
            {
                if(obj.Header == "Квадратизация")
                    if(bool.Parse(obj.NewValue))
                        project.GmshController.SetRecombineSurface(number);
                    else
                    {
                        GmshController.Gmsh.Model.Mesh.RemoveConstraints(new int[] { 2, number });
                        GmshController.Gmsh.Model.RemoveAttribute($"recombine surface {number}");
                    }

                var attributes = GmshController.GetTransfiniteSurface(number);

                if (obj.Header == "Угловые точки")
                    attributes[0] = obj.NewValue;    
                else if (obj.Header == "Ориентация ребер")
                    attributes[1] = obj.NewValue;  

                var arrangement = attributes[1].ToEnum<Arrangement>();
                var points = attributes[0].Split(',').Select(x => int.Parse(x));

                project.GmshController.SetTransfiniteSurface(number, arrangement, points.ToArray());
                //GmshController.Gmsh.Model.Mesh.SetTransfiniteSurface(number, arrangement, points.ToArray());
            }
            
        }
    }
}
