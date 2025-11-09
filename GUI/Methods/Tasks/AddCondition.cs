using BaseModule.Extensions;
using BaseModule.Tasks.BasicAdvisorControls.Events;
using Geometry;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using Project.Tasks;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void материалToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                IEnumerable<IGroup> groups;
                if (project.ProjectType == TaskType.Volume)
                    groups = project.GetAllModelGroups().Where(x => x.ObjType == ObjType.Элемент3D);
                else if (project.ProjectType == TaskType.AxiPlain | project.ProjectType == TaskType.Plain)
                    groups = project.GetAllModelGroups().Where(x => x.ObjType == ObjType.Элемент2D);
                else
                    groups = project.GetAllModelGroups().Where(x => x.ObjType == ObjType.Элемент1D);

                if (groups.Count() == 0)
                    throw new Exception("Отсутствуют группы элементов");

                var matDB = project.MaterialsDB;
                if (matDB == null)
                    throw new Exception("Не загружена база физических свойств");
                if (matDB.Count == 0)
                    throw new Exception("База физических свойств пустая");

                var funDB = project.FunctionsDB;
                if (funDB == null)
                    throw new Exception("Не загружена база функций");
                if (funDB.Count == 0)
                    throw new Exception("База функций пустая");

                var matData = new MatData(matDB.First().Value, groups.First(), 0, 1);
                project.TaskData.Add(matData);
                PresentCondDataOnTree();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }

        private void средаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                IEnumerable<IGroup> groups;
                if (project.ProjectType == TaskType.Volume)
                    groups = project.GetAllModelGroups().Where(x => x.ObjType == ObjType.Элемент2D);
                else if (project.ProjectType == TaskType.AxiPlain | project.ProjectType == TaskType.Plain)
                    groups = project.GetAllModelGroups().Where(x => x.ObjType == ObjType.Элемент1D);
                else
                    return;

                if (groups.Count() == 0)
                    throw new Exception("Отсутствуют группы элементов");

                var medData = new MediaData(groups.First(), 0, 1);
                project.TaskData.Add(medData);
                PresentCondDataOnTree();

            }
            catch (Exception)
            {

            }
        }

        private void нагревToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                IEnumerable<IGroup> groups;
                if (project.ProjectType == TaskType.Volume)
                    groups = project.GetAllModelGroups().Where(x => x.ObjType == ObjType.Элемент3D);
                else if (project.ProjectType == TaskType.AxiPlain | project.ProjectType == TaskType.Plain)
                    groups = project.GetAllModelGroups().Where(x => x.ObjType == ObjType.Элемент2D);
                else
                    groups = project.GetAllModelGroups().Where(x => x.ObjType == ObjType.Элемент1D);

                if (groups.Count() == 0)
                    throw new Exception("Отсутствуют группы элементов");

                var heatData = new HeatData(groups.First(), 0, 1);
                project.TaskData.Add(heatData);
                PresentCondDataOnTree();

            }
            catch (Exception)
            {
            }
        }

        private void закреплениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var groups = project.GetAllModelGroups().Where(x => x.ObjType == ObjType.Узел);

                if (groups.Count() == 0)
                    throw new Exception("Отсутствуют группы элементов");

                var clampData = new ClampData(groups.First(), 0, 1);
                project.TaskData.Add(clampData);
                PresentCondDataOnTree();

            }
            catch (Exception)
            {


            }
        }

        private void нагрузкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var groups = project.GetAllModelGroups().Where(x => x.ObjType == ObjType.Узел);

                if (groups.Count() == 0)
                    return;

                var loadData = new LoadData(groups.First(), 0, 1);
                project.TaskData.Add(loadData);
                PresentCondDataOnTree();
            }
            catch (Exception)
            {
            }
        }
       
        public async void AddConditions(AddDataEventArgs arg2)
        {
            try
            {
                if (arg2.DataInfo.Contains("LRF"))
                {
                    foreach (ObjType type in Enum.GetValues(typeof(ObjType)))
                    {
                        project.SetModelObjectsBackColor(type);
                        var pres = project.CreateModelObjectsPresentor(type);
                        SetVBObjectAttribute(pres, "цвет");
                    }

                    DisplayObjects();
                    //SelectedObjects = ObjType.Узел.ToString();

                    var taskStrLRF = CreateSurfaceAsync(project.ModelData, ObjType.Узел);
                    await taskStrLRF;
                    var vec = taskStrLRF.Result.Normal;
                    var nVec = Geometry.Vector.GetVectorNorm(vec);

                    AddDataLRF(nVec, arg2.DataName, arg2.DataInfo);
                }
                else
                {
                    var newData = project.TaskData.Create(arg2.DataName.ToEnum<DataKind>(), arg2.DataInfo, project.ModelData.GroupData);
                    project.TaskData.Add(newData);
                }

                PresentCondDataOnTree();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void AddDataLRF(Point3D vec, string dataName, string dataInfo)
        {
            var dataAr = dataInfo.Split(' ');

            var lrfStr = dataAr.First(x => x.Contains("LRF"));
            var lrfInd = lrfStr.IndexOf("LRF");
            var valStr = dataAr[lrfInd + 1];

            var val = float.Parse(valStr);
            var rVec = vec.Mult(val);

            dataAr[lrfInd] = "X";
            dataAr[lrfInd] = rVec._x.ToString();

            var x_data = project.TaskData.Create(dataName.ToEnum<DataKind>(), string.Join(" ", dataAr), project.ModelData.GroupData);
            project.TaskData.Add(x_data);

            dataAr[lrfInd] = "Y";
            dataAr[lrfInd] = rVec._y.ToString();

            var y_data = project.TaskData.Create(dataName.ToEnum<DataKind>(), string.Join(" ", dataAr), project.ModelData.GroupData);
            project.TaskData.Add(y_data);

            dataAr[lrfInd] = "Z";
            dataAr[lrfInd] = rVec._z.ToString();

            var z_data = project.TaskData.Create(dataName.ToEnum<DataKind>(), string.Join(" ", dataAr), project.ModelData.GroupData);
            project.TaskData.Add(z_data);
        }
    }
}
