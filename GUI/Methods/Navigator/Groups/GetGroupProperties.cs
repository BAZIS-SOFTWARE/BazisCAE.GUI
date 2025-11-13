using BaseModule.PropertiesPanel;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using OpenTK.Graphics.OpenGL;
using static BazisGUI.Methods.PlatformSpecific.PlatformSpecific;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public List<RowProperty> GetGroupProperty(IGroup obj)
        {
            var rows = new List<RowProperty>();

            rows.Add(new RowProperty("Имя", obj.Name));

            if (obj.ObjType == ObjType.Узел)
            {
                rows.Add(new RowProperty("Сортировка",
    new ButtonPropertyValue("Отсортировать",
    new Action(() => { obj.SortByDistance(); }))));
                rows.Add(new RowProperty("Направление",
                    new ButtonPropertyValue("Показать",
                    new Action(async () => { await ShowDirection(obj); }))));
                rows.Add(new RowProperty("Направление",
    new ButtonPropertyValue("Реверс",
    new Action(() => { obj.Reverse(); }))));
            }    
            else
            {
                rows.Add(new RowProperty("Узлы элементов",
    new ButtonPropertyValue("Показать",
    new Action(() => { ShowGroupWithNodes(obj); }))));
            }


            return rows;
        }

        private async Task ShowDirection(IGroup group)
        {
            foreach (var item in group)
            {
                DisplayGeometryObjectEvent = null;
                DisplayGeometryObjectEvent += new Action(() =>
                {
                    var quadObj = gluNewQuadric(); // создаем новый объект
                                                       // для создания сфер и цилиндров
                                                       //Glu.gluQuadricOrientation(quadObj, Glu.GLU_OUTSIDE);
                    GL.PushMatrix();
                    GL.PolygonMode(TriangleFace.FrontAndBack, PolygonMode.Fill);
                    GL.Color3(1f, 0, 0);
                    GL.Translate(-Position._x, -Position._y, -Position._z);

                    GL.Translate(item._x, item._y, item._z);


                    //Glu.gluQuadricDrawStyle(quadObj, Glu.GLU_FILL); // устанавливаем
                    gluSphere(quadObj, 1.5, 10, 10); // рисуем сферу
                                                         // радиусом 0.5
                    GL.PopMatrix();
                    gluDeleteQuadric(quadObj);
                });
                DisplayObjects();
                Thread.Sleep(500);
            }
        }
    }
}