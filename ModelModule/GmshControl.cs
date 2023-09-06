using GmshApi;
using GmshApi.Api;
using Model;
using Model.Interfaces;
using ModelController.ModelScenePresentator;
using Project.TasksData;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace ModelModule
{
    public partial class GmshControl : UserControl
    {
        private GeometryObject geometry;
        private MeshObject mesh;
        private ModelData modelData;
        private TreeNode selectedNode;
        private MeshField field;

        public event Action<object, ModelData> updateModelData;

        public GmshControl()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            geometry = new GeometryObject();
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
            modelData.Clear();
            FillModelDataGeometry();
            ClearGeometryTree();
            ClearMeshTree();
            ClearVolumesTree();
            FillGeometryTreeView();
            ShowHideGeometryControls(true);
            ShowHideMeshBox(true);
            ShowHideMeshControls(false);
            ShowHideVolumeBox(false);
            ShowHideVolumeControls(false);
            RedrawModel(fitOnScreen, "Элементы1D");
        }

        private void RedrawModel(bool fitOnScreen, params string[] objTypes)
        {
            var grandParent = Tag as ModelPage;
            var scene = grandParent.SceneControl;
            grandParent.ModelPresenter = new ModelScenePresentator(modelData);
            if (modelData.ObjectData.Count > 0)
                foreach (var type in objTypes)
                    grandParent.PresentDataToScene(type);
            if (fitOnScreen)
                scene.FitObjectsToScreen();
            scene.DisplayObjects();
        }

        private void ClearAllVBO()
        {
            var grandParent = Tag as ModelPage;
            grandParent.ClearAllDataOnScene();
        }

        private void GenerateMesh()
        {
            modelData.Clear();
            ClearAllVBO();
            ClearVolumesTree();
            ClearMeshTree();
            geometry.Generate(1);
            mesh = geometry.Generate(2);
            FillModelDataMesh();
            FillMeshTreeView();
            ShowHideMeshControls(true);
            if (geometry.GetMaxDimension() > 2)
            {
                ShowHideVolumeBox(true);
                ShowHideVolumeControls(false);
            }
            RedrawModel(false, "Элементы2D");
        }

        private void GenerateVolumes()
        {
            modelData.Clear();
            ClearAllVBO();
            ClearVolumesTree();
            mesh = geometry.Generate(3);
            FillModelDataVolumes();
            FillVolumesTreeView();
            ShowHideVolumeControls(true);
            RedrawModel(false, "Элементы3D");
        }

        private void OnDeleteGeometry(object sender, EventArgs e)
        {
            modelData.Clear();
            ClearAllVBO();
            ClearAllTrees();
            ShowHideGeometryControls(false);
            ShowHideVolumeBox(false);
            ShowHideMeshBox(false);
            RedrawModel(false);
            geometry.Dispose();
        }

        private void OnDeleteMesh(object sender, EventArgs e) 
        {
            ClearAllVBO();
            GenerateGeometry(false);
        }

        private void OnDeleteVolume(object sender, EventArgs e) => GenerateMesh();

        private void FillModelDataGeometry()
        {
            modelData.ObjectData.AddRange(geometry.GetControlPoints());
            modelData.ObjectData.AddRange(geometry.GetElements1D());
        }

        private void FillModelDataMesh()
        {
            modelData.ObjectData.AddRange(mesh.GetNodes());
            modelData.ObjectData.AddRange(mesh.GetElement1D());
            modelData.ObjectData.AddRange(mesh.GetElement2D());
        }

        private void FillModelDataVolumes()
        {
            modelData.ObjectData.AddRange(mesh.GetElement3D());
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
                ClearAllVBO();
                geometry = new GeometryObject(loadFileDialog.FileName);
                GmshWrapperModel.ModelSetCurrent(geometry.Id.ToString());
                field = new MeshField(MeshFieldType.BoundaryLayer);
                GenerateGeometry();
            }
        }

        private void OnGenerateMesh(object sender, EventArgs e) => GenerateMesh();
        private void OnGenerateVolume(object sender, EventArgs e) => GenerateVolumes();

        private void OnDencityChange(object sender, EventArgs e)
        {
            var result = 0.0;
            if (mesh == null)
                mesh = geometry.Generate(0);
            if (Double.TryParse(meshDensityValue.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out result)) 
                mesh.Density = result;
        }

        private void OnAlgorithmChoice(object sender, EventArgs e)
        {
            var choice = sender as ComboBox;
            var algo = new Triangulation2DAlgorithm[] { Triangulation2DAlgorithm.MeshAdapt,
                                                        Triangulation2DAlgorithm.Automatic,
                                                        Triangulation2DAlgorithm.Delaunay,
                                                        Triangulation2DAlgorithm.FrontalDelaunay,
                                                        Triangulation2DAlgorithm.FrontalDelaunayQuad
                                                       };
            mesh?.ChangeTriangulationAlgorithm2D(algo[choice.SelectedIndex]);
        }

        private void OnRefine(object sender, EventArgs e)
        {
            modelData.Clear();
            ClearAllVBO();
            ClearVolumesTree();
            ClearMeshTree();
            mesh.RefineMesh();
            FillModelDataMesh();
            FillMeshTreeView();
            ShowHideVolumeControls(false);
            RedrawModel(false, "Элементы2D");
        }

        private void OnQuadrangulate(object sender, EventArgs e)
        {
            modelData.Clear();
            ClearAllVBO();
            ClearVolumesTree();
            ClearMeshTree();
            mesh.QuadrangulateMesh();
            FillModelDataMesh();
            FillMeshTreeView();
            ShowHideVolumeControls(false);
            RedrawModel(false, "Элементы2D");
        }

        private void FillGeometryTreeView()
        {
            entTree.Nodes.Clear();
            var entities = geometry.GetEntities(-1);
            for (var i = 1; i < entities.Length; i += 2)
            {
                var dim = entities[i - 1];
                if (dim == 0)
                    AddTreeNode(entTree.Nodes, "Контрольные узлы", "Контрольный узел " + entities[i].ToString());
                else if (dim == 1)
                    AddTreeNode(entTree.Nodes, "Кривые", "Кривая " + entities[i].ToString());
                else if (dim == 2)
                    AddTreeNode(entTree.Nodes, "Поверхности", "Поверхность " + entities[i].ToString());
                else if (dim == 3)
                    AddTreeNode(entTree.Nodes, "Объемы", "Объем " + entities[i].ToString());
            }
        }

        private void FillMeshTreeView()
        {
            foreach (var data in modelData.ObjectData)
            {
                if (data.ObjKind == ObjKind.Node)
                    AddTreeNode(elemsTree.Nodes, "Узлы", "Узел " + data.Number.ToString());
                else if (data.ObjKind == ObjKind.Beam)
                    AddTreeNode(elemsTree.Nodes, "Линии", "Линия " + data.Number.ToString());
            }
            var entities = geometry.GetEntities(2);
            for (var i = 1; i < entities.Length; i += 2)
            {
                ElementInfo[] elemInfo;
                long[][] elemTags, nodeTags;
                var surfaceTag = entities[i];
                var surfaceId = "Поверхность " + surfaceTag.ToString();
                AddTreeNode(elemsTree.Nodes, "Поверхности", surfaceId);
                mesh.GetElementsInfo(2, surfaceTag, out elemInfo, out elemTags, out nodeTags);
                for (var j = 0; j < elemInfo.Length; ++j)
                {
                    var faceType = elemInfo[j].elementName.Contains("Triangle") ? "Треугольник " : "Квад ";
                    for (var k = 0; k < elemTags[0].Length; ++k)
                    {
                        var treeCol = elemsTree.Nodes["Поверхности"].Nodes;
                        AddTreeNode(treeCol, surfaceId, faceType + elemTags[0][k].ToString());
                    }
                }
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
            if (selectedNode != null)
            {
                var keyInfo = selectedNode.Text.Split(' ');
                if (keyInfo.Length > 1)
                {
                    var number = Int32.Parse(keyInfo[1]);
                    if (selectedNode.Text.Contains("Треугольник") || selectedNode.Text.Contains("Квад"))
                    {
                        ClearAllVBO();
                        modelData.Clear();
                        elemsTree.Nodes.Remove(selectedNode);
                        mesh.RemoveElements2D(new int[] { number });
                    }
                    else if (selectedNode.Text.Contains("Поверхность"))
                    {
                        ClearAllVBO();
                        modelData.Clear();
                        var surface = mesh.GetSurfaceById(number).ToArray();
                        mesh.RemoveSurfaceById(number);
                    }
                    modelData.ObjectData.AddRange(mesh.GetElement2D());
                    elemsTree.Nodes.Remove(selectedNode);
                    RedrawModel(false,"Элементы2D");
                }
            }
        }

        private void OnAddBoundFilter(object sender, EventArgs e)
        {
            GetBoundaryFilterFromGUI();
            geometry.AddField(field);
            field.SetDisplayFieldType(DisplayFieldType.BoundaryLayer);
        }

        private void OnBoundFilterCheck(object sender, EventArgs e)
        {
            var check = sender as CheckBox;
            GetValueFromCheckbox(check);
        }

        private void OnFilterListEnter(object sender, EventArgs e)
        {
            var text = sender as TextBox;
            GetListValuesFromGUI(text);
        }

        private void OnFilterValueEnter(object sender, EventArgs e)
        {
            var text = sender as TextBox;
            GetValueFromGUI(text);
        }

        private void GetListValuesFromGUI(TextBox control)
        {
            var tag = control.Tag.ToString();
            var data = control.Text.Split(' ');
            var values = new double[data.Length];
            for (var i = 0; i < data.Length; ++i)
            {
                var value = 0.0;
                if (!Double.TryParse(data[i], out value))
                {
                    control.Text = "";
                    values = Array.Empty<double>();
                    break;
                }
                values[i] = value;
            }
            field.SetOptionValues(tag, values);
        }

        private void GetValueFromGUI(TextBox control)
        {
            var optValue = control.Tag.ToString().Split(' ');
            var value = 0.0;
            if (!Double.TryParse(control.Text, out value))
            {
                control.Text = optValue[1];
                value = Double.Parse(optValue[1]);
            }
            field.SetOptionValue(optValue[0], value);
        }

        private void GetValueFromCheckbox(CheckBox check)
        {
            var tag = check.Tag.ToString();
            var value = Convert.ToDouble(check.Checked);
            if (tag == "BetaLaw")
                betaBox.Enabled = check.Checked;
            field.SetOptionValue(tag, value);
        }

        private void GetBoundaryFilterFromGUI()
        {
            var lists = new TextBox[] { pointsList, curvesList, excludedSurfacesList, sizesList, fanPointsList, fanPointsSizesList };
            var values = new TextBox[] { size, sizeFar, thickness, ratio, anisoMax, nbLayers, beta };
            var checks = new CheckBox[] { betaLaw, intersectMetrics, quads };
            for (var i = 0; i < lists.Length; ++i)
                GetListValuesFromGUI(lists[i]);
            for (var i = 0; i < values.Length; ++i)
                GetValueFromGUI(values[i]);
            for (var i = 0; i < checks.Length; ++i)
                GetValueFromCheckbox(checks[i]);
        }

        private void OnTransfiniteCurve(object sender, EventArgs e)
        {
            var nPoints = 0;
            var coef = 0.0;
            var statusCoef = Double.TryParse(algoCoef.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out coef);
            var statusNPoints = Int32.TryParse(algoNPoints.Text, out nPoints);
            if (statusCoef && statusNPoints && selectedNode != null)
            {
                if (nPoints < 3)
                    algoNPoints.Text = "";
                else
                {
                    var idCurve = Int32.Parse(selectedNode.Text.Split(' ')[1]);
                    var mesh = geometry.Generate(0);
                    var checkedRadio = GetCheckedRadioButton();
                    var trAlgo = (TransfiniteAlgorithm)Enum.Parse(typeof(TransfiniteAlgorithm),
                                  checkedRadio.Tag.ToString());
                    mesh.SetMeshPointsOnCurve(nPoints, trAlgo, coef, idCurve);
                }
            }
        }

        private RadioButton GetCheckedRadioButton()
        {
            var radio = new RadioButton[] { progAlgo, bumpAlgo, betaAlgo };
            for (var i = 0; i < radio.Length; ++i)
                if (radio[i].Checked)
                    return radio[i];
            return radio[0];
        }

        private void OnExit(object sender, EventArgs e)
        {
            updateModelData?.Invoke(this, modelData);
            this.ParentForm.Close();
        }
    }
}
