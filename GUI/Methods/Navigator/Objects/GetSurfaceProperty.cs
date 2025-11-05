using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using GmshApi;
using Model.Interfaces;
using OperationalController;
using System.Collections.Generic;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private List<RowProperty> GetSurfaceProperties(int number)
        {
            var rows = new List<RowProperty>();

            rows.Add(new RowProperty("Номер", number));

            var attributes = GmshController.GetTransfiniteSurface(number);//GmshController.Gmsh.Model.GetAttribute($"transfinite surface {number}");
            var meshTypes = new List<string>() { "*", "регулярная" };

            if (attributes.Length == 0)
                rows.Add(new RowProperty("Вид сетки",
                    new DropDownPropertyValue("*", meshTypes)));
            else
            {
                //gmshController.Gmsh.Model.SetAttribute($"transfinite vol {number}", 
                //new string[] { "регулярная" });
                rows.Add(new RowProperty("Вид сетки",
                    new DropDownPropertyValue("регулярная", meshTypes)));

                rows.Add(new RowProperty("Угловые точки", attributes[0]));
                rows.Add(new RowProperty("Ориентация ребер", attributes[1]));
            }

            rows.Add(new RowProperty("Номера точек", new ButtonPropertyValue("Показать",
    () => {
        var all = GmshController.Gmsh.Model.GetAdjacencies(2, number).Item2
        .Select(x => GmshController.Gmsh.Model.GetAdjacencies(1, x).Item2);

        var distComb =  all.SelectMany(x => x).Distinct().ToArray();

        ShowObjectsNumbers(ObjType.Точка, distComb);
        DisplayObjects();
    })));
            //controller.Gmsh.Model.Mesh.SetTransfiniteSurface(1);

            // TO DO добавть два свойства классу SurfaceFigure
            // - IsTransfinite (опция)
            // - Угловые точки (строка - редактируемая)
            // - IsRecombine (checkBox)
            // - снять все ограничения (если значение - *)

            return rows;
        }
    }
}
