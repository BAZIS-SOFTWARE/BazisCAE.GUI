using ModelInterfaces;
using System;
using System.Globalization;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelControllerInterfaces.GmshController;

namespace ModelModule
{
    public partial class GMSHGeneralMeshControl : UserControl
    {
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
        /// <summary>
        /// Get types of elements
        /// </summary>
        public IEnumerable<string> ElementsType 
        { 
            get
            {
                foreach (var item in elementType.Values)
                {
                    yield return item.Item1;
                }
            }
        }
        public event Action<double> setMeshAlgoEvent;
        public event Action updateObjectsDataEvent;
        public event Action<ObjType> deleteMeshEvent;
        public event Action<object,double, ObjType> generateMeshEvent;
        public event Action<object> generateQuadMesh;
        public event Action<bool> showTransPoints;
        public event Action updateGeometryVBOEvent;
        public event Action updateTreeViewEvent;
        public event Action<bool> showCurveInfoEvent;
        public event Action<bool> showSurfaceInfoEvent;
        public event Action<object, Show3dTextEventArgs> show3dTextEvent;
        public event Action<List<int>> showObjectsEvent;
        public event Action<ObjType> resetColorObjectsEvent;
        public event Action<object> refineMesh;
        public event Action<bool> showHeatMapEvent;

        public event Action<object, DeleteElementEventArgs> deleteElementEvent;
        public event Action<object, SetTransfiniteCurveEventArgs> setTransfiniteCurveEvent;
        public event Action<object,int> setCurveDataEvent;


        public GMSHGeneralMeshControl()
        {
            InitializeComponent();
            //algoChoice.SelectedIndex = 3;
        }
        

        private void OnDeleteMesh2D(object sender, EventArgs e)
        {
            ClearTreeView(3);
            //ShowHideTabControls(3, false);
            //ShowHideGeneralTabControls(3, false);

            ClearTreeView(2);
            //ShowHideTabControls(2, false);

            deleteMeshEvent?.Invoke(ObjType.Элемент2D);
        }

        private void OnDeleteMesh3D(object sender, EventArgs e)
        {
            ClearTreeView(3);
            //ShowHideTabControls(3, false);

            deleteMeshEvent?.Invoke(ObjType.Элемент3D);
        }

        public void ShowHideGeneralTabControls(int dim, bool show = true)
        {
            if (dim == 1)
            {
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
                grbVolControlBox.Enabled = show;
                btnGenVolMesh.Enabled = show;
            }
        }

        public void ShowHideTabControls(int dim, bool show = true)
        {
            if (dim == 2)
            {
                btnMesh2DDel.Enabled = show;
                surfsTree.Enabled = show;
            }
            else if (dim == 3)
            {
                grbVolControlBox.Enabled = show;
                volumesTree.Enabled = show;
            }
        }

        /// <summary>
        /// GetTreeView
        /// </summary>
        /// <param name="dim"></param>
        /// <returns>TreeView</returns>
        public TreeView GetTreeView(int dim)
        {
            if (dim == 1)
                return geomTree;
            else if (dim == 2)
                return surfsTree;
            else
                return volumesTree;
        }
        /// <summary>
        /// ClearTreeView
        /// </summary>
        /// <param name="dim"></param>
        public void ClearTreeView(int dim)
        {
            if (dim == 1)
                geomTree.Nodes.Clear();
            else if (dim == 2)
                surfsTree.Nodes.Clear();
            else if (dim == 3)
                volumesTree.Nodes.Clear();
        }


        private void OnGenerateMesh2D(object sender, EventArgs e)
        {      
            //if (volumesTree.Nodes.Count > 0)
            //{
            //    ShowHideTabControls(3, false);
            //    ClearTreeView(3);
            //}

            //ShowHideTabControls(3, true);

            var result = 0.0;
            if (Double.TryParse(meshDensityValue.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
                generateMeshEvent?.Invoke(this, result,ObjType.Элемент2D);          
        }

        private void OnGenerateMesh3D(object sender, EventArgs e)
        {
            var result = 0.0;
            if (Double.TryParse(meshDensityValue.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
                generateMeshEvent?.Invoke(this, result,ObjType.Элемент3D);           
        }

        private void OnAlgorithmChoice(object sender, EventArgs e)
        {
            var algo = new double[] { 1, 2, 5, 6, 8 };
            setMeshAlgoEvent?.Invoke(algo[algoChoice.SelectedIndex]);
        }

        private void OnRefine(object sender, EventArgs e)
        {
            refineMesh?.Invoke(this);

            ShowHideTabControls(3, false);
            ClearTreeView(3);         
        }

        private void OnQuadrangulate(object sender, EventArgs e)
        {
            generateQuadMesh?.Invoke(this);
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

        public void FillGeometryTreeView(IGmshController GmshController)
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

        public void FillMeshTreeView(IGmshController gmshController, TreeView tree, int dim,
                                       string generalKey = "Поверхности", string generalChild = "Поверхность ")
        {
            ClearTreeView(dim);
            int[] dimTags;
            gmshController.ModelGetGeometryEntities(out dimTags, dim);
            int[] elementTypes;
            long[][] elementTags, nodeTags;
            var surfNodes = new TreeNode[dimTags.Length / 2];
            tree.Nodes.Add(generalKey);
            for (int i = 1, m = 0; i < dimTags.Length; i += 2, ++m)
            {
                gmshController.ModelMeshGetElements(dim, dimTags[i], out elementTypes, out elementTags, out nodeTags);
                var child = generalChild + dimTags[i].ToString();
                surfNodes[m] = new TreeNode(child);
                var currentSurface = surfNodes[m];
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
                        var nodNodes = new TreeNode[triple.Item3];
                        for (var l = 0; l < triple.Item3; ++l)
                        {
                            var nodeTag = "Узел " + nodeTags[j][k * triple.Item3 + l].ToString();
                            nodNodes[l] = new TreeNode(nodeTag);
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
        public void WriteCurveSettingsToControls(string[] attributes)
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
            var curveNodes = TryGetCurveNodeRecursevely(e.Node);

            var objsNumbers = new List<int>();
            foreach (var item in curveNodes)
            {
                var tag = FindObjectByTreeNode(item);
                objsNumbers.Add(tag);
            }

            showObjectsEvent?.Invoke(objsNumbers);

            if (curveNodes.Count == 0 | curveNodes.Count > 1)
                pointsControlBox.Enabled = false;
            else
            {
                pointsControlBox.Enabled = true;
                var tag = FindObjectByTreeNode(e.Node);

                setCurveDataEvent?.Invoke(this,tag);           
            }

            //redrawScene?.Invoke(false);
        }

        private List<TreeNode> TryGetCurveNodeRecursevely(TreeNode node)
        {
            var trNodes = new List<TreeNode>();

            GetCurveNodes(trNodes, node);

            return trNodes.Distinct(new TreeNodeEqualityComparer()).ToList();
        }

        private void GetCurveNodes(List<TreeNode> trNodes, TreeNode node)
        {
            if (node.Text.Contains("Кривая"))
                trNodes.Add(node);
            foreach (TreeNode item in node.Nodes)
            {
                GetCurveNodes(trNodes, item);
            }
        }       

        public int GetElementTypeByString(ref string query)
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
            try
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
                        ShowHideGeneralTabControls(3, false);
                        ClearTreeView(2);
                        ShowHideTabControls(2, false);

                        deleteMeshEvent?.Invoke(ObjType.Элемент2D);
                    }
                    else
                    {
                        deleteMeshEvent?.Invoke(ObjType.Элемент3D);
                    }
                }
                else
                {
                    var tag = Int32.Parse(currentNode.Parent.Text.Split(' ')[1]);
                    surfsTree.Nodes.Remove(currentNode);

                    var keyData = currentNode.Text.Split(' ');
                    var isNumeric = keyData.Length > 1;

                    deleteElementEvent?.Invoke(this, new DeleteElementEventArgs(dim, tag, keyData, isNumeric));
                    //NewMethod(dim, tag, keyData, isNumeric);

                    if (dim == 2)
                    {
                        deleteMeshEvent?.Invoke(ObjType.Элемент2D);
                    }
                    else
                    {
                        deleteMeshEvent?.Invoke(ObjType.Элемент3D);
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void entTree_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            var oldNode = geomTree.SelectedNode;
            
            if (oldNode != null)
                resetColorObjectsEvent?.Invoke(ObjType.Линия);
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
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
                    setTransfiniteCurveEvent?.Invoke(this, new SetTransfiniteCurveEventArgs(tag, attributes, 3, coef,points));
                }
            }

            if (chbShowCurvesInfo.Checked)
                showCurveInfoEvent?.Invoke(true);
            if (chbShowHeatMap.Checked)
                showHeatMapEvent?.Invoke(true);
            if (chbShowTranfPoints.Checked)
                showTransPoints?.Invoke(true);
        }

        private void chbShowCurvesInfo_Click(object sender, EventArgs e)
        {
            if (chbShowCurvesInfo.Checked)
                showCurveInfoEvent?.Invoke(true);
            else
                showCurveInfoEvent?.Invoke(false);//Прячем весь текст
        }

        private void chbShowHeatMap_Click(object sender, EventArgs e)
        {

            if (chbShowHeatMap.Checked)
                showHeatMapEvent?.Invoke(true);
            else showHeatMapEvent?.Invoke(false);

        }

        private void chbShowSurfacesInfo_Click(object sender, EventArgs e)
        {
            if (chbShowSurfacesInfo.Checked)
                showSurfaceInfoEvent?.Invoke(true);
            else
                showSurfaceInfoEvent?.Invoke(false);
        }

        private void chbShowTranfPoints_Click(object sender, EventArgs e)
        {
            if (chbShowTranfPoints.Checked)
                showTransPoints?.Invoke(true);
            else
                showTransPoints?.Invoke(false);
        }
    }
}