using BazisGUI.PropertiesPanel;
using Model.Interfaces;
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

            var attributes = GmshController.GetTransfiniteSurface(number);//GmshController.Gmsh.Model.GetAttribute($"transfinite surface {number}");
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
            // TODO Продолжить после завершения работ Николая
            // Если кривых нет , то поле пустое. Если есть то узнать список кривых и вывести через запятую
            rows.Add(new RowProperty("Добавленные кривые", string.Empty));
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
