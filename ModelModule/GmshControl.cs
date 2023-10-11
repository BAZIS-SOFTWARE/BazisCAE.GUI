using GmshApi.GmshController;
using GmshApi.GmshKernel;
//using GmshApi.Api;
using Model;
using Model.Interfaces;
using ModelController.ModelScenePresentator;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using SceneInterface;
using Project.TasksData;
using System.Collections.Generic;
using Project.Interfaces;
using MathNet.Numerics.Distributions;
using System.Collections.ObjectModel;
using MathNet.Numerics;

namespace ModelModule
{
    public partial class GmshControl : UserControl
    {
        private GmshController controller;
        private int boundFieldTag;
        private int boundViewTag;
       
        private ModelData modelData;
        private TreeNode selectedNode;

        public event Action<ModelData> updateModelData;
        public event Action<string> showErrorMessage;
        public event Action<bool, string[]> redrawScene;

        private string CurrentModel { get; set; }


        public GmshControl()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            controller = new GmshController(@"..\..\..\..\packages\gmsh.dll");
            modelData = new ModelData();
            algoChoice.SelectedIndex = 3;
        }

        private void ShowHideGeometryControls(bool show) => geoDelBtn.Enabled = geoElBox.Enabled = filterBox.Enabled = show;

        private void ShowHideMeshControls(bool show) => meshDelBtn.Enabled = meshElBox.Enabled = 
                                                        meshOpBox.Enabled = elemDelBtn.Enabled = show;

        private void ShowHideVolumeControls(bool show) => delVolBtn.Enabled = volElBox.Enabled = show;
        private void ShowHideMeshBox(bool show) => meshGenBox.Enabled = show;
        private void ShowHideVolumeBox(bool show) => volumeBox.Enabled = show;
        private void GenerateGeometry(bool fitOnScreen = true)
        {
            var ierr = 0;
            modelData.Clear();
            controller.gmshModelMeshGenerate(1, ref ierr);
            if (ierr == 1)
                showErrorMessage.Invoke("Ошибка при генерации геометрии, проверьте файл-скрипт");
            else if(FillModelDataGeometry())
            {
                ClearGeometryTree();
                ClearMeshTree();
                ClearVolumesTree();
                FillGeometryTreeView();
                ShowHideGeometryControls(true);
                ShowHideMeshBox(true);
                ShowHideMeshControls(false);
                ShowHideVolumeBox(false);
                ShowHideVolumeControls(false);
                redrawScene.Invoke(fitOnScreen, new string[] { "Узлы", "Элементы1D" });
            }
        }

        private void UpdateMesh()
        {
            if (FillModelDataMesh())
            {
                var ierr = 0;
                ClearVolumesTree();
                ClearMeshTree();
                FillMeshTreeView();
                ShowHideMeshControls(true);
                var dim = controller.gmshModelGetDimension(ref ierr);
                if (dim > 2)
                {
                    ShowHideVolumeBox(true);
                    ShowHideVolumeControls(false);
                }
                redrawScene?.Invoke(false, new string[] { "Узлы", "Элементы1D", "Элементы2D" });
            }
        }

        private void UpdateVolumes()
        {
            if (FillModelDataVolumes())
            {
                ClearVolumesTree();
                FillVolumesTreeView();
                ShowHideVolumeControls(true);
                redrawScene?.Invoke(false, new string[] { "Узлы", "Элементы1D", "Элементы2D", "Элементы3D" });
            }
        }

        private void RemoveGeometry()
        {
            var ierr = 0;
            controller.gmshModelMeshClear(new int[0], IntPtr.Zero, ref ierr);
            modelData.Clear();
            updateModelData?.Invoke(modelData);
            ClearAllTrees();
            ShowHideGeometryControls(false);
            ShowHideVolumeBox(false);
            ShowHideMeshBox(false);
            redrawScene?.Invoke(false, new string[0]);
            controller.gmshModelRemove(ref ierr);
            if (ierr == 1)
                showErrorMessage?.Invoke("Ошибка при удалении модели, невозможно удалить модель");
        }

        private void GenerateMesh()
        {
            var ierr = 0;
            controller.gmshModelMeshGenerate(1, ref ierr);
            controller.gmshModelMeshGenerate(2, ref ierr);
            if (ierr == 1)
                showErrorMessage?.Invoke("Ошибка при генерации сетки, проверьте настройки и фильтры геометрии");
            else
                UpdateMesh();
        }

        private void GenerateVolumes()
        {
            var ierr = 0;
            controller.gmshModelMeshGenerate(3, ref ierr);
            if (ierr == 1)
                showErrorMessage?.Invoke("Ошибка при генерации сетки, проверьте настройки и фильтры геометрии");
            else
                UpdateVolumes();
        }

        private void OnDeleteGeometry(object sender, EventArgs e) => RemoveGeometry();

        private void OnDeleteMesh(object sender, EventArgs e)
        {
            var ierr = 0;
            controller.gmshModelMeshClear(new int[] { 3, -1 }, (IntPtr) 2, ref ierr);
            controller.gmshModelMeshClear(new int[] { 2, -1 }, (IntPtr)2, ref ierr);
            int[] dimTags;
            modelData.ObjectData.RemoveRange("Узлы");
            modelData.ObjectData.RemoveRange("Элементы2D");
            modelData.ObjectData.RemoveRange("Элементы3D");
            if (controller.ModelGetGeometryEntities(out dimTags, 0))
                modelData.ObjectData.AddRange(controller.CreateGeometryEntities(ObjKind.Point, dimTags));
            updateModelData?.Invoke(modelData);
            ShowHideMeshBox(true);
            ShowHideMeshControls(false);
            ShowHideVolumeBox(false);
            ShowHideVolumeControls(false);
            redrawScene.Invoke(false, new string[] { "Узлы", "Элементы1D" });
        }

        private void OnDeleteVolume(object sender, EventArgs e) => GenerateMesh();

        private bool FillModelDataGeometry()
        {
            int[] dimTags;
            List<ModelObject> cPoints, curves;
            if (controller.ModelGetGeometryEntities(out dimTags, 0))
                cPoints = controller.CreateGeometryEntities(ObjKind.Point, dimTags);
            else
            {
                showErrorMessage.Invoke("Ошибка, невозможно получить контрольные точки, проверьте файл-скрипт");
                return false;
            }
            if (controller.ModelGetGeometryEntities(out dimTags, 1))
                curves = controller.CreateGeometryEntities(ObjKind.Curve, dimTags);
            else
            {
                showErrorMessage.Invoke("Ошибка, невозможно получить кривые, проверьте файл-скрипт");
                return false;
            }
            modelData.ObjectData.RemoveRange("Узлы");
            modelData.ObjectData.RemoveRange("Элементы1D");
            modelData.ObjectData.AddRange(cPoints);
            modelData.ObjectData.AddRange(curves);
            updateModelData?.Invoke(modelData);
            return true;
        }

        private bool FillModelDataMesh()
        {
            var status = true;
            var nodesData = controller.GetNodes(ref status);
            if (!status)
            {
                showErrorMessage.Invoke("Ошибка, невозможно получить узлы модели");
                return status;
            }
            var meshData = controller.GetMeshEntities(2, -1, ref status);
            if (!status)
            {
                showErrorMessage.Invoke("Ошибка, невозможно получить Элементы2D модели");
                return status;
            }
            modelData.ObjectData.RemoveRange("Узлы");
            modelData.ObjectData.RemoveRange("Элементы2D");
            modelData.ObjectData.AddRange(nodesData);
            modelData.ObjectData.AddRange(meshData);
            updateModelData?.Invoke(modelData);
            return true;
        }

        private bool FillModelDataVolumes()
        {
            var status = true;
            var nodes = controller.GetNodes(ref status);
            if (!status)
            {
                showErrorMessage.Invoke("Ошибка, невозможно получить узлы модели");
                return status;
            }
            var volumesData = controller.GetMeshEntities(3,-1, ref status);
            if (!status)
            {
                showErrorMessage.Invoke("Ошибка, невозможно получить Элементы3D модели");
                return status;
            }
            modelData.ObjectData.RemoveRange("Узлы");
            modelData.ObjectData.RemoveRange("Элементы3D");
            modelData.ObjectData.AddRange(nodes);
            modelData.ObjectData.AddRange(volumesData);
            updateModelData?.Invoke(modelData);
            return status;
        }

        private void ClearGeometryTree() => entTree.Nodes.Clear();
        private void ClearMeshTree() => elemsTree.Nodes.Clear();
        private void ClearVolumesTree() => volumesTree.Nodes.Clear();

        private void ClearAllTrees()
        {
            ClearVolumesTree();
            ClearMeshTree();
            ClearGeometryTree();
        }

        private void OnLoadFile(object sender, EventArgs e)
        {
            if (loadFileDialog.ShowDialog() == DialogResult.OK)
            {
                var ierr = 0;
                controller.gmshOpen(loadFileDialog.FileName, ref ierr);
                if (ierr == 1)
                    showErrorMessage.Invoke("Файл не найден");
                GenerateGeometry();
                //geometry = new GeometryObject(loadFileDialog.FileName);
                //geometry.RemoveField(field);
                //field = new MeshField(MeshFieldType.BoundaryLayer);
                //GenerateGeometry();
            }
        }

        private void OnGenerateMesh(object sender, EventArgs e) => GenerateMesh();
        private void OnGenerateVolume(object sender, EventArgs e) => GenerateVolumes();

        private void OnDencityChange(object sender, EventArgs e)
        {
            var ierr = 0;
            var result = 0.0;
            if (Double.TryParse(meshDensityValue.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
            {
                controller.gmshOptionSetNumber("Mesh.MeshSizeFactor", result, ref ierr);
                if(ierr == 1)
                    showErrorMessage.Invoke("Ошибка, невозможно установить заданую плотность сетки");
            }
        }

        private void OnAlgorithmChoice(object sender, EventArgs e)
        {
            var ierr = 0;
            var choice = sender as ComboBox;
            var algo = new double[] { 1, 2, 5, 6, 8 };
            controller.gmshOptionSetNumber("Mesh.Algorithm", algo[choice.SelectedIndex], ref ierr);
            if (ierr == 1)
                showErrorMessage.Invoke("Ошибка, невозможно установить заданый алгоритм");
        }

        private void OnRefine(object sender, EventArgs e)
        {
            var ierr = 0;
            controller.gmshModelMeshRefine(ref ierr);
            if (ierr == 1)
                showErrorMessage.Invoke("Ошибка, невозможно уплотнить сетку");
            else
            {
                controller.gmshModelMeshClear(new int[] { 3, -1 }, (IntPtr)2, ref ierr);
                if (FillModelDataMesh())
                {
                    ClearVolumesTree();
                    ClearMeshTree();
                    FillMeshTreeView();
                    ShowHideVolumeControls(false);
                    redrawScene?.Invoke(false, new string[] { "Узлы", "Элементы1D", "Элементы2D" });
                }
            }
        }

        private void OnQuadrangulate(object sender, EventArgs e)
        {
            var ierr = 0;
            controller.gmshModelMeshRecombine(ref ierr);
            if (ierr == 1)
                showErrorMessage.Invoke("Ошибка, невозможно трансформировать сетку");
            else
            {
                controller.gmshModelMeshClear(new int[] { 3, -1 }, (IntPtr)2, ref ierr);
                if (FillModelDataMesh())
                {
                    ClearVolumesTree();
                    ClearMeshTree();
                    FillMeshTreeView();
                    ShowHideVolumeControls(false);
                    redrawScene?.Invoke(false, new string[] { "Узлы", "Элементы1D", "Элементы2D" });
                }
            }
        }

        private void FillGeometryTreeView()
        {
            entTree.Nodes.Clear();
            int[] dimTags;
            controller.ModelGetGeometryEntities(out dimTags, 0);
            for (var i = 1; i < dimTags.Length; i += 2)
            {
                if (dimTags[i - 1] == 0)
                    AddTreeNode(entTree.Nodes, "Контрольные узлы", "Контрольный узел " + dimTags[i].ToString());
                else if (dimTags[i - 1] == 1)
                    AddTreeNode(entTree.Nodes, "Кривые", "Кривая " + dimTags[i].ToString());
                else if (dimTags[i - 1] == 2)
                    AddTreeNode(entTree.Nodes, "Поверхности", "Поверхность " + dimTags[i].ToString());
                else if (dimTags[i - 1] == 3)
                    AddTreeNode(entTree.Nodes, "Объемы", "Объем " + dimTags[i].ToString());
            }
        }

        private bool FillMeshTreeView()
        {
            int[] dimTags;
            controller.ModelGetGeometryEntities(out dimTags, 2);
            int[] elementTypes;
            long[][] elementTags, nodeTags;
            for (var i = 1; i < dimTags.Length; i += 2)
            {
                if(!controller.ModelMeshGetElements(2, dimTags[i], out elementTypes, out elementTags, out nodeTags))
                {
                    showErrorMessage.Invoke($"Ошибка, невозможно получить информацию об элементе {dimTags[i]}");
                    return false;
                }
                var surfKey = "Поверхности";
                var surfChild = "Поверхность " + dimTags[i].ToString();
                AddTreeNode(elemsTree.Nodes, surfKey, surfChild);
                var currentSurface = elemsTree.Nodes[surfKey].Nodes[surfChild];
                for (var j = 0; j < elementTypes.Length; ++j)
                {
                    string elemKey, elemChild;
                    DetectMeshElement(elementTypes[j], out elemKey, out elemChild);
                    var elements = elementTags[j];
                    var nodesCount = elementTypes[j] + 1;
                    for (var k = 0L; k < elements.Length; ++k)
                    {
                        var elemTag = elements[k];
                        var currentElement = elemChild + elemTag.ToString();
                        AddTreeNode(currentSurface.Nodes, elemKey, currentElement);
                        var currentType = currentSurface.Nodes[elemKey].Nodes[currentElement];
                        for (var l = 0; l < nodesCount; ++l)
                        {
                            var nodeTag = "Узел " + nodeTags[j][k * nodesCount + l].ToString();
                            currentType.Nodes.Add(nodeTag, nodeTag);
                        }
                    }
                }
            }
            return true;
        }

        private void DetectMeshElement(int element, out string key, out string child)
        {
            if (element == 2)
            {
                key = "Треугольники";
                child = "Треугольник ";
            }
            else
            {
                key = "Квады";
                child = "Квад ";
            }
        }

        private void FillVolumesTreeView()
        {
            foreach (var data in modelData.ObjectData)
            {
                if (data.ObjKind == ObjKind.Tetra)
                    AddTreeNode(volumesTree.Nodes, "Тетраэдры", "Тетраэдр " + data.Number.ToString());
                else if (data.ObjKind == ObjKind.Hexa)
                    AddTreeNode(volumesTree.Nodes, "Гексаэдры", "Гексаэдр " + data.Number.ToString());
                else if (data.ObjKind == ObjKind.Penta)
                    AddTreeNode(volumesTree.Nodes, "Пирамиды", "Пирамида " + data.Number.ToString());
            }
        }

        private void AddTreeNode(TreeNodeCollection tree, string key, string childInfo)
        {
            if (!tree.ContainsKey(key))
                tree.Add(key, key);
            tree[key].Nodes.Add(childInfo, childInfo);
        }

        private void OnTreeChange(object sender, TreeViewEventArgs e)
        {
            var treeView = sender as TreeView;
            selectedNode = e.Node;
            if (treeView.Tag.ToString().Contains("entTree"))
            {
                var keyInfo = selectedNode.Text.Split(' ');
                pointsControlBox.Enabled = keyInfo[0].Contains("Кривая") ? true : false;
            }
        }

        private void OnDeleteElement(object sender, EventArgs e)
        {
            var keyInfo = selectedNode.Text.Split(' ');
            if (selectedNode != null)
            {
                ObjKind kind = ObjKind.ElementSurface;
                if (selectedNode.Text.Contains("Треугольник"))
                    kind = ObjKind.Triangle;
                else if (selectedNode.Text.Contains("Квад"))
                    kind = ObjKind.Quad;
                else if (selectedNode.Text.Contains("Поверхности"))
                {
                    var ierr = 0;
                    controller.gmshModelMeshClear(new int[0], IntPtr.Zero, ref ierr);


                }
                if (kind == ObjKind.Triangle || kind == ObjKind.Quad && keyInfo.Length > 1)
                {
                    var number = Int32.Parse(keyInfo[1]);
                    RemoveById(kind, number);
                }



                //Int32.Parse(keyInfo[1]);

                /*
                if (keyInfo.Length > 1)
                {
                    var number = Int32.Parse(keyInfo[1]);
                    if (selectedNode.Text.Contains("Треугольник") || selectedNode.Text.Contains("Квад"))
                    {
                        modelData.ObjectData.FindMany(ObjKind.)
                        modelData.Clear();
                        mesh.RemoveElements2D(new int[] { number });
                        FillModelDataMesh();
                    }
                    else if (selectedNode.Text.Contains("Поверхность"))
                    {
                        modelData.Clear();
                        var surface = mesh.GetSurfaceById(number).ToArray();
                        mesh.RemoveSurfaceById(number);
                        FillModelDataMesh();
                    }
                    elemsTree.Nodes.Remove(selectedNode);
                    redrawScene?.Invoke(false,new string[] { "Узлы", "Элементы1D", "Элементы2D" });
                }*/
            }
        }

        private void RemoveById(ObjKind kind, int id)
        {
            var element = modelData.ObjectData.FindMany(kind).Where(v => v.Number == id).First();
            modelData.ObjectData.Remove(element);
            controller.DeleteMeshElements(new long[] { id });
        }

        private void OnAddBoundFilter(object sender, EventArgs e)
        {
            var ierr = 0;
            int[] list;
            controller.ModelMeshFieldList(out list);
            if (Array.Find(list, v => v == boundFieldTag) == default)
            {
                var field = controller.gmshModelMeshFieldAdd("BoundaryLayer", 1, ref ierr);
                if (ierr == 1)
                {
                    showErrorMessage.Invoke("Ошибка, невозможно создать граничный фильтр");
                    return;
                }
                else
                {
                    boundFieldTag = 1;
                    controller.gmshModelMeshFieldSetAsBoundaryLayer(boundFieldTag, ref ierr);
                    if (ierr == 1)
                    {
                        showErrorMessage.Invoke("Ошибка, невозможно установить в слой текущий фильтр");
                        return;
                    }
                }
            }
            chkBeta.Enabled = chkQuad.Enabled = chkMetrics.Enabled = true;
            grpFieldGeneral.Enabled = grpFieldSize.Enabled = true;
            grpFieldLayer.Enabled = grpFieldFan.Enabled = true;
        }

        private void OnRemoveBoundFilter(object sender, EventArgs e)
        {
            var ierr = 0;
            controller.gmshModelMeshFieldRemove(boundFieldTag, ref ierr);
            if (ierr == 1)
                showErrorMessage($"Ошибка, невозможно удалить фильтр с идентификатором {boundFieldTag}");
            chkBeta.Enabled = chkQuad.Enabled = chkMetrics.Enabled = false;
            grpFieldGeneral.Enabled = grpFieldSize.Enabled = false;
            grpFieldLayer.Enabled = grpFieldFan.Enabled = false;
        }

        private void OnBoundFilterCheck(object sender, EventArgs e)
        {
            var control = sender as CheckBox;
            var tag = control.Tag.ToString();
            var value = Convert.ToDouble(control.Checked);
            if (tag == "BetaLaw")
                grpFieldBeta.Enabled = control.Checked;
            var ierr = 0;
            controller.gmshModelMeshFieldSetNumber(boundFieldTag, tag, value, ref ierr);
            if (ierr == 1)
                showErrorMessage.Invoke("Ошибка, невозможно установить заданные значения фильтра");
        }

        private void OnFilterListEnter(object sender, EventArgs e)
        {
            var control = sender as TextBox;
            var tag = control.Tag.ToString();
            var data = control.Text.Split(' ', ',');
            var values = new double[data.Length];
            for (var i = 0; i < data.Length; ++i)
            {
                var value = 0.0;
                if (!Double.TryParse(data[i], out value))
                {
                    control.Text = "";
                    showErrorMessage.Invoke("Ошибка, проверьте настройки ввода фильтра");
                    return;
                }
                values[i] = value;
            }
            var ierr = 0;
            controller.gmshModelMeshFieldSetNumbers(boundFieldTag, tag, values, (IntPtr)values.Length, ref ierr);
            if (ierr == 1)
            {
                control.Text = "";
                showErrorMessage.Invoke("Ошибка, невозможно установить заданные значения фильтра");
            }
        }

        private void OnFilterValueEnter(object sender, EventArgs e)
        {
            var control = sender as TextBox;
            var optValue = control.Tag.ToString().Split(' ');
            var value = 0.0;
            if (!Double.TryParse(control.Text, out value))
            {
                showErrorMessage.Invoke("Ошибка, невозможно прочитать значение, проверьте поле ввода фильтра");
                value = Double.Parse(optValue[1]);
                return;
            }
            var ierr = 0;
            controller.gmshModelMeshFieldSetNumber(boundFieldTag, optValue[0], value, ref ierr);
            if(ierr == 1)
            {
                control.Text = optValue[1];
                showErrorMessage.Invoke("Ошибка, невозможно установить заданные значения фильтра");
            }
        }

        private void OnTransfiniteCurve(object sender, EventArgs e)
        {
            var nPoints = 0;
            var coef = 0.0;
            if (!Double.TryParse(algoCoef.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out coef) ||
                !Int32.TryParse(algoNPoints.Text, out nPoints))
            {
                showErrorMessage.Invoke("Ошибка, проверьте правильность ввода уточнения кривых");
                return;
            }
            if (nPoints < 3)
                algoNPoints.Text = "";
            else
            {
                var tag= Int32.Parse(selectedNode.Text.Split(' ')[1]);
                var checkedRadio = GetCheckedRadioButton();
                var ierr = 0;
                controller.gmshModelMeshSetTransfiniteCurve(tag, nPoints, checkedRadio.Text , coef, ref ierr);
            }
        }

        private RadioButton GetCheckedRadioButton()
        {
            var radio = new RadioButton[] { rbtnProgressive, rbtnBump, rbtnBeta };
            for (var i = 0; i < radio.Length; ++i)
                if (radio[i].Checked)
                    return radio[i];
            return radio[0];
        }

        private void OnExit(object sender, EventArgs e)
        {
            updateModelData?.Invoke(modelData);
            this.ParentForm.Close();
        }
    }
}
