using BaseModule.Console;
using BazisGUI.Utilities;
using Geometry;
using Model;
using Model.GeometryObjects;
using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
using Model.MeshObjects;
using ModelController.MeshObjsUtility;
using ModelController.ModelScenePresentator;
using ModelController.ModelScenePresentator.GlObjsPresenters;
using ModelControllerInterfaces;
using Newtonsoft.Json.Linq;
using Scene;
using Scene.Events;
using Scene.Interfaces;
using Scene.VBO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static BaseModule.Interfaces.GeneralParams;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BazisGUI
{
    public partial class ScenePage : UserControl
    {
        IPresentersCreator presentersCreator = new PresentersCreator();

        public IPresentersCreator PresentersCreator { get { return presentersCreator; } }

        public ChangeInsideSurface ChangeInsideSurface => new ChangeInsideSurface();


        [Category("SceneControl")]
        [Description("Сцена для отображения объектов")]
        public SceneControl SceneControl
        {
            get { return sceneControl; }
        }
        [Category("General")]
        [Description("Уровень прозрачности объектов")]
        public int TransparencyValue { get; set; }

        [Category("General")]
        [Description("Показать внутренние объекты")]
        public bool ShowInsideObjects { get; set; }

        public ScenePage()
        {
            InitializeComponent();
        }


        public event Action<object> MeshGroupCreatedEvent;
        public event Action<object, string, Color> SceneInfoEvent;
        public event Action<object> ShowAllObjectsEvent;
        public event Action<object> SelectionDeletedEvent;
        public event Action<object, SelectObjectsEventArgs> SelectObjectsEvent;
        public event Action<object> HideSelectedObjects;
        public event Action SceneExpandEvent;
        public event Action SceneFoldEvent;
        public event Action<object> SetBackColorToAllObjectsEvent;


        public virtual void PresentCrossSection(ISurfaceObjsPresenter presenter)
        {
            var inds = presenter.CreateIndexes();
            var ptrs = presenter.CreatePointers(inds.Item1);
            var coords = presenter.CreateVertexes(inds.Item2, "координаты");
            var colors = presenter.CreateVertexes(inds.Item3, "цвет");
            var normals = presenter.CreateVertexes(inds.Item2, "нормаль");
            var edges = presenter.CreateEdgeFlags(inds.Item4);

            var separs = presenter.CreateSeparators();

            sceneControl.CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, "crossSection", separs, ObjView.LinesSurface);
            sceneControl.DisplayObjects();
        }

        public void ClearAllGeometryDataOnScene()
        {
            sceneControl.DeleteVBObjects(ObjType.Точка.ToString());
            sceneControl.DeleteVBObjects(ObjType.Кривая.ToString());
            sceneControl.DeleteVBObjects(ObjType.Поверхность.ToString());
            sceneControl.DeleteVBObjects(ObjType.Объем.ToString());
        }

        public void ClearAllMeshDataOnScene()
        {
            sceneControl.DeleteVBObjects(ObjType.Узел.ToString());
            sceneControl.DeleteVBObjects(ObjType.Элемент1D.ToString());
            sceneControl.DeleteVBObjects(ObjType.Элемент2D.ToString());
            sceneControl.DeleteVBObjects(ObjType.Элемент3D.ToString());
        }

        public void PresentAllModelObjectsToScene(IModelData modelData)
        {
            foreach (ObjType item in Enum.GetValues(typeof(ObjType)))
            {
                var presentor = CreateObjectsPresentor(modelData, item);
                if (presentor.Count() > 0)
                {
                    presentor.ViewMode = modelData.ObjectData.GetSetsInfo(item).First().ViewMode;
                    CreateObjectsOnScene(item.ToString(), presentor);
                }
            }
        }

        public IObjsPresenter CreateObjectsPresentor(IModelData modelData, ObjType objType)
        {

            switch (objType)
            {
                case ObjType.Узел:
                    return presentersCreator.CreatePointObjectsPresenter(modelData.ObjectData.NodesSet.Values);
                case ObjType.Кривая:
                    return presentersCreator?.CreateLineObjectsPresenter(modelData.ObjectData.CurveCollection.GetObjects());
                case ObjType.Поверхность:
                    return presentersCreator.CreateSurfaceObjectsPresenter(modelData.ObjectData.SurfaceCollection.GetObjects());
                case ObjType.Объем:
                    return presentersCreator.CreateSurfaceObjectsPresenter(modelData.ObjectData.VolumeCollection.GetObjects());
                case ObjType.Элемент1D:
                    return presentersCreator.CreateLineObjectsPresenter(modelData.ObjectData.E1DCollection.GetObjects());

                case ObjType.Элемент2D:
                    return presentersCreator.CreateSurfaceObjectsPresenter(modelData.ObjectData.E2DCollection.GetObjects());

                case ObjType.Элемент3D:
                    if (!ShowInsideObjects)
                        ChangeInsideSurface.HideInsideSurfaces(modelData.ObjectData.E3DCollection.GetObjects());
                    return presentersCreator.CreateSurfaceObjectsPresenter(modelData.ObjectData.E3DCollection.GetObjects());
                default:
                    return presentersCreator.CreatePointObjectsPresenter(modelData.ObjectData.PointsSet.Values);
            }
        }

        public void CreateObjectsOnScene(string objsName, IObjsPresenter presenter)
        {
            var inds = presenter.CreateIndexes();
            var ptrs = presenter.CreatePointers(inds.Item1);
            var coords = presenter.CreateVertexes(inds.Item2, "координаты");
            var colors = presenter.CreateVertexes(inds.Item3, "цвет");
            var normals = presenter.CreateVertexes(inds.Item2, "нормаль");
            var edges = presenter.CreateEdgeFlags(inds.Item4);

            if(ptrs.Length != 0)
            {
                if (presenter.PresenterType == PresenterType.Surface)
                {
                    var pres = (ISurfaceObjsPresenter)presenter;
                    var separs = pres.CreateSeparators();

                    if (presenter.ViewMode == ViewMode.Line)
                        sceneControl.CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, objsName, separs, ObjView.Lines);
                    else if (presenter.ViewMode == ViewMode.LineSurface)
                        sceneControl.CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, objsName, separs, ObjView.LinesSurface);
                    else
                        sceneControl.CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, objsName, separs, ObjView.Surface);
                }

                else if (presenter.PresenterType == PresenterType.Line)
                {
                    sceneControl.CreateLineVBObjects(ptrs, coords, colors, normals, edges, objsName);
                }

                else
                    sceneControl.CreatePointVBObjects(ptrs, coords, colors, normals, objsName);
            }

        }

        private void sceneControl_SelectObjectsEvent(object arg1, Scene.Events.SelectObjectsEventArgs arg2)
        {
            SelectObjectsEvent?.Invoke(this, arg2);
        }  

        public void SetObjectsSceneAttribute(IObjsPresenter presenter, string objsName,string attribName)
        {
            //var objName = objsType.ToString();
            var vboObjs = sceneControl.FindVBObj(objsName);

            if (vboObjs != null)
            {         
                if (presenter.Count() > 0)
                {
                    if(attribName == "цвет")
                    {
                        var colors = presenter.CreateVertexes(vboObjs.ColorLength, "цвет");
                        vboObjs.PointsColors = colors;
                    }
                    else
                    {
                        var coords = presenter.CreateVertexes(vboObjs.CoordLength, "координаты");
                        vboObjs.PointsCoords = coords;
                    }
                }
            }
        } 

        public List<IModelObject> SearchObjects(IEnumerable<IModelObject> objects, RectangleBox selectionBox, bool isSorted)
        {
            var camera = sceneControl.GetCamera();
            var selections = new List<IModelObject>();

            foreach (var item in objects)
            {
                if (item.ViewState)
                {
                    var scrPoints = new Point2D[item.NumberOfPoints];
                    var scnPoints = new Point3D[item.NumberOfPoints];

                    var pointCounter = 0;
                    foreach (var point in item.GetCoordinates())
                    {
                        var scnPoint = camera.GetSceenCoord(point);
                        scnPoints[pointCounter] = scnPoint;

                        var scrPoint = camera.GetScreenCoord(scnPoint);
                        scrPoints[pointCounter] = scrPoint;

                        pointCounter++;
                    }

                    if (selectionBox.IsPointsInside(scrPoints))
                        selections.Add(item);
                }
            }

            if(isSorted & selections.Count > 0)
            {
                var near = selections.OrderByDescending(x => camera.GetSceenCoord(x.CalcCentr())._z).FirstOrDefault();
                selections =  new List<IModelObject>() { near };
            }
            
            return selections;
        }

        private void создатьГруппуItem_Click(object sender, EventArgs e)
        {
            MeshGroupCreatedEvent?.Invoke(this);
        }

        private void скрытьВыбранноеItem_Click(object sender, EventArgs e)
        {
            HideSelectedObjects?.Invoke(this);
        }

        public void PresentModelObjectsOnScene(IModelData modelData, string objects)
        {
            if (objects == "Объекты")
            {
                sceneControl.DeleteAllVBObjects();
                PresentAllModelObjectsToScene(modelData);
            }
            else if (objects == "Элементы")
            {
                sceneControl.DeleteVBObjects(ObjType.Элемент1D.ToString());
                CreateObjectsOnScene(ObjType.Элемент1D.ToString(), CreateObjectsPresentor(modelData,ObjType.Элемент1D));
                sceneControl.DeleteVBObjects(ObjType.Элемент2D.ToString());
                CreateObjectsOnScene(ObjType.Элемент2D.ToString(), CreateObjectsPresentor(modelData,ObjType.Элемент2D));
                sceneControl.DeleteVBObjects(ObjType.Элемент3D.ToString());
                CreateObjectsOnScene(ObjType.Элемент3D.ToString(), CreateObjectsPresentor(modelData,ObjType.Элемент3D));
            }
            else if (objects == "Фигуры")
            {
                sceneControl.DeleteVBObjects(ObjType.Поверхность.ToString());
                CreateObjectsOnScene(ObjType.Поверхность.ToString(), CreateObjectsPresentor(modelData,ObjType.Поверхность));
                sceneControl.DeleteVBObjects(ObjType.Объем.ToString());
                CreateObjectsOnScene(ObjType.Объем.ToString(), CreateObjectsPresentor(modelData,ObjType.Объем));
            }
            else
            {
                sceneControl.DeleteVBObjects(objects);
                var objType = Converters.ConvertToObjsType(objects);
                CreateObjectsOnScene(objects, CreateObjectsPresentor(modelData,objType));
            }


            sceneControl.DisplayObjects();
        }

        private void показатьСкрытыеItem_Click(object sender, EventArgs e)
        {
            try
            {
                ShowAllObjectsEvent?.Invoke(this);

            }
            catch (Exception ex)
            {
                SceneInfoEvent?.Invoke(this, ex.Message, Color.Red);
            }
        }

        public void ClearAllDataOnScene()
        {
            sceneControl.HideAllGeometryObjs();
            sceneControl.HideDisplayText2D();
            sceneControl.HideDisplayText3D();
            sceneControl.DeleteAllVBObjects();
        }

        private void menuItem_InfoSelectedObjects_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    var objs = ObjectsProvider.SelectorProvider(ModelData.ObjectData, SelectedObjects);
            //    var selObjs = objs.Where(x => x.Color == SceneControl.SelectionColor);

            //    var message = $"Выбраны {SelectedObjects} {selObjs.Count()}";

            //    var numbers = string.Join("\n", selObjs.Select(x => x.ToString()).ToArray());

            //    message += "\n" + numbers;

            //    SceneInfoEvent?.Invoke(sender, message, Color.Black);
            //}
            //catch (Exception ex)
            //{
            //    SceneInfoEvent?.Invoke(sender, ex.Message, Color.Red);
            //}
        }

        private void menuItem_SetRotPoint_Click(object sender, EventArgs e)
        {
            var left = sceneControl.ScreenMousePosition.X;
            var rigth = sceneControl.ScreenMousePosition.X + 10;
            var top = sceneControl.ScreenMousePosition.Y;
            var bottom = sceneControl.ScreenMousePosition.Y - 10;

            var selectionBox = new RectangleBox(left, rigth, bottom, top);

            var selection = new List<Point3D>();



            foreach (var glObj in sceneControl.GetVBObjs())
            {
                var coords = glObj.PointsCoords;

                var length = coords.Length / 3;

                for (int i = 0; i < length; i++)
                {
                    var x = coords[3 * i + 0];
                    var y = coords[3 * i + 1];
                    var z = coords[3 * i + 2];

                    var scnCoord = sceneControl.GetCamera().GetSceenCoord(x, y, z);
                    var scrCoord = sceneControl.GetCamera().GetScreenCoord(scnCoord);

                    if (selectionBox.IsPointInside(scrCoord))
                        selection.Add(scnCoord);
                }
            }

            selection = selection.OrderByDescending(x => x._z).ToList();
            if (selection.Count > 0)
                sceneControl.SetRotationCentre(selection.First());

            sceneControl.DisplayObjects();
        }

        private void menuItem_DeleteSelectedObjects_Click(object sender, EventArgs e)
        {
            SelectionDeletedEvent?.Invoke(sender);
        }

        private void sceneControl_MessageEvent(object arg1, Scene.Events.MessageEventArgs arg2)
        {
            SceneInfoEvent?.Invoke(arg1,arg2.Message,Color.Red);
        }

        private void sceneControl_SceneMouseClickEvent(object arg1, MouseEventArgs arg2)
        {
            if (!sceneControl.MouseMoveFlag)
                if (arg2.Button == MouseButtons.Right)
                    contextMenu.Show(this, arg2.Location);
        }

        private void sceneControl_SceneKeyDownEvent(object arg1, KeyEventArgs arg2)
        {
            if(arg2.KeyCode == Keys.Escape)
            {
                SetBackColorToAllObjectsEvent?.Invoke(this);
            }
        }

        private void sceneControl_SceneControlExpandEvent()
        {
            SceneExpandEvent?.Invoke();
        }

        private void sceneControl_SceneControlFoldEvent()
        {
            SceneFoldEvent?.Invoke();
        }

        internal void ColorObjects(IModelData modelData, string objTypeStr)
        {
            if (objTypeStr == "Объекты")
            {
                foreach (ObjType type in Enum.GetValues(typeof(ObjType)))
                    SetObjectsSceneAttribute(CreateObjectsPresentor(modelData, type), type.ToString(), "цвет");
            }
            else if (objTypeStr == "Элементы")
            {
                SetObjectsSceneAttribute(CreateObjectsPresentor(modelData, ObjType.Элемент1D), objTypeStr.ToString(), "цвет");
                SetObjectsSceneAttribute(CreateObjectsPresentor(modelData, ObjType.Элемент2D), objTypeStr.ToString(), "цвет");
                SetObjectsSceneAttribute(CreateObjectsPresentor(modelData, ObjType.Элемент3D), objTypeStr.ToString(), "цвет");
            }
            else if (objTypeStr == "Фигуры")
            {
                SetObjectsSceneAttribute(CreateObjectsPresentor(modelData, ObjType.Поверхность), objTypeStr.ToString(), "цвет");
                SetObjectsSceneAttribute(CreateObjectsPresentor(modelData, ObjType.Объем), objTypeStr.ToString(), "цвет");
            }
            else
            {
                var objType = Converters.ConvertToObjsType(objTypeStr);
                var presentor = CreateObjectsPresentor(modelData, objType);
                SetObjectsSceneAttribute(presentor, objType.ToString(), "цвет");
            }


            sceneControl.DisplayObjects();
        }
    }
}
