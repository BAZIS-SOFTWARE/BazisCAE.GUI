using BaseModule.Extensions;
using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BaseModule.Tasks.BasicAdvisorControls.Events;
using BazisGUI.Utilities;
using Geometry;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using Project.Tasks;
using PropertiesCalculator.MaterialData;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_AddConditionEvent(object arg1, NodeName arg2)
        {
            try
            {
                if (arg2 == NodeName.Материал)
                {
                    IEnumerable<IGroup> groups;
                    if (project.ProjectType == TaskType.Volume)
                        groups = project.GetAllModelGroups().Where(x => x.ObjType == ObjType.Элемент3D);
                    else if (project.ProjectType == TaskType.AxiPlain | project.ProjectType == TaskType.Plain)
                        groups = project.GetAllModelGroups().Where(x => x.ObjType == ObjType.Элемент2D);
                    else
                        groups = project.GetAllModelGroups().Where(x => x.ObjType == ObjType.Элемент1D);

                    if (groups.Count() == 0)
                        return;

                    var matDB = GetDataBase<MaterialDBData>(project.MaterialsDB, project.Path);
                    if (matDB == null)
                        return;
                    var mat = matDB.Keys.ToList();
                    if (mat.Count == 0)
                        return;

                    var matData = new MatData(mat.First(), groups.First(), 0, 1);
                    project.TaskData.Add(matData);
                    PresentCondDataOnTree();
                }

                else if (arg2 == NodeName.Закрепление)
                {
                    var groups = project.GetAllModelGroups().Where(x => x.ObjType == ObjType.Узел);

                    if (groups.Count() == 0)
                        return;

                    var clampData = new ClampData(groups.First(), 0, 1);
                    project.TaskData.Add(clampData);
                    PresentCondDataOnTree();
                }

                else if(arg2 == NodeName.Нагрузка)
                {
                    var groups = project.GetAllModelGroups().Where(x => x.ObjType == ObjType.Узел);

                    if (groups.Count() == 0)
                        return;

                    var clampData = new ClampData(groups.First(), 0, 1);
                    project.TaskData.Add(clampData);
                    PresentCondDataOnTree();
                }

                else if (arg2 == NodeName.Среда)
                {
                    IEnumerable<IGroup> groups;
                    if (project.ProjectType == TaskType.Volume)
                        groups = project.GetAllModelGroups().Where(x => x.ObjType == ObjType.Элемент2D);
                    else if (project.ProjectType == TaskType.AxiPlain | project.ProjectType == TaskType.Plain)
                        groups = project.GetAllModelGroups().Where(x => x.ObjType == ObjType.Элемент1D);
                    else
                        return;

                    if (groups.Count() == 0)
                        return;

                    var medData = new MediaData(groups.First(), 0, 1);
                    project.TaskData.Add(medData);
                    PresentCondDataOnTree();
                }
                else
                {
                    IEnumerable<IGroup> groups;
                    if (project.ProjectType == TaskType.Volume)
                        groups = project.GetAllModelGroups().Where(x => x.ObjType == ObjType.Элемент3D);
                    else if (project.ProjectType == TaskType.AxiPlain | project.ProjectType == TaskType.Plain)
                        groups = project.GetAllModelGroups().Where(x => x.ObjType == ObjType.Элемент2D);
                    else
                        groups = project.GetAllModelGroups().Where(x => x.ObjType == ObjType.Элемент1D);

                    if (groups.Count() == 0)
                        return;

                    var heatData = new HeatData(groups.First(), 0, 1);
                    project.TaskData.Add(heatData);
                    PresentCondDataOnTree();
                }

                //System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
                //var generalForm = new Form
                //{
                //    Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon"))),
                //    Text = "Инструмент создания физических данных",
                //    AutoSize = true,
                //    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                //    FormBorderStyle = FormBorderStyle.FixedSingle,
                //    MaximizeBox = false,
                //    MinimizeBox = false
                //};

                //var elLoadGrpsNames = GetLoadGroupsNames(project.ProjectType, project.ModelData);
                //var ndGrpsNames = project.ModelData.GroupData.FindMany(ObjType.Узел).Select(x => x.Name).ToList();

                //var appFolder = Path.GetDirectoryName(Application.ExecutablePath);
                //if (appFolder == project.Path)
                //{
                //    MessageBox.Show("Рабочая папка проекта должна отличаться от папки установки программы!");
                //    return;
                //}
                //var matDB = GetDataBase<MaterialDBData>(project.MaterialsDB, project.Path);
                //var funDB = GetDataBase<FunctionDBData>(project.FunctionsDB, project.Path);

                //if (matDB == null || funDB == null)
                //{
                //    console.PrintInfo("Не выбран источник базы данных!", Color.Red);
                //    return;
                //}
                //var mat = matDB.Keys.ToList();
                //var func = funDB.Keys.ToList();

                //var generalControlCreator = new GeneralСontrol(arg2.ToString(), mat, func, elLoadGrpsNames, ndGrpsNames);
                //generalControlCreator.CreatePhysicalDataEvent += (arg) => { AddConditions(arg); };
                ////generalControlCreator.CreatePhysicalDataEvent += (s) => generalForm.Close();
                //generalForm.Controls.Add(generalControlCreator);
                //generalForm.Show(this);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
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
                    SelectedObjects = ObjType.Узел.ToString();

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
