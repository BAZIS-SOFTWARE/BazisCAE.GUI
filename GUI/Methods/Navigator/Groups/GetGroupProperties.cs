using BaseModule.PropertiesPanel;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using OpenTK.Graphics.OpenGL;
using static BazisGUI.Methods.PlatformSpecific.PlatformSpecific;
using System.Linq;
using Project.Interfaces.Tasks;

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

            // показываем возможные условия
            //var res = project.TaskData.Find(obj.Name);
            //if (res.Count() == 0)
                if(obj.ObjType != ObjType.Узел)
                    CreateElementsConditionsProperties(obj, rows);
                else
                    CreateNodesConditionsProperties(obj, rows);
            //else
            //    rows.Add(new RowProperty("Условие", res.First().Kind));

            return rows;
        }

        private void CreateNodesConditionsProperties(IGroup obj, List<RowProperty> rows)
        {
                    rows.Add(new RowProperty("Создать условие",
        new DropDownPropertyValue("*",
        new List<string>() {
            DataKind.Закрепление.ToString(),
            DataKind.Среда.ToString(),
            DataKind.Нагрузка.ToString()
        })));                          
        }

        private void CreateElementsConditionsProperties(IGroup obj, List<RowProperty> rows)
        {
            if (project.ProjectType == TaskType.Volume)
            {
                if (obj.ObjType == ObjType.Элемент3D)
                {
                    if (project.ProjectKind == TaskKind.термическая | 
                        project.ProjectKind == (TaskKind.термическая | TaskKind.механическая))
                        rows.Add(new RowProperty("Создать условие",
                        new DropDownPropertyValue("*",
                        new List<string>() {
                            DataKind.Материал.ToString(),
                            DataKind.Нагрев.ToString(),
                        })));
                    else if (project.ProjectKind == TaskKind.механическая)
                        rows.Add(new RowProperty("Создать условие",
                        new DropDownPropertyValue("*",
                        new List<string>() {
                                        DataKind.Материал.ToString()
                        })));
                }

                else if (obj.ObjType == ObjType.Элемент2D)
                    if (project.ProjectKind == TaskKind.термическая |
    project.ProjectKind == (TaskKind.термическая | TaskKind.механическая))
                        rows.Add(new RowProperty("Создать условие",
                        new DropDownPropertyValue("*",
                        new List<string>()
                        {
                            DataKind.Среда.ToString()
                        })));
            }
            else if (project.ProjectType == TaskType.AxiPlain | project.ProjectType == TaskType.Plain)
            {
                if (obj.ObjType == ObjType.Элемент2D)
                    rows.Add(new RowProperty("Создать условие",
                    new DropDownPropertyValue("*",
                    new List<string>()
                    {
                        DataKind.Материал.ToString()
                    })));
                else if (obj.ObjType == ObjType.Элемент1D)
                    if (project.ProjectKind == TaskKind.термическая |
    project.ProjectKind == (TaskKind.термическая | TaskKind.механическая))
                        rows.Add(new RowProperty("Создать условие",
                        new DropDownPropertyValue("*",
                        new List<string>()
                        {
                            DataKind.Материал.ToString(),DataKind.Среда.ToString()
                        })));
                    else if (project.ProjectKind == TaskKind.механическая)
                        rows.Add(new RowProperty("Создать условие",
                        new DropDownPropertyValue("*",
                        new List<string>()
                        {
                            DataKind.Материал.ToString()
                        })));
            }
            else if (project.ProjectType == TaskType.Linear)
            {
                if (obj.ObjType == ObjType.Элемент1D)
                    rows.Add(new RowProperty("Создать условие",
                    new DropDownPropertyValue("*",
                    new List<string>()
                    {
                        DataKind.Материал.ToString()
                    })));
            }
            else
            {
                if (obj.ObjType == ObjType.Элемент1D)
                    rows.Add(new RowProperty("Создать условие",
                    new DropDownPropertyValue("*",
                    new List<string>()
                    {
                        DataKind.Материал.ToString()
                    })));
                else if (obj.ObjType == ObjType.Элемент2D)
                    rows.Add(new RowProperty("Создать условие",
                    new DropDownPropertyValue("*",
                    new List<string>()
                    {
                        DataKind.Материал.ToString(),DataKind.Среда.ToString()
                    })));
                else if (obj.ObjType == ObjType.Элемент3D)
                    rows.Add(new RowProperty("Создать условие",
                    new DropDownPropertyValue("*",
                    new List<string>()
                    {
                        DataKind.Материал.ToString()
                    })));
            }
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