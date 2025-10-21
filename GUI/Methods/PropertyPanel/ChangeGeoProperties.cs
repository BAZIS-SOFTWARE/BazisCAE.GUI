using BaseModule.Extensions;
using BaseModule.PropertiesPanel;
using GmshApi;
using OperationalController;
using Project.Interfaces.Tasks;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void ChangeGeoProperties(PropertyChangedEventArgs obj)
        {
            if (obj.Header == "Мин.размер")
                gmshController.Gmsh.Option.SetNumber("Mesh.MeshSizeMin", double.Parse(obj.NewValue));
            else if (obj.Header == "Макс.размер")
                gmshController.Gmsh.Option.SetNumber("Mesh.MeshSizeMax", double.Parse(obj.NewValue));
            else if (obj.Header == "Алгоритм 2D")
                gmshController.Gmsh.Option.SetNumber("Mesh.Algorithm", (double)obj.NewValue.ToEnum<MeshAlgorithm2D>());
            else if (obj.Header == "Алгоритм 3D")
                gmshController.Gmsh.Option.SetNumber("Mesh.Algorithm3D", (double)obj.NewValue.ToEnum<MeshAlgorithm3D>());

            else if(obj.Header == "Показать узлы на кривых")
            {
                settingsConfig.ShowNodesOnCurves = bool.Parse(obj.NewValue);
                ShowNodesOnCurves(settingsConfig.ShowNodesOnCurves);
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
