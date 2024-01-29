using GmshApi.GmshController;
using Model;
using ModelInterfaces;
using System;
using System.Globalization;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using ModelInterfaces.GeometryObjects;
using System.Data;
using System.Linq;
using System.Text;
using Model.MeshObjects;
using Geometry;
using ModelInterfaces.MeshObjects;
using SceneInterface;

namespace ModelModule
{
    public partial class GmshControl : UserControl
    {
        private const string cadTemplates = "CAD Files(*.brep; *.stp; *.step; *.igs; *.iges)|" +
                                                      "*.brep; *.stp; *.step; *.igs; *.iges";
        private const string scriptTemplates = "Script Files(*.geo)|*.geo";
        private GmshController controller;
        private int boundFieldTag;
        private TreeNode selectedNode;
        private TreeNode lastNode;
        private Dictionary<int, Tuple<string, string>> fundamental = new Dictionary<int, Tuple<string, string>>
        {
            { 2, Tuple.Create("Поверхности","Поверхность") },
            { 3, Tuple.Create("Объемы","Объем") },
        };
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
        public bool SaveObjectData { get; set; }
        public bool IsControllerLoaded { get => controller != null; }
        public IObjectsData ObjectData { get; internal set; }

        public event Action<ObjType, IEnumerable<IModelObject>> updatePointData;
        public event Action<ObjType, IEnumerable<ILineObject<IGeometryPoint>>> updateLineData;
        public event Action<ObjType, IEnumerable<ILineObject<INode>>> updateElement1Data;
        public event Action<ObjType, IEnumerable<ISurfaceElement>> updateSurfaceData;
        public event Action<IObjectsData> saveObjectData;
        public event Action<IEnumerable<ILineObject<IGeometryPoint>>, IModelObject> ShowObjectsEvent;
        public event Action<string> showErrorMessage;
        public event Action<bool> redrawScene;


        public GmshControl()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            ParentForm.FormClosing += OnClosingForm;
            var path = Environment.GetEnvironmentVariable("BazisMeshPath", EnvironmentVariableTarget.Machine);

            if (path == null || path == "")
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "All files(*.*)|*.*|" +
                    "dinamic library(*.dll)|*.dll";
                if (dialog.ShowDialog() == DialogResult.Cancel)
                    return;
                path = dialog.FileName;
            }
            else
                path = $@"{path}\Mesh\gmsh.dll";
            controller = new GmshController(path);
            ObjectData = new ObjectsData();
            var ierr = 0;
            controller.gmshOptionSetNumber("General.AbortOnError", 0, ref ierr);//Запретить поделию Кристофа обваливать Базис
            algoChoice.SelectedIndex = 3;
        }

        private bool UpdateGeometry(int[] numbers = null)
        {
            IEnumerable<ILineObject<IGeometryPoint>> curves = null;
            IEnumerable<IModelObject> cPoints = null;
            if (numbers == null)
            {
                bool status = false;
                int[] dimTags;
                controller.ModelGetGeometryEntities(out dimTags, 0);
                cPoints = controller.CreateControlPoints(dimTags);
                controller.ModelGetGeometryEntities(out dimTags, 1);
                curves = controller.CreateLines(dimTags, ref status);
            }
            ObjectData.Clear(ObjType.Объект);

            updatePointData?.Invoke(ObjType.Точка, cPoints);
            updateLineData?.Invoke(ObjType.Линия, curves);
            /*if (cPoints != null)//Не работает
                ObjectData.PointCollection.AddRange(cPoints);*/
            if (curves != null)
                ObjectData.LineCollection.AddRange(curves);
            return true;
        }

        private void GenerateGeometry()
        {
            DeleteMesh(false);
            UpdateGeometry();
            var ierr = 0;
            FillGeometryTreeView();
            if (controller.gmshModelGetDimension(ref ierr) > 1)
                ShowHideGeneralTabControls(2);
            ShowHideGeneralTabControls(1);
            ShowHideTabControls(1);
            redrawScene?.Invoke(true);
        }

        private void OnDeleteGeometry(object sender, EventArgs e) => DeleteGeometry(true);
        public void DeleteGeometry(bool redraw = true)
        {
            DeleteMesh(false);
            UpdateGeometry(new int[0]);
            ClearTreeView(1);
            ShowHideGeneralTabControls(2, false);
            ShowHideGeneralTabControls(1, false);
            ShowHideTabControls(1, false);
            if (redraw)
                redrawScene?.Invoke(true);
        }

        private void OnDeleteMesh(object sender, EventArgs e) => DeleteMesh();

        private bool DeleteMesh(bool redraw = true)
        {
            var status = true;
            UpdateSurfaceElements(ObjType.Фигура2D, new int[0]);
            if (volumesTree.Nodes.Count > 0)
            {
                ClearTreeView(3);
                ShowHideTabControls(3, false);
            }
            ShowHideGeneralTabControls(3, false);
            ClearTreeView(2);
            ShowHideTabControls(2, false);
            status = true;
            if (redraw)
                redrawScene.Invoke(false);
            return status;
        }

        private void OnDeleteVolume(object sender, EventArgs e) => DeleteVolume();

        private void DeleteVolume(bool redraw = true)
        {
            string error;
            int[] dimTags;
            controller.ModelGetGeometryEntities(out dimTags, 3);
            UpdateSurfaceElements(ObjType.Фигура3D, dimTags);
            ClearTreeView(3);
            ShowHideTabControls(3, false);
            if (redraw)
                redrawScene.Invoke(false);
        }

        private void ShowHideGeneralTabControls(int dim, bool show = true)
        {
            if (dim == 1)
            {
                geoElBox.Enabled = show;
                filterBox.Enabled = show;
                pointsControlBox.Enabled = false;
            }
            else if (dim == 2)
            {
                algoLabel.Enabled = show;//Активация/деактивация "Алгоритм построения сетки"
                algoChoice.Enabled = show;//Активация/деактивация эл.управления выбора алгоритма
                densityLabel.Enabled = show;//Активация/деактивация "Размер элементов"
                meshDensityValue.Enabled = show;//Активация/деактивация эл.управления ввода размера элементов
                meshGenBtn.Enabled = show;//Активация/деактивация кнопки сгенерировать
                meshGenBox.Enabled = show;//Бокс с элементами управления генерации сетки
            }
            else if (dim == 3)
            {
                volumeBox.Enabled = show;
                volGenBtn.Enabled = show;
            }
        }

        private void ShowHideTabControls(int dim, bool show = true)
        {
            if (dim == 1)
            {
                geoDelBtn.Enabled = show;
            }
            else if (dim == 2)
            {
                meshDelBtn.Enabled = show;
                meshElBox.Enabled = show;
                meshOpBox.Enabled = show;
            }
            else if (dim == 3)
            {
                delVolBtn.Enabled = show;
                volElBox.Enabled = show;
            }
        }

        private void ClearTreeView(int dim)
        {
            if (dim == 1)
                entTree.Nodes.Clear();
            else if (dim == 2)
                elemsTree.Nodes.Clear();
            else if (dim == 3)
                volumesTree.Nodes.Clear();
        }

        private void OnLoadFile(object sender, EventArgs e)
        {
            if (!IsControllerLoaded)
            {
                showErrorMessage?.Invoke("Загрузите gmsh.dll");
                return;
            }
            loadFileDialog.Filter = sender.Equals(geoLoadBtn) ? cadTemplates : scriptTemplates;
            if (loadFileDialog.ShowDialog() == DialogResult.OK)
            {
                var ierr = 0;
                controller.gmshClear(ref ierr);
                controller.gmshOpen(loadFileDialog.FileName, ref ierr);
                GenerateGeometry();
            }
        }

        private void OnGenerateMesh(object sender, EventArgs e)
        {
            var ierr = 0;
            string error;
            controller.gmshModelMeshGenerate(1, ref ierr);
            controller.gmshModelMeshGenerate(2, ref ierr);
            controller.LoggerGetLastError(out error);
            if (!String.IsNullOrEmpty(error))
                showErrorMessage?.Invoke(error);
            UpdateSurfaceElements(ObjType.Элемент2D);
            if (volumesTree.Nodes.Count > 0)
            {
                ShowHideTabControls(3, false);
                ClearTreeView(3);
            }
            FillMeshTreeView(elemsTree, 2);
            ShowHideTabControls(2, true);
            if (controller.gmshModelGetDimension(ref ierr) > 2)
                ShowHideGeneralTabControls(3, true);
            redrawScene?.Invoke(false);
        }

        private void OnGenerateVolume(object sender, EventArgs e)
        {
            var ierr = 0;
            string error;
            controller.gmshModelMeshGenerate(3, ref ierr);
            controller.LoggerGetLastError(out error);
            if (!String.IsNullOrEmpty(error))
                showErrorMessage?.Invoke(error);
            UpdateSurfaceElements(ObjType.Элемент3D);
            FillMeshTreeView(volumesTree, 3, "Объемы", "Объем ");
            ShowHideTabControls(3, true);
            redrawScene?.Invoke(false);
        }

        private void OnDencityChange(object sender, EventArgs e)
        {
            var result = 0.0;
            if (Double.TryParse(meshDensityValue.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
            {
                var ierr = 0;
                controller.gmshOptionSetNumber("Mesh.MeshSizeFactor", result, ref ierr);
            }
        }

        private void OnAlgorithmChoice(object sender, EventArgs e)
        {
            var ierr = 0;
            string error;
            var choice = sender as ComboBox;
            var algo = new double[] { 1, 2, 5, 6, 8 };
            controller.gmshOptionSetNumber("Mesh.Algorithm", algo[choice.SelectedIndex], ref ierr);
        }

        private void OnRefine(object sender, EventArgs e)
        {
            var ierr = 0;
            string error;
            controller.gmshModelMeshRefine(ref ierr);
            UpdateSurfaceElements(ObjType.Элемент2D);
            if (volumesTree.Nodes.Count > 0)
            {
                ShowHideTabControls(3, false);
                ClearTreeView(3);
            }
            FillMeshTreeView(elemsTree, 2);
            redrawScene?.Invoke(false);
        }

        private void OnQuadrangulate(object sender, EventArgs e)
        {
            var filename = string.Empty;
            controller.ModelGetFileName(out filename);
            var ext = Path.GetExtension(filename);
            if (ext.Contains("igs") || ext.Contains("iges"))
            {
                var ierr = 0;
                string error;
                controller.gmshModelMeshRecombine(ref ierr);
                controller.LoggerGetLastError(out error);
                if (!String.IsNullOrEmpty(error))
                    showErrorMessage?.Invoke(error);
                UpdateSurfaceElements(ObjType.Элемент2D);
                if (volumesTree.Nodes.Count > 0)
                {
                    ShowHideTabControls(3, false);
                    ClearTreeView(3);
                }
                FillMeshTreeView(elemsTree, 2);
                redrawScene?.Invoke(false);
            }
        }

        private Dictionary<int, Dictionary<int, TreeNode>> CreateGeometryNodes(int[] dimTags)
        {
            var nodes = new Dictionary<int, Dictionary<int, TreeNode>>();
            var value = new StringBuilder(100);
            for (var i = 0; i < dimTags.Length; i += 2)
            {
                var dim = dimTags[i];
                var tag = dimTags[i + 1];
                value.Append(geometryType[dim].Item1);
                value.Append(tag);
                if (!nodes.ContainsKey(dim))
                    nodes.Add(dim, new Dictionary<int, TreeNode>());
                nodes[dim].Add(tag, new TreeNode(value.ToString()));
                value.Clear();
            }
            return nodes;
        }

        private void FillGeometryTreeView()
        {
            int[] dimTags, upwards, downwards;
            controller.ModelGetGeometryEntities(out dimTags, -1);
            ClearTreeView(1);
            var nodes = CreateGeometryNodes(dimTags);
            for (var i = 0; i < dimTags.Length; i += 2)
            {
                var dim = dimTags[i];
                var tag = dimTags[i + 1];
                controller.ModelGetAdjacencies(dim, tag, out upwards, out downwards);
                var current = nodes[dim][tag];
                if (upwards.Length == 0)
                    entTree.Nodes.Add(current);
                for (var j = 0; j < upwards.Length; ++j)
                {
                    var upTag = upwards[j];
                    var node = nodes[dim + 1][upTag];
                    var child = current.Parent != null ? current.Clone() as TreeNode : current;
                    node.Nodes.Add(child);
                }
            }
        }

        private void FillMeshTreeView(TreeView tree, int dim,
                                       string generalKey = "Поверхности", string generalChild = "Поверхность ")
        {
            ClearTreeView(dim);
            int[] dimTags;
            controller.ModelGetGeometryEntities(out dimTags, dim);
            int[] elementTypes;
            long[][] elementTags, nodeTags;
            for (var i = 1; i < dimTags.Length; i += 2)
            {
                controller.ModelMeshGetElements(dim, dimTags[i], out elementTypes, out elementTags, out nodeTags);
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
        }

        private void AddTreeNode(TreeNodeCollection tree, string key, string childInfo)
        {
            if (!tree.ContainsKey(key))
                tree.Add(key, key);
            tree[key].Nodes.Add(childInfo, childInfo);
        }

        private IModelObject FindObjectByTreeNode(TreeNode node)
        {
            var tokens = node.Text.Split(' ');
            return ObjectData.Find(ObjType.Линия, Int32.Parse(tokens[1]));
        }

        private void OnTreeChange(object sender, TreeViewEventArgs e)
        {
            var treeView = sender as TreeView;
            lastNode = selectedNode;
            selectedNode = e.Node;
            if (treeView.Tag.ToString().Contains("entTree"))
            {

                if (selectedNode.Text.Contains("Кривая"))
                {
                    pointsControlBox.Enabled = true;
                    IModelObject showObj, resetObj = null;
                    if (lastNode != null && lastNode.Text.Contains("Кривая"))
                    {
                        resetObj = FindObjectByTreeNode(lastNode);
                        resetObj.MasterColor = resetObj.InitialColor;
                    }
                    var keyInfo = selectedNode.Text.Split(' ');
                    showObj = FindObjectByTreeNode(selectedNode);
                    ShowObjectsEvent(ObjectData.LineCollection, showObj);
                }
                else
                    pointsControlBox.Enabled = false;
            }
            if (lastNode != null && lastNode.Text.Contains("Кривая"))
            {
                var resetObj = FindObjectByTreeNode(lastNode);
                resetObj.MasterColor = resetObj.InitialColor;
                ShowObjectsEvent(ObjectData.LineCollection, resetObj);
            }
        }
        private List<Tuple<int, string, Node[]>> GetElements(int dim, int tags = -1)
        {
            ElementProperties[] properties;
            int[] elementTypes;
            long[][] elemTags, nodeTags;
            long[] nodesT;
            double[] coords, parametric;
            var elems = new List<Tuple<int,string,Node[]>>();
            if (controller.ModelMeshGetElements(dim, tags, out elementTypes, out elemTags, out nodeTags))
            {
                if (controller.ModelMeshGetElementProperties(elementTypes, out properties))
                {
                    for (int i = 0; i < properties.Length; ++i)
                    {
                        var elements = elemTags[i];
                        controller.ModelMeshGetNodesByElementType(elementTypes[i], -1, false, out nodesT, out coords, out parametric);
                        for (var j = 0; j < elements.Length; ++j)
                        {
                            var nodesCount = properties[i].numNodes;
                            var nodesPerElem = new Node[nodesCount];
                            for (int k = 0; k < nodesCount; ++k)
                            {
                                var coordStride = j * nodesCount * 3 + k * 3;
                                var tagStride = j * nodesCount + k;
                                var x = (float)coords[coordStride + 0];
                                var y = (float)coords[coordStride + 1];
                                var z = (float)coords[coordStride + 2];
                                var point = new Point3D(x, y, z);
                                nodesPerElem[k] = new Node((int)nodeTags[i][tagStride], point);
                            }
                            elems.Add(Tuple.Create((int)elements[j], properties[i].elementName, nodesPerElem));
                        }
                    }
                }
            }
            return elems;
        }

        private List<Beam> CreateBeamElements()
        {
            var elements = new List<Beam>();
            foreach(var item in GetElements(1))
                elements.Add(new Beam(item.Item1, item.Item3));
            return elements;
        }

        private IEnumerable<IElement2D> Create2DElements()
        {
            var elements = new List<Element2D>();
            foreach (var item in GetElements(2))
            {
                if(item.Item2.Contains("Triangle"))
                    elements.Add(new Triangle(item.Item1, item.Item3));
                else
                    elements.Add(new Quad(item.Item1, item.Item3));
            }
            return elements.Count == 0 ? null : elements;
        }

        private IEnumerable<IElement3D> Create3DElements()
        {
            var elements = new List<Element3D>();
            foreach (var item in GetElements(3))
            {
                if (item.Item2.Contains("Tetra"))
                    elements.Add(new Tetra(item.Item1, item.Item3));
                else if (item.Item2.Contains("Hexa"))
                    elements.Add(new Hexa(item.Item1, item.Item3));
                else
                    elements.Add(new Penta(item.Item1, item.Item3));
            }
            return elements.Count == 0 ? null : elements;
        }

        private bool UpdateSurfaceElements(ObjType type, int[] numbers = null)
        {
            //TO DO
            //Создать метод для удаление любового объекта используя objData.Clear(ObjType)

            var ierr = 0;
            bool status = false;
            var dim = type == ObjType.Элемент2D || type == ObjType.Фигура2D ? 2 : 3;
            var updatedType = dim == 2 ? ObjType.Элемент2D : ObjType.Элемент3D;
            var forceClear = dim == 2 && volumesTree.Nodes.Count > 0;
            if (forceClear)
            {
                int[] dimTags;
                ObjectData.E3DCollection.Clear();
                updateSurfaceData.Invoke(ObjType.Элемент3D, null);
                controller.ModelGetGeometryEntities(out dimTags, 3);
                controller.gmshModelMeshClear(dimTags, (IntPtr)dimTags.Length, ref ierr);
            }
            if (numbers != null)//Удаляем сетку по условию
            {
                if (type == ObjType.Фигура2D || type == ObjType.Фигура3D)
                    controller.gmshModelMeshClear(numbers, (IntPtr)numbers.Length, ref ierr);
                else
                {
                    var idElems = numbers.Select(x => (long)x).ToArray();
                    controller.DeleteMeshElements(idElems);
                }
            }
            var nodes = controller.GetNodes(ref status);
            nodes = nodes.Count == 0 ? null : nodes;
            ObjectData.NodeCollection.Clear();
            if (nodes != null)
                ObjectData.NodeCollection.AddRange(nodes);
            updatePointData.Invoke(ObjType.Узел, nodes);
            if (updatedType == ObjType.Элемент2D)
            {
                var elements = Create2DElements();
                ObjectData.E2DCollection.Clear();
                if (elements != null)
                    ObjectData.E2DCollection.AddRange(elements); 
                updateSurfaceData.Invoke(updatedType, elements);
            }
            else
            {
                var elements = Create3DElements();
                ObjectData.E3DCollection.Clear();
                if (elements != null)
                    ObjectData.E3DCollection.AddRange(elements);
                updateSurfaceData.Invoke(updatedType, elements);
            }
            if (dim == 2)
            {
                ObjectData.E1DCollection.Clear();
                var elements1d = CreateBeamElements();
                elements1d = elements1d.Count == 0 ? null : elements1d;
                if (elements1d != null)
                    ObjectData.E1DCollection.AddRange(elements1d);
                updateElement1Data(ObjType.Элемент1D, elements1d);
            }
            return true;
        }

        private int[] GetElementsByType(ref string query, int dim, int tag)
        {
            var intType = GetElementTypeByString(ref query);
            string error;
            int[] elTypes;
            long[][] elTags, nodeTags;
            controller.ModelMeshGetElements(dim, tag, out elTypes, out elTags, out nodeTags);
            int[] dimTags = null;
            for (var i = 0; i < elTypes.Length; ++i)
                if (elTypes[i] == intType)
                {
                    var tags = elTags[i];
                    dimTags = new int[tags.Length * 2];
                    for (var j = 0; j < tags.Length; ++j)
                    {
                        dimTags[j * 2] = dim;
                        dimTags[j * 2 + 1] = Convert.ToInt32(tags[j]);
                    }
                    break;
                }
            return dimTags;
        }

        private bool IsNummericElement(int dim, string nodeKey)
        {
            if (nodeKey.Contains(fundamental[dim].Item2))
                return true;
            foreach (var element in elementType.Values)
                if (nodeKey.Contains(element.Item2))
                    return true;
            return false;
        }

        private int GetElementTypeByString(ref string query)
        {
            foreach (var entry in elementType)
                if (query.Contains(entry.Value.Item1))
                    return entry.Key;
            return 0;
        }

        private void OnDeleteElement(object sender, EventArgs e) => DeleteElement(ObjType.Элемент2D);

        private void OnDeleteVolElement(object sender, EventArgs e) => DeleteElement(ObjType.Элемент3D, ObjType.Фигура3D);

        private void DeleteElement(ObjType type, ObjType baseElement = ObjType.Поверхность)
        {
            // TO DO 
            // Может изменить вход на treeNode с которого было вызвано это действие?

            var dim = type == ObjType.Элемент2D ? 2 : 3;
            var parent = selectedNode;
            while (parent.Parent != null && parent.Parent.Nodes.Count == 1)
                parent = parent.Parent;
            if (parent.Text.Contains(fundamental[dim].Item1))
            {
                if (dim == 2)
                    DeleteMesh();
                else
                    DeleteVolume();
            }
            else
            {
                var isNumeric = IsNummericElement(dim, parent.Text);
                var keyData = parent.Text.Split(' ');
                var delType = parent.Text.Contains(fundamental[dim].Item2) ? baseElement : type;
                var dimTags = isNumeric ? new int[] { dim, Int32.Parse(keyData[1]) }
                             : GetElementsByType(ref keyData[0], dim, Int32.Parse(parent.Parent.Text.Split(' ')[1]));
                elemsTree.Nodes.Remove(parent);
                UpdateSurfaceElements(delType, dimTags);
                redrawScene?.Invoke(false);
            }
        }

        private void OnAddBoundFilter(object sender, EventArgs e)
        {
            var ierr = 0;
            var field = controller.gmshModelMeshFieldAdd("BoundaryLayer", -1, ref ierr);
            boundFieldTag = field;
            controller.gmshModelMeshFieldSetAsBoundaryLayer(boundFieldTag, ref ierr);
            btnFieldAdd.Enabled = false;
            chkBeta.Enabled = chkQuad.Enabled = btnFieldDelete.Enabled = chkMetrics.Enabled = true;
            grpFieldGeneral.Enabled = grpFieldSize.Enabled = true;
            grpFieldLayer.Enabled = grpFieldFan.Enabled = true;
            grpFieldBeta.Enabled = chkBeta.Checked;
        }

        private void OnRemoveBoundFilter(object sender, EventArgs e)
        {
            var ierr = 0;
            controller.gmshModelMeshFieldRemove(boundFieldTag, ref ierr);
            btnFieldAdd.Enabled = true;
            chkBeta.Enabled = chkQuad.Enabled = btnFieldDelete.Enabled = chkMetrics.Enabled = false;
            grpFieldGeneral.Enabled = grpFieldSize.Enabled = false;
            grpFieldLayer.Enabled = grpFieldFan.Enabled = false;
            grpFieldBeta.Enabled = false;
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
                var value = 0;
                if (!Int32.TryParse(data[i], out value))
                    return;
                values[i] = value;
            }
            var ierr = 0;
            controller.gmshModelMeshFieldSetNumbers(boundFieldTag, tag, values, (IntPtr)values.Length, ref ierr);
        }

        private void OnFilterValueEnter(object sender, EventArgs e)
        {
            var control = sender as TextBox;
            var optValue = control.Tag.ToString().Split(' ');
            var value = 0.0;
            if (!Double.TryParse(control.Text, out value))
                return;
            var ierr = 0;
            string error;
            controller.gmshModelMeshFieldSetNumber(boundFieldTag, optValue[0], value, ref ierr);
            controller.LoggerGetLastError(out error);
            if (!String.IsNullOrEmpty(error))
                showErrorMessage?.Invoke(error);
        }

        private void OnTransfiniteCurve(object sender, EventArgs e)
        {
            var nPoints = 0;
            var coef = 0.0;
            if (!Double.TryParse(algoCoef.Text, out coef) || !Int32.TryParse(algoNPoints.Text, out nPoints))
                return;
            var tag = Int32.Parse(selectedNode.Text.Split(' ')[1]);
            var checkedRadio = GetCheckedRadioButton();
            var ierr = 0;
            controller.gmshModelMeshSetTransfiniteCurve(tag, nPoints, checkedRadio.Text, coef, ref ierr);
        }

        private RadioButton GetCheckedRadioButton()
        {
            var radio = new RadioButton[] { rbtnProgressive, rbtnBump, rbtnBeta };
            for (var i = 0; i < radio.Length; ++i)
                if (radio[i].Checked)
                    return radio[i];
            return radio[0];
        }

        private void OnClosingForm(object sender, FormClosingEventArgs e)
        {
            if (IsControllerLoaded)
            {
                if (SaveObjectData)
                    saveObjectData?.Invoke(ObjectData);
                else
                    DeleteGeometry();
                var ierr = 0;
                controller.gmshFinalize(ref ierr);
            };
        }

        private void OnSaveData(object sender, EventArgs e)
        {
            SaveObjectData = true;
            ParentForm.Close();
        }
    }
}