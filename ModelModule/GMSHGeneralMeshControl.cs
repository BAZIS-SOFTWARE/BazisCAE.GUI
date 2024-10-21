using ModelInterfaces;
using System;
using System.Globalization;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelControllerInterfaces.GmshController;
using Model.MeshObjects;

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

        public bool IsNumberOfCurveNodesShowen
        {
            get { return chbShowNumberOfCurveNodes.Checked; }
        }

        public bool IsNodesOnCurvesShowen
        {
            get { return chbShowNodesOnCurves.Checked; }
        }

        public bool IsSurfaceNumbersShowen
        {
            get { return chbShowSurfaceNumbers.Checked; }
        }


        public event Action<object,bool> switchMeshGradientEvent;
        public event Action<object, MeshGradientSettingsEventArgs> setMeshGradientSettingsEvent;
        public event Action<double> setMeshAlgoEvent;
        public event Action updateObjectsDataEvent;
        public event Action<ObjType> deleteMeshEvent;
        public event Action<object,double> generate2DTriangleMeshEvent;
        public event Action<object> generate3DTetraMeshEvent;
        public event Action<object> generate2DQuadMesh;
        public event Action<bool> showNodesOnCurvesEvent;
        public event Action updateGeometryVBOEvent;
        //public event Action updateTreeViewEvent;
        public event Action<object,bool> showNumberOfCurveNodesEvent;
        public event Action<object,bool> showShowSurfaceNumbersEvent;
        //public event Action<object, Show3dTextEventArgs> show3dTextEvent;
        public event Action<ObjType,List<int>> ShowObjectsEvent;
        public event Action<ObjType> resetColorObjectsEvent;
        public event Action<object> refineMesh;
        public event Action<bool> showHeatMapEvent;

        public event Action<object, DeleteElementEventArgs> deleteElementEvent;

        public event Action<object, CurveAttribsEventArgs> SetCurveAttributeEvent;
        public event Action<object,int> GetCurveAttribEvent;
        public event Action<int> CurveAttribDeleteEvent;

        public event Action<object, int> GetPointSizeEvent;      
        public event Action<object, int, double[]> SetPointSizeEvent;
        public event Action<int> PointAttribDeleteEvent;

        public event Action<object, double[]> setMinMaxSizesEvent;


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
                entitieSettingsBox.Enabled = false;
            }
            else if (dim == 2)
            {
                algoLabel.Enabled = show;//Активация/деактивация "Алгоритм построения сетки"
                cmbAlgoChoice.Enabled = show;//Активация/деактивация эл.управления выбора алгоритма
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
            if (!meshDensityValue.IsValueValid())
                return;
            var result = Double.Parse(meshDensityValue.Text);
   
            generate2DTriangleMeshEvent?.Invoke(this, result);          
        }

        private void OnGenerateMesh3D(object sender, EventArgs e)
        {
            generate3DTetraMeshEvent?.Invoke(this);
        }

        private void OnAlgorithmChoice(object sender, EventArgs e)
        {
            var algo = new double[] { 1, 2, 5, 6, 8 };

            if (!cmbAlgoChoice.IsValueValid())
                return;

            setMeshAlgoEvent?.Invoke(algo[cmbAlgoChoice.SelectedIndex]);
        }

        private void OnRefine(object sender, EventArgs e)
        {
            refineMesh?.Invoke(this);

            //ShowHideTabControls(3, false);
            ClearTreeView(3);         
        }

        private void OnQuadrangulate(object sender, EventArgs e)
        {
            generate2DQuadMesh?.Invoke(this);
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

        private int FindObjectNumber(TreeNode node)
        {
            var tokens = node.Text.Split(' ');
            var lastToken = tokens.Length - 1;
            return Int32.Parse(tokens[lastToken]);
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
            var text = e.Node.Text;

            if (text.Contains("Контрольный узел"))
            {
                resetColorObjectsEvent?.Invoke(ObjType.Точка);
            }
            else if (text.Contains("Кривая"))
            {
                resetColorObjectsEvent?.Invoke(ObjType.Линия);
            }
            else if (text.Contains("Поверхность"))
            {
                resetColorObjectsEvent?.Invoke(ObjType.Линия);
            }
            else if (text.Contains("Объем"))
            {
                resetColorObjectsEvent?.Invoke(ObjType.Линия);
            }
        }

        private void entTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //List<TreeNode> curveNodes = new List<TreeNode>();
            var nText = e.Node.Text;
            if (nText.Contains("Контрольный узел"))
            {
                var pointNumber = FindObjectNumber(e.Node);
                ShowObjectsEvent?.Invoke(ObjType.Точка,new List<int>() { pointNumber });

                pointSettingsControl.BringToFront();
                GetPointSizeEvent?.Invoke(pointSettingsControl, pointNumber);
            }
            else if (nText.Contains("Кривая") || nText.Contains("Поверхность")
                || nText.Contains("Объем"))
            {
                var curveNumbers = TryGetCurveNodeRecursevely(e.Node).Select(x =>
                FindObjectNumber(x)).ToList();

                ShowObjectsEvent?.Invoke(ObjType.Линия, curveNumbers);

                curveSettingsControl.BringToFront();

                if (nText.Contains("Кривая"))
                    GetCurveAttribEvent?.Invoke(curveSettingsControl, curveNumbers[0]);
            }
        }

        private void chbShowNumberOfCurveNodes_Click(object sender, EventArgs e)
        {
            if (chbShowNumberOfCurveNodes.Checked)
                showNumberOfCurveNodesEvent?.Invoke(this,true);
            else
                showNumberOfCurveNodesEvent?.Invoke(this,false);//Прячем весь текст
        }

        private void chbShowHeatMap_Click(object sender, EventArgs e)
        {

            if (chbShowHeatMap.Checked)
                showHeatMapEvent?.Invoke(true);
            else showHeatMapEvent?.Invoke(false);

        }

        private void chbShowSurfaceNumbers_Click(object sender, EventArgs e)
        {
            if (chbShowSurfaceNumbers.Checked)
                showShowSurfaceNumbersEvent?.Invoke(this,true);
            else
                showShowSurfaceNumbersEvent?.Invoke(this,false);
        }

        private void chbShowNodesOnCurves_Click(object sender, EventArgs e)
        {
            if (chbShowNodesOnCurves.Checked)
                showNodesOnCurvesEvent?.Invoke(true);
            else
                showNodesOnCurvesEvent?.Invoke(false);
        }


        public void SetGradientSetting(float layerThickness, float surfaceMeshSize, float coreMeshSize,float powerOfGradient)
        {
            txbLayerThickness.Text = layerThickness.ToString();
            txbSurfaceMeshSize.Text = surfaceMeshSize.ToString();
            txbCoreMeshSize.Text = coreMeshSize.ToString();
            txbMeshGradientPower.Text = powerOfGradient.ToString();
        }

        private void grbGradientMeshSettings_CheckBoxClick(object obj)
        {
            if (grbGradientMeshSettings.CheckState)
                switchMeshGradientEvent?.Invoke(this,true);
            else
                switchMeshGradientEvent?.Invoke(this,false);
        }

        private void btnSetGradientSettings_Click(object sender, EventArgs e)
        {
            if (!txbLayerThickness.IsValueValid())
                return;
            if (!txbSurfaceMeshSize.IsValueValid())
                return;
            if (!txbCoreMeshSize.IsValueValid())
                return;
            if (!txbMeshGradientPower.IsValueValid())
                return;

            var layerThickness = double.Parse(txbLayerThickness.Text);
            var surfaceMeshSize = double.Parse(txbSurfaceMeshSize.Text);
            var coreMeshSize = double.Parse(txbCoreMeshSize.Text);
            var gradientMeshPower = double.Parse(txbMeshGradientPower.Text);

            setMeshGradientSettingsEvent?.Invoke(this,
                new MeshGradientSettingsEventArgs(layerThickness, surfaceMeshSize, coreMeshSize, gradientMeshPower));
        }

        private void BtnMinMaxSizes_Click(object sender, EventArgs e)
        {
            var separators = new char[] { ',', ' ' };
            var tokens = txbMinMaxSizes.Text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            double min, max;
            if (double.TryParse(tokens[0], out min))
            {
                if(double.TryParse(tokens[1], out max))
                {
                    setMinMaxSizesEvent?.Invoke(this, new double[]  { min, max });
                }
            }
        }

        private void CurveSettingsControl_pressOkEvent(object arg1,  string[] arg3)
        {
            var number = FindObjectNumber(geomTree.SelectedNode);
            var args = new CurveAttribsEventArgs(number, arg3);
            SetCurveAttributeEvent?.Invoke(this, args);

            if (chbShowNumberOfCurveNodes.Checked)
                showNumberOfCurveNodesEvent?.Invoke(this, true);
            if (chbShowHeatMap.Checked)
                showHeatMapEvent?.Invoke(true);
            if (chbShowNodesOnCurves.Checked)
                showNodesOnCurvesEvent?.Invoke(true);
        }

        private void CurveSettingsControl_pressDelEvent(object arg1)
        {
            var number = FindObjectNumber(geomTree.SelectedNode);
            CurveAttribDeleteEvent(number);
        }

        private void PointSettingsControl_pressOkEvent(object arg1, double[] arg2)
        {
            var number = FindObjectNumber(geomTree.SelectedNode);
            SetPointSizeEvent?.Invoke(arg1, number, arg2);
        }

        private void PointSettingsControl_pressDelEvent(object arg1)
        {
            var number = FindObjectNumber(geomTree.SelectedNode);
            PointAttribDeleteEvent(number);
        }
    }
}