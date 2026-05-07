using BazisGUI.Extensions;
using BazisGUI.PropertiesPanel;
using GmshApi;
using Model.GeometryObjects;
using OperationalController;
using OperationalController.GmshController;
using Project.Interfaces.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void ChangeVolProperty(PropertyChangedEventArgs obj, int number, ref bool flag)
        {
            // Тут задаем настройки сетки в объемах геометрии
            if (Enum.TryParse(obj.Key, out VolumePropertyKeys key))
            {
                if (key == VolumePropertyKeys.MeshType)
                {
                    var value = Enum.Parse<VolGenMeshTypes>(obj.NewValue);
                    flag = true;
                    if (value == VolGenMeshTypes.Regular)
                        GmshController.SetTransfiniteVolume(number);

                    else if (value == VolGenMeshTypes.Gradient)
                        GmshController.SetGradientVolume(number, 1, 1, 1, 10);

                    else
                        RemoveTransfition(number);
                }

                else
                {
                    var attributes = GmshController.GetTransfiniteVolume(number);

                    if (key == VolumePropertyKeys.TransitionGradientDegree)
                        attributes[1] = obj.NewValue;

                    else if (key == VolumePropertyKeys.LayerThickness)
                        attributes[2] = obj.NewValue;

                    else if (key == VolumePropertyKeys.SurfaceElementsSize)
                        attributes[3] = obj.NewValue;

                    else if (key == VolumePropertyKeys.CenterElementsSize)
                        attributes[4] = obj.NewValue;

                    var power = double.Parse(attributes[1]);
                    var distMax = double.Parse(attributes[2]);
                    var surfSize = double.Parse(attributes[3]);
                    var coreSize = double.Parse(attributes[4]);

                    GmshController.SetGradientVolume(number, power, distMax, surfSize, coreSize);
                }
            }
        }

        private void DelMeshGradientSettings(int number)
        {
            GmshController.Gmsh.Model.Mesh.Field.Remove(number);

            // TODO переписать так чтобы снимались ограничения только с узлов объема
            var points = GmshController.Gmsh.Model.GetEntities(0);
            GmshController.Gmsh.Model.Mesh.RemoveConstraints(points);
            GmshController.Gmsh.Option.SetNumber("Mesh.MeshSizeExtendFromBoundary", 1);
        }

        private void RemoveTransfition(int number)
        {
            // тут спросить у Николая достаточно ли одной команды для снятия транфиниции объема?
            GmshController.Gmsh.Model.Mesh.RemoveConstraints(new int[] { 3, number });
            //удаляем запись из словаря атрибутов
            GmshController.Gmsh.Model.RemoveAttribute($"transfinite vol {number}");
            // удаление фильтра градиентной сетки
            DelMeshGradientSettings(number);
        }
    }
}
