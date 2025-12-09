using System;
using System.Linq;
using Model.Interfaces;
using System.Drawing;
using BazisGUI.Navigator;
using ResultDB.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using UserControlsEx.Graph;
using Geometry;
using Model.MeshObjects;

namespace BazisGUI
{
    public partial class BaseForm
    {
   
        private async void console_NodesShiftCoordinate()
        {
            try
            {
                // выбор объектов
                var message = $@"Выберите первый узел и нажмите на клавишу ""E"" для подтверждения или клавишу ""ESC"" для отмены";
                var firstRes = await SelectObjectAsync(ObjType.Узел, message);
                var fNode = firstRes as Node;

                var set = project.GetModelSetInfo(ObjType.Узел, fNode.Number);
                set.SetBackColor();

                var pres = project.CreateModelObjectsPresentor(set);
                if (pres != null)
                    SetVBObjectAttribute(pres, "цвет");

                message = $@"Выберите второй узел и нажмите на клавишу ""E"" для подтверждения или клавишу ""ESC"" для отмены";
                var secondRes = await SelectObjectAsync(ObjType.Узел, message);
                var sNode = secondRes as Node;

                set = project.GetModelSetInfo(ObjType.Узел, sNode.Number);
                set.SetBackColor();

                pres = project.CreateModelObjectsPresentor(set);
                if (pres != null)
                    SetVBObjectAttribute(pres, "цвет");

                await SelectContainerAsync(@"Выберите узлы для перемещения и нажмите на клавишу ""E"" для подтверждения");

                var nodes = project.GetAllModelNodes().
    Where(x => x.Color == settingsConfig.SelectObjectColor);

                if (nodes.Count() == 0)
                    throw new Exception("Не выбран ни один узел");
                
                var vec = sNode.Position.Sub(fNode.Position);

                ChangeCoordinates(nodes, vec);

                ClearAllDataOnScene();
                CreateVBObjects("Объекты");

                DisplayObjects();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private static void ChangeCoordinates(IEnumerable<Node> nodes, Point3D vec)
        {
            foreach (var node in nodes)
            {
                var temp = node.Position.Sum(vec);
                node.Position._x = temp._x;
                node.Position._y = temp._y;
                node.Position._z = temp._z;
            }
        }
    }
}
