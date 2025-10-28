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
            //var attributes = gmshController.Gmsh.Model.GetAttribute($"transfinite surface {number}");

            //if (attributes.Length == 0)
            //attributes = new string[] { Arrangement.Left.ToString(), "" }; // тут записать угловые точки

            if (obj.Header == "Вид сетки")
            {
                flag = true;
                if (obj.NewValue == "регулярная")
                {
                    project.GmshController.SetTransfiniteSurface(number);

                    //var surface = (SurfaceFigure)project.GetModelObject(ObjType.Поверхность, number);


                    //var pointsNumbs = new List<int>();
                    //foreach (var item in surface.CurveNumbers)
                    //{
                    //    var curve = (Curve)project.GetModelObject(ObjType.Кривая, item);
                    //    foreach (var pointNumb in curve.PointsNumbers)
                    //        pointsNumbs.Add(pointNumb);
                    //}

                    //var distinct = pointsNumbs.Distinct();
                    //var pointsStr = string.Join(",", distinct);

                    //var attributes = new string[] { pointsStr, Arrangement.Left.ToString() };
                    //GmshController.Gmsh.Model.
                    //    SetAttribute($"transfinite surface {number}", attributes);
                    
                    ////Пока уберем. Добавлять если больше 4 точек - distinct.ToArray()
                    //GmshController.Gmsh.Model.Mesh.SetTransfiniteSurface(number, Arrangement.Left);
                    //GmshController.Gmsh.Model.Mesh.SetRecombine(2, number);
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
                var attributes = GmshController.GetTransfiniteSurface(number);
                //var attributes = GmshController.Gmsh.Model.
                //GetAttribute($"transfinite surface {number}");

                if (obj.Header == "Угловые точки")
                    attributes[0] = obj.NewValue;    
                else if (obj.Header == "Ориентация ребер")
                    attributes[1] = obj.NewValue;  

       //         GmshController.Gmsh.Model.
       //SetAttribute($"transfinite surface {number}", attributes);

                var arrangement = attributes[1].ToEnum<Arrangement>();
                var points = attributes[0].Split(',').Select(x => int.Parse(x));

                project.GmshController.SetTransfiniteSurface(number, arrangement, points.ToArray());
                //GmshController.Gmsh.Model.Mesh.SetTransfiniteSurface(number, arrangement, points.ToArray());
            }
            
        }
    }
}
