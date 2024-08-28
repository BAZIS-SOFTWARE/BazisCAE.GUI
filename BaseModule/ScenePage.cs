using BaseModule.Console;
using Geometry;
using Model;
using ModelControllerInterfaces;
using ModelInterfaces;
using ModelInterfaces.GeometryObjects;
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

namespace BaseModule
{
    public partial class ScenePage : UserControl
    {
        [Category("General")]
        [Description("Выбранный объект сцены")]
        public ObjType SelectedObjects { get; set; }

        public IModelData ModelData { get; set; }

        public IModelController ModelController { get; set; }

        public IPresentersCreator PresentersCreator
        {
            get { return ModelController.PresentersCreator; }
        }
        [Category("SceneControl")]
        [Description("Сцена для отображения объектов")]
        public SceneControl SceneControl
        {
            get { return sceneControl; }
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


        public virtual void PresentCrossSection(ISurfaceFigure surface)
        {

            var presenter = ModelController.PresentersCreator.CreateSurfaceObjectsPresenter(new List<ISurfaceFigure>() { surface }, false);

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
            sceneControl.DeleteVBObjects(ObjType.Линия.ToString());
            sceneControl.DeleteVBObjects(ObjType.Фигура2D.ToString());
            sceneControl.DeleteVBObjects(ObjType.Фигура3D.ToString());
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
            foreach (var item in ModelData.ObjectData.ObjsTypes)
            {
                var presentor = CreateObjectsPresentor(item);
                if (presentor.Count() > 0)
                    CreateObjectsOnScene(item.ToString(), presentor);
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
                if (PresentersCreator.GetView(objsName) == PresenterView.Line)
                    sceneControl.CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, objsName, ObjView.Lines);
                else if (PresentersCreator.GetView(objsName) == PresenterView.LineSurface)
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
            foreach (var item in ModelData.ObjectData.ObjsTypes)
            {
                foreach (var obj in ModelData.ObjectData.GetObjects(item))
                    obj.SetBackColor();
                SetObjectsSceneColor(item);
            }

        }

        private void sceneControl_SelectObjectsEvent(object arg1, Scene.Events.SelectObjectsEventArgs arg2)
        {
            var selections = SearchObjects(SelectedObjects, arg2.SelectionBox);

            if (selections.Count > 0)
            {
                SelectObjects(arg2.IsSelected, arg2.IsSorted, selections);

                if (SelectedObjects == ObjType.Объект)
                {
                    var types = ModelData.ObjectData.ObjsTypes;
                    foreach (var type in types)
                        SetObjectsSceneColor(type);
                }
                else if (SelectedObjects == ObjType.Элемент)
                {
                    SetObjectsSceneColor(ObjType.Элемент1D);
                    SetObjectsSceneColor(ObjType.Элемент2D);
                    SetObjectsSceneColor(ObjType.Элемент3D);
                }
                else if (SelectedObjects == ObjType.Фигура)
                {
                    SetObjectsSceneColor(ObjType.Фигура2D);
                    SetObjectsSceneColor(ObjType.Фигура3D);
                }
                else
                    SetObjectsSceneColor(SelectedObjects);

                sceneControl.DisplayObjects();
            }
        }

        public void SetObjectsSceneColor(ObjType objsType)
        {
            var objName = objsType.ToString();
            var vboObjs = sceneControl.FindVBObj(objName);

            if (vboObjs != null)
            {
                var objsPresenter = CreateObjectsPresentor(objsType);

                if (objsPresenter.Count() > 0)
                {
                    var colors = objsPresenter.CreateVertexes(vboObjs.ColorLength, "цвет");
                    vboObjs.PointsColors = colors;
                }
            }
        }

        private void SelectObjects(bool isSelected, bool isSorted, List<IModelObject> selections)
        {
            if (isSorted & selections.Count > 0)
            {
                var camera = sceneControl.GetCamera();

                var near = selections.OrderByDescending(x => camera.GetSceenCoord(x.CalcCentr())._z).First();
                if (isSelected)
                {
                    near.MasterColor = sceneControl.SelectionColor;
                }
                else
                    near.SetBackColor();
            }
            else
            {
                foreach (var obj in selections)
                    if (isSelected)
                    {
                        obj.MasterColor = sceneControl.SelectionColor;
                    }

                    else
                        obj.SetBackColor();
            }
        }

        public List<IModelObject> SearchObjects(ObjType objType, RectangleBox selectionBox)
        {
            var camera = sceneControl.GetCamera();
            var selections = new List<IModelObject>();

            foreach (var item in ModelData.ObjectData.GetObjects(objType))
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
                    presenter = PresentersCreator.CreatePointObjectsPresenter(ModelData.ObjectData.NodeCollection);
                    break;
                case ObjType.Линия:
                    presenter = PresentersCreator.CreateLineObjectsPresenter(ModelData.ObjectData.LineCollection);
                    break;
                case ObjType.Фигура2D:
                    presenter = PresentersCreator.CreateSurfaceObjectsPresenter(ModelData.ObjectData.Fig2DCollection, false);
                    break;
                case ObjType.Фигура3D:
                    presenter = PresentersCreator.CreateSurfaceObjectsPresenter(ModelData.ObjectData.Fig3DCollection, false);
                    break;
                case ObjType.Элемент1D:
                    presenter = PresentersCreator.CreateLineObjectsPresenter(ModelData.ObjectData.E1DCollection);
                    break;
                case ObjType.Элемент2D:
                    presenter = PresentersCreator.CreateSurfaceObjectsPresenter(ModelData.ObjectData.E2DCollection, false);
                    break;
                case ObjType.Элемент3D:
                    presenter = PresentersCreator.CreateSurfaceObjectsPresenter(ModelData.ObjectData.E3DCollection, true);
                    break;
                default:
                    presenter = PresentersCreator.CreatePointObjectsPresenter(ModelData.ObjectData.PointCollection);
                    break;
            }

            return presenter;
        }

        private void создатьГруппуItem_Click(object sender, EventArgs e)
        {
            if (SelectedObjects == ObjType.Объект |
                SelectedObjects == ObjType.Фигура |
                SelectedObjects == ObjType.Элемент)
            {
                SceneInfoEvent?.Invoke(sender, $"Нельзя создать группу {SelectedObjects}", Color.Orange);
            }
            else
            {
                var selObjs = ModelData.ObjectData.GetObjects(SelectedObjects).
                Where(x => x.MasterColor == SceneControl.SelectionColor);


                if (selObjs.Count() > 0)
                {
                    var grps = ModelData.GroupData.FindMany(SelectedObjects);

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

                    var group = ModelData.GroupData.Create(name, SelectedObjects);

                    group.AddRange(selObjs);
                    ModelData.GroupData.Add(group);

                    foreach (var selObj in selObjs)
                        selObj.SetBackColor();

                    SetObjectsSceneColor(SelectedObjects);

                    sceneControl.DisplayObjects();

                    MeshGroupCreatedEvent?.Invoke(this, name);
                }
            }  
        }

        private void скрытьВыбранноеItem_Click(object sender, EventArgs e)
        {
            var selObjs = ModelData.ObjectData.GetObjects(SelectedObjects).
                Where(x => x.MasterColor == sceneControl.SelectionColor);

            foreach (var selObj in selObjs)
                selObj.ViewState = false;

            if (SelectedObjects == ObjType.Объект)
            {
                sceneControl.DeleteAllVBObjects();
                PresentAllModelObjectsToScene();
            }
            else if (SelectedObjects == ObjType.Элемент)
            {
                sceneControl.DeleteVBObjects(ObjType.Элемент1D.ToString());
                CreateObjectsOnScene(ObjType.Элемент1D.ToString(), CreateObjectsPresentor(ObjType.Элемент1D));
                sceneControl.DeleteVBObjects(ObjType.Элемент2D.ToString());
                CreateObjectsOnScene(ObjType.Элемент2D.ToString(), CreateObjectsPresentor(ObjType.Элемент2D));
                sceneControl.DeleteVBObjects(ObjType.Элемент3D.ToString());
                CreateObjectsOnScene(ObjType.Элемент3D.ToString(), CreateObjectsPresentor(ObjType.Элемент3D));
            }
            else if (SelectedObjects == ObjType.Фигура)
            {
                sceneControl.DeleteVBObjects(ObjType.Фигура2D.ToString());
                CreateObjectsOnScene(ObjType.Фигура2D.ToString(), CreateObjectsPresentor(ObjType.Фигура2D));
                sceneControl.DeleteVBObjects(ObjType.Фигура3D.ToString());
                CreateObjectsOnScene(ObjType.Фигура3D.ToString(), CreateObjectsPresentor(ObjType.Фигура3D));
            }
            else
            {
                var strObjType = SelectedObjects.ToString();
                sceneControl.DeleteVBObjects(strObjType);
                CreateObjectsOnScene(strObjType, CreateObjectsPresentor(SelectedObjects));
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

                foreach (var item in ModelData.ObjectData.ObjsTypes)
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
                var objs = ModelData.ObjectData.GetObjects(SelectedObjects);
                var selObjs = objs.Where(x => x.MasterColor == SceneControl.SelectionColor);

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
            var selObjs = ModelData.ObjectData.GetObjects(SelectedObjects).
    Where(x => x.MasterColor == SceneControl.SelectionColor);

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
    }
}
