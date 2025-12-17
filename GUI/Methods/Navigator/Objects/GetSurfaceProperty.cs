using BazisGUI.PropertiesPanel;
using GmshApi;
using Model.Interfaces;
using OperationalController.GmshController;
using System.Collections.Generic;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private List<RowProperty> GetSurfaceProperties(int number)
        {
            var rows = new List<RowProperty>();

            rows.Add(new RowProperty("Номер", number, true));

            var attributes = GmshController.GetTransfiniteSurface(number);
            var meshTypes = new List<string>() { "*", "регулярная" };

            if (attributes.Length == 0)
                rows.Add(new RowProperty("Вид сетки",new DropDownPropertyValue("*", meshTypes)));
            else
            {
                rows.Add(new RowProperty("Вид сетки", new DropDownPropertyValue("регулярная", meshTypes)));
                rows.Add(new RowProperty("Угловые точки", attributes[0]));
                rows.Add(new RowProperty("Ориентация ребер", attributes[1]));
                rows.Add(new RowProperty("Квадратизация", GmshController.GetRecombineSurface(number)));
            }

            var numbersCurves = GmshController.Gmsh.Model.Mesh.GetEmbedded(2, number).Where((v, i) => (i & 1) == 1).ToArray();
            var strCurvesNumber = string.Join(",", numbersCurves);
            rows.Add(new RowProperty("Добавленные кривые", strCurvesNumber));

            rows.Add(new RowProperty("Номера точек", new ButtonPropertyValue("Показать",
            () => 
            {
                var all = GmshController.Gmsh.Model.GetAdjacencies(2, number).Item2
                .Select(x => GmshController.Gmsh.Model
                .GetAdjacencies(1, x).Item2);
                
                var distComb =  all.SelectMany(x => x).Distinct().ToArray();
                ShowObjectsNumbers(ObjType.Точка, distComb);
                DisplayObjects();
            })));
            return rows;
        }
    }
}
