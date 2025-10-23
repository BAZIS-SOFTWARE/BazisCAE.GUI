using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using GmshApi;
using Model.GeometryObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private List<RowProperty> GetVolProperties(int number)
        {
            var rows = new List<RowProperty>();

            rows.Add(new RowProperty("Номер", number));

            var list = gmshController.Gmsh.Model.Mesh.Field.List();
            var attributes = gmshController.Gmsh.Model.GetAttribute($"transfinite vol {number}");
            var meshTypes = new List<string>() { "*", "градиентная", "регулярная" };


            if (!list.Contains(number))
            {
                if(attributes.Length == 0)
                    rows.Add(new RowProperty("Вид сетки", 
                        new DropDownPropertyValue("*", meshTypes)));
                else
                {
                    //gmshController.Gmsh.Model.SetAttribute($"transfinite vol {number}", 
                        //new string[] { "регулярная" });
                    rows.Add(new RowProperty("Вид сетки",
                        new DropDownPropertyValue(attributes[0], meshTypes)));
                }
            }
            else
            {
                rows.Add(new RowProperty("Вид сетки",
                        new DropDownPropertyValue(attributes[0], meshTypes)));
                rows.Add(new RowProperty("Степень градиента перехода", attributes[1]));
                rows.Add(new RowProperty("Толщина слоя", attributes[2]));
                rows.Add(new RowProperty("Размер элементов на поверхности", attributes[3]));
                rows.Add(new RowProperty("Размер элементов в центре", attributes[4]));
            }

            return rows;
        }      
    }
}
