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
using Model.GeometryObjects;
using Geometry;
using ModelInterfaces.MeshObjects;
using SceneInterface;
using System.Runtime.ExceptionServices;
using System.Security;
using System.Data.Odbc;

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

        public event Action<ObjType> updateVBOEvent;
        //public event Action saveObjectData;
        public event Action<int> ShowObjectsEvent;
        public event Action<ObjType,bool> ResetColorObjectsEvent;
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
            //ObjectData = new ObjectsData();
            var ierr = 0;
            controller.gmshOptionSetNumber("General.AbortOnError", 0, ref ierr);//Запретить поделию Кристофа обваливать Базис
            algoChoice.SelectedIndex = 3;
        }

        private bool UpdateGeometry(ObjType objType)
        {
            if (objType == ObjType.Точка)
            {
                ObjectData.PointCollection.Clear();
                int[] dimTags;
                controller.ModelGetGeometryEntities(out dimTags, 0);
                var controlPoints = controller.CreateControlPoints(dimTags);
                if(controlPoints.Count > 0)
                    ObjectData.PointCollection.AddRange(controlPoints);
                updateVBOEvent?.Invoke(ObjType.Точка);
            }
            else if (objType == ObjType.Линия)
            {
                bool status = false;
                int[] dimTags;
                ObjectData.LineCollection.Clear();
                controller.ModelGetGeometryEntities(out dimTags, 1);
                var curves = controller.CreateLines(dimTags, ref status);
                if(curves.Count > 0)
                    ObjectData.LineCollection.AddRange(curves);
                updateVBOEvent?.Invoke(ObjType.Линия);
            }
            return true;
        }

        private void GenerateGeometry()
        {
            DeleteMesh();
            UpdateGeometry(ObjType.Точка);
            UpdateGeometry(ObjType.Линия);
            var ierr = 0;
            FillGeometryTreeView();
            if (controller.gmshModelGetDimension(ref ierr) > 1)
                ShowHideGeneralTabControls(2);
            ShowHideGeneralTabControls(1);
            ShowHideTabControls(1);
            redrawScene?.Invoke(true);
        }

        private void OnDeleteGeometry(object sender, EventArgs e)
        {
            DeleteMesh();
            var ierr = 0;
            controller.gmshClear(ref ierr);
            UpdateGeometry(ObjType.Точка);
            UpdateGeometry(ObjType.Линия);
            //UpdateGeometry(new int[0]);//Удалить всю геометрию
            ClearTreeView(1);
            ShowHideGeneralTabControls(2, false);
            ShowHideGeneralTabControls(1, false);
            ShowHideTabControls(1, false);

            redrawScene?.Invoke(true);
        }
        public void DeleteGeometry(bool redraw = true)
        {
            DeleteMesh();
            var ierr = 0;
            controller.gmshClear(ref ierr);
            UpdateGeometry(ObjType.Точка);
            UpdateGeometry(ObjType.Линия);
            //UpdateGeometry(new int[0]);//Удалить всю геометрию
            ClearTreeView(1);
            ShowHideGeneralTabControls(2, false);
            ShowHideGeneralTabControls(1, false);
            ShowHideTabControls(1, false);
            if (redraw)
                redrawScene?.Invoke(true);
        }

        private void OnDeleteMesh2D(object sender, EventArgs e) => DeleteMesh();

        private void DeleteMesh()
        {
            DeleteMeshObjects(ObjType.Узел);
            UpdateObjectsData(ObjType.Узел);
            UpdateObjectsData(ObjType.Элемент1D);
            UpdateObjectsData(ObjType.Элемент2D);
            UpdateObjectsData(ObjType.Элемент3D);

            updateVBOEvent?.Invoke(ObjType.Узел);
            updateVBOEvent?.Invoke(ObjType.Элемент1D);
            updateVBOEvent?.Invoke(ObjType.Элемент2D);
            updateVBOEvent?.Invoke(ObjType.Элемент3D);
            //UpdateSurfaceElements(ObjType.Фигура2D, new int[0]);//Удалить все - заменено
            if (volumesTree.Nodes.Count > 0)
            {
                ClearTreeView(3);
                ShowHideTabControls(3, false);
            }
            ShowHideGeneralTabControls(3, false);
            ClearTreeView(2);
            ShowHideTabControls(2, false);
        }

        private void OnDeleteVolume(object sender, EventArgs e) => DeleteVolume();

        private void DeleteVolume(bool redraw = true)
        {
            DeleteMeshObjects(ObjType.Элемент3D);
            UpdateObjectsData(ObjType.Узел);
            UpdateObjectsData(ObjType.Элемент3D);
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
                mesh2DGenBtn.Enabled = show;//Активация/деактивация кнопки сгенерировать
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

        [HandleProcessCorruptedStateExceptions]
        [SecurityCritical]
        private void OnGenerateMesh2D(object sender, EventArgs e)
        {
            var ierr = 0;
            string error;
            //controller.gmshOptionSetNumber("General.AbortOnError", 0, ref ierr);
            try
            {
                controller.gmshModelMeshGenerate(1, ref ierr);
                controller.gmshModelMeshGenerate(2, ref ierr);
            }
            catch(Exception ex)
            {
                showErrorMessage?.Invoke(ex.Message);
                OnSaveData(this, null);
                return;
            }
            controller.LoggerGetLastError(out error);
            if (!String.IsNullOrEmpty(error))
                showErrorMessage?.Invoke(error);
            if (volumesTree.Nodes.Count > 0)
            {
                DeleteMeshObjects(ObjType.Элемент3D);
                UpdateObjectsData(ObjType.Элемент3D);
                ShowHideTabControls(3, false);
                ClearTreeView(3);
            }
            UpdateObjectsData(ObjType.Узел);
            UpdateObjectsData(ObjType.Элемент1D);
            UpdateObjectsData(ObjType.Элемент2D);

            updateVBOEvent?.Invoke(ObjType.Узел);
            updateVBOEvent?.Invoke(ObjType.Элемент1D);
            updateVBOEvent?.Invoke(ObjType.Элемент2D);
            updateVBOEvent?.Invoke(ObjType.Элемент3D);

            FillMeshTreeView(elemsTree, 2);
            ShowHideTabControls(2, true);
            if (controller.gmshModelGetDimension(ref ierr) > 2)
                ShowHideGeneralTabControls(3, true);
            redrawScene?.Invoke(false);
        }

        [HandleProcessCorruptedStateExceptions]
        [SecurityCritical]
        private void OnGenerateMesh3D(object sender, EventArgs e)
        {
            var ierr = 0;
            string error;
            try
            {
                controller.gmshModelMeshGenerate(3, ref ierr);
            }
            catch (Exception ex)
            {
                showErrorMessage?.Invoke(ex.Message);
                OnSaveData(this, null);
                return;
            }
            controller.LoggerGetLastError(out error);
            if (!String.IsNullOrEmpty(error))
                showErrorMessage?.Invoke(error);

            UpdateObjectsData(ObjType.Элемент3D);
            UpdateObjectsData(ObjType.Узел);

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
            var choice = sender as ComboBox;
            var algo = new double[] { 1, 2, 5, 6, 8 };
            controller.gmshOptionSetNumber("Mesh.Algorithm", algo[choice.SelectedIndex], ref ierr);
        }

        private void OnRefine(object sender, EventArgs e)
        {
            var ierr = 0;
            controller.gmshModelMeshRefine(ref ierr);
            if (volumesTree.Nodes.Count > 0)
            {
                DeleteMeshObjects(ObjType.Элемент3D);
                UpdateObjectsData(ObjType.Элемент3D);
                ShowHideTabControls(3, false);
                ClearTreeView(3);
            }
            UpdateObjectsData(ObjType.Элемент2D);
            UpdateObjectsData(ObjType.Элемент1D);
            UpdateObjectsData(ObjType.Узел);
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
                if (volumesTree.Nodes.Count > 0)
                {
                    DeleteMeshObjects(ObjType.Элемент3D);
                    UpdateObjectsData(ObjType.Элемент3D);
                    ShowHideTabControls(3, false);
                    ClearTreeView(3);
                }
                UpdateObjectsData(ObjType.Элемент2D);
                UpdateObjectsData(ObjType.Элемент1D);
                UpdateObjectsData(ObjType.Узел);
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
            var surfNodes = new TreeNode[dimTags.Length / 2];
            tree.Nodes.Add(generalKey);
            for (int i = 1, m = 0; i < dimTags.Length; i += 2, ++m)
            {
                controller.ModelMeshGetElements(dim, dimTags[i], out elementTypes, out elementTags, out nodeTags);
                var child = generalChild + dimTags[i].ToString();
                surfNodes[m] = new TreeNode(child);
                //AddTreeNode(tree.Nodes, generalKey, child);//Очень медленно работает добавление узла в циклах, нужно что-то делать
                var currentSurface = surfNodes[m];
                //var currentSurface = tree.Nodes[generalKey].Nodes[child];
                for (var j = 0; j < elementTypes.Length; ++j)
                {
                    var triple = elementType[elementTypes[j]];//, out elemKey, out elemChild, out points);
                    var elements = elementTags[j];
                    var elemBase = new TreeNode(triple.Item1);
                    var elemNodes = new TreeNode[elements.Length];
                    for (var k = 0L; k < elements.Length; ++k)
                    {
                        var elemTag = elements[k];
                        var currentElement = triple.Item2 + elemTag.ToString();
                        elemNodes[k] = new TreeNode(currentElement);
                        //AddTreeNode(currentSurface.Nodes, triple.Item1, currentElement);//Очень медленно работает добавление узла в циклах, нужно что-то делать
                        //var currentType = currentSurface.Nodes[triple.Item1].Nodes[currentElement];
                        var nodNodes = new TreeNode[triple.Item3];
                        for (var l = 0; l < triple.Item3; ++l)
                        {
                            var nodeTag = "Узел " + nodeTags[j][k * triple.Item3 + l].ToString();
                            nodNodes[l] = new TreeNode(nodeTag);
                            //currentType.Nodes.Add(nodeTag, nodeTag);
                        }
                        elemNodes[k].Nodes.AddRange(nodNodes);
                    }
                    elemBase.Nodes.AddRange(elemNodes);
                    currentSurface.Nodes.Add(elemBase);
                }
                tree.Nodes[0].Nodes.Add(currentSurface);
            }
        }

        private void AddTreeNode(TreeNodeCollection tree, string key, string childInfo)
        {
            if (!tree.ContainsKey(key))
                tree.Add(key, key);
            tree[key].Nodes.Add(childInfo, childInfo);
        }

        private int FindObjectByTreeNode(TreeNode node)
        {
            var tokens = node.Text.Split(' ');
            //return ObjectData.Find(ObjType.Линия, Int32.Parse(tokens[1]));
            return Int32.Parse(tokens[1]);
        }

        private void entTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text.Contains("Кривая"))
            {
                pointsControlBox.Enabled = true;
                var objInd = FindObjectByTreeNode(e.Node);
                ShowObjectsEvent?.Invoke(objInd);
            }
            else
                pointsControlBox.Enabled = false;
            redrawScene?.Invoke(false);
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

        private List<IElement2D> Create2DElements()
        {
            var elements = new List<IElement2D>();
            foreach (var item in GetElements(2))
            {
                if(item.Item2.Contains("Triangle"))
                    elements.Add(new Triangle(item.Item1, item.Item3));
                else
                    elements.Add(new Quad(item.Item1, item.Item3));
            }
            return elements;
        }

        private List<IElement3D> Create3DElements()
        {
            var elements = new List<IElement3D>();
            foreach (var item in GetElements(3))
            {
                if (item.Item2.Contains("Tetra"))
                    elements.Add(new Tetra(item.Item1, item.Item3));
                else if (item.Item2.Contains("Hexa"))
                    elements.Add(new Hexa(item.Item1, item.Item3));
                else
                    elements.Add(new Penta(item.Item1, item.Item3));
            }
            return elements;
        }

        private void DeleteElementsByNumbers(int[] dimTags)
        {
            var ierr = 0;
            controller.gmshModelMeshClear(dimTags, (IntPtr)dimTags.Length, ref ierr);
        }

        private void DeleteMeshObjects(ObjType type)
        {
            var ierr = 0;
            int[] dimTags = null;
            var dim = 0;
            if(type == ObjType.Узел)
            {
                dim = 0;
                controller.ModelGetGeometryEntities(out dimTags, dim);
            }
            if (type == ObjType.Элемент1D)//удаляем все 1d элементы
            {
                dim = 1;
                controller.ModelGetGeometryEntities(out dimTags, dim);
            }
            else if (type == ObjType.Элемент2D)//удаляем все 2d элементы
            {
                dim = 2;
                controller.ModelGetGeometryEntities(out dimTags, dim);
            }
            else if (type == ObjType.Элемент3D)//удаляем все 3d элементы
            {
                dim = 3;
                controller.ModelGetGeometryEntities(out dimTags, dim);
            }
            //else if (type == ObjType.Узел)//удаляем всю сетку узлы,1d,2d,3d
            //{
            //    dimTags = new int[0];
            //}
            controller.gmshModelMeshClear(dimTags, (IntPtr)dimTags.Length, ref ierr);
        }

        private void UpdateObjectsData(ObjType type)
        {
            if (type == ObjType.Узел)
            {
                var status = false;
                ObjectData.NodeCollection.Clear();
                var nodes = controller.GetNodes(ref status);
                if(nodes.Count > 0)
                    ObjectData.NodeCollection.AddRange(nodes);
            }
            else if (type == ObjType.Элемент1D)
            {
                ObjectData.E1DCollection.Clear();
                var elements1D = CreateBeamElements();
                if(elements1D.Count > 0)
                    ObjectData.E1DCollection.AddRange(elements1D);
            }
            else if (type == ObjType.Элемент2D)
            {
                ObjectData.E2DCollection.Clear();
                var elements2D = Create2DElements();
                if(elements2D.Count > 0)
                    ObjectData.E2DCollection.AddRange(elements2D);
            }
            else if (type == ObjType.Элемент3D)
            {
                ObjectData.E3DCollection.Clear();
                var elements3D = Create3DElements();
                if(elements3D.Count > 0)
                    ObjectData.E3DCollection.AddRange(elements3D);
            }           
        }

        private int[] GetElementsByType(ref string query, int dim, int tag)
        {
            var intType = GetElementTypeByString(ref query);
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
            var parent = type == ObjType.Элемент2D ? elemsTree.SelectedNode : volumesTree.SelectedNode;
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
                DeleteElementsByNumbers(dimTags);
                UpdateObjectsData(type);
                UpdateObjectsData(ObjType.Узел);
                //UpdateSurfaceElements(delType, dimTags);//Удалить только указанные димТагс - заменено
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
            /*controller.LoggerGetLastError(out error);
            if (!String.IsNullOrEmpty(error))
                showErrorMessage?.Invoke(error);*/
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
                if (!SaveObjectData)
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

        private void entTree_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            var oldNode = entTree.SelectedNode;
            if (oldNode != null && oldNode.Text.Contains("Кривая"))
                ResetColorObjectsEvent?.Invoke(ObjType.Линия, true);
            else
                pointsControlBox.Enabled = false;
        }
    }
}