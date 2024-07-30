using BaseModule;
using Geometry;
using Model.GeometryObjects;
using ModelControllerInterfaces.GmshController;
using ModelInterfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security;
using System.Windows.Forms;

namespace ModelModule
{
    public partial class ModelPage : BasePage
    {
        public IGmshController GmshController { get; set; }
        public ModelPage() : base()
        {
            InitializeComponent();
        }  
        

        public void CreateSurfaceElements()
        {           
            var els3D = scenePage.ModelData.ObjectData.E3DCollection;
            if (els3D.Count() != 0)
            {
                ScenePage.SceneControl.DeleteVBObjects(ObjType.Элемент2D.ToString());

                var startNumber = scenePage.ModelData.ObjectData.GetLastNumber(ObjType.Элемент) + 1;
                var boundaryElements2D = ScenePage.ModelController.Extractor2DFrom3D.Create(startNumber, els3D.ToArray());

                scenePage.ModelData.ObjectData.E2DCollection.AddRange(boundaryElements2D);

                ScenePage.SceneControl.HideAllGeometryObjs();
                ScenePage.SceneControl.HideDisplayText2D();
                ScenePage.SceneControl.HideDisplayText3D();

                ScenePage.CreateObjectsOnScene(ObjType.Элемент2D.ToString(), ScenePage.CreateObjectsPresentor(ObjType.Элемент2D));

                ScenePage.SceneControl.DisplayObjects();
                PresentProjectOnTree();

                ConsoleControl.PrintInfo("Созданы 2D элементы", Color.Black);
            }
            else
                ConsoleControl.PrintInfo("Модель не содержит объемных элементов!", Color.Red);
        }

        public void LoadGMSHMeshControl()
        {
            //SceneControl.IsBlending = false;//Прозрачность пока больше мешает

            if (GmshController == null)
                MessageBox.Show("Контроллер генератора сетки не загружен!");

            else
            {
                var meshGenerator = new GMSHGeneralMeshControl();
                var gmshForm = new Form()
                {
                    TopMost = true,
                    ShowIcon = false,
                    ClientSize = meshGenerator.Size,
                    MaximizeBox = false,
                    FormBorderStyle = FormBorderStyle.FixedSingle,
                    Text = "Cеточный тетра генератор"
                };
                gmshForm.FormClosing += GmshForm_FormClosing;

                meshGenerator.setMeshAlgoEvent += (ar) =>
                {
                    var ierrAlgo = 0;
                    GmshController.OptionSetNumber("Mesh.Algorithm", ar, ref ierrAlgo);
                };

                meshGenerator.switchMeshGradientEvent += MeshGenerator_switchMeshGradientEvent;
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
                meshGenerator.showObjectsEvent += ShowObjects;
                meshGenerator.generate2DQuadMesh += MeshGenerator_generate2DQuadMesh;      
                meshGenerator.showHeatMapEvent += GmshControl_showHeatMapEvent;
                meshGenerator.resetColorObjectsEvent += GmshControl_ResetColorObjectsEvent;
                meshGenerator.setTransfiniteCurveEvent += MeshGenerator_setTransfiniteCurveEvent;
                meshGenerator.setCurveDataEvent += SetCurveDataEventHandler;
                meshGenerator.deleteElementEvent += DeleteElementsByNumber;
                meshGenerator.setMeshGradientSettingsEvent += MeshGenerator_setMeshGradientSettingsEvent;

                gmshForm.Controls.Add(meshGenerator);
                meshGenerator.Dock = DockStyle.Fill;

                var ierr = 0;
                meshGenerator.FillGeometryTreeView(GmshController);
                if (GmshController.GetGeometryObjectDimension(ref ierr) > 1)
                    meshGenerator.ShowHideGeneralTabControls(2, true);

                meshGenerator.ShowHideGeneralTabControls(1);
                meshGenerator.ShowHideTabControls(1);

                gmshForm.Show();
            }        
            //ModelPresenter.Clear();//Подчищаем Presenter во избежании артефактов
        }

        private void MeshGenerator_setMeshGradientSettingsEvent(object arg1, MeshGradientSettingsEventArgs arg2)
        {
            var ierr = 0;
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

        private void MeshGenerator_switchMeshGradientEvent(object arg1, bool arg2)
        {
            if(arg2)
            {
                var ierr = 0;
                var field = GmshController.ModelMeshFieldAdd("Extend", -1, ref ierr);
            }
            else
            {
                var ierr = 0;
                int[] list, points;
                GmshController.ModelMeshFieldList(out list);
                GmshController.ModelMeshFieldRemove(list.First(), ref ierr);
                GmshController.ModelGetGeometryEntities(out points, 0);
                GmshController.ModelMeshRemoveConstraints(points, (IntPtr)points.Length, ref ierr);
                GmshController.OptionSetNumber("Mesh.MeshSizeExtendFromBoundary", 1, ref ierr);
            }
        }

        private void SetCurveDataEventHandler(object sender, int tag)
        {
            var cntr = (GMSHGeneralMeshControl)sender;
            string[] attributes;
            GmshController.ModelGetAttribute($"transfinite {tag}", out attributes);
            cntr.WriteCurveSettingsToControls(attributes);
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
            if(flag)
            {
                ShowSurfaceNumbers();
            }
            else
            {
                var cnt = sender as GMSHGeneralMeshControl;
                ScenePage.SceneControl.HideDisplayText3D();

                if (cnt.IsNumberOfCurveNodesShowen)
                    ShowNumberOfCurveNodes();
            }

            ScenePage.SceneControl.DisplayObjects();
        }

        private void MeshGenerator_showNumberOfCurveNodes(object sender, bool obj)
        {
            // тут нужно перебрать все кривые которые есть в модели и показать их параметры разметки
            if (obj)
            {
                ShowNumberOfCurveNodes();
            }
            else
            {
                var cnt = sender as GMSHGeneralMeshControl;
                ScenePage.SceneControl.HideDisplayText3D();

                if (cnt.IsSurfaceNumbersShowen)
                    ShowSurfaceNumbers();
            }


            ScenePage.SceneControl.DisplayObjects();
        }

        private void ShowSurfaceNumbers()
        {
            int[] dimTags;
            GmshController.ModelGetGeometryEntities(out dimTags, 2);

            for (var i = 1; i < dimTags.Length; i += 2)
            {
                var point = GetCenterOfGeometryEntity(2, dimTags[i]);
                //var point = GetOffsetPointFromCenter(2, dimTags[i], 10);
                var text = $"Поверхность {dimTags[i]}";

                ScenePage.SceneControl.DisplayText3D(text, Color.Black, point.Sum(new Point3D(5,5,5)));
            }
        }

        private void ShowNumberOfCurveNodes()
        {
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

                    ScenePage.SceneControl.DisplayText3D(text, Color.Black, point);
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

            ScenePage.ClearAllDataOnScene();
            ScenePage.PresentAllModelObjectsToScene();
            ScenePage.SceneControl.DisplayObjects();
        }

        private void MeshGenerator_setTransfiniteCurveEvent(object arg1, SetTransfiniteCurveEventArgs arg2)
        {
            var ierr = 0;
            GmshController.ModelSetAttribute($"transfinite {arg2.tag}", arg2.attributes, (IntPtr)arg2.v, ref ierr);
                if (arg2.attributes.All(x => x.Length != 0))
                {
                    GmshController.ModelMeshSetTransfiniteCurve(arg2.tag, (int)arg2.points, arg2.attributes[1], arg2.coef, ref ierr);
                    //Перегенерация сетки, если она присутствовала в момент уплотнения кривой
                }
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
                    ConsoleControl.PrintInfo(error, Color.Red);
                cntr.ShowHideTabControls(3, false);
                cntr.ClearTreeView(3);
                var objs = GmshController.GetMeshObjects();


                scenePage.ModelData.ObjectData.Clear(ObjType.Узел);
                var trv = cntr.GetTreeView(2);
                cntr.FillMeshTreeView(GmshController,trv, 2);
            }
        }

        private void MeshGenerator_refineMesh(object sender)
        {
            var cntr = (GMSHGeneralMeshControl)sender;
            var ierr = 0;
            GmshController.ModelMeshRefine(ref ierr);

            var trv = cntr.GetTreeView(2);
            cntr.FillMeshTreeView(GmshController, trv, 2);

            scenePage.ModelData.ObjectData.Clear(ObjType.Узел);//Удаляем только элементы сетки, геометрию не трогаем
            UpdateMeshVBO();

            PresentProjectOnTree();

            ScenePage.SceneControl.FitObjectsToScreen();
            ScenePage.SceneControl.DisplayObjects();
        }

        [HandleProcessCorruptedStateExceptions]
        [SecurityCritical]
        private void MeshGenerator_generate3DMeshEvent(object sender)
        {
            var ierr = 0;
            string error;
            try
            {
                var cntr = (GMSHGeneralMeshControl)sender;

                DeleteGMSHMeshObjects(ObjType.Элемент3D);
                GmshController.ModelMeshGenerate(3, ref ierr);
                var trv = cntr.GetTreeView(3);
                cntr.FillMeshTreeView(GmshController, trv, 3, "Объемы", "Объем ");
            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
                return;
            }
            GmshController.LoggerGetLastError(out error);
            if (!String.IsNullOrEmpty(error))
                ConsoleControl.PrintInfo(error, Color.Red);

            scenePage.ModelData.ObjectData.Clear(ObjType.Узел);//Удаляем только элементы сетки, геометрию не трогаем
            UpdateMeshVBO();

            PresentProjectOnTree();

            ScenePage.SceneControl.FitObjectsToScreen();
            ScenePage.SceneControl.DisplayObjects();
        }

        [HandleProcessCorruptedStateExceptions]
        [SecurityCritical]
        private void MeshGenerator_generate2DMeshEvent(object sender, double meshDencity)
        {
            var ierr = 0;
            string error;
            try
            {
                var cntr = (GMSHGeneralMeshControl)sender;
                GmshController.OptionSetNumber("Mesh.MeshSizeFactor", meshDencity, ref ierr);

                DeleteGMSHMeshObjects(ObjType.Узел);
                GmshController.ModelMeshGenerate(1, ref ierr);
                GmshController.ModelMeshGenerate(2, ref ierr);
                var trv = cntr.GetTreeView(2);
                cntr.FillMeshTreeView(GmshController, trv, 2);
            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
                return;
            }
            GmshController.LoggerGetLastError(out error);
            if (!String.IsNullOrEmpty(error))
                ConsoleControl.PrintInfo(error, Color.Red);

            scenePage.ModelData.ObjectData.Clear(ObjType.Узел);//Удаляем только элементы сетки, геометрию не трогаем
            UpdateMeshVBO();

            PresentProjectOnTree();

            ScenePage.SceneControl.FitObjectsToScreen();
            ScenePage.SceneControl.DisplayObjects();
        }

        private void MeshGenerator_deleteMeshEvent(ObjType objType)
        {
            if(objType == ObjType.Элемент2D)
            {
                DeleteGMSHMeshObjects(ObjType.Узел);
            }
            else if(objType == ObjType.Элемент3D)
            {
                DeleteGMSHMeshObjects(ObjType.Элемент3D);
            }

            scenePage.ModelData.ObjectData.Clear(ObjType.Узел);//Удаляем только элементы сетки, геометрию не трогаем
            UpdateMeshVBO();

            PresentProjectOnTree();

            ScenePage.SceneControl.FitObjectsToScreen();
            ScenePage.SceneControl.DisplayObjects();
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
            ScenePage.SceneControl.DeleteVBObjects("transPoints");

            if (flag)
            {
                var dic = GetCurvesNumbersAndNodes();

                var points = new List<GeometryPoint>();
                foreach (var item in dic.Keys)
                {
                    points.AddRange(GetTransPointsCoords(item));
                }

                var presentor = ScenePage.PresentersCreator.CreatePointObjectsPresenter(points);

                ScenePage.CreateObjectsOnScene("transPoints", presentor);
            }

            ScenePage.SceneControl.DisplayObjects();
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
                ScenePage.SceneControl.HideGeometryObj("DisplaySceneScale");

                if (flag)
                {
                    var curvesInfo = GetCurvesNumbersAndNodes();
                    var max = curvesInfo.Max(x => x.Value);
                    var min = curvesInfo.Min(x => x.Value);

                    var scale = ScenePage.SceneControl.CreateScaleObject(min, max, 3, "", "");

                    ScenePage.SceneControl.DisplaySceneScale(scale);

                    foreach (var item in curvesInfo)
                    {
                        var color = scale.GetValueColor(item.Value);
                        scenePage.ModelData.ObjectData.LineCollection.Find(item.Key).MasterColor = color;
                    }

                    var linePres = ScenePage.PresentersCreator.CreateLineObjectsPresenter(scenePage.ModelData.ObjectData.LineCollection);
                    ScenePage.SceneControl.DeleteVBObjects(ObjType.Линия.ToString());
                    ScenePage.CreateObjectsOnScene(ObjType.Линия.ToString(), linePres);
                    ScenePage.SceneControl.DisplayObjects();
                }
                else
                {
                    foreach (var item in scenePage.ModelData.ObjectData.LineCollection)
                        item.SetBackColor();

                    var linePres = ScenePage.PresentersCreator.CreateLineObjectsPresenter(scenePage.ModelData.ObjectData.LineCollection);
                    ScenePage.SceneControl.DeleteVBObjects(ObjType.Линия.ToString());
                    ScenePage.CreateObjectsOnScene(ObjType.Линия.ToString(), linePres);
                    ScenePage.SceneControl.DisplayObjects();
                }
            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }



        private void GmshControl_ResetColorObjectsEvent(ObjType objType)
        {
            foreach (var item in scenePage.ModelData.ObjectData.GetObjects(objType))
                item.SetBackColor();
            ScenePage.SetObjectsSceneColor(ObjType.Линия);
        }

        private void ShowObjects(List<int> objNumbers)
        {
            try
            {
                foreach (var item in objNumbers)
                {
                    scenePage.ModelData.ObjectData.LineCollection.Find(item).MasterColor
    = ScenePage.SceneControl.SelectionColor;
                }

                ScenePage.SetObjectsSceneColor(ObjType.Линия);
                ScenePage.SceneControl.DisplayObjects();
            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void UpdateMeshVBO()
        {
            var objs = GmshController.GetMeshObjects();

            if(objs.Item1.Count > 0)
                scenePage.ModelData.ObjectData.NodeCollection.AddRange(objs.Item1);
            if (objs.Item1.Count > 0)
                scenePage.ModelData.ObjectData.E1DCollection.AddRange(objs.Item2);
            if (objs.Item1.Count > 0)
                scenePage.ModelData.ObjectData.E2DCollection.AddRange(objs.Item3);
            if (objs.Item4.Count > 0)
                scenePage.ModelData.ObjectData.E3DCollection.AddRange(objs.Item4);

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
            var vbo = ScenePage.SceneControl.FindVBObj(item.ToString());

            if (vbo != null)
                ScenePage.SceneControl.DeleteVBObjects(item.ToString());

            var presentor = ScenePage.CreateObjectsPresentor(item);
            if (presentor.Count() > 0)
                ScenePage.CreateObjectsOnScene(item.ToString(), presentor);
        }   

        private void RedrawScene(bool fitOnScreen)
        {
            if (fitOnScreen)
                ScenePage.SceneControl.FitObjectsToScreen();
            ScenePage.SceneControl.DisplayObjects();
        }

        public void OpenMesh3DGenerator()
        {
            ScenePage.SceneControl.HideAllGeometryObjs();
            ScenePage.SceneControl.HideDisplayText2D();
            ScenePage.SceneControl.HideDisplayText3D();
            PresentProjectOnTree();
            LoadGMSHMeshControl();
            ScenePage.SceneControl.DisplayObjects();
        }

        private void ModelPage_DeleteSelectedObjectsEvent()
        {
            PresentProjectOnTree();
        }
    }
}