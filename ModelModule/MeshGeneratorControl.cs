using GmshApi.GmshController;
using Model;
using ModelInterfaces;
using System;
using System.Globalization;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;

namespace ModelModule
{
    public partial class GmshControl : UserControl
    {
        private GmshController controller;
        private int boundFieldTag;
        private int boundViewTag;
        private TreeNode selectedNode;
        private Dictionary<int, Tuple<string, string, int>> elementType = new Dictionary<int, Tuple<string, string, int>>
                                                            {
                                                                { 2, Tuple.Create("Треугольники","Треугольник ", 3) },
                                                                { 3, Tuple.Create("Квады","Квад ", 4) },
                                                                { 4, Tuple.Create("Тетраэдры","Тетраэдр ", 4) },
                                                                { 5, Tuple.Create("Гексаэдры","Гексаэдр ", 8) },
                                                                { 6, Tuple.Create("Призмы","Призма ", 6) },
                                                                { 7, Tuple.Create("Пирамиды","Пирамида ", 5) },
                                                            };
        private Dictionary<int, Tuple<string, string>> geometryType = new Dictionary<int, Tuple<string, string>>
                                                            {
                                                                { 3, Tuple.Create("Объем ","Поверхность ") },
                                                                { 2, Tuple.Create("Поверхность ","Кривая ") },
                                                                { 1, Tuple.Create("Кривая ","Контрольный узел ") },
                                                                { 0, Tuple.Create("Контрольный узел ","") }
                                                            };

        public event Action<string, IEnumerable<IModelObject>> updatePointData;
        public event Action<string, IEnumerable<ILineObject>> updateLineData;
        public event Action<string, IEnumerable<ISurfaceElement>> updateSurfaceData;
        public event Action<string, int> ShowObjectsEvent;
        public event Action<string> showErrorMessage;
        public event Action<bool> redrawScene;


        public GmshControl()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            controller = new GmshController(@"I:\Project\GUI\packages\gmsh.dll");
            Disposed += GmshControl_Disposed;
            algoChoice.SelectedIndex = 3;
        }

        private void GmshControl_Disposed(object sender, EventArgs e)
        {
            var ierr = 0;
            controller.gmshFinalize(ref ierr);
            if (ierr == 1)
                showErrorMessage.Invoke("Ошибка, работа сеточного генератора завершена с ошибкой");
        }

        private void ShowHideGeometryControls(bool show) => geoDelBtn.Enabled = geoElBox.Enabled = filterBox.Enabled = show;

        private void ShowHideMeshControls(bool show) => meshDelBtn.Enabled = meshElBox.Enabled =
                                                        meshOpBox.Enabled = elemDelBtn.Enabled = show;

        private void ShowHideVolumeControls(bool show) => delVolBtn.Enabled = volElBox.Enabled = show;
        private void ShowHideMeshBox(bool show) => meshGenBox.Enabled = show;
        private void ShowHideVolumeBox(bool show) => volumeBox.Enabled = show;
        private void GenerateGeometry(bool fitOnScreen = true)
        {
            updateSurfaceData.Invoke("", null);
            if (FillModelDataGeometry())
            {
                ClearAllTrees();
                FillGeometryTreeView();
                ShowHideGeometryControls(true);
                ShowHideMeshBox(true);
                ShowHideMeshControls(false);
                ShowHideVolumeBox(false);
                ShowHideVolumeControls(false);
                redrawScene.Invoke(fitOnScreen);
            }
        }

        private void GenerateMesh(bool isRemesh = true)
        {
            var ierr = 0;
            if (isRemesh)
                controller.gmshModelMeshGenerate(1, ref ierr);
            controller.gmshModelMeshGenerate(2, ref ierr);
            if (ierr == 1)
                showErrorMessage?.Invoke("Ошибка при генерации сетки, проверьте настройки и фильтры геометрии");
            else
            {
                updatePointData("Узлы", null);
                updateSurfaceData.Invoke("Элементы2D", null);
                if (FillModelDataMesh(2))
                    UpdateMeshControlsAndRedraw();
            }
        }

        private void GenerateVolumes()
        {
            var ierr = 0;
            controller.gmshModelMeshGenerate(3, ref ierr);
            if (ierr == 1)
                showErrorMessage?.Invoke("Ошибка при генерации объемов, проверьте настройки и фильтры сетки");
            else if (FillModelDataMesh(3))
            {
                //updateModel("Элементы2D", null);//Удаляем Элементы2D после построения 3D элементов ??
                ClearVolumesTree();
                FillMeshTreeView(volumesTree, 3, "Объемы", "Объем ");
                ShowHideVolumeControls(true);
                redrawScene?.Invoke(false);
            }
        }

        private bool FillModelDataGeometry() => UpdateGeometry(ObjKind.Point) & UpdateGeometry(ObjKind.Curve);

        private bool FillModelDataMesh(int dim)
        {
            var nodeStatus = UpdateMesh(ObjType.Узлы, dim);
            var elemStatus = dim == 2 ? UpdateMesh(ObjType.Элементы2D, dim) : UpdateMesh(ObjType.Элементы3D, dim);
            return nodeStatus & elemStatus;
        }

        private bool UpdateGeometry(ObjKind objKind)
        {
            int[] dimTags;
            var objMessage = objKind == ObjKind.Point ? "контрольные точки" : "кривые";
            var objType = objKind == ObjKind.Point ? "Узлы" : "Элементы1D";
            var dim = objKind == ObjKind.Point ? 0 : 1;
            var status = true;
            if (controller.ModelGetGeometryEntities(out dimTags, dim))
            {
                if (objKind == ObjKind.Point)
                {
                    var cPoints = controller.CreateControlPoints(dimTags);
                    updatePointData(objType, cPoints);
                }
                else
                {
                    var lines = controller.CreateLines(dimTags, ref status);
                    updateLineData(objType, lines);
                }
            }
            else
                showErrorMessage.Invoke($"Ошибка, невозможно получить {objMessage}, проверьте файл-скрипт");
            return status;
        }

        private bool UpdateMesh(ObjType objType, int dim)
        {
            var status = false;
            if (objType == ObjType.Узлы)
            {
                var nodes = controller.GetNodes(ref status);
                if (status)
                {
                    updatePointData(objType.ToString(), nodes);
                    return true;
                }
            }
            else
            {
                var mesh = controller.GetMeshEntities(dim, -1, ref status);
                if (status)
                {
                    updateSurfaceData(objType.ToString(), mesh);
                    return true;
                }
            }
            showErrorMessage.Invoke($"Ошибка, невозможно получить {objType} модели");
            return false;
        }

        private void UpdateMeshControlsAndRedraw()
        {
            var ierr = 0;
            ClearVolumesTree();
            ClearMeshTree();
            FillMeshTreeView(elemsTree, 2);
            ShowHideMeshControls(true);
            if (controller.gmshModelGetDimension(ref ierr) > 2)
            {
                ShowHideVolumeBox(true);
                ShowHideVolumeControls(false);
            }
            redrawScene?.Invoke(false);
        }

        private void OnDeleteGeometry(object sender, EventArgs e)
        {
            var ierr = 0;
            controller.gmshModelMeshClear(new int[0], IntPtr.Zero, ref ierr);
            updateSurfaceData.Invoke("", null);
            ClearAllTrees();
            ShowHideGeometryControls(false);
            ShowHideVolumeBox(false);
            ShowHideMeshBox(false);
            controller.gmshModelRemove(ref ierr);
            if (ierr == 1)
                showErrorMessage?.Invoke("Ошибка при удалении модели, невозможно удалить модель");
            redrawScene?.Invoke(false);
        }

        private void OnDeleteMesh(object sender, EventArgs e)
        {
            var ierr = 0;
            controller.gmshModelMeshClear(new int[] { 3, -1 }, (IntPtr)2, ref ierr);
            controller.gmshModelMeshClear(new int[] { 2, -1 }, (IntPtr)2, ref ierr);
            GenerateGeometry(false);
        }

        private void OnDeleteVolume(object sender, EventArgs e)
        {
            var ierr = 0;
            controller.gmshModelMeshClear(new int[] { 3, -1 }, (IntPtr)2, ref ierr);
            updateSurfaceData.Invoke("Элементы3D", null);
            GenerateMesh(false);
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
                string error = string.Empty;
                if (ierr == 1 && controller.LoggerGetLastError(out error))
                    showErrorMessage.Invoke(error);
                else
                    GenerateGeometry();
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
                if (ierr == 1)
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
                updatePointData.Invoke("Узлы", null);
                updateSurfaceData.Invoke("Элементы2D", null);
                if (FillModelDataMesh(2))
                    UpdateMeshControlsAndRedraw();
            }
        }

        private void OnQuadrangulate(object sender, EventArgs e)
        {
            var filename = string.Empty;
            controller.ModelGetFileName(out filename);
            var ext = Path.GetExtension(filename);
            if (ext.Contains("igs") || ext.Contains("iges"))
            {
                var ierr = 0;
                controller.gmshModelMeshRecombine(ref ierr);
                if (ierr == 1)
                    showErrorMessage.Invoke("Ошибка, невозможно трансформировать сетку");
                else
                {
                    updatePointData.Invoke("Узлы", null);
                    updateSurfaceData.Invoke("Элементы2D", null);
                    if (FillModelDataMesh(2))
                        UpdateMeshControlsAndRedraw();
                }
            }
        }

        private void FillGeometryTreeView()
        {
            entTree.Nodes.Clear();
            int[] dimTags, upwards, downwards;
            controller.ModelGetGeometryEntities(out dimTags, -1);
            if (dimTags.Length > 1)
            {
                for (var i = dimTags.Length - 1; i > 0; i -= 2)
                {
                    var dim = dimTags[i - 1];
                    var current = geometryType[dim].Item1 + dimTags[i].ToString();
                    var child = geometryType[dim].Item2;
                    controller.ModelGetAdjacencies(dim, dimTags[i], out upwards, out downwards);
                    var nodes = entTree.Nodes.Find(current, true);
                    TreeNodeCollection parent;
                    if (nodes.Length != 0)
                        parent = nodes[0].Nodes;
                    else
                    {
                        var node = entTree.Nodes.Add(current, current);
                        parent = node.Nodes;
                    }
                    for (var j = 0; j < downwards.Length; ++j)
                    {
                        var newChild = child + downwards[j].ToString();
                        parent.Add(newChild, newChild);
                    }
                }
            }
        }

        private bool FillMeshTreeView(TreeView tree, int dim, string generalKey = "Поверхности", string generalChild = "Поверхность ")
        {
            int[] dimTags;
            controller.ModelGetGeometryEntities(out dimTags, dim);
            int[] elementTypes;
            long[][] elementTags, nodeTags;
            for (var i = 1; i < dimTags.Length; i += 2)
            {
                if (!controller.ModelMeshGetElements(dim, dimTags[i], out elementTypes, out elementTags, out nodeTags))
                {
                    showErrorMessage.Invoke($"Ошибка, невозможно получить информацию об элементе {dimTags[i]}");
                    return false;
                }
                var child = generalChild + dimTags[i].ToString();
                AddTreeNode(tree.Nodes, generalKey, child);
                var currentSurface = tree.Nodes[generalKey].Nodes[child];
                for (var j = 0; j < elementTypes.Length; ++j)
                {
                    var triple = elementType[elementTypes[j]];//, out elemKey, out elemChild, out points);
                    var elements = elementTags[j];
                    for (var k = 0L; k < elements.Length; ++k)
                    {
                        var elemTag = elements[k];
                        var currentElement = triple.Item2 + elemTag.ToString();
                        AddTreeNode(currentSurface.Nodes, triple.Item1, currentElement);
                        var currentType = currentSurface.Nodes[triple.Item1].Nodes[currentElement];
                        for (var l = 0; l < triple.Item3; ++l)
                        {
                            var nodeTag = "Узел " + nodeTags[j][k * triple.Item3 + l].ToString();
                            currentType.Nodes.Add(nodeTag, nodeTag);
                        }
                    }
                }
            }
            return true;
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

                ShowObjectsEvent("Линия", Convert.ToInt32(keyInfo[1]));
            }

        }

        private void OnDeleteElement(object sender, EventArgs e)
        {
            var keyInfo = selectedNode.Text.Split(' ');
            if (selectedNode != null)
            {
                var ierr = 0;
                if (keyInfo[0].Contains("Поверхност"))
                {
                    if (keyInfo.Length == 1)
                        controller.gmshModelMeshClear(new int[0], IntPtr.Zero, ref ierr);
                    else
                        controller.gmshModelMeshClear(new int[] { 2, Int32.Parse(keyInfo[1]) }, (IntPtr)2, ref ierr);
                }
                else if (keyInfo.Length == 1)
                {
                    var ids = new long[selectedNode.Nodes.Count];
                    for (var i = 0; i < selectedNode.Nodes.Count; ++i)
                        ids[i] = Convert.ToInt64(selectedNode.Nodes[i].Text.Split(' ')[1]);
                    controller.DeleteMeshElements(ids);
                }
                else
                    controller.DeleteMeshElements(new long[] { Int64.Parse(keyInfo[1]) });
                var status = false;
                var nodes = controller.GetNodes(ref status);//Получаем узлы, если нужно
                var elems = controller.GetMeshEntities(2, -1, ref status);
                updatePointData.Invoke("Узлы", null);//Удаляем узлы если нужно
                updatePointData.Invoke("Узлы", nodes);
                updateSurfaceData.Invoke("Элементы2D", null);
                updateSurfaceData.Invoke("Элементы2D", elems);
                elemsTree.Nodes.Remove(selectedNode);
                redrawScene?.Invoke(false);
            }
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
            btnFieldAdd.Enabled = false;
            chkBeta.Enabled = chkQuad.Enabled = btnFieldDelete.Enabled = chkMetrics.Enabled = true;
            grpFieldGeneral.Enabled = grpFieldSize.Enabled = true;
            grpFieldLayer.Enabled = grpFieldFan.Enabled = true;
        }

        private void OnRemoveBoundFilter(object sender, EventArgs e)
        {
            var ierr = 0;
            controller.gmshModelMeshFieldRemove(boundFieldTag, ref ierr);
            if (ierr == 1)
                showErrorMessage($"Ошибка, невозможно удалить фильтр с идентификатором {boundFieldTag}");
            btnFieldAdd.Enabled = true;
            chkBeta.Enabled = chkQuad.Enabled = btnFieldDelete.Enabled = chkMetrics.Enabled = false;
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
                    return;
                }
                values[i] = value;
            }
            var ierr = 0;
            controller.gmshModelMeshFieldSetNumbers(boundFieldTag, tag, values, (IntPtr)values.Length, ref ierr);
            if (ierr == 1)
                control.Text = "";
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
            if (ierr == 1)
                control.Text = optValue[1];
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
                var tag = Int32.Parse(selectedNode.Text.Split(' ')[1]);
                var checkedRadio = GetCheckedRadioButton();
                var ierr = 0;
                controller.gmshModelMeshSetTransfiniteCurve(tag, nPoints, checkedRadio.Text, coef, ref ierr);
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
            this.ParentForm.Close();
        }
    }
}
