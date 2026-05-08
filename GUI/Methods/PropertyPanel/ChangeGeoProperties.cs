using BazisGUI.Extensions;
using BazisGUI.PropertiesPanel;
using GmshApi;
using OperationalController;
using Project.Interfaces.Tasks;
using System;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void ChangeGeoProperties(PropertyChangedEventArgs obj)
        {
            if (Enum.TryParse(obj.Key, out GeoPropertyKeys key))
            {
                switch (key)
                {
                    case GeoPropertyKeys.MinSize:
                        GmshController.Gmsh.Option.SetNumber("Mesh.MeshSizeMin", double.Parse(obj.NewValue));
                        break;
                    case GeoPropertyKeys.MaxSize:
                        GmshController.Gmsh.Option.SetNumber("Mesh.MeshSizeMax", double.Parse(obj.NewValue));
                        break;
                    case GeoPropertyKeys.Algorithm2D:
                        GmshController.Gmsh.Option.SetNumber("Mesh.Algorithm", (double)obj.NewValue.ToEnum<MeshAlgorithm2D>());
                        break;
                    case GeoPropertyKeys.Algorithm3D:
                        GmshController.Gmsh.Option.SetNumber("Mesh.Algorithm3D", (double)obj.NewValue.ToEnum<MeshAlgorithm3D>());
                        break;
                    case GeoPropertyKeys.ScaleCoef:
                        GmshController.Gmsh.Option.SetNumber("Mesh.MeshSizeFactor", double.Parse(obj.NewValue));
                        break;
                    case GeoPropertyKeys.ShowPointsOnCurves:
                        settingsConfig.ShowNodesOnCurves = bool.Parse(obj.NewValue);
                        ShowNodesOnCurves(settingsConfig.ShowNodesOnCurves);
                        break;
                    case GeoPropertyKeys.ShowMeshOnGeneration:
                        settingsConfig.ShowAllMeshWhenGeneration = bool.Parse(obj.NewValue);
                        break;
                }
            }
           
            /*
             * TO DO
             * Реализовать изменение свойств в ядре gmsh для построения сетки
             *  1. мин размер элементов 
             *  gmshController.Gmsh.Option.SetNumber("Mesh.MeshSizeMin", sizes[0]);
                2. макс размер элементов 
            gmshController.Gmsh.Option.SetNumber("Mesh.MeshSizeMax", sizes[1]);
                3. алгоритм построения 2д (делоне,фронтал)
                4. алгоритм построения 3д (делоне,фронтал)
                5. масштаб сетки (element size factor)
             */
        }
    }
}
