using ModelInterfaces;
using System;
using System.Globalization;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using Geometry;
using ModelInterfaces.MeshObjects;
using System.Runtime.ExceptionServices;
using System.Security;
using ModelControllerInterfaces.GmshController;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Collections.ObjectModel;

namespace ModelModule
{
    public partial class GmshControl : UserControl
    {
        private const string cadTemplates = "CAD Files(*.brep; *.stp; *.step; *.igs; *.iges)|" +
                                                      "*.brep; *.stp; *.step; *.igs; *.iges";
        private const string scriptTemplates = "Script Files(*.geo)|*.geo";
        public IGmshController GmshController { get; set; }

        private int boundFieldTag;

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
        public bool IsControllerLoaded { get => GmshController != null; }
        public IObjectsData ObjectData { get; internal set; }

        public event Action<ObjType> updateVBOEvent;
        public event Action updateTreeViewEvent;
        public event Action hide3dTextEvent;
        public event Action<object, Show3dTextEventArgs> show3dTextEvent;
        public event Action<int> ShowObjectsEvent;
        public event Action<ObjType,bool> ResetColorObjectsEvent;
        public event Action<string> showErrorMessage;
        public event Action<object, ShowHeatMapEventArgs> showHeatMapEvent;
        public event Action hideHeatMapEvent;
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
            GmshController.Load(path);
            //ObjectData = new ObjectsData();
            var ierr = 0;
            GmshController.OptionSetNumber("General.AbortOnError", 0, ref ierr);//Запретить поделию Кристофа обваливать Базис
            algoChoice.SelectedIndex = 3;
        }

        private void UpdateGeometry(ObjType objType)
        {
            if (objType == ObjType.Точка)
            {
                ObjectData.PointCollection.Clear();
                int[] dimTags;
                GmshController.ModelGetGeometryEntities(out dimTags, 0);
                var controlPoints = GmshController.CreateControlPoints(dimTags);
                if(controlPoints.Count > 0)
                    ObjectData.PointCollection.AddRange(controlPoints);  
            }
            else if (objType == ObjType.Линия)
            {
                int[] dimTags;
                ObjectData.LineCollection.Clear();
                GmshController.ModelGetGeometryEntities(out dimTags, 1);
                var curves = GmshController.CreateLines(dimTags);
                if(curves.Count > 0)
                    ObjectData.LineCollection.AddRange(curves);
            }
        }

        private void GenerateGeometry()
        {
            DeleteMesh();
            updateVBOEvent?.Invoke(ObjType.Узел);//Обновляем все VBO не связанный с геометрией, т.к могло произойти удаление сетки
            updateVBOEvent?.Invoke(ObjType.Элемент1D);
            updateVBOEvent?.Invoke(ObjType.Элемент2D);
            updateVBOEvent?.Invoke(ObjType.Элемент3D);
            hide3dTextEvent?.Invoke();//Вызов очистки 3d текста

            ClearTreeView(3);
            ShowHideTabControls(3, false);
            ShowHideGeneralTabControls(3, false);

            ClearTreeView(2);
            ShowHideTabControls(2, false);

            UpdateGeometry(ObjType.Точка);
            UpdateGeometry(ObjType.Линия);
            updateVBOEvent?.Invoke(ObjType.Точка);
            updateVBOEvent?.Invoke(ObjType.Линия);
            var ierr = 0;
            FillGeometryTreeView();
            if (GmshController.GetGeometryObjectDimension(ref ierr) > 1)
                ShowHideGeneralTabControls(2);
            ShowHideGeneralTabControls(1);
            ShowHideTabControls(1);

            redrawScene?.Invoke(true);

            updateTreeViewEvent?.Invoke();
        }

        private void OnDeleteGeometry(object sender, EventArgs e)
        {
            DeleteGeometry();
            hide3dTextEvent?.Invoke();
            redrawScene?.Invoke(true);
            updateTreeViewEvent?.Invoke();
        }
        public void DeleteGeometry()
        {
            DeleteMesh();

            ClearTreeView(3);
            ShowHideTabControls(3, false);
            ShowHideGeneralTabControls(3, false);

            ClearTreeView(2);
            ShowHideTabControls(2, false);

            var ierr = 0;
            GmshController.Clear(ref ierr);
            UpdateGeometry(ObjType.Точка);
            UpdateGeometry(ObjType.Линия);
            updateVBOEvent?.Invoke(ObjType.Точка);
            updateVBOEvent?.Invoke(ObjType.Линия);
            //Обновляем все VBO, поскольку они могли присутствовать до удаления
            updateVBOEvent?.Invoke(ObjType.Узел);
            updateVBOEvent?.Invoke(ObjType.Элемент1D);
            updateVBOEvent?.Invoke(ObjType.Элемент2D);
            updateVBOEvent?.Invoke(ObjType.Элемент3D);
            ClearTreeView(1);
            ShowHideGeneralTabControls(2, false);
            ShowHideGeneralTabControls(1, false);
            ShowHideTabControls(1, false);
        }

        private void OnDeleteMesh2D(object sender, EventArgs e)
        {
            DeleteMesh();

            ClearTreeView(3);
            ShowHideTabControls(3, false);
            ShowHideGeneralTabControls(3, false);

            ClearTreeView(2);
            ShowHideTabControls(2, false);

            updateVBOEvent?.Invoke(ObjType.Узел);
            updateVBOEvent?.Invoke(ObjType.Элемент1D);
            updateVBOEvent?.Invoke(ObjType.Элемент2D);
            updateVBOEvent?.Invoke(ObjType.Элемент3D);

            redrawScene(false);

            updateTreeViewEvent?.Invoke();
        }
        /// <summary>
        /// Метод который удаляет только элементы сетки
        /// </summary>
        private void DeleteMesh()
        {
            DeleteMeshObjects(ObjType.Узел);
            ObjectData.Clear(ObjType.Узел);//Удаляем только элементы сетки, геометрию не трогаем
        }
        /// <summary>
        /// Удаляет только элементы 3D, обновляет VBO, деревья элементов, и пререрисовывает сцену
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDeleteMesh3D(object sender, EventArgs e)
        {
            DeleteMeshObjects(ObjType.Элемент3D);

            ObjectData.ClearAll();
            var objs = GmshController.GetMeshObjects();
            ObjectData.NodeCollection.AddRange(objs.Item1);
            ObjectData.E1DCollection.AddRange(objs.Item2);
            ObjectData.E2DCollection.AddRange(objs.Item3);

            updateVBOEvent?.Invoke(ObjType.Узел);
            updateVBOEvent?.Invoke(ObjType.Элемент3D);

            ClearTreeView(3);
            ShowHideTabControls(3, false);
            redrawScene.Invoke(false);

            updateTreeViewEvent?.Invoke();
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
                btnMesh2DDel.Enabled = show;
                meshElBox.Enabled = show;
                meshOpBox.Enabled = show;
            }
            else if (dim == 3)
            {
                btnMesh3DDel.Enabled = show;
                volElBox.Enabled = show;
            }
        }

        private void ClearTreeView(int dim)
        {
            if (dim == 1)
                geomTree.Nodes.Clear();
            else if (dim == 2)
                surfsTree.Nodes.Clear();
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
                GmshController.Clear(ref ierr);
                GmshController.Open(loadFileDialog.FileName, ref ierr);
                GenerateGeometry();
            }
        }

        [HandleProcessCorruptedStateExceptions]
        [SecurityCritical]
        private void OnGenerateMesh2D(object sender, EventArgs e)
        {
            var ierr = 0;
            string error;
            try
            {
                GmshController.ModelMeshGenerate(1, ref ierr);
                GmshController.ModelMeshGenerate(2, ref ierr);
            }
            catch(Exception ex)
            {
                showErrorMessage?.Invoke(ex.Message);
                OnSaveData(this, null);
                return;
            }
            GmshController.LoggerGetLastError(out error);
            if (!String.IsNullOrEmpty(error))
                showErrorMessage?.Invoke(error);
            if (volumesTree.Nodes.Count > 0)
            {
                DeleteMeshObjects(ObjType.Элемент3D);
                ShowHideTabControls(3, false);
                ClearTreeView(3);
            }
            ObjectData.Clear(ObjType.Узел);
            var objs = GmshController.GetMeshObjects();
            ObjectData.NodeCollection.AddRange(objs.Item1);
            ObjectData.E1DCollection.AddRange(objs.Item2);
            ObjectData.E2DCollection.AddRange(objs.Item3);

            updateVBOEvent?.Invoke(ObjType.Узел);
            updateVBOEvent?.Invoke(ObjType.Элемент1D);
            updateVBOEvent?.Invoke(ObjType.Элемент2D);
            updateVBOEvent?.Invoke(ObjType.Элемент3D);

            FillMeshTreeView(surfsTree, 2);
            ShowHideTabControls(2, true);
            if (GmshController.GetGeometryObjectDimension(ref ierr) > 2)
                ShowHideGeneralTabControls(3, true);
            redrawScene?.Invoke(false);

            updateTreeViewEvent?.Invoke();
        }

        [HandleProcessCorruptedStateExceptions]
        [SecurityCritical]
        private void OnGenerateMesh3D(object sender, EventArgs e)
        {
            var ierr = 0;
            string error;
            try
            {
                GmshController.ModelMeshGenerate(3, ref ierr);
            }
            catch (Exception ex)
            {
                showErrorMessage?.Invoke(ex.Message);
                OnSaveData(this, null);
                return;
            }
            GmshController.LoggerGetLastError(out error);
            if (!String.IsNullOrEmpty(error))
                showErrorMessage?.Invoke(error);

            var objs = GmshController.GetMeshObjects();
            if (objs.Item4.Count > 0)//Было ли что-то сгенерировано ?
            {
                ObjectData.Clear(ObjType.Узел);
                ObjectData.NodeCollection.AddRange(objs.Item1);
                ObjectData.E1DCollection.AddRange(objs.Item2);
                ObjectData.E2DCollection.AddRange(objs.Item3);
                ObjectData.E3DCollection.AddRange(objs.Item4);

                updateVBOEvent?.Invoke(ObjType.Узел);
                updateVBOEvent?.Invoke(ObjType.Элемент3D);

                FillMeshTreeView(volumesTree, 3, "Объемы", "Объем ");
                ShowHideTabControls(3, true);
                redrawScene?.Invoke(false);
            }

            updateTreeViewEvent?.Invoke();
        }

        private void OnDencityChange(object sender, EventArgs e)
        {
            var result = 0.0;
            if (Double.TryParse(meshDensityValue.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
            {
                var ierr = 0;
                GmshController.OptionSetNumber("Mesh.MeshSizeFactor", result, ref ierr);
            }
        }

        private void OnAlgorithmChoice(object sender, EventArgs e)
        {
            var ierr = 0;
            var choice = sender as ComboBox;
            var algo = new double[] { 1, 2, 5, 6, 8 };
            GmshController.OptionSetNumber("Mesh.Algorithm", algo[choice.SelectedIndex], ref ierr);
        }

        private void OnRefine(object sender, EventArgs e)
        {
            var ierr = 0;
            GmshController.ModelMeshRefine(ref ierr);

            ShowHideTabControls(3, false);
            ClearTreeView(3);
            var objs = GmshController.GetMeshObjects();
            ObjectData.Clear(ObjType.Узел);

            ObjectData.NodeCollection.AddRange(objs.Item1);
            ObjectData.E1DCollection.AddRange(objs.Item2);
            ObjectData.E2DCollection.AddRange(objs.Item3);

            updateVBOEvent?.Invoke(ObjType.Элемент3D);
            updateVBOEvent?.Invoke(ObjType.Элемент2D);
            updateVBOEvent?.Invoke(ObjType.Элемент1D);
            updateVBOEvent?.Invoke(ObjType.Узел);
            
            FillMeshTreeView(surfsTree, 2);
            redrawScene?.Invoke(false);
            updateTreeViewEvent?.Invoke();
        }

        private void OnQuadrangulate(object sender, EventArgs e)
        {
            var filename = string.Empty;
            GmshController.ModelGetFileName(out filename);
            var ext = Path.GetExtension(filename);
            if (ext.Contains("igs") || ext.Contains("iges"))
            {
                var ierr = 0;
                string error;
                GmshController.ModelMeshRecombine(ref ierr);
                GmshController.LoggerGetLastError(out error);
                if (!String.IsNullOrEmpty(error))
                    showErrorMessage?.Invoke(error);
                ShowHideTabControls(3, false);
                ClearTreeView(3);
                var objs = GmshController.GetMeshObjects();
                ObjectData.Clear(ObjType.Узел);

                ObjectData.NodeCollection.AddRange(objs.Item1);
                ObjectData.E1DCollection.AddRange(objs.Item2);
                ObjectData.E2DCollection.AddRange(objs.Item3);

                updateVBOEvent?.Invoke(ObjType.Элемент2D);
                updateVBOEvent?.Invoke(ObjType.Элемент1D);
                updateVBOEvent?.Invoke(ObjType.Узел);

                FillMeshTreeView(surfsTree, 2);
                redrawScene?.Invoke(false);
                updateTreeViewEvent?.Invoke();
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
            GmshController.ModelGetGeometryEntities(out dimTags, -1);
            ClearTreeView(1);
            var nodes = CreateGeometryNodes(dimTags);
            for (var i = 0; i < dimTags.Length; i += 2)
            {
                var dim = dimTags[i];
                var tag = dimTags[i + 1];
                GmshController.ModelGetAdjacencies(dim, tag, out upwards, out downwards);
                var current = nodes[dim][tag];
                if (upwards.Length == 0)
                    geomTree.Nodes.Add(current);
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
            GmshController.ModelGetGeometryEntities(out dimTags, dim);
            int[] elementTypes;
            long[][] elementTags, nodeTags;
            var surfNodes = new TreeNode[dimTags.Length / 2];
            tree.Nodes.Add(generalKey);
            for (int i = 1, m = 0; i < dimTags.Length; i += 2, ++m)
            {
                GmshController.ModelMeshGetElements(dim, dimTags[i], out elementTypes, out elementTags, out nodeTags);
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

                    if (dim == 2)
                        elemBase.ContextMenuStrip = cmsRemoveMesh2D;
                    else
                        elemBase.ContextMenuStrip = cmsRemoveMesh3D;

                    var elemNodes = new TreeNode[elements.Length];
                    for (var k = 0L; k < elements.Length; ++k)
                    {
                        var elemTag = elements[k];
                        var currentElement = triple.Item2 + elemTag.ToString();
                        elemNodes[k] = new TreeNode(currentElement);

                        if (dim == 2)
                            elemNodes[k].ContextMenuStrip = cmsRemoveMesh2D;
                        else
                            elemNodes[k].ContextMenuStrip = cmsRemoveMesh3D;
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

        private int FindObjectByTreeNode(TreeNode node)
        {
            var tokens = node.Text.Split(' ');
            return Int32.Parse(tokens[1]);
        }
        /// <summary>
        /// Записывает настройки трансфиниции в элементы управления
        /// </summary>
        private void WriteCurveSettingsToControls(string[] attributes)
        {
            if(attributes.Length == 0)
            {
                rbtnProgressive.Checked = true;
                algoCoef.Text = "1.0";
                txbAlgoNPoints.Text = string.Empty;
            }
            else
            {
                var law = attributes[1];
                if (rbtnBump.Text.Contains(law))
                    rbtnBump.Checked = true;
                else if (rbtnBeta.Text.Contains(law))
                    rbtnBeta.Checked = true;
                else
                    rbtnProgressive.Checked = true;

                txbAlgoNPoints.Text = attributes[0];
                algoCoef.Text = attributes[2].Length == 0 ? "1.0" : attributes[2];
            }
        }

        private void entTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text.Contains("Кривая"))
            {
                pointsControlBox.Enabled = true;
                var tag = FindObjectByTreeNode(e.Node);
                var attributes = GetCurrentCurveAttributes(tag);
                WriteCurveSettingsToControls(attributes);
                ShowObjectsEvent?.Invoke(tag);
            }
            else
                pointsControlBox.Enabled = false;
            redrawScene?.Invoke(false);
        }

        private void DeleteElementsByNumbers(int[] dimTags, string keyData)
        {
            foreach (var element in elementType.Values)
                if (element.Item1.Contains(keyData))
                {
                    long[] idElems = dimTags.Where((i, v) => (v & 1) == 1)
                                            .Select(v => (long)v)
                                            .ToArray();
                    GmshController.DeleteMeshElements(idElems);
                    return;
                }
            var ierr = 0;
            GmshController.ModelMeshClear(dimTags, (IntPtr)dimTags.Length, ref ierr);
        }

        private void DeleteMeshObjects(ObjType type)
        {
            var ierr = 0;
            int[] dimTags = null;
            var dim = 0;
            if(type == ObjType.Узел) //удаляем всю сетку узлы,1d,2d,3d
            {
                dimTags = new int[0];
                /*dim = 0;
                controller.ModelGetGeometryEntities(out dimTags, dim);*/
            }

            if (type == ObjType.Элемент1D)//удаляем все 1d элементы
            {
                dim = 1;
                GmshController.ModelGetGeometryEntities(out dimTags, dim);
            }
            else if (type == ObjType.Элемент2D)//удаляем все 2d элементы
            {
                dim = 2;
                GmshController.ModelGetGeometryEntities(out dimTags, dim);
            }
            else if (type == ObjType.Элемент3D)//удаляем все 3d элементы
            {
                dim = 3;
                GmshController.ModelGetGeometryEntities(out dimTags, dim);
            }

            GmshController.ModelMeshClear(dimTags, (IntPtr)dimTags.Length, ref ierr);
        }

        private int[] GetElementsByType(ref string query, int dim, int tag)
        {
            var intType = GetElementTypeByString(ref query);
            int[] elTypes;
            long[][] elTags, nodeTags;
            GmshController.ModelMeshGetElements(dim, tag, out elTypes, out elTags, out nodeTags);
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

        private int GetElementTypeByString(ref string query)
        {
            foreach (var entry in elementType)
                if (query.Contains(entry.Value.Item1))
                    return entry.Key;
            return 0;
        }

        private void OnDeleteElement2D(object sender, EventArgs e) => DeleteElement(surfsTree.SelectedNode);

        private void OnDeleteElement3D(object sender, EventArgs e) => DeleteElement(volumesTree.SelectedNode);

        private void DeleteElement(TreeNode currentNode)
        {
            // TO DO 
            // Может изменить вход на treeNode с которого было вызвано это действие? - Ок, сделано.
            var tn = new TreeNode();
            var dim = currentNode.TreeView.Equals(surfsTree) ? 2 : 3;
            
            // Ищем одиночные узлы двигаясь вверх по дереву,
            // пока не встречаем более чем один узел в ветке.
            while (currentNode.Parent != null && currentNode.Parent.Nodes.Count == 1)
                currentNode = currentNode.Parent;

            if (currentNode.Text.Contains(fundamental[dim].Item1))
            {
                ClearTreeView(3);
                ShowHideTabControls(3, false);
                if (dim == 2)
                {
                    DeleteMesh();
                    ShowHideGeneralTabControls(3, false);
                    ClearTreeView(2);
                    ShowHideTabControls(2, false);
                }
                else
                {
                    DeleteMeshObjects(ObjType.Элемент3D);
                    ObjectData.Clear(ObjType.Узел);
                    var objs = GmshController.GetMeshObjects();
                    if (objs.Item1.Count > 0)
                        ObjectData.NodeCollection.AddRange(objs.Item1);
                    if (objs.Item2.Count > 0)
                        ObjectData.E1DCollection.AddRange(objs.Item2);
                    if (objs.Item3.Count > 0)
                        ObjectData.E2DCollection.AddRange(objs.Item3);
                }
                updateVBOEvent?.Invoke(ObjType.Элемент3D);
                updateVBOEvent?.Invoke(ObjType.Элемент2D);
                updateVBOEvent?.Invoke(ObjType.Элемент1D);
                updateVBOEvent?.Invoke(ObjType.Узел);
            }
            else
            {
                var keyData = currentNode.Text.Split(' ');
                var isNumeric = keyData.Length > 1;
                var dimTags = isNumeric ? new int[] { dim, Int32.Parse(keyData[1]) }
                             : GetElementsByType(ref keyData[0], dim, Int32.Parse(currentNode.Parent.Text.Split(' ')[1]));
                surfsTree.Nodes.Remove(currentNode);
                DeleteElementsByNumbers(dimTags, keyData[0]);
                var objs = GmshController.GetMeshObjects();
                if (dim == 2)
                {
                    ObjectData.Clear(ObjType.Элемент2D);
                    ObjectData.E2DCollection.AddRange(objs.Item3);
                    updateVBOEvent?.Invoke(ObjType.Элемент2D);
                }
                else
                {
                    ObjectData.Clear(ObjType.Элемент3D);
                    ObjectData.E3DCollection.AddRange(objs.Item4);
                    updateVBOEvent?.Invoke(ObjType.Элемент3D);
                }
            }
            updateTreeViewEvent?.Invoke();
            redrawScene?.Invoke(false);
        }

        private void OnAddBoundFilter(object sender, EventArgs e)
        {
            var ierr = 0;
            var field = GmshController.ModelMeshFieldAdd("BoundaryLayer", -1, ref ierr);
            boundFieldTag = field;
            GmshController.ModelMeshFieldSetAsBoundaryLayer(boundFieldTag, ref ierr);
            btnFieldAdd.Enabled = false;
            chkBeta.Enabled = chkQuad.Enabled = btnFieldDelete.Enabled = chkMetrics.Enabled = true;
            grpFieldGeneral.Enabled = grpFieldSize.Enabled = true;
            grpFieldLayer.Enabled = grpFieldFan.Enabled = true;
            grpFieldBeta.Enabled = chkBeta.Checked;
        }

        private void OnRemoveBoundFilter(object sender, EventArgs e)
        {
            var ierr = 0;
            GmshController.ModelMeshFieldRemove(boundFieldTag, ref ierr);
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
            GmshController.ModelMeshFieldSetNumber(boundFieldTag, tag, value, ref ierr);
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
            GmshController.ModelMeshFieldSetNumbers(boundFieldTag, tag, values, (IntPtr)values.Length, ref ierr);
        }

        private void OnFilterValueEnter(object sender, EventArgs e)
        {
            var control = sender as TextBox;
            var optValue = control.Tag.ToString().Split(' ');
            var value = 0.0;
            if (!Double.TryParse(control.Text, out value))
                return;
            var ierr = 0;
            GmshController.ModelMeshFieldSetNumber(boundFieldTag, optValue[0], value, ref ierr);
        }
        /// <summary>
        /// Получить аттрибуты для текущей выбранной в дереве узлов кривой
        /// </summary>
        /// <returns>Аттрибуты кривой</returns>
        private string[] GetCurrentCurveAttributes(int tag)
        {
            string[] attributes;
            GmshController.ModelGetAttribute($"transfinite {tag}", out attributes);
            return attributes;
        }

        private void OnClosingForm(object sender, FormClosingEventArgs e)
        {
            if (IsControllerLoaded)
            {
                hide3dTextEvent?.Invoke();
                if (!SaveObjectData)
                {
                    DeleteGeometry();
                    redrawScene?.Invoke(true);
                }

                var ierr = 0;
                GmshController.Finalize(ref ierr);

                updateTreeViewEvent?.Invoke();
                hideHeatMapEvent?.Invoke();
            };
        }

        private void OnSaveData(object sender, EventArgs e)
        {
            SaveObjectData = true;
            ParentForm.Close();
        }

        private void entTree_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            var oldNode = geomTree.SelectedNode;
            if (oldNode != null && oldNode.Text.Contains("Кривая"))
            {
                ResetColorObjectsEvent?.Invoke(ObjType.Линия, true);
            }
            else
                pointsControlBox.Enabled = false;
        }
        /// <summary>
        /// Вернуть центр масс текущей геометрической сущности
        /// </summary>
        /// <param name="dim">Геометрическая размерность</param>
        /// <param name="tag">Идентификатор геометрической сущности</param>
        /// <returns>Центр масс</returns>
        private Point3D GetCenterOfGeometryEntity(int dim, int tag)
        {
            var ierr = 0;
            double x = 0, y = 0, z = 0;
            GmshController.ModelOccGetCenterOfMass(dim, tag, ref x, ref y, ref z, ref ierr);
            var point = new Point3D((float)x, (float)y, (float)z);
            return point;
        }
        /// <summary>
        /// Показать информацию о кривых
        /// </summary>
        private void ShowCurvesInfo()
        {
            // тут нужно перебрать все кривые которые есть в модели и показать их параметры разметки
            string[] attribList;
            GmshController.ModelGetAttributeNames(out attribList);
            var list = new List<Tuple<string,Point3D>>(attribList.Length);
            foreach (var item in attribList)
            {          
                var tag = Int32.Parse(item.Split(' ')[1]);
                var attributes = GetCurrentCurveAttributes(tag);

                if(attributes.Length == 3)
                {
                    var text = $"{attributes[2]} {attributes[1]} {attributes[0]}";
                    var point = GetCenterOfGeometryEntity(1,tag);
                    list.Add(Tuple.Create(text, point));
                }
            }
            show3dTextEvent?.Invoke(this,new Show3dTextEventArgs(list));  
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            var ierr = 0;
            var tag = FindObjectByTreeNode(geomTree.SelectedNode);

            var attributes = new string[3] { txbAlgoNPoints.Text, rbtnProgressive.Text, algoCoef.Text };
            if (rbtnBeta.Checked)
                attributes[1] = rbtnBeta.Text;
            else if (rbtnBump.Checked)
                attributes[1] = rbtnBump.Text;
            double points = 0, coef = 0;
            if(Double.TryParse(txbAlgoNPoints.Text, out points))//Обязательный TryParse иначе Exсeption по пустому полю
            {
                if(Double.TryParse(algoCoef.Text, out coef))//Обязательный TryParse иначе Exсeption по пустому полю
                {
                    GmshController.ModelSetAttribute($"transfinite {tag}", attributes, (IntPtr)3, ref ierr);
                    if (attributes.All(x => x.Length != 0))
                    {
                        GmshController.ModelMeshSetTransfiniteCurve(tag, (int)points, attributes[1], coef, ref ierr);
                        //Перегенерация сетки, если она присутствовала в момент уплотнения кривой
                        if (ObjectData.E2DCollection.Count > 0)
                            OnGenerateMesh2D(sender, EventArgs.Empty);
                    }
                }
            }

            if (chbShowCurvesInfo.Checked)
                ShowCurvesInfo();

            if (chbShowHeatMap.Checked)
            {
                var dict = GetCurvesNumbersAndNodes();
                showHeatMapEvent?.Invoke(this, new ShowHeatMapEventArgs(dict));
            }
        }

        private void chbShowCurvesInfo_Click(object sender, EventArgs e)
        {
            if (chbShowCurvesInfo.Checked)
                ShowCurvesInfo();
            else
            {
                hide3dTextEvent?.Invoke();//Прячем весь текст
                if (chbShowCurvesInfo.Checked)//Рассматриваем случай когда поверхности должны быть отображены
                    ShowSurfacesInfo();
            }
        }

        private void chbShowHeatMap_Click(object sender, EventArgs e)
        {

            if (chbShowHeatMap.Checked)
            {
                var dict = GetCurvesNumbersAndNodes();
                showHeatMapEvent?.Invoke(this, new ShowHeatMapEventArgs(dict));
            }
            else hideHeatMapEvent?.Invoke();

        }
        /// <summary>
        /// GetNodesOnCurves. Where key - curve number, value - nodes on curve
        /// </summary>
        /// <returns></returns>
        private Dictionary<int, int> GetCurvesNumbersAndNodes()
        {
            var curveDict = new Dictionary<int, int>();
            //1)Добавляем в словарь сначала размеченные кривые
            string[] attribList;
            GmshController.ModelGetAttributeNames(out attribList);
            foreach (var item in attribList)
            {
                var tag = Int32.Parse(item.Split(' ')[1]);
                var attributes = GetCurrentCurveAttributes(tag);
                var points = attributes.Length == 3 ? Int32.Parse(attributes[0]) : 0;
                curveDict.Add(tag, points);
            }
            //2)Добавляем в словарь неразмеченные кривые, которых нет в словаре (со значением ноль)
            int[] dimTags;
            GmshController.ModelGetGeometryEntities(out dimTags, 1);
            for (var i = 1; i < dimTags.Length; i += 2)
                if (!curveDict.ContainsKey(dimTags[i]))
                    curveDict.Add(dimTags[i], 0);
            return curveDict;
        }
        /*
        private Point3D GetOffsetPointFromCenter(int dim, int tag, float offset)
        {
            var controller = (GmshApi.GmshController.GmshController)GmshController;
            var ierr = 0;
            double x = 0, y = 0, z = 0;
            GmshController.ModelOccGetCenterOfMass(dim, tag, ref x, ref y, ref z, ref ierr);
            var point = new Point3D((float)x, (float)y, (float)z);
            double[] parametric, first;
            controller.ModelGetParametrization(dim, tag, new double[] { x, y, z }, out parametric);
            controller.ModelGetDerivative(dim, tag, new double[] { parametric[0], parametric[1] }, out first);
            var du = new Point3D((float)first[0], (float)first[1], (float)first[2]);
            var dv = new Point3D((float)first[3], (float)first[4], (float)first[5]);
            var normal = Vector.CrossProd(du, dv);
            normal = Vector.GetVectorNorm(normal);
            var scaledNormal = normal.Mult(offset);
            var potPoint = point.Sum(scaledNormal);
            return potPoint;
            var status = controller.gmshModelIsInside(dim, tag, new double[] { potPoint._x, potPoint._y, potPoint._z },
                                                     (IntPtr)3, 0, ref ierr);
            return status == 1 ? point.Sub(scaledNormal) : potPoint;
        }*/

        private void ShowSurfacesInfo()
        {
            int[] dimTags;
            GmshController.ModelGetGeometryEntities(out dimTags, 2);
            var surfList = new List<Tuple<string, Point3D>>();
            for (var i = 1; i < dimTags.Length; i += 2)
            {
                var point = GetCenterOfGeometryEntity(2, dimTags[i]);
                //var point = GetOffsetPointFromCenter(2, dimTags[i], 10);
                var text = $"Поверхность {dimTags[i]}";
                surfList.Add(Tuple.Create(text, point));
            }
            show3dTextEvent?.Invoke(this, new Show3dTextEventArgs(surfList));
        }

        private void chbShowSurfacesInfo_Click(object sender, EventArgs e)
        {
            if (chbShowSurfacesInfo.Checked)
                ShowSurfacesInfo();
            else
            {
                hide3dTextEvent?.Invoke();//Прячем весь текст
                if (chbShowCurvesInfo.Checked)//Рассматриваем случай когда кривые должны быть отображены
                    ShowCurvesInfo();
            }
        }
    }
}