using BaseModule.Console;
using BazisGUI.Utilities;
using Geometry;
using Model;
using Model.GeometryObjects;
using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
using ModelControllerInterfaces;
using Newtonsoft.Json.Linq;
using Scene;
using Scene.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BaseModule.Interfaces.GeneralParams;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BazisGUI
{
    public partial class ScenePage : UserControl
    {
        [Category("General")]
        [Description("Выбранный объект сцены")]
        public string SelectedObjects { get; set; }

        IModelData ModelData { get { return ModelController.ModelData; } }

        IModelController ModelController { get; set; }

        IPresentersCreator PresentersCreator
        {
            get { return ModelController.PresentersCreator; }
        }

        public void SetModelController(IModelController modelController)
        {
            ModelController = modelController;
        }

        public IModelController GetModelController()
        {
            return ModelController;
        }


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
        [Description("Цвет узлов")]
        public Color NodeColor
        {
            set
            {
                foreach (var item in ModelData.ObjectData.NodesSet.Values)
                {
                    item.Color = value;
                }
            }
        }  

        public ScenePage()
        {
            InitializeComponent();
        }

        //public event Action<object, Scene.Events.SelectObjectsEventArgs> SelectObjectsEvent;
        public event Action<object, string> MeshGroupCreatedEvent;
        public event Action<object, string, Color> SceneInfoEvent;
        public event Action<object> ShowAllObjectsEvent;
        public event Action<object> SelectionDeletedEvent;
        public event Action SceneExpandEvent;
        public event Action SceneFoldEvent;


        public virtual void PresentCrossSection(SurfaceFigure surface)
        {

            var presenter = ModelController.PresentersCreator.CreateSurfaceObjectsPresenter(new List<SurfaceFigure>() { surface }, false);

            var inds = presenter.CreateIndexes();
            var ptrs = presenter.CreatePointers(inds.Item1);
            var coords = presenter.CreateVertexes(inds.Item2, "координаты");
            var colors = presenter.CreateVertexes(inds.Item3, "цвет");
            var normals = presenter.CreateVertexes(inds.Item2, "нормаль");
            var edges = presenter.CreateEdgeFlags(inds.Item4);

            sceneControl.CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, "crossSection", ObjView.LinesSurface);
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

        public void PresentAllModelObjectsToScene()
        {
            foreach (ObjType item in Enum.GetValues(typeof(ObjType)))
            {
                var presentor = CreateObjectsPresentor(item);
                if (presentor.Count() > 0)
                {
                    presentor.ViewMode = ModelData.ObjectData.GetSetsInfo(item).First().ViewMode;
                    CreateObjectsOnScene(item.ToString(), presentor);
                }

            }
        }

        public void CreateObjectsOnScene(string objsName, IObjsPresenter presenter)
        {
            if (!sceneControl.DrawInsideObjects & presenter.IsVolumeObjs)
            {
                var volPresenter = (IVolumeObjsPresenter)presenter;
                volPresenter.HideInsideSurfaces();
            }

            var inds = presenter.CreateIndexes();
            var ptrs = presenter.CreatePointers(inds.Item1);
            var coords = presenter.CreateVertexes(inds.Item2, "координаты");
            var colors = presenter.CreateVertexes(inds.Item3, "цвет");
            var normals = presenter.CreateVertexes(inds.Item2, "нормаль");
            var edges = presenter.CreateEdgeFlags(inds.Item4);

            if (presenter.PresenterType == PresenterType.Surface)
            {
                if (presenter.ViewMode == ViewMode.Line)
                    sceneControl.CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, objsName, ObjView.Lines);
                else if (presenter.ViewMode == ViewMode.LineSurface)
                    sceneControl.CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, objsName, ObjView.LinesSurface);
                else
                    sceneControl.CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, objsName, ObjView.Surface);
            }

            else if (presenter.PresenterType == PresenterType.Line)
            {
                sceneControl.CreateLineVBObjects(ptrs, coords, colors, normals, edges, objsName);
            }

            else
                sceneControl.CreatePointVBObjects(ptrs, coords, colors, normals, objsName);
        }

        public void SetBackColorToAllObjects()
        {
            foreach (ObjType item in Enum.GetValues(typeof(ObjType)))
            {
                ModelData.ObjectData.SetBackColor(item);
                SetObjectsSceneAttribute(item, "цвет");
            }

        }

        private void sceneControl_SelectObjectsEvent(object arg1, Scene.Events.SelectObjectsEventArgs arg2)
        {
            var selections = SearchObjects(arg2.SelectionBox);

            if (selections.Count > 0)
            {
                SelectObjects(arg2.IsSelected, arg2.IsSorted, selections);

                if (SelectedObjects == "Объекты")
                {
                    foreach (ObjType type in Enum.GetValues(typeof(ObjType)))
                        SetObjectsSceneAttribute(type, "цвет");
                }
                else if (SelectedObjects == "Элементы")
                {
                    SetObjectsSceneAttribute(ObjType.Элемент1D, "цвет");
                    SetObjectsSceneAttribute(ObjType.Элемент2D, "цвет");
                    SetObjectsSceneAttribute(ObjType.Элемент3D, "цвет");
                }
                else if (SelectedObjects == "Фигуры")
                {
                    SetObjectsSceneAttribute(ObjType.Поверхность, "цвет");
                    SetObjectsSceneAttribute(ObjType.Объем, "цвет");
                }
                else
                    SetObjectsSceneAttribute(Converters.ConvertToObjsType(SelectedObjects), "цвет");

                sceneControl.DisplayObjects();
            }
        }

        public void SetObjectsSceneAttribute(ObjType objsType, string attribName)
        {
            var objName = objsType.ToString();
            var vboObjs = sceneControl.FindVBObj(objName);

            if (vboObjs != null)
            {
                var objsPresenter = CreateObjectsPresentor(objsType);

                if (objsPresenter.Count() > 0)
                {
                    if(attribName == "цвет")
                    {
                        var colors = objsPresenter.CreateVertexes(vboObjs.ColorLength, "цвет");
                        vboObjs.PointsColors = colors;
                    }
                    else
                    {
                        var coords = objsPresenter.CreateVertexes(vboObjs.CoordLength, "координаты");
                        vboObjs.PointsCoords = coords;
                    }
                }
            }
        }

        private void SelectObjects(bool isSelected, bool isSorted, List<IModelObject> selections)
        {
            try
            {
                if (isSorted & selections.Count > 0)
                {
                    var camera = sceneControl.GetCamera();

                    var near = selections.OrderByDescending(x => camera.GetSceenCoord(x.CalcCentr())._z).First();
                    var set = ModelData.ObjectData.GetSetInfo(near.ObjType, near.Number);
                    if (isSelected)
                    {
                        near.Color = sceneControl.SelectionColor;
                    }
                    else
                        near.Color = set.Color;
                }
                else
                {
                    foreach (var obj in selections)
                    {
                        var set = ModelData.ObjectData.GetSetInfo(obj.ObjType, obj.Number);
                        if (isSelected)
                        {
                            obj.Color = sceneControl.SelectionColor;
                        }

                        else
                            obj.Color = set.Color;
                    }
                }
            }
            catch (Exception ex)
            {
                SceneInfoEvent?.Invoke(this, ex.Message, Color.Red);
            }
        }

        public List<IModelObject> SearchObjects(RectangleBox selectionBox)
        {
            var camera = sceneControl.GetCamera();
            var selections = new List<IModelObject>();

            foreach (var item in ObjectsProvider.SelectorProvider(ModelData.ObjectData,SelectedObjects))
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
            return selections;
        }

        public IObjsPresenter CreateObjectsPresentor(ObjType objType)
        {
            IObjsPresenter presenter;

            switch (objType)
            {
                case ObjType.Узел:
                    presenter = PresentersCreator.CreatePointObjectsPresenter(ModelData.ObjectData.NodesSet.Values);
                    break;
                case ObjType.Кривая:
                    presenter = PresentersCreator.CreateLineObjectsPresenter(ModelData.ObjectData.CurveCollection.GetObjects());
                    break;
                case ObjType.Поверхность:
                    presenter = PresentersCreator.CreateSurfaceObjectsPresenter(ModelData.ObjectData.SurfaceCollection.GetObjects(), false);
                    break;
                case ObjType.Объем:
                    presenter = PresentersCreator.CreateSurfaceObjectsPresenter(ModelData.ObjectData.VolumeCollection.GetObjects(), false);
                    break;
                case ObjType.Элемент1D:
                    presenter = PresentersCreator.CreateLineObjectsPresenter(ModelData.ObjectData.E1DCollection.GetObjects());
                    break;
                case ObjType.Элемент2D:
                    presenter = PresentersCreator.CreateSurfaceObjectsPresenter(ModelData.ObjectData.E2DCollection.GetObjects(), false);
                    break;
                case ObjType.Элемент3D:
                    presenter = PresentersCreator.CreateSurfaceObjectsPresenter(ModelData.ObjectData.E3DCollection.GetObjects(), true);
                    break;
                default:
                    presenter = PresentersCreator.CreatePointObjectsPresenter(ModelData.ObjectData.PointsSet.Values);
                    break;
            }

            return presenter;
        }

        private void создатьГруппуItem_Click(object sender, EventArgs e)
        {
            if (SelectedObjects == "Объекты" |
                SelectedObjects == "Фигуры" |
                SelectedObjects == "Элементы")
            {
                SceneInfoEvent?.Invoke(sender, $"Нельзя создать группу {SelectedObjects}", Color.Orange);
            }
            else
            {
                var selObjs = ObjectsProvider.SelectorProvider(ModelData.ObjectData, SelectedObjects).
                Where(x => x.Color == SceneControl.SelectionColor);


                if (selObjs.Count() > 0)
                {
                    var objType = Converters.ConvertToObjsType(SelectedObjects);
                    var grps = ModelData.GroupData.FindMany(objType);

                    var counter = 1;
                    var name = $"{SelectedObjects}_{grps.Count() + counter}";

                    while (true)
                    {
                        if (ModelData.GroupData.Find(name) != null)
                        {
                            counter++;
                            name = $"{SelectedObjects}_{grps.Count() + counter}";
                        }
                        else break;
                    }

                    var group = ModelData.GroupData.Create(name, objType);

                    group.AddRange(selObjs);
                    ModelData.GroupData.Add(group);

                    ModelData.ObjectData.SetBackColor(objType);
                    SetObjectsSceneAttribute(objType, "цвет");

                    sceneControl.DisplayObjects();

                    MeshGroupCreatedEvent?.Invoke(this, name);
                }
            }  
        }

        private void скрытьВыбранноеItem_Click(object sender, EventArgs e)
        {

            var selObjs = ObjectsProvider.SelectorProvider(ModelData.ObjectData, SelectedObjects).
                Where(x => x.Color == sceneControl.SelectionColor);

            foreach (var selObj in selObjs)
                selObj.ViewState = false;

            if (SelectedObjects == "Объекты")
            {
                sceneControl.DeleteAllVBObjects();
                PresentAllModelObjectsToScene();
            }
            else if (SelectedObjects == "Элементы")
            {
                sceneControl.DeleteVBObjects(ObjType.Элемент1D.ToString());
                CreateObjectsOnScene(ObjType.Элемент1D.ToString(), CreateObjectsPresentor(ObjType.Элемент1D));
                sceneControl.DeleteVBObjects(ObjType.Элемент2D.ToString());
                CreateObjectsOnScene(ObjType.Элемент2D.ToString(), CreateObjectsPresentor(ObjType.Элемент2D));
                sceneControl.DeleteVBObjects(ObjType.Элемент3D.ToString());
                CreateObjectsOnScene(ObjType.Элемент3D.ToString(), CreateObjectsPresentor(ObjType.Элемент3D));
            }
            else if (SelectedObjects == "Фигуры")
            {
                sceneControl.DeleteVBObjects(ObjType.Поверхность.ToString());
                CreateObjectsOnScene(ObjType.Поверхность.ToString(), CreateObjectsPresentor(ObjType.Поверхность));
                sceneControl.DeleteVBObjects(ObjType.Объем.ToString());
                CreateObjectsOnScene(ObjType.Объем.ToString(), CreateObjectsPresentor(ObjType.Объем));
            }
            else
            {
                sceneControl.DeleteVBObjects(SelectedObjects);
                var objType = Converters.ConvertToObjsType(SelectedObjects);
                CreateObjectsOnScene(SelectedObjects, CreateObjectsPresentor(objType));
            }


            sceneControl.DisplayObjects();
        }

        private void показатьСкрытыеItem_Click(object sender, EventArgs e)
        {
            ShowAllObjects();
            SceneControl.DisplayObjects();

            ShowAllObjectsEvent?.Invoke(sender);
        }

        public void ClearAllDataOnScene()
        {
            sceneControl.HideAllGeometryObjs();
            sceneControl.HideDisplayText2D();
            sceneControl.HideDisplayText3D();
            sceneControl.DeleteAllVBObjects();
        }

        public void ShowAllObjects()
        {
            try
            {
                SceneControl.DeleteAllVBObjects();

                foreach (ObjType item in Enum.GetValues(typeof(ObjType)))
                {
                    foreach (var modelObject in ModelData.ObjectData.GetObjects(item))
                        modelObject.ViewState = true;
                }

                PresentAllModelObjectsToScene();

            }
            catch (Exception ex)
            {
                SceneInfoEvent?.Invoke(this, ex.Message, Color.Red);
            }
        }

        private void menuItem_InfoSelectedObjects_Click(object sender, EventArgs e)
        {
            try
            {
                var objs = ObjectsProvider.SelectorProvider(ModelData.ObjectData, SelectedObjects);
                var selObjs = objs.Where(x => x.Color == SceneControl.SelectionColor);

                var message = $"Выбраны {SelectedObjects} {selObjs.Count()}";

                var numbers = string.Join("\n", selObjs.Select(x => x.ToString()).ToArray());

                message += "\n" + numbers;

                SceneInfoEvent?.Invoke(sender, message, Color.Black);
            }
            catch (Exception ex)
            {
                SceneInfoEvent?.Invoke(sender, ex.Message, Color.Red);
            }
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
            var selObjs = ObjectsProvider.SelectorProvider(ModelData.ObjectData, SelectedObjects).
    Where(x => x.Color == SceneControl.SelectionColor);

            foreach (var selObj in selObjs)
                selObj.ExistState = false;

            ModelData.ObjectData.ClearNotExisted();
            ModelData.GroupData.ClearNotExisted();
            sceneControl.DeleteAllVBObjects();

            PresentAllModelObjectsToScene();

            sceneControl.DisplayObjects();

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
                SetBackColorToAllObjects();
                SceneControl.DisplayObjects();
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
    }
}
