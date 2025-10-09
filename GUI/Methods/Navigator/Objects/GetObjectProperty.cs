using BaseModule.PropertiesPanel;
using Model.Interfaces;
using Model.Interfaces.MeshObjects;
using Model.MeshObjects;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private RowProperty GetPointProperty(int number) 
        {
            var dimTags = new int[] { 0, number };
            var meshSize = gmshController.Gmsh.Model.Mesh.GetSizes(dimTags);

            return new RowProperty("Размер элементов", meshSize[0]);
        }

        private List<RowProperty> GetElementProperty(IElement element)
        {
            var nodes = string.Join(";", element.GetVertexes().Select(node => node.Number).ToList());
            var levels = new List<string>() { "1", "2" };
            var rows = new List<RowProperty>
            {
                new RowProperty("Номер", element.Number, true),
                new RowProperty("Порядок элемента", new DropDownPropertyValue(element.Level, levels)),
                new RowProperty("Входящие узлы", nodes, true)
            };

            return rows;
        }

        private List<RowProperty> GetNodeProperty(Node node)
        {
            var coord = node.GetCoordinates();
            var listNumbers = string.Join(";", node.GetElements().Select(element => element.Number).ToList());

            var rows = new List<RowProperty>
            {
                new RowProperty("Номер", node.Number, true),
                new RowProperty("Координата X", node.Position._x),
                new RowProperty("Координата Y", node.Position._y),
                new RowProperty("Координата Z", node.Position._z),
                new RowProperty("Связанные элементы", listNumbers, true)
            };

            return rows;
        }
    }
}
