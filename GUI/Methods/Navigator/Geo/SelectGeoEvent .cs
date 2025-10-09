using BaseModule.Extensions;
using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using GmshApi;
using Model.Interfaces;
using OperationalController;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_SelectGeoEvent()
        {
            try
            {
                if (gmshController.Gmsh == null)
                    return;
                List<RowProperty> rows = new List<RowProperty>();

                var actMinSize = gmshController.Gmsh.Option.GetNumber("Mesh.MeshSizeMin");
                var actMaxSize = gmshController.Gmsh.Option.GetNumber("Mesh.MeshSizeMax");
                var actAlgo2d = gmshController.Gmsh.Option.GetNumber("Mesh.Algorithm");
                var alg2D = actAlgo2d.ToString().ToEnum<MeshAlgorithm2D>();
                var actAlgo3d = gmshController.Gmsh.Option.GetNumber("Mesh.Algorithm3D");
                var alg3D = actAlgo2d.ToString().ToEnum<MeshAlgorithm3D>();
                var actSizeFactor = gmshController.Gmsh.Option.GetNumber("Mesh.MeshSizeFactor");

                var algs2D = Enum.GetValues(typeof(MeshAlgorithm2D)).
                    Cast<MeshAlgorithm2D>().Select(x => x.ToString());
                var algs3D = Enum.GetValues(typeof(MeshAlgorithm3D)).
                    Cast<MeshAlgorithm3D>().Select(x => x.ToString());

                rows.Add(new RowProperty("Мин.размер", actMinSize));
                rows.Add(new RowProperty("Макс.размер", actMaxSize));
                rows.Add(new RowProperty("Алгоритм 2D",new DropDownPropertyValue(alg2D, algs2D.ToList())));
                rows.Add(new RowProperty("Алгоритм 3D",new DropDownPropertyValue(alg3D, algs3D.ToList())));
                rows.Add(new RowProperty("Масштаб. коэфициент", actSizeFactor));
                rows.Add(new RowProperty("Показать узлы на кривых", false));
                rows.Add(new RowProperty("Показать кол-во узлов на кривых", false));
                rows.Add(new RowProperty("Показать названия поверхностей", false));
                propertiesPanel.DrawTable(rows);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }
    }
}
