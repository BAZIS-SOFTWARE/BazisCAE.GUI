using BaseModule;
using BaseModule.Mesh;
using BaseModule.Mesh.SettingsControls;
using Geometry;
using GmshApi;
using Model.GeometryObjects;
using ModelControllerInterfaces;
using ModelInterfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security;
using System.Windows.Forms;
using TaskModule.BasicTaskAdvisor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BazisGUI
{
    public partial class ModelPage : ToolStripPage
    {
        IGmshController GmshController { get; set; }

        IModelController ModelController
        {
            get { return BasePage.ScenePage.GetModelController(); }
        }

        IModelData ModelData
        {
            get { return ModelController.ModelData; }
        }
        public ModelPage() : base()
        {
            InitializeComponent();

            selectToolStrip.Location = new Point(3, 0);
            instrumentalToolStrip.Location = new Point(selectToolStrip.Size.Width + 4, 0);

            var pContr = (PinnedMeshGenControl)EmbeddedControls.Find("pinnedMeshGenControl", false)[0];
            pContr.BringToFront();
            var meshContr = pContr.MeshGeneratorControl;

            SetMeshControl(meshContr);
        }

        private void SetMeshControl(GMSHGeneralMeshControl meshGenerator)
        {
            meshGenerator.setMeshAlgoEvent += (ar) =>
            {
                var ierrAlgo = 0;
                GmshController.OptionSetNumber("Mesh.Algorithm", ar, ref ierrAlgo);
            };

            meshGenerator.delMeshGradientEvent += MeshGenerator_delMeshGradientEvent;
            meshGenerator.showShowSurfaceNumbersEvent += MeshGenerator_showSurfaceNumbers;
            meshGenerator.showNumberOfCurveNodesEvent += MeshGenerator_showNumberOfCurveNodes;
            meshGenerator.generate3DTetraMeshEvent += MeshGenerator_generate3DMeshEvent;
            meshGenerator.generate2DTriangleMeshEvent += MeshGenerator_generate2DMeshEvent;
            meshGenerator.deleteMeshEvent += MeshGenerator_deleteMeshEvent;
            meshGenerator.showNodesOnCurvesEvent += MeshGenerator_showNodesOnCurves;
            meshGenerator.updateObjectsDataEvent += UpdateMeshVBO;
            meshGenerator.updateGeometryVBOEvent += UpdateGeometryVBO;
            //meshGenerator.updateTreeViewEvent += () => { PresentProjectOnTree(); };
            meshGenerator.refineMesh += MeshGenerator_refineMesh;
            meshGenerator.ShowObjectsEvent += ShowObjects;
            meshGenerator.generate2DQuadMesh += MeshGenerator_generate2DQuadMesh;
            meshGenerator.showHeatMapEvent += GmshControl_showHeatMapEvent;
            meshGenerator.resetColorObjectsEvent += GmshControl_ResetColorObjectsEvent;

            meshGenerator.SetCurveAttributeEvent += MeshGenerator_SetCurveAttributeEvent;
            meshGenerator.GetCurveAttribEvent += MeshGenerator_GetCurveAttribEvent;
            meshGenerator.CurveAttribDeleteEvent += MeshGenerator_CurveAttribDeleteEvent;

            meshGenerator.deleteElementEvent += DeleteElementsByNumber;
            meshGenerator.setMeshGradientSettingsEvent += MeshGenerator_setMeshGradientSettingsEvent;

            meshGenerator.SetPointSizeEvent += SetPointSizesEventHandler;
            meshGenerator.PointAttribDeleteEvent += MeshGenerator_PointAttribDeleteEvent;
            meshGenerator.GetPointSizeEvent += MeshGenerator_GetPointSizeEvent;

            meshGenerator.setMinMaxSizesEvent += SetMinMaxSizesEvent;
            //gmshForm.Controls.Add(meshGenerator);
            //meshGenerator.Dock = DockStyle.Fill;
        }

        public void CreateSurfaceElements(ObjType objType)
        {
            var scenePage = BasePage.ScenePage;

            try
            {
                if (objType == ObjType.Элемент2D)
                {
                    var els3D = ModelData.ObjectData.E3DCollection;
                    if (els3D.Count() == 0)
                        BasePage.ConsoleControl.PrintInfo("Модель не содержит 3D элементов!", Color.Red);
                    else
                    {
                        scenePage.SceneControl.DeleteVBObjects(ObjType.Элемент2D.ToString());

                        var startNumber = ModelData.ObjectData.GetLastNumber(ObjType.Элемент) + 1;
                        var boundaryElements2D = ModelController.Extractor2DFrom3D.Create(startNumber, els3D.ToArray());

                        ModelData.ObjectData.E2DCollection.AddRange(boundaryElements2D);
                    }                
                }
                else if (objType == ObjType.Элемент1D)
                {
                    var els2D = ModelData.ObjectData.E2DCollection;
                    if (els2D.Count() == 0)
                        BasePage.ConsoleControl.PrintInfo("Модель не содержит 2D элементов!", Color.Red);
                    else
                    {
                        scenePage.SceneControl.DeleteVBObjects(ObjType.Элемент1D.ToString());

                        var startNumber = ModelData.ObjectData.GetLastNumber(ObjType.Элемент) + 1;
                        var boundaryElements1D = ModelController.Extractor1DFrom2D.Create(startNumber, els2D.ToArray());

                        ModelData.ObjectData.E1DCollection.AddRange(boundaryElements1D);
                    }
                }

                scenePage.SceneControl.HideAllGeometryObjs();
                scenePage.SceneControl.HideDisplayText2D();
                scenePage.SceneControl.HideDisplayText3D();

                scenePage.CreateObjectsOnScene(objType.ToString(), scenePage.CreateObjectsPresentor(objType));

                scenePage.SceneControl.DisplayObjects();
                BasePage.PresentProjectOnTree();

                BasePage.ConsoleControl.PrintInfo($"Созданы {objType}", Color.Black);
            }
            catch (Exception ex)
            {
                BasePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }        
        }

        private void MeshGenerator_SetCurveAttributeEvent(object arg1, CurveAttribsEventArgs arg2)
        {
            var ierr = 0;
            GmshController.ModelSetAttribute($"transfinite {arg2.Tag}", arg2.Attributes, (IntPtr)arg2.Attributes.Length, ref ierr);
            if (!string.IsNullOrEmpty(arg2.Attributes[0]) && !string.IsNullOrEmpty(arg2.Attributes[2]))
                GmshController.ModelMeshSetTransfiniteCurve(arg2.Tag, arg2.Points, arg2.Attributes[1], arg2.Coef, ref ierr);
        }

        private void MeshGenerator_CurveAttribDeleteEvent(int obj)
        {
            var ierr = 0;
            var dimTags = new int[] { 1, obj };
            GmshController.ModelRemoveAttribute($"transfinite {obj}", ref ierr);
            GmshController.ModelMeshRemoveConstraints(dimTags, (IntPtr)dimTags.Length, ref ierr);
        }

        private void MeshGenerator_GetCurveAttribEvent(object arg1, int arg2)
        {
            try
            {
                string[] attributes;
                GmshController.ModelGetAttribute($"transfinite {arg2}", out attributes);
                var curveControl = arg1 as GMSHCurveSettingsControl;
                curveControl.SetCurveAttributes(attributes);
            }
            catch (Exception ex)
            {
                BasePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }

        }

        private void MeshGenerator_PointAttribDeleteEvent(int obj)
        {
            var ierr = 0;
            var dimTags = new int[] { 0, obj };
            GmshController.ModelMeshRemoveConstraints(dimTags, (IntPtr)dimTags.Length, ref ierr);
        }

        private void MeshGenerator_GetPointSizeEvent(object arg1, int arg2)
        {
            try
            {
                var dimTags = new int[] { 0, arg2 };
                var meshSize = GmshController.GetMeshDensity(dimTags);
                var pointControl = arg1 as GMSHPointSettingsControl;
                pointControl.SetPointSize(meshSize[0]);
            }
            catch (Exception ex)
            {
                BasePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }

        }

        private void MeshGenerator_setMeshGradientSettingsEvent(object arg1, MeshGradientSettingsEventArgs arg2)
        {
            var ierr = 0;
            GmshController.ModelMeshFieldAdd("Extend", -1, ref ierr);

            int[] list;
            GmshController.ModelMeshFieldList(out list);
            if (list.Length != 0)
            {
                var field = list.First();
                int[] points, curves, surfaces;
                GmshController.ModelGetGeometryEntities(out points, 0);
                GmshController.ModelGetGeometryEntities(out curves, 1);
                GmshController.ModelGetGeometryEntities(out surfaces, 2);
                var curveTags = curves.Where((v, i) => (i & 1) != 0)
                                      .Select(v => (double)v).ToArray();
                var surfTags = surfaces.Where((v, i) => (i & 1) != 0)
                                       .Select(v => (double)v).ToArray();
                GmshController.ModelMeshSetSize(points, (IntPtr)points.Length, arg2.surfaceMeshSize, ref ierr);
                GmshController.ModelMeshFieldSetNumbers(field, "CurvesList", curveTags, (IntPtr)curveTags.Length, ref ierr);
                GmshController.ModelMeshFieldSetNumbers(field, "SurfacesList", surfTags, (IntPtr)surfTags.Length, ref ierr);
                GmshController.ModelMeshFieldSetNumber(field, "Power", arg2.gradientMeshPower, ref ierr);
                GmshController.ModelMeshFieldSetNumber(field, "DistMax", arg2.layerThickness, ref ierr);
                GmshController.ModelMeshFieldSetNumber(field, "SizeMax", arg2.coreMeshSize, ref ierr);
                GmshController.ModelMeshFieldSetAsBackgroundMesh(field, ref ierr);
                GmshController.OptionSetNumber("Mesh.MeshSizeExtendFromBoundary", -2, ref ierr);
            }
        }

        private void SetPointSizesEventHandler(object sender, int pointNumber, double[] pointSize)
        {
            var ierr = 0;
            var dimTags = new int[] { 0, pointNumber };
            GmshController.ModelMeshSetSize(dimTags, (IntPtr)dimTags.Length, pointSize[0], ref ierr);
        }

        private void SetMinMaxSizesEvent(object sender, double[] sizes)
        {
            var ierr = 0;
            GmshController.OptionSetNumber("Mesh.MeshSizeMin", sizes[0], ref ierr);
            GmshController.OptionSetNumber("Mesh.MeshSizeMax", sizes[1], ref ierr);
        }

        private void MeshGenerator_delMeshGradientEvent(object arg1)
        {
            var ierr = 0;
            int[] list, points;
            GmshController.ModelMeshFieldList(out list);
            GmshController.ModelMeshFieldRemove(list.First(), ref ierr);
            GmshController.ModelGetGeometryEntities(out points, 0);
            GmshController.ModelMeshRemoveConstraints(points, (IntPtr)points.Length, ref ierr);
            GmshController.OptionSetNumber("Mesh.MeshSizeExtendFromBoundary", 1, ref ierr);
        }

        private void DeleteElementsByNumber(object sender, DeleteElementEventArgs args)
        {
            var cntr = (GMSHGeneralMeshControl)sender;
            var intType = cntr.GetElementTypeByString(ref args.keyData[0]);

            var dimTags = args.isNumeric ? new int[] { args.dim, Int32.Parse(args.keyData[1]) }
                         : GetElementsByType(intType, args.dim, args.tag);


            DeleteElementsByNumbers(dimTags, args.keyData[0], cntr.ElementsType);
        }

        private int[] GetElementsByType(int intType, int dim, int tag)
        {
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

        private void DeleteElementsByNumbers(int[] dimTags, string keyData, IEnumerable<string> elementType)
        {
            foreach (var element in elementType)
                if (element.Contains(keyData))
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


        private void MeshGenerator_showSurfaceNumbers(object sender,bool flag)
        {
            var scenePage = BasePage.ScenePage;
            if (flag)
            {
                ShowSurfaceNumbers();
            }
            else
            {
                var cnt = sender as GMSHGeneralMeshControl;
                scenePage.SceneControl.HideDisplayText3D();

                if (cnt.IsNumberOfCurveNodesShowen)
                    ShowNumberOfCurveNodes();
            }

            scenePage.SceneControl.DisplayObjects();
        }

        private void MeshGenerator_showNumberOfCurveNodes(object sender, bool obj)
        {
            var scenePage = BasePage.ScenePage;
            // тут нужно перебрать все кривые которые есть в модели и показать их параметры разметки
            if (obj)
            {
                ShowNumberOfCurveNodes();
            }
            else
            {
                var cnt = sender as GMSHGeneralMeshControl;
                scenePage.SceneControl.HideDisplayText3D();

                if (cnt.IsSurfaceNumbersShowen)
                    ShowSurfaceNumbers();
            }


            scenePage.SceneControl.DisplayObjects();
        }

        private void ShowSurfaceNumbers()
        {
            var scenePage = BasePage.ScenePage;
            int[] dimTags;
            GmshController.ModelGetGeometryEntities(out dimTags, 2);

            for (var i = 1; i < dimTags.Length; i += 2)
            {
                var point = GetCenterOfGeometryEntity(2, dimTags[i]);
                //var point = GetOffsetPointFromCenter(2, dimTags[i], 10);
                var text = $"Поверхность {dimTags[i]}";

                scenePage.SceneControl.DisplayText3D(text, Color.Black, point.Sum(new Point3D(5,5,5)));
            }
        }

        private void ShowNumberOfCurveNodes()
        {
            var scenePage = BasePage.ScenePage;
            string[] attribList;
            GmshController.ModelGetAttributeNames(out attribList);

            foreach (var item in attribList)
            {
                var tag = Int32.Parse(item.Split(' ')[1]);
                var attributes = GetCurrentCurveAttributes(tag);

                if (attributes.Length == 3)
                {
                    // var text = $"{attributes[2]} {attributes[1]} {attributes[0]}";
                    var text = $"{attributes[0]}";
                    var point = GetCenterOfGeometryEntity(1, tag);

                    scenePage.SceneControl.DisplayText3D(text, Color.Black, point);
                }
            }
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

        private void GmshForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //SceneControl.HideAllGeometryObjs();
            //SceneControl.HideDisplayText3D();
            var scenePage = BasePage.ScenePage;

            scenePage.ClearAllDataOnScene();
            scenePage.PresentAllModelObjectsToScene();
            scenePage.SceneControl.DisplayObjects();
        }

        private void MeshGenerator_generate2DQuadMesh(object obj)
        {
            var cntr = (GMSHGeneralMeshControl)obj;
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
                    BasePage.ConsoleControl.PrintInfo(error, Color.Red);
                cntr.ShowHideTabControls(3, false);
                cntr.ClearTreeView(3);
                var objs = GmshController.GetMeshObjects();

                ModelData.ObjectData.Clear(ObjType.Узел);
                
                FillMeshTreeView(cntr, 2);
            }
        }

        private void MeshGenerator_refineMesh(object sender)
        {
            var scenePage = BasePage.ScenePage;
            var cntr = (GMSHGeneralMeshControl)sender;
            var ierr = 0;
            GmshController.ModelMeshRefine(ref ierr);

            FillMeshTreeView(cntr, 2);

            ModelData.ObjectData.Clear(ObjType.Узел);//Удаляем только элементы сетки, геометрию не трогаем
            UpdateMeshVBO();

            BasePage.PresentProjectOnTree();

            scenePage.SceneControl.FitObjectsToScreen();
            scenePage.SceneControl.DisplayObjects();
        }

        [HandleProcessCorruptedStateExceptions]
        [SecurityCritical]
        private void MeshGenerator_generate3DMeshEvent(object sender)
        {
            var scenePage = BasePage.ScenePage;
            var ierr = 0;
            string error;
            try
            {
                var cntr = (GMSHGeneralMeshControl)sender;

                DeleteGMSHMeshObjects(ObjType.Элемент3D);
                GmshController.ModelMeshGenerate(3, ref ierr);

                FillMeshTreeView(cntr, 3, "Объемы", "Объем ");
            }
            catch (Exception ex)
            {
                BasePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
                return;
            }
            GmshController.LoggerGetLastError(out error);
            if (!String.IsNullOrEmpty(error))
                BasePage.ConsoleControl.PrintInfo(error, Color.Red);

            ModelData.ObjectData.Clear(ObjType.Узел);//Удаляем только элементы сетки, геометрию не трогаем
            UpdateMeshVBO();

            BasePage.PresentProjectOnTree();

            scenePage.SceneControl.FitObjectsToScreen();
            scenePage.SceneControl.DisplayObjects();
        }

        [HandleProcessCorruptedStateExceptions]
        [SecurityCritical]
        private void MeshGenerator_generate2DMeshEvent(object sender, double meshDencity)
        {
            var scenePage = BasePage.ScenePage;
            var ierr = 0;
            string error;
            try
            {
                var cntr = (GMSHGeneralMeshControl)sender;
                GmshController.OptionSetNumber("Mesh.MeshSizeFactor", meshDencity, ref ierr);

                DeleteGMSHMeshObjects(ObjType.Узел);
                GmshController.ModelMeshGenerate(1, ref ierr);
                GmshController.ModelMeshGenerate(2, ref ierr);

                FillMeshTreeView(cntr, 2);
            }
            catch (Exception ex)
            {
                BasePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
                return;
            }
            GmshController.LoggerGetLastError(out error);
            if (!String.IsNullOrEmpty(error))
                BasePage.ConsoleControl.PrintInfo(error, Color.Red);

            ModelData.ObjectData.Clear(ObjType.Узел);//Удаляем только элементы сетки, геометрию не трогаем
            UpdateMeshVBO();

            BasePage.PresentProjectOnTree();

            scenePage.SceneControl.FitObjectsToScreen();
            scenePage.SceneControl.DisplayObjects();
        }

        private void MeshGenerator_deleteMeshEvent(ObjType objType)
        {
            var scenePage = BasePage.ScenePage;

            if (objType == ObjType.Элемент2D)
            {
                DeleteGMSHMeshObjects(ObjType.Узел);
            }
            else if(objType == ObjType.Элемент3D)
            {
                DeleteGMSHMeshObjects(ObjType.Элемент3D);
            }

            ModelData.ObjectData.Clear(ObjType.Узел);//Удаляем только элементы сетки, геометрию не трогаем
            UpdateMeshVBO();

            BasePage.PresentProjectOnTree();

            scenePage.SceneControl.FitObjectsToScreen();
            scenePage.SceneControl.DisplayObjects();
        }

        private void DeleteGMSHMeshObjects(ObjType type)
        {
            var ierr = 0;
            int[] dimTags = null;
            var dim = 0;
            if (type == ObjType.Узел) //удаляем всю сетку узлы,1d,2d,3d
            {
                dimTags = new int[0];
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

        private void MeshGenerator_showNodesOnCurves(bool flag)
        {
            var scenePage = BasePage.ScenePage;
            scenePage.SceneControl.DeleteVBObjects("transPoints");

            if (flag)
            {
                var dic = GetCurvesNumbersAndNodes();

                var points = new List<GeometryPoint>();
                foreach (var item in dic.Keys)
                {
                    points.AddRange(GetTransPointsCoords(item));
                }

                var presentor = ModelController.PresentersCreator.CreatePointObjectsPresenter(points);

                scenePage.CreateObjectsOnScene("transPoints", presentor);
            }

            scenePage.SceneControl.DisplayObjects();
        }

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
                var points = attributes.Length == 3 && !string.IsNullOrEmpty(attributes[0]) ? Int32.Parse(attributes[0]) : 0;
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

        private string[] GetCurrentCurveAttributes(int tag)
        {
            string[] attributes;
            GmshController.ModelGetAttribute($"transfinite {tag}", out attributes);
            return attributes;
        }

        private List<GeometryPoint> GetTransPointsCoords(int curveTag)
        {
            var ierr = 0;
            long[] nodeTags;
            double[] coords, parametrics;

            GmshController.ModelMeshGenerate(1, ref ierr);
            GmshController.ModelMeshGetNodes(1, curveTag, false, false, out nodeTags, out coords, out parametrics);

            var gPoints = new List<GeometryPoint>();
            var num = 0;
            for (int i = 0; i < coords.Length; i += 3)
            {
                var gPoint = new GeometryPoint(num++, new Point3D((float)coords[i], (float)coords[i + 1], (float)coords[i + 2]));
                gPoints.Add(gPoint);
            }
            return gPoints;
        }

        private void GmshControl_showHeatMapEvent(bool flag)
        {
            try
            {
                var scenePage = BasePage.ScenePage;
                scenePage.SceneControl.HideGeometryObj("DisplaySceneScale");

                if (flag)
                {
                    var curvesInfo = GetCurvesNumbersAndNodes();
                    var max = curvesInfo.Max(x => x.Value);
                    var min = curvesInfo.Min(x => x.Value);

                    var scale = scenePage.SceneControl.CreateScaleObject(min, max, 3, "", "");

                    scenePage.SceneControl.DisplaySceneScale(scale);

                    foreach (var item in curvesInfo)
                    {
                        var color = scale.GetValueColor(item.Value);
                        ModelData.ObjectData.LineCollection.Find(item.Key).MasterColor = color;
                    }

                    var linePres = ModelController.PresentersCreator.CreateLineObjectsPresenter(ModelData.ObjectData.LineCollection);
                    scenePage.SceneControl.DeleteVBObjects(ObjType.Линия.ToString());
                    scenePage.CreateObjectsOnScene(ObjType.Линия.ToString(), linePres);
                    scenePage.SceneControl.DisplayObjects();
                }
                else
                {
                    foreach (var item in ModelData.ObjectData.LineCollection)
                        item.SetBackColor();

                    var linePres = ModelController.PresentersCreator.CreateLineObjectsPresenter(ModelData.ObjectData.LineCollection);
                    scenePage.SceneControl.DeleteVBObjects(ObjType.Линия.ToString());
                    scenePage.CreateObjectsOnScene(ObjType.Линия.ToString(), linePres);
                    scenePage.SceneControl.DisplayObjects();
                }
            }
            catch (Exception ex)
            {
                BasePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }



        private void GmshControl_ResetColorObjectsEvent(ObjType objType)
        {
            var scenePage = BasePage.ScenePage;
            foreach (var item in ModelData.ObjectData.GetObjects(objType))
                item.SetBackColor();
            scenePage.SetObjectsSceneColor(ObjType.Линия);
        }

        private void ShowObjects(ObjType objType,List<int> objNumbers)
        {
            try
            {
                var scenePage = BasePage.ScenePage;

                foreach (var item in objNumbers)
                {
                    ModelData.ObjectData.Find(objType, item).MasterColor
    = scenePage.SceneControl.SelectionColor;
                }

                scenePage.SetObjectsSceneColor(objType);
                scenePage.SceneControl.DisplayObjects();
            }
            catch (Exception ex)
            {
                BasePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void UpdateMeshVBO()
        {
            var objs = GmshController.GetMeshObjects();
            var scenePage = BasePage.ScenePage;
            if (objs.Item1.Count > 0)
                ModelData.ObjectData.NodeCollection.AddRange(objs.Item1);
            if (objs.Item1.Count > 0)
                ModelData.ObjectData.E1DCollection.AddRange(objs.Item2);
            if (objs.Item1.Count > 0)
                ModelData.ObjectData.E2DCollection.AddRange(objs.Item3);
            if (objs.Item4.Count > 0)
                ModelData.ObjectData.E3DCollection.AddRange(objs.Item4);

            PresentObjects(ObjType.Узел);
            PresentObjects(ObjType.Элемент1D);
            PresentObjects(ObjType.Элемент2D);
            PresentObjects(ObjType.Элемент3D);
        }

        private void UpdateGeometryVBO()
        {
            PresentObjects(ObjType.Точка);
            PresentObjects(ObjType.Линия);
        }

        private void PresentObjects(ObjType item)
        {
            var scenePage = BasePage.ScenePage;
            var vbo = scenePage.SceneControl.FindVBObj(item.ToString());

            if (vbo != null)
                scenePage.SceneControl.DeleteVBObjects(item.ToString());

            var presentor = scenePage.CreateObjectsPresentor(item);
            if (presentor.Count() > 0)
                scenePage.CreateObjectsOnScene(item.ToString(), presentor);
        }   

        public void SetGMSHController(IGmshController gmshController)
        {
            var scenePage = BasePage.ScenePage;
            scenePage.SceneControl.HideAllGeometryObjs();
            scenePage.SceneControl.HideDisplayText2D();
            scenePage.SceneControl.HideDisplayText3D();
            BasePage.PresentProjectOnTree();

            if (gmshController == null)
                MessageBox.Show("Контроллер генератора сетки не загружен!");

            GmshController = gmshController;
            //SceneControl.IsBlending = false;//Прозрачность пока больше мешает

            var pContr = (PinnedMeshGenControl)EmbeddedControls.Find("pinnedMeshGenControl", false)[0];
            var meshContr = pContr.MeshGeneratorControl;

            var ierr = 0;
            FillGeometryTreeView(meshContr);
            if (GmshController.GetGeometryObjectDimension(ref ierr) > 1)
                meshContr.ShowHideGeneralTabControls(2, true);

            //meshGenerator.ShowHideGeneralTabControls(1);
            meshContr.ShowHideTabControls(1);

            scenePage.SceneControl.DisplayObjects();
        }

        public void FillGeometryTreeView(GMSHGeneralMeshControl cntr)
        {
            int[] dimTags, upwards, downwards;
            GmshController.ModelGetGeometryEntities(out dimTags, -1);
            cntr.ClearTreeView(1);
            var geomTree = cntr.GetTreeView(1);
            var nodes = cntr.CreateGeometryNodes(dimTags);
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

        public void FillMeshTreeView(GMSHGeneralMeshControl cntr, int dim,
                                       string generalKey = "Поверхности", string generalChild = "Поверхность ")
        {
            var tree = cntr.GetTreeView(dim);
            cntr.ClearTreeView(dim);
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
                cntr.CreateMeshNodes(child, dim, elementTags, nodeTags);
            }
        }       
    }
}