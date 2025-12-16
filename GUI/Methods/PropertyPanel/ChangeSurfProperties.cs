using BazisGUI.Extensions;
using BazisGUI.PropertiesPanel;
using GmshApi;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void ChangeSurfaceProperty(PropertyChangedEventArgs obj, int number, ref bool flag)
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
            else if (obj.Header == "Добавленные кривые")
            {
                if(obj.OldValue != "")
                    GmshController.Gmsh.Model.Mesh.RemoveEmbedded([2, number]);
                
                var tags = GetArray(obj.NewValue);
                if ( tags != null)
                    GmshController.Gmsh.Model.Mesh.Embed(1, tags, 2, number);
            }
            else
            {
                var attributes = GmshController.GetTransfiniteSurface(number);
                if (obj.Header == "Квадратизация") 
                {
                    if (bool.Parse(obj.NewValue))
                        project.GmshController.SetRecombineSurface(number);
                    else
                    {
                        GmshController.Gmsh.Model.Mesh.RemoveConstraints(new int[] { 2, number });
                        GmshController.Gmsh.Model.RemoveAttribute($"recombine surface {number}");
                    }
                }
                else if (obj.Header == "Угловые точки")
                {
                    attributes[0] = obj.NewValue;
                }

                else if (obj.Header == "Ориентация ребер")
                {
                    attributes[1] = obj.NewValue;
                }
                var arrangement = attributes[1].ToEnum<Arrangement>();
                var points = attributes[0].Split(',').Select(x => int.Parse(x));

                project.GmshController.SetTransfiniteSurface(number, arrangement, points.ToArray());
            }
            

            int[] GetArray(string data)
            {
                var arrayStr = data.Split(',');
                int[] tags = arrayStr.Where(s => int.TryParse(s, out _)).Select(int.Parse).ToArray();
                return tags;
            }
        }
    }
}
