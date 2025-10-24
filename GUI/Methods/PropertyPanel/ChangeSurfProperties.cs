using BaseModule.Extensions;
using BaseModule.PropertiesPanel;
using GmshApi;
using Model.GeometryObjects;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void ChangeSurfaceProperty(PropertyChangedEventArgs obj, int number,ref bool flag)
        {
            //var attributes = gmshController.Gmsh.Model.GetAttribute($"transfinite surface {number}");

            //if (attributes.Length == 0)
            //attributes = new string[] { Arrangement.Left.ToString(), "" }; // тут записать угловые точки

            if (obj.Header == "Вид сетки")
            {
                flag = true;
                if (obj.NewValue == "регулярная")
                {
                    var surface = (SurfaceFigure)project.GetModelObject(ObjType.Поверхность, number);


                    var pointsNumbs = new List<int>();
                    foreach (var item in surface.CurveNumbers)
                    {
                        var curve = (Curve)project.GetModelObject(ObjType.Кривая, item);
                        foreach (var pointNumb in curve.PointsNumbers)
                            pointsNumbs.Add(pointNumb);
                    }

                    var distinct = pointsNumbs.Distinct();
                    var pointsStr = string.Join(",", distinct);

                    var attributes = new string[] { obj.NewValue, pointsStr, Arrangement.Left.ToString() };
                    gmshController.Gmsh.Model.
                        SetAttribute($"transfinite surface {number}", attributes);
                    
                    //Пока уберем. Добавлять если больше 4 точек - distinct.ToArray()
                    gmshController.Gmsh.Model.Mesh.SetTransfiniteSurface(number, Arrangement.Left);
                    gmshController.Gmsh.Model.Mesh.SetRecombine(2, number);
                }
                else
                {
                    // тут спросить у Николая достаточно ли одной команды для снятия транфиниции объема?
                    gmshController.Gmsh.Model.Mesh.RemoveConstraints(new int[] { 2, number });
                    //удаляем запись из словаря атрибутов
                    gmshController.Gmsh.Model.RemoveAttribute($"transfinite surface {number}");
                }
            }
            else
            {
                var attributes = gmshController.Gmsh.Model.
GetAttribute($"transfinite surface {number}");

                if (obj.Header == "Угловые точки")
                    attributes[1] = obj.NewValue;    
                else if (obj.Header == "Ориентация ребер")
                    attributes[2] = obj.NewValue;  

                gmshController.Gmsh.Model.
       SetAttribute($"transfinite surface {number}", attributes);

                var arrangement = attributes[2].ToEnum<Arrangement>();
                var points = attributes[1].Split(',').Select(x => int.Parse(x));
                gmshController.Gmsh.Model.Mesh.SetTransfiniteSurface(number, arrangement, points.ToArray());
            }
            
        }
    }
}
