using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.Platform.Windows;
using Geometry;
using System.ComponentModel;
using System.Reflection;
using BazisGUI.Scene.Interfaces;
using BazisGUI.Scene.VBO;
using BazisGUI.Scene.EventsArgs;
using BazisGUI.Scene;
using BazisGUI.Utilities;
using Model.Interfaces.ObjectsCollections;
using Model.Interfaces;
using ModelControllerInterfaces;

namespace BazisGUI
{
    public partial class BaseForm
    {
        List<VBObject> glObjs = new List<VBObject>();

        //Dictionary<GLObjType,HashSet<VBObject>> glObjs = new List<VBObject>();

        int fontBase;//Идентификатор первого сгенерированного Glyph(глифа)
        bool blending;
        bool lighting;
        /// <summary>
        /// 
        /// </summary>
        ///         /// <inheritdoc/>
        [Category("Navigation")]
        [Description("Get mouse position from center of screen")]
        public System.Drawing.Point ScreenMousePosition { get; private set; } = new System.Drawing.Point(0, 0);

        SceneCamera camera;
        SceneCompass compass;
        SceneBasis basis;
        ScreenRectangle selectionRectangle;
        ClipPlaneRenderer clipPlaneRenderer;
        Advanced3DClipper advanced3DClipper;
        AverageColorRenderer averageColorRenderer;

        private Color backGroundColor = Color.Green;
        private Color selectionColor = Color.Green;

        private ViewAxis rotAxis;
        private float rotAngle = 2.5f;
        private float scaleFactor = 1.0f;
        bool displayRotatioPoint;
        bool displayCompass = true;
        bool displayClipPlane = false;
        private ViewProjection projection = ViewProjection.Perspective;

        /// <inheritdoc/>
        [Category("Navigation")]
        [Description("Set mouse move flag")]
        public bool MouseMoveFlag { get; private set; }
        /// <inheritdoc/>

        [Category("Navigation")]
        [Description("Set rotation axis")]
        public ViewAxis RotationAxis
        {
            get { return rotAxis; }
            set { rotAxis = value; }
        }
        /// <inheritdoc/>

        [Category("Navigation")]
        [Description("Set rotation angle")]
        public float RotationAngle
        {
            get { return rotAngle; }
            set { rotAngle = value; }
        }
        /// <inheritdoc/>
        [Category("General properties")]
        [Description("Set projection")]
        public ViewProjection Projection
        {
            get { return projection; }
            set { projection = value; }
        }

        /// <inheritdoc/>

        [Description("Set backGround color")]
        [Category("General properties")]
        public Color BackGroundColor
        {
            get { return backGroundColor; }
            set {
                backGroundColor = value;
                AverageColorRenderer.BackgroundColor = value;
            }
        }
        /// <inheritdoc/>
        [Description("Ignore surface back edges")]
        [Category("General properties")]
        public bool ShowSurfaceBackEdges
        {
            get => AverageColorRenderer.ShowSurfaceBackEdges;
            set => AverageColorRenderer.ShowSurfaceBackEdges = value;
        }
        /// <inheritdoc/>

        [Description("Display compass")]
        [Category("General properties")]
        [DefaultValue(true)]
        public bool DisplayCompass
        {
            get { return displayCompass; }
            set { displayCompass = value; }
        }
        /// <inheritdoc/>

        [Description("Set selection color")]
        [Category("General properties")]
        public Color SelectionColor
        {
            get { return selectionColor; }
            set { selectionColor = value; }
        }
        /// <inheritdoc/>


        [Description("Set lighting for surfaceObjects")]
        [Category("General properties")]
        [DefaultValue(false)]
        public bool IsLighting
        {
            get => lighting;
            set
            {
                lighting = value;
                AverageColorRenderer.IsLighting = value;//Синхронизация с рендером прозрачности
            }
        }
        /// <inheritdoc/>

        [Description("Set or Get lighting translate vector X")]
        [Category("General properties")]
        public float LightTranslateX { get; set; }
        /// <inheritdoc/>

        [Description("Set or Get lighting translate vector Y")]
        [Category("General properties")]
        public float LightTranslateY { get; set; }
        /// <inheritdoc/>

        [Description("Set or Get lighting translate vector Z")]
        [Category("General properties")]
        public float LightTranslateZ { get; set; }
        /// <inheritdoc/> 
        [Description("Set or Get light linear attenuation")]
        [Category("General properties")]
        public float LightAttenuation
        {
            get
            {
                var par = 0.0f;
                Gl.glGetLightfv(Gl.GL_LIGHT0, Gl.GL_LINEAR_ATTENUATION, out par);
                return par;
            }
            set => Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_LINEAR_ATTENUATION, ref value);
        }

        /// <inheritdoc/>

        [Description("Set Cutting for surfaceObjects")]
        [Category("General properties")]
        [DefaultValue(false)]
        public bool IsCutting { get; set; }

        /// <inheritdoc/>
        [Description("Set blending")]
        [Category("General properties")]
        [DefaultValue(false)]
        public bool IsBlending
        {
            get
            {
                return blending;
            }
            set
            {
                blending = value;
                AverageColorRenderer.IsEnable = value;
            }
        }

        /// <summary>
        /// IsSceneExpand
        /// </summary>
        [Description("Set Expand")]
        [Category("General properties")]
        [DefaultValue(false)]
        public bool IsSceneExpand { get; set; }
/// <inheritdoc/>

        public ISceneCamera GetCamera()
        {
            return camera;
        }
/// <inheritdoc/>


        public IVBObject FindVBObj(string objName)
        {
            return glObjs.Find(x => x.ObjName == objName);
        }

/// <inheritdoc/>

        public float ScaleFactor
        {
            get{ return scaleFactor; }
            set { scaleFactor = value; }
        }
/// <inheritdoc/>

        public int SceneWidth { get { return this.Width; } }
/// <inheritdoc/>

        public int SceneHeight { get { return this.Height; } }
/// <inheritdoc/>

        public float ShadowAngle { get ; set ; }
        /// <inheritdoc/>
        public bool IsSmoothShadow { get ; set; }

        [Category("General")]
        [Description("Уровень прозрачности объектов")]
        public int TransparencyValue { get; set; }

        [Category("General")]
        [Description("Показать внутренние объекты")]
        public bool IsInsideObjectsShown { get; set; }
        /// <inheritdoc/>

        [Description("Set backGround color")]
        [Category("General properties")]
        public bool DisplayBasis { get; set; }

        /// <inheritdoc/>
        [Description("Set or get clip plane")]
        [Category("General properties")]
        public bool IsClipPlane 
        { 
            get
            {
                return displayClipPlane;
            }
            set
            {
                displayClipPlane = value;

                if(value)
                {
                    if (glObjs.Count > 0)
                    {
                        var bbox = glObjs.OrderByDescending(v => v.BoundingBox.GetDiagonalLength())
                                         .First().BoundingBox;
                        clipPlaneRenderer.BoundingBox = bbox;
                        clipPlaneRenderer.CreateBoudingBoxVBO(bbox.LeftUpNear, bbox.RightDownFar);
                    }
                    else
                        clipPlaneRenderer.CreateBoudingBoxVBO(new Point3D(), new Point3D());              

                }
                else
                    clipPlaneRenderer?.DestroyBoundingBoxVBO();
            }
        }

        /// <summary>
        /// SceneMouseClickEvent
        /// </summary>
        public event Action<object, MouseEventArgs> SceneMouseClickEvent;
        /// <summary>
        /// SceneKeyDownEvent
        /// </summary>
        public event Action<object, KeyEventArgs> SceneKeyDownEvent;

        //public event Action<object, EventArgs> ShowAllHiddenObjectsEvent;
        //public event Action<object, EventArgs> HideSelectedObjectsEvent;
        //public event Action<object, EventArgs> CreateMeshGroupEvent;
        //public event Action<object, EventArgs> DeleteSelectionEvent;

        /// <summary>
        /// MessageEvent
        /// </summary>
        public event Action<object, MessageEventArgs> MessageEvent;
/// <inheritdoc/>

        public event Action SceneControlExpandEvent;
        /// <inheritdoc/>
        public event Action SceneControlFoldEvent;

        event Action DisplayGeometryObjectEvent;
        event Action DisplayText3DEvent;
        event Action DisplayText2DEvent;
        event Action DisplayRotationPointEvent;
        event Action DisplayClipPlaneEvent;
        event Action DisplayReflectionPlaneEvent;


        public void PresentCrossSection(ISurfaceObjsPresenter presenter)
        {
            var inds = presenter.CreateIndexes();
            var ptrs = presenter.CreatePointers(inds.Item1);
            var coords = presenter.CreateVertexes(inds.Item2, "координаты");
            var colors = presenter.CreateVertexes(inds.Item3, "цвет");
            var normals = presenter.CreateVertexes(inds.Item2, "нормаль");
            var edges = presenter.CreateEdgeFlags(inds.Item4);

            var separs = presenter.CreateSeparators();

            CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, "crossSection", separs, ObjView.LinesSurface);
            DisplayObjects();
        }

        public void ClearAllGeometryDataOnScene()
        {
            DeleteVBObjects(ObjType.Точка.ToString());
            DeleteVBObjects(ObjType.Кривая.ToString());
            DeleteVBObjects(ObjType.Поверхность.ToString());
            DeleteVBObjects(ObjType.Объем.ToString());
        }

        public void ClearAllMeshDataOnScene()
        {
            DeleteVBObjects(ObjType.Узел.ToString());
            DeleteVBObjects(ObjType.Элемент1D.ToString());
            DeleteVBObjects(ObjType.Элемент2D.ToString());
            DeleteVBObjects(ObjType.Элемент3D.ToString());
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
                    if (IsInsideObjectsShown)
                        changeInsideSurface.HideInsideSurfaces(modelData.ObjectData.E3DCollection.GetObjects());
                    return presentersCreator.CreateSurfaceObjectsPresenter(modelData.ObjectData.E3DCollection.GetObjects());
                default:
                    return presentersCreator.CreatePointObjectsPresenter(modelData.ObjectData.PointsSet.Values);
            }
        }

        public void PresentObjectsOnScene(IObjsPresenter presenter, string name)
        {
            var vbobj = FindVBObj(name);
            if (vbobj != null)
            {
                var viewMode = vbobj.ViewMode;

                DeleteVBObjects(name);
                CreateObjectsOnScene(name, presenter);
                ChangeViewModeVBObjects(name, viewMode);
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

            if (ptrs.Length != 0)
            {
                if (presenter.PresenterType == PresenterType.Surface)
                {
                    var pres = (ISurfaceObjsPresenter)presenter;
                    var separs = pres.CreateSeparators();

                    if (presenter.ViewMode == ViewMode.Line)
                        CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, objsName, separs, ObjView.Lines);
                    else if (presenter.ViewMode == ViewMode.LineSurface)
                        CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, objsName, separs, ObjView.LinesSurface);
                    else
                        CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, objsName, separs, ObjView.Surface);
                }

                else if (presenter.PresenterType == PresenterType.Line)
                {
                    CreateLineVBObjects(ptrs, coords, colors, normals, edges, objsName);
                }

                else
                    CreatePointVBObjects(ptrs, coords, colors, normals, objsName);
            }

        }

        public void SetObjectsSceneAttribute(IObjsPresenter presenter, string objsName, string attribName)
        {
            //var objName = objsType.ToString();
            var vboObjs = FindVBObj(objsName);

            if (vboObjs != null)
            {
                if (presenter.Count() > 0)
                {
                    if (attribName == "цвет")
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
            var camera = GetCamera();
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

            if (isSorted & selections.Count > 0)
            {
                var near = selections.OrderByDescending(x => camera.GetSceenCoord(x.CalcCentr())._z).FirstOrDefault();
                selections = new List<IModelObject>() { near };
            }

            return selections;
        }

        public void PresentModelObjectsOnScene(IModelData modelData, string objects)
        {
            if (objects == "Объекты")
            {
                DeleteAllVBObjects();
                PresentAllModelObjectsToScene(modelData);
            }
            else if (objects == "Элементы")
            {
                DeleteVBObjects(ObjType.Элемент1D.ToString());
                CreateObjectsOnScene(ObjType.Элемент1D.ToString(), CreateObjectsPresentor(modelData, ObjType.Элемент1D));
                DeleteVBObjects(ObjType.Элемент2D.ToString());
                CreateObjectsOnScene(ObjType.Элемент2D.ToString(), CreateObjectsPresentor(modelData, ObjType.Элемент2D));
                DeleteVBObjects(ObjType.Элемент3D.ToString());
                CreateObjectsOnScene(ObjType.Элемент3D.ToString(), CreateObjectsPresentor(modelData, ObjType.Элемент3D));
            }
            else if (objects == "Фигуры")
            {
                DeleteVBObjects(ObjType.Поверхность.ToString());
                CreateObjectsOnScene(ObjType.Поверхность.ToString(), CreateObjectsPresentor(modelData, ObjType.Поверхность));
                DeleteVBObjects(ObjType.Объем.ToString());
                CreateObjectsOnScene(ObjType.Объем.ToString(), CreateObjectsPresentor(modelData, ObjType.Объем));
            }
            else
            {
                DeleteVBObjects(objects);
                var objType = Converters.ConvertToObjsType(objects);
                CreateObjectsOnScene(objects, CreateObjectsPresentor(modelData, objType));
            }


            DisplayObjects();
        }

        public void ClearAllDataOnScene()
        {
            HideAllGeometryObjs();
            HideDisplayText2D();
            HideDisplayText3D();
            DeleteAllVBObjects();
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


            DisplayObjects();
        }

        /// <inheritdoc/>


        public void SceneInitialization()
        {
            basis = new SceneBasis();
            DisplayRotationPointEvent = CreateRotationPoint();
            camera = new SceneCamera(0, 0, -5, Width, Height, 2.5f);
            UpdateProjection();
            compass = new SceneCompass();

            selectionRectangle = new ScreenRectangle();

            /*
            IntPtr hdc = Wgl.wglGetCurrentDC();
            Wgl.wglUseFontBitmapsW(hdc, 0, 1150, 1000); // Ниже заменю на проверенный корректный вызов*/

            fontBase = Gl.glGenLists(1150);//кол-во глифов (элементов для рисования букв 256 - только латиница, 1150 - поддержка еще и кирилицы)
            ChangeTextFont(fontBase);//Используем шрифт по-умолчанию
            //ChangeTextFont(fontBase, "Comic Sans", 18, FontStyle.Italic);//Проверка различного типа шрифтов
            compass.FontBase = fontBase;
            //После этого мы должны передавать fontBase в любой класс, который использует шрифты!          

            Gle.Load();
            //AverageColorRenderer.CreateAverageColorRenderer(scene.Width, scene.Height);
            averageColorRenderer = new AverageColorRenderer(Width, Height);
            clipPlaneRenderer = new ClipPlaneRenderer();
            advanced3DClipper = new Advanced3DClipper();
            Disposed += (s, e) =>
            {
                foreach (var obj in glObjs)
                    VBO.DeleteAllBuffers(obj);
                averageColorRenderer.Dispose();
                clipPlaneRenderer.Dispose();
                advanced3DClipper.Dispose();
                Gl.glDeleteLists(fontBase, 1150);
            };
            //Disposed += (s, e) => AverageColorRenderer.Dispose();
            //Disposed += (s, e) => clipPlaneRenderer.Dispose();
            //DisplayClipPlane();//Регистрируем обработчик визуализации сечения
        }


        /// <summary>
        /// Для корректного отображения шрифтов нужен HDC окна, созданного на этапе вызова метода scene.InitializeContexts();
        /// Однако оно приватное, мы можем получить его через рефлексию
        /// </summary>
        /// <returns>IntPtr - deviceContext</returns>
        private IntPtr GetDeviceContext()
        {
            var bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            var fields = typeof(SimpleOpenGlControl).GetFields(bindingFlags);
            return (IntPtr)fields[1].GetValue(scene);//deviceContext распологается на первом индексе!
        }
        /// <summary>
        /// Использовать шрифты по умолчанию или задать свой, для отображения текста
        /// </summary>
        /// <param name="fBase">Индекс сгенерированный с помощью комманды Gl.GenLists()</param>
        /// <param name="fontFamily">Семейство шрифтов например "Times New Roman"</param>
        /// <param name="size">Размер шрифта</param>
        /// <param name="style">Курсив(Italic), жирный(Bold) и т.д</param>
        private void ChangeTextFont(int fBase, string fontFamily = "", float size = 8.25f, FontStyle style = FontStyle.Regular)
        {
            var hdc = GetDeviceContext();
            if (string.IsNullOrEmpty(fontFamily))
            {
                var status = Wgl.wglUseFontBitmapsW(hdc, 0, 1150, fBase);
            }
            else
            {
                var font = new Font(fontFamily, size, style);
                var hFont = font.ToHfont();

                //Вызов системных функций, для корректной замены шрифта!
                var oldFont = Gdi.SelectObject(hdc, hFont);//Делаем Swap шрифтов
                var status = Wgl.wglUseFontBitmapsW(hdc, 0, 1150, fBase);

                Gdi.SelectObject(hdc, oldFont);//Делаем текущим старый шрифт
                Gdi.DeleteObject(hFont);//Обязательно освобождаем неуправляемый ресурс
            }
        }

        private void DisplayControlStatus()
        {
            var cornerRect = new ScreenRectangle() { Red = 0, Green = 0, Blue = 0 };

            cornerRect.winScrenePosit = new Point(Width - 18, Height - 9);
            cornerRect.winScreneCoord.X = cornerRect.winScrenePosit.X + 8;
            cornerRect.winScreneCoord.Y = cornerRect.winScrenePosit.Y - 8;
            cornerRect.Display(scene.Width, scene.Height);

            if (IsSceneExpand)
            {
                cornerRect.winScrenePosit = new Point(Width - 21, Height - 12);
                cornerRect.winScreneCoord.X = cornerRect.winScrenePosit.X + 8;
                cornerRect.winScreneCoord.Y = cornerRect.winScrenePosit.Y - 8;
                cornerRect.Display(scene.Width, scene.Height);
            }
        }
        /// <inheritdoc/>

        public void DisplayObjects()
        {
            Gl.glClearColor(BackGroundColor.R/255.0f, BackGroundColor.G / 255.0f, BackGroundColor.B / 255.0f, 0);
            // очистка буфера цвета и буфера глубины в заданный цвет 
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            if (IsBlending && !advanced3DClipper.IsEnable)
                averageColorRenderer.ClearColors();
            if (DisplayBasis)
            {
                if(IsBlending && !advanced3DClipper.IsEnable)
                    averageColorRenderer.DoActionsBeforeDrawing(null, DrawElements.GeometryObjects);
                basis.Display(camera, scaleFactor);
                if (displayRotatioPoint)
                    DisplayRotationPointEvent.Invoke();
                if (IsBlending && !advanced3DClipper.IsEnable)
                    averageColorRenderer.DoActionsAfterDrawing(null, DrawElements.GeometryObjects);
            }

            //----
            Gl.glPushMatrix();
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            var matrix = camera.GetViewMatrix();
            var viewMatrixAr = matrix.AsColumnMajorArray();

            Gl.glLoadMatrixf(viewMatrixAr);
            Gl.glPopMatrix();
            //----
            // вызов всех подключенных методов   
            DisplayGeometryObjectEvent?.Invoke();

            if(IsCutting)
            {
                Gl.glEnable(Gl.GL_CULL_FACE);
                Gl.glCullFace(Gl.GL_BACK);
                Gl.glFrontFace(Gl.GL_CCW);
            }
            //if (IsLighting)//Перенес в другое место
                //Gl.glEnable(Gl.GL_LIGHTING);
            //if(IsBlending) //Не нужно
                //Gl.glEnable(Gl.GL_BLEND);

            DisplayModelObjects();
            if (IsBlending && !advanced3DClipper.IsEnable)
                averageColorRenderer.BlendFramebuffers();

            if (DisplayCompass)
            {
                Gl.glDisable(Gl.GL_DEPTH);
                compass.Display(camera, scaleFactor);
                Gl.glEnable(Gl.GL_DEPTH);
            }


            DisplayText3DEvent?.Invoke();
            DisplayText2DEvent?.Invoke(); 

            DisplayControlStatus();

            Gl.glFlush();
            scene.Invalidate();
        }

        private void DisplayModelObjects()
        {
            Gl.glPushMatrix();//У каждого VBObject теперь свои трансформации
            Gl.glTranslatef(-camera.Position._x, -camera.Position._y, -camera.Position._z);

            Gl.glEnable(Gl.GL_NORMALIZE); //делам нормали одинаковой величины во избежание артефактов
            Gl.glEnable(Gl.GL_LIGHT0);

            //Установим вектор перемещения для источника света GL_LIGHT0
            Gl.glPushMatrix();
            Gl.glLoadIdentity();
            Gl.glTranslatef(LightTranslateX, LightTranslateY, LightTranslateZ);
            var pos = new float[] { 0.0f, 0.0f, 1.0f, 1.0f };
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, pos);
            Gl.glPopMatrix();

            Gl.glBlendFuncSeparate(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA, Gl.GL_ONE, Gl.GL_ONE);

            //Gl.glEnableClientState(Gl.GL_VERTEX_ARRAY);//Перенес по месту вызова Draw конкретного объекта, может помочь
            //Gl.glEnableClientState(Gl.GL_COLOR_ARRAY);
            //Gl.glEnableClientState(Gl.GL_NORMAL_ARRAY);
            //Gl.glEnableClientState(Gl.GL_EDGE_FLAG_ARRAY);
            DisplayReflectionPlaneEvent?.Invoke();
            if(displayClipPlane)
                DisplayClipPlaneEvent?.Invoke();
            if (IsLighting)
                Gl.glEnable(Gl.GL_LIGHTING);
            float[] global_ambient = new float[] { 0.2f, 0.2f, 0.2f, 1 };
            Gl.glLightModelfv(Gl.GL_LIGHT_MODEL_AMBIENT, global_ambient);
            float[] diffuse = new float[] { 1, 1, 1, 1 };
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, diffuse);
            //float[] light_position = new float[] { 1, 1, 1, 1 };
            //Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light_position);
            Gl.glLightModeli(Gl.GL_LIGHT_MODEL_TWO_SIDE, Gl.GL_TRUE);

            //Gl.glColorMaterial(Gl.GL_FRONT_AND_BACK, Gl.GL_AMBIENT_AND_DIFFUSE); // have to be before loadinng objects you want to light
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);

            Gl.glLineWidth(1.5f);


            foreach (var sObj in glObjs.Where(x => x.GL_ObjType == GLObjType.triangle))
            {
                Gl.glPushMatrix();
                Gl.glMultMatrixf(sObj.ModelMatrix);
                //Поправка: Возможное решение проблемы с отсутсвием картинки в режиме ребер на радеоне! (работает на NVidia)
                //Gl.glEnableClientState(Gl.GL_EDGE_FLAG_ARRAY);
                sObj.Load();
                //Gl.glDisableClientState(Gl.GL_EDGE_FLAG_ARRAY);
                Gl.glPopMatrix();
            }
            Gl.glDisable(Gl.GL_LIGHTING);

            foreach (var lObj in glObjs.Where(x => x.GL_ObjType == GLObjType.line))
            {
                Gl.glPushMatrix();
                Gl.glMultMatrixf(lObj.ModelMatrix);
                lObj.Load();
                Gl.glPopMatrix();
            }
            foreach (var pObj in glObjs.Where(x => x.GL_ObjType == GLObjType.point))
            {
                Gl.glPushMatrix();
                Gl.glMultMatrixf(pObj.ModelMatrix);
                pObj.Load();
                Gl.glPopMatrix();
            }

            Gl.glDisable(Gl.GL_BLEND);
            Gl.glDisable(Gl.GL_CULL_FACE);
            Gl.glDisable(Gl.GL_COLOR_MATERIAL);
            //Gl.glDisableClientState(Gl.GL_VERTEX_ARRAY);
            //Gl.glDisableClientState(Gl.GL_COLOR_ARRAY);

            //Gl.glDisableClientState(Gl.GL_NORMAL_ARRAY);
            //Gl.glDisableClientState(Gl.GL_EDGE_FLAG_ARRAY);
            Gl.glPopMatrix();
        }       

        /// <inheritdoc/>
        //TO DO добавить тест
        public void SetRotationCentre(Point3D modelPoint)
        {
            var viewMatrix = camera.GetViewMatrix();

            camera.Position = modelPoint; // Может быть не хранить мировые кординаты выбранной точки как позицию камеры

            viewMatrix[0, 3] = 0; viewMatrix[1, 3] = 0;
            var tempViewMatrixAr = viewMatrix.AsColumnMajorArray();
            Gl.glLoadMatrixf(tempViewMatrixAr);
        }
/// <inheritdoc/>

        public void PlaneObjs(ViewPlane plane)
        {
            camera.SetOnPlane(plane, scaleFactor);
        }
/// <inheritdoc/>

        public void ScaleObjs(float scaleFactor)
        {
            Gl.glScalef(scaleFactor, scaleFactor, scaleFactor);
            var crd = GetSceneCoordOfScreenVector(0, 1);
            this.scaleFactor = (float)Math.Sqrt(Math.Pow(crd._x, 2) + Math.Pow(crd._y, 2) + Math.Pow(crd._z, 2));
        }
        /// <inheritdoc/>

        public void RotateObjs()
        {
            camera.Rotate(rotAxis,rotAngle);
        }
/// <inheritdoc/>


        public void FitObjectsToScreen()
        {
            var matrix = camera.GetViewMatrix();
            matrix[0, 3] = 0; matrix[1, 3] = 0;
            var tempViewMatrixAr = matrix.AsColumnMajorArray();

            Gl.glLoadMatrixf(tempViewMatrixAr);

            for (int i = 0; i < 3; i++)
            {
                var factor = 1.0f;
                var maxRad = 0.0f;

                foreach (var glObj in glObjs)
                {
                    var coords = glObj.PointsCoords;

                    if (coords.Length == 0)
                        continue;

                    var length = coords.Length / 3;
                    for (int j = 0; j < length; j++)
                    {
                        var x = coords[3 * j + 0];
                        var y = coords[3 * j + 1];
                        var z = coords[3 * j + 2];
                        var scnCoord = camera.GetSceenCoord(x,y,z);
                        var scrCoord = camera.GetScreenCoord(scnCoord);

                        var pRad = (float)Math.Sqrt((scrCoord._x * scrCoord._x) + (scrCoord._y * scrCoord._y));

                        if (pRad > maxRad) maxRad = pRad;
                    }

                    if (Width > Height)
                        factor = 1 / (maxRad / (float)(Height / 2));
                    else { factor = 1 / (maxRad / (float)(Width / 2)); }

                    if (factor == 0) factor = 1;

                    ScaleObjs(factor);
                }
                if (Math.Abs(factor - 1) < 0.1) break;
            }
        }
      
/// <inheritdoc/>

        public void UpdateProjection()
        {
            var aspectRatio = (double)scene.Width / scene.Height;
            var angleDeg = 2.5;
            if (Projection == ViewProjection.Parallel)
            {
                float[] view = new float[16];
                Gl.glGetFloatv(Gl.GL_MODELVIEW_MATRIX, view);//Не могу вызывать Camera.GetViewMatrix() - т.к Camera = null
                var worldPos = new Point3D(-view[12], -view[13], -view[14]);
                var distance = Vector.GetVectorLenght(worldPos);
                if (Math.Abs(distance) < 1e-4)
                    distance = 1;
                var radAngle = angleDeg * Math.PI / 180;
                var height = Math.Tan(radAngle / 2) * distance * 2;
                var width = height * aspectRatio;
                var sizeX = width / 2;
                var sizeY = height / 2;
                Gl.glMatrixMode(Gl.GL_PROJECTION);
                Gl.glLoadIdentity();
                Gl.glOrtho(-sizeX, sizeX, -sizeY, sizeY, -distance * 2, distance * 2);
            }
            else
            {
                Gl.glMatrixMode(Gl.GL_PROJECTION);
                Gl.glLoadIdentity();
                Glu.gluPerspective(angleDeg, aspectRatio, 1, 2000);
            }
            Gl.glMatrixMode(Gl.GL_MODELVIEW);//Возврашаем на ModelView, иначе начинаются проблемы с рисованием
        }

        
        /// <summary>
        /// Смена режима прозрачности для vbo-объектов
        /// </summary>
        /// <param name="isTransparent"></param>
        public void ChangeVBOTransparentMode(bool isTransparent)
        {
            if (advanced3DClipper.IsEnable)
                return;
            var drawObj = isTransparent ? averageColorRenderer : null;
            foreach(var globj in glObjs)
                globj.ActiveDrawingObject = drawObj;
        }
        /// <summary>
        /// Смена толщины отображения слоя 3д элементов
        /// </summary>
        /// <param name="thickness"></param>
        public void ChangeLayerThickness(float thickness) => advanced3DClipper.LayerThickness = thickness;

        /// <summary>
        /// Смена режима отсечения для 3д элементов
        /// </summary>
        /// <param name="mode">Режим отсечения</param>
        /// <param name="element3dObj">Имя объекта 3д элементов</param>
        public void ChangeClipMode(ClipMode mode, string element3dObj)
        {
            advanced3DClipper.ClipMode = mode;
            var obj = FindVBObj(element3dObj);

            if (obj != null)
            {
                var el3d = (SurfaceObjects)obj;
                if (mode == ClipMode.None)
                {
                    el3d.ActiveDrawingObject = null;
                    Gl.glDisable(Gl.GL_CLIP_PLANE0);
                }
                else
                    el3d.ActiveDrawingObject = advanced3DClipper;
                advanced3DClipper.Create3DBoundingBoxes(el3d);
            }
        }

        /// <inheritdoc/>
        public void ChangeClipPlane(Plane plane)
        {
            DisplayClipPlaneEvent = null;

            DisplayClipPlaneEvent += new Action(() =>
            {
                if (IsBlending && !advanced3DClipper.IsEnable)
                    averageColorRenderer.DoActionsBeforeDrawing(null, DrawElements.GeometryObjects);
                float[] modelMatrix = new float[16];
                Gl.glGetFloatv(Gl.GL_MODELVIEW_MATRIX, modelMatrix);//Запоминаем предыдущую матрицу в стеке
                Gl.glPushMatrix();
                var origin = plane.Normal.Mult(plane.Shifting);

                var sX = Math.Sign(plane.Normal._x);
                var sY = Math.Sign(plane.Normal._y);
                var sZ = Math.Sign(plane.Normal._z);

                var bbox = clipPlaneRenderer.BoundingBox;

                var diagonal = Vector.GetVectorLenght(bbox.LeftUpNear.Sub(bbox.RightDownFar));
                var center = bbox.RightDownFar.Sum(bbox.LeftUpNear).Mult(0.5f);
                Gl.glTranslatef(center._x, center._y, center._z);
                Gl.glTranslatef(sX * origin._x, sY * origin._y, sZ * origin._z);
                var angle = Vector.GetCosAngleVectors(new Point3D(0, 0, -1), plane.Normal);
                angle = (float)(Math.Acos(angle) * 180 / Math.PI);
                var axis = Vector.CrossProd(new Point3D(0, 0, -1), plane.Normal);
                Gl.glRotatef(angle, axis._x, axis._y, axis._z);
                var normalSize = diagonal * 0.125f;

                Gl.glGetFloatv(Gl.GL_MODELVIEW_MATRIX, advanced3DClipper.ClipMatrix);
                advanced3DClipper.ScaleFactor = ScaleFactor;

                clipPlaneRenderer.Draw(modelMatrix, normalSize);

                Gl.glPopMatrix();
                if (IsBlending && !advanced3DClipper.IsEnable)
                    averageColorRenderer.DoActionsAfterDrawing(null, DrawElements.GeometryObjects);
            });
        }        


        private Action CreateRotationPoint()
        {
            return new Action(() =>
            {
                Gl.glPushMatrix();
                Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL);
                Gl.glColor3f(1, 0.75f, 0);

                var quadObj = Glu.gluNewQuadric();

                Gl.glScalef(1 / scaleFactor, 1 / scaleFactor, 1 / scaleFactor);
                Glu.gluSphere(quadObj, 0.003, 10, 10); // рисуем сферу
                Gl.glPopMatrix();
                Glu.gluDeleteQuadric(quadObj);
            });
        }
/// <inheritdoc/>

        public void DisplayText3D(string str, Color color, Point3D coord)
        {
            var met = new Action(() =>
            {
                if (IsBlending && !advanced3DClipper.IsEnable)
                    averageColorRenderer.DoActionsBeforeDrawing(null, DrawElements.GeometryObjects);
                Gl.glPushMatrix();
                Gl.glTranslatef(-camera.Position._x, -camera.Position._y, -camera.Position._z);
                Gl.glColor3b(color.R, color.G, color.B);
                Gl.glRasterPos3f(coord._x, coord._y, coord._z);
                Gl.glPushAttrib(Gl.GL_LIST_BASE);//Избегаем пересечений списков, сохраняем старую базу
                Gl.glListBase(fontBase);//Устанавливаем базу на fontBase
                Gl.glCallLists(str.Length, Gl.GL_UNSIGNED_SHORT, str);
                Gl.glPopAttrib();//Возвращаем старую базу
                Gl.glPopMatrix();
                if (IsBlending && !advanced3DClipper.IsEnable)
                    averageColorRenderer.DoActionsAfterDrawing(null, DrawElements.GeometryObjects);
            });

            DisplayText3DEvent += met;
        }
/// <inheritdoc/>

        public void DisplayText2D(string str, Color color, Point2D coord)
        {
            var met = new Action(() =>
            {
                if (IsBlending && !advanced3DClipper.IsEnable)
                    averageColorRenderer.DoActionsBeforeDrawing(null, DrawElements.GeometryObjects);
                Gl.glMatrixMode(Gl.GL_PROJECTION);
                Gl.glPushMatrix();
                Gl.glLoadIdentity();

                Gl.glOrtho(0, camera.Width, 0, camera.Height, 0.1, 200);

                Gl.glMatrixMode(Gl.GL_MODELVIEW);
                Gl.glPushMatrix();
                Gl.glLoadIdentity();


                Gl.glPushMatrix();

                Gl.glColor3b(color.R, color.G, color.B);
                Gl.glRasterPos3f(coord._x, coord._y, -5);
                Gl.glPushAttrib(Gl.GL_LIST_BASE);//Избегаем пересечений списков, сохраняем старую базу
                Gl.glListBase(fontBase);//Устанавливаем базу на fontBase
                Gl.glCallLists(str.Length, Gl.GL_UNSIGNED_SHORT, str);
                Gl.glPopAttrib();//Возвращаем старую базу
                Gl.glPopMatrix();

                Gl.glMatrixMode(Gl.GL_PROJECTION);
                Gl.glPopMatrix();
                Gl.glMatrixMode(Gl.GL_MODELVIEW);
                Gl.glPopMatrix();
                if (IsBlending && !advanced3DClipper.IsEnable)
                    averageColorRenderer.DoActionsAfterDrawing(null, DrawElements.GeometryObjects);
            });
            DisplayText2DEvent += met;
        }


        /// <summary>
        /// ShowAllVBObjects
        /// </summary>
        public void ShowAllVBObjects()
        {
            glObjs.ForEach(x => x.ViewState = true);
        }
        /// <summary>
        /// HideAllVBObjects
        /// </summary>
        public void HideAllVBObjects()
        {
            glObjs.ForEach(x => x.ViewState = false);
        }
        /// <summary>
        /// HideAllGeometryObjs
        /// </summary>
        public void HideAllGeometryObjs()
        {
            DisplayGeometryObjectEvent = null;
        }
/// <inheritdoc/>

        public void HideDisplayText3D()
        {
            DisplayText3DEvent = null;
        }
/// <inheritdoc/>

        public void HideDisplayText2D()
        {
            DisplayText2DEvent = null;
        }
/// <inheritdoc/>

        public void HideGeometryObj(string searchMethod)
        {
            //var list = PlugDisplayObjectEvent?.GetInvocationList();
            for (int i = 0; i < DisplayGeometryObjectEvent?.GetInvocationList().Count(); i++)
            {
                var del = DisplayGeometryObjectEvent.GetInvocationList()[i];
                if (del.Method.Name.Contains(searchMethod))
                {
                    DisplayGeometryObjectEvent -= (Action)del;
                    i--;
                }
            }
        }
/// <inheritdoc/>

        public bool FindGeometryObj(string searchMethod)
        {
            //var list = PlugDisplayObjectEvent?.GetInvocationList();
            for (int i = 0; i < DisplayGeometryObjectEvent?.GetInvocationList().Count(); i++)
            {
                var del = DisplayGeometryObjectEvent.GetInvocationList()[i];
                if (del.Method.Name.Contains(searchMethod))
                {
                    return true;
                }
            }
            return false;
        }
/// <inheritdoc/>

        public bool DeleteVBObjects(string objName)
        {
            var glObj = glObjs.Find(x => x.ObjName == objName);
            if (glObj != null)
            {
                VBO.DeleteAllBuffers(glObj);//Если удаляем объект, то чистим массивы во избежании утечки памяти на видеокарте
                return glObjs.Remove(glObj);
            }
            else return false;
                                
        }
/// <inheritdoc/>

        public void DeleteAllVBObjects()
        {
            foreach (var glObj in glObjs)
                VBO.DeleteAllBuffers(glObj);//Если удаляем объект, то чистим массивы во избежании утечки памяти на видеокарте
            glObjs.Clear();
            clipPlaneRenderer?.DestroyBoundingBoxVBO();//Удаление VBO объекта не связанный со сценой
        }

        /// <summary>
        /// Находит общие точки в VBO-массиве координат
        /// </summary>
        /// <param name="glCoords">VBO-массив координат</param>
        /// <returns>Словарь (ключ)точка: (значение)список смещений точек внутри VBO</returns>
        public Dictionary<VBOPoint, List<int>> FindCommonPoints(float[] glCoords)
        {
            var cPoints = new Dictionary<VBOPoint, List<int>>();
            for (var i = 0; i < glCoords.Length; i += 3)
            {
                var point = new VBOPoint(glCoords[i], glCoords[i + 1], glCoords[i + 2]);
                if(!cPoints.ContainsKey(point))
                    cPoints.Add(point, new List<int>(10));
                cPoints[point].Add(i); 
            }
            return cPoints;
        }
        /// <summary>
        /// Просчитывает единичные нормали
        /// </summary>
        /// <param name="glNormals">VBO-массив нормалей</param>
        public void GetUnitNormals(float[] glNormals)
        {
            for (var i = 0; i < glNormals.Length; i += 9)
            {
                var normal = new Point3D(glNormals[i], glNormals[i + 1], glNormals[i + 2]);
                normal = Vector.GetVectorNorm(normal);
                for(var j = 0; j < 3; ++j)
                    SetNormal(glNormals, normal, i + j * 3);
            }
        }

        private void SetNormal(float[] glNormals, Point3D normal, int stride)
        {
            glNormals[stride] = normal._x;
            glNormals[stride + 1] = normal._y;
            glNormals[stride + 2] = normal._z;
        }
        /// <summary>
        /// SmoothShadow
        /// </summary>
        /// <param name="glCoords"></param>
        /// <param name="glNormals"></param>
        /// <returns></returns>
        public float[] SmoothShadow(float[] glCoords, float[] glNormals)
        {
            var radAngle = ShadowAngle / 180f * (float)Math.PI;
            var minCos = (float)Math.Cos(radAngle);
            var cPoints = FindCommonPoints(glCoords);
            GetUnitNormals(glNormals);
            var smoothNormals = new float[glNormals.Length];
            foreach (var point in cPoints)
                for (var i = 0; i < point.Value.Count; ++i)
                {
                    var key = point.Value[i];
                    var srcNormal = new Point3D(glNormals[key], glNormals[key + 1], glNormals[key + 2]);
                    var intNormal = new Point3D(srcNormal._x, srcNormal._y, srcNormal._z);
                    for (var j = 0; j < point.Value.Count; ++j)
                    {
                        var sKey = point.Value[j];
                        var cmpNormal = new Point3D(glNormals[sKey], glNormals[sKey + 1], glNormals[sKey + 2]);
                        if (i != j && Vector.DotProd(cmpNormal, srcNormal) >= minCos)
                            intNormal = intNormal.Sum(cmpNormal);
                    }
                    SetNormal(smoothNormals, intNormal, point.Value[i]);
                }
            return smoothNormals;
        }
        /// <summary>
        /// CreateSurfaceVBObjects
        /// </summary>
        /// <param name="ptrs"></param>
        /// <param name="coords"></param>
        /// <param name="colors"></param>
        /// <param name="normals"></param>
        /// <param name="edges"></param>
        /// <param name="objsName"></param>
        /// <param name="separs"></param>
        /// <param name="viewMode"></param>
        public void CreateSurfaceVBObjects(int[] ptrs, float[] coords, float[] colors, float[] normals, 
            bool[] edges, string objsName, int[] separs,ObjView viewMode)
        {
            if (IsSmoothShadow)
                normals = SmoothShadow(coords, normals);

            var vbObj = new SurfaceObjects(edges, ptrs, coords, colors, normals, objsName);
            vbObj.CreateSeparators(separs);
            vbObj.ViewMode = viewMode;
            glObjs.Add(vbObj);
            vbObj.ActiveDrawingObject = AverageColorRenderer.IsEnable ? averageColorRenderer : null;
        }
        /// <summary>
        /// CreateLineVBObjects
        /// </summary>
        /// <param name="ptrs"></param>
        /// <param name="coords"></param>
        /// <param name="colors"></param>
        /// <param name="normals"></param>
        /// <param name="edges"></param>
        /// <param name="objsName"></param>
        public void CreateLineVBObjects(int[] ptrs, float[] coords, float[] colors, float[] normals, bool[] edges, string objsName)
        {
            var obj = new LineObjects(edges, ptrs, coords, colors, normals, objsName);
            glObjs.Add(obj);
            obj.ActiveDrawingObject = AverageColorRenderer.IsEnable ? averageColorRenderer : null;
        }
        /// <summary>
        /// CreatePointVBObjects
        /// </summary>
        /// <param name="ptrs"></param>
        /// <param name="coords"></param>
        /// <param name="colors"></param>
        /// <param name="normals"></param>
        /// <param name="objsName"></param>
        public void CreatePointVBObjects(int[] ptrs, float[] coords, float[] colors, float[] normals, string objsName)
        {
            var obj = new PointObjects(ptrs, coords, colors, normals ,objsName);
            glObjs.Add(obj);
            obj.ActiveDrawingObject = AverageColorRenderer.IsEnable ? averageColorRenderer : null;
        }


        /// <inheritdoc/>


        public void CopyVBObjects(VBObject original, string copyName)
        {
            var pointers = original.PointsIndexes;
            var coords = original.PointsCoords;
            var colors = original.PointsColors;
            var normals = original.NormalsCoords;
            if (original.GL_ObjType == GLObjType.point)
                CreatePointVBObjects(pointers, coords, colors, normals, copyName);
            else if (original.GL_ObjType == GLObjType.line)
                CreateLineVBObjects(pointers, coords, colors, normals, new bool[0], copyName);
            else if (original.GL_ObjType == GLObjType.triangle)
            {
                var sObj = original as SurfaceObjects;
                var edges = sObj.EdgeFlags;
                normals = normals.Select(v => -v).ToArray();

                CreateSurfaceVBObjects(pointers, coords, colors, normals, edges, copyName, sObj.Separators, ObjView.LinesSurface);
            }
        }
        /// <inheritdoc/>

        public void HideReflectionPlane()
        {
            DisplayReflectionPlaneEvent = null;
        }
/// <inheritdoc/>

        public void DisplayReflectionPlane(string objName, float[] coeff)
        {
            var plane = new Plane(new Point3D(coeff[0], coeff[1], coeff[2]), coeff[3]);
            var original = FindVBObj(objName);

            if(original == null)
                throw new Exception($"Объект с именем {original.ObjName} не существует");

            var met = new Action(() =>
            {
                if (IsBlending && !advanced3DClipper.IsEnable)
                    averageColorRenderer.DoActionsBeforeDrawing(null, DrawElements.GeometryObjects);
                var bb = original.BoundingBox;
                Gl.glPushMatrix();
                Gl.glMultMatrixf(original.ModelMatrix);
                var normal = Vector.GetVectorNorm(plane.Normal);
                var origin = normal.Mult(plane.Shifting);
                Gl.glTranslatef(origin._x, origin._y, origin._z);
                var z = new Point3D(0, 0, -1);
                var angleY = Vector.GetCosAngleVectors(z, normal);
                angleY = (float)(Math.Acos(angleY) * 180 / Math.PI);
                var axisY = Vector.CrossProd(z, normal);
                Gl.glRotatef(angleY, axisY._x, axisY._y, axisY._z);

                var scale = 1f;
                var left = bb.LeftUpNear.Mult(scale);
                var right = bb.RightDownFar.Mult(scale);

                var zN = (float)Math.Min(right._x - left._x, left._y - right._y) * -Math.Sign(plane.Shifting) * 0.25f;
                normal = new Point3D(0, 0, zN);

                var center = new Point3D((right._x + left._x) / 2, (right._y + left._y) / 2, 0);
                var endNormal = center.Sum(normal);

                var arrow0 = new Point3D((left._x - center._x) * 0.5f, 0, 0);
                var arrow1 = arrow0.Mult(-1);

                arrow0 = arrow0.Sub(normal).Mult(0.15f);
                arrow1 = arrow1.Sub(normal).Mult(0.15f);

                arrow0 = endNormal.Sum(arrow0);
                arrow1 = endNormal.Sum(arrow1);

                //Рисование рамки
                Gl.glBegin(Gl.GL_LINE_STRIP);
                Gl.glColor3f(0, 1, 0);
                Gl.glVertex3f(left._x, right._y, 0);

                Gl.glColor3f(0, 1, 0);
                Gl.glVertex3f(right._x, right._y, 0);

                Gl.glColor3f(0, 1, 0);
                Gl.glVertex3f(right._x, left._y, 0);

                Gl.glColor3f(0, 1, 0);
                Gl.glVertex3f(left._x, left._y, 0);

                Gl.glColor3f(0, 1, 0);
                Gl.glVertex3f(left._x, right._y, 0);
                Gl.glEnd();
                //Рисование нормали (3 линии)
                Gl.glBegin(Gl.GL_LINES);
                Gl.glColor3f(0, 1, 0);
                Gl.glVertex3f(center._x, center._y, center._z);
                Gl.glColor3f(0, 1, 0);
                Gl.glVertex3f(endNormal._x, endNormal._y, endNormal._z);

                Gl.glColor3f(0, 1, 0);
                Gl.glVertex3f(endNormal._x, endNormal._y, endNormal._z);
                Gl.glColor3f(0, 1, 0);
                Gl.glVertex3f(arrow0._x, arrow0._y, arrow0._z);

                Gl.glColor3f(0, 1, 0);
                Gl.glVertex3f(endNormal._x, endNormal._y, endNormal._z);
                Gl.glColor3f(0, 1, 0);
                Gl.glVertex3f(arrow1._x, arrow1._y, arrow1._z);
                Gl.glEnd();
                Gl.glPopMatrix();
                if (IsBlending && !advanced3DClipper.IsEnable)
                    averageColorRenderer.DoActionsAfterDrawing(null, DrawElements.GeometryObjects);
            });

            DisplayReflectionPlaneEvent = met;
        }


        private void CreateNormalsFromPoints(string newVbo, float[] points, float[] normals, float sF = 1.0f)
        {
            var vCount = points.Length / 3;
            var indices = Enumerable.Range(0, vCount * 2).ToArray();
            var edges = new bool[vCount * 2].Select(v => true).ToArray();
            var newNormals = new float[vCount * 6];
            var newColors = new float[vCount * 8];
            var pointCoords = new float[vCount * 6];

            for (int i = 0, j = 0; i < points.Length; i += 3, j += 6)
            {
                for (var k = 0; k < 3; ++k)
                    pointCoords[j + k] = points[i + k];
                for (var k = 3; k < 6; ++k)
                    pointCoords[j + k] = points[i + k - 3] + normals[i + k - 3] * sF;
            }
            CreateLineVBObjects(indices, pointCoords, newColors, newNormals, edges, newVbo);
        }

        private void CreateNormalsFromCenterSurface(string newVbo, float[] points, float[] normals, float sF = 1.0f)
        {
            var vCount = points.Length / 3;
            var indCount = vCount / 3 * 2;
            var indices = Enumerable.Range(0, indCount).ToArray();
            var edges = new bool[indCount].Select(v => true).ToArray();
            var newNormals = new float[indCount * 3];
            var newColors = new float[indCount * 4];
            var pointCoords = new float[indCount * 3];
            var layout = Enumerable.Range(0, indCount).Select(v => (float)v).ToArray();

            for (int i = 0, j = 0; i < points.Length; i += 9, j += 6)
            {
                pointCoords[j] = (points[i] + points[i + 3] + points[i + 6]) / 3;
                pointCoords[j + 1] = (points[i + 1] + points[i + 4] + points[i + 7]) / 3;
                pointCoords[j + 2] = (points[i + 2] + points[i + 5] + points[i + 8]) / 3;

                pointCoords[j + 3] = pointCoords[j] + normals[i] * sF;
                pointCoords[j + 4] = pointCoords[j + 1] + normals[i + 1] * sF;
                pointCoords[j + 5] = pointCoords[j + 2] + normals[i + 2] * sF;
            }
            CreateLineVBObjects(indices, pointCoords, newColors, newNormals, edges, newVbo);
        }


        /// <summary>
        /// Показать нормали объекта
        /// </summary>
        /// <param name="vboObj">[In]Имя вбо объекта</param>
        /// <param name="show">[In]Показать?</param>
        /// <param name="fromPoints">[In]Нормали из точек</param>
        /// <param name="sF">[In]Размер нормали</param>
        public void ShowNormals(string vboObj, bool show, bool fromPoints = false, float sF = 1.0f)
        {
            var src = FindVBObj(vboObj);
            if (src != null && src.GL_ObjType == GLObjType.triangle)
            {
                var vboNormal = vboObj + " Нормали";
                var obj = FindVBObj(vboNormal);
                if (show)
                {
                    if (obj == null)
                    {
                        var vbObj = src as VBObject;
                        var points = src.PointsCoords;
                        var normals = vbObj.NormalsCoords;

                        if (fromPoints)
                            CreateNormalsFromPoints(vboNormal, points, normals, sF);
                        else
                            CreateNormalsFromCenterSurface(vboNormal, points, normals, sF);
                    }
                }
                else if (obj != default)
                    DeleteVBObjects(vboNormal);
            }
        }



        /// <summary>
        /// Создает зеркальную (относительно плоскости) копию вбо-объекта, если задано имя оригинала и копии и коэффициенты плоскости
        /// </summary>
        /// <param name="srcVboName">[In]Имя объекта источника или пустая строка как триггер отмены эвента рисования плоскости</param>
        /// <param name="copyVboName">[In]Имя объекта копии</param>
        /// <param name="coef">[In]Коэффициенты плоскости</param>
        public void CreateReflectedVBObject(string srcVboName, string copyVboName, float[] coef)
        {
            var normal = new Point3D(coef[0], coef[1], coef[2]);
            normal = Vector.GetVectorNorm(normal);
            var plane = new Plane(normal, coef[3]);

            var copyVbo = FindVBObj(copyVboName);
            if(copyVbo != null)
                throw new Exception($"Объект с именем {copyVbo} уже существует");

            var srcVbo = FindVBObj(srcVboName) as VBObject;

            if (srcVbo == null)
                throw new Exception($"Объект с именем {srcVbo} не существует") ;

            CopyVBObjects(srcVbo, copyVboName);
            var copeVbo  = FindVBObj(copyVboName);
            
            var reflMatrix = SceneCamera.GetReflectionMatrix(plane);//from stack
            //DisplayReflectionPlane(src, plane);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);//видовая и модельная матрица
            Gl.glPushMatrix();
            Gl.glLoadMatrixf(srcVbo.ModelMatrix);
            Gl.glMultMatrixf(reflMatrix);
            Gl.glGetFloatv(Gl.GL_MODELVIEW_MATRIX, copeVbo.ModelMatrix);
            Gl.glPopMatrix();
        }

/// <inheritdoc/>


        public void ChangeViewModeVBObjects(string objsName, ObjView objView)
        {
            var glObj = glObjs.Find(x => x.ObjName == objsName);
            if (glObj == null)
                MessageEvent?.Invoke(this, new MessageEventArgs("Не найдены объекты указанного типа!"));
            else
                glObj.ViewMode = objView;
        }
 
        /// <summary>
        /// ChangeSettingsVBObjects
        /// </summary>
        /// <param name="objsName"></param>
        /// <param name="pointsSize"></param>
        /// <param name="linesWith"></param>
        public void ChangeSettingsVBObjects(string objsName, float pointsSize, float linesWith)
        {
            var glObj = glObjs.Find(x => x.ObjName == objsName);
            if (glObj == null)
                MessageEvent?.Invoke(this, new MessageEventArgs("Не найдены объекты указанного типа!"));
            else
            {
                glObj.Gl_PointSize = pointsSize;
                glObj.Gl_LineWidth = linesWith;
            }
        }
/// <inheritdoc/>

        public void DisplayLocalFrame(Frame frame)
        {
            var met = new Action(() =>
            {
                if (IsBlending && !advanced3DClipper.IsEnable)
                    averageColorRenderer.DoActionsBeforeDrawing(null, DrawElements.GeometryObjects);
                Gl.glPushMatrix();
                Gl.glTranslatef(-camera.Position._x, -camera.Position._y, -camera.Position._z);

                Gl.glLineWidth(1.5f);
                Gl.glBegin(Gl.GL_LINES);

                // draw "Z"
                var axis_z = frame.Centre.Sum(frame.Dir_Z);
                
                Gl.glColor3f(0, 0, 1);
                Gl.glVertex3f(frame.Centre._x, frame.Centre._y, frame.Centre._z);
                Gl.glVertex3f(axis_z._x, axis_z._y, axis_z._z);


                // draw "Y"
                var axis_y = frame.Centre.Sum(frame.Dir_Y);
                Gl.glColor3f(0, 1, 0);
                Gl.glVertex3f(frame.Centre._x, frame.Centre._y, frame.Centre._z);
                Gl.glVertex3f(axis_y._x, axis_y._y, axis_y._z);


                // draw "X"
                var axis_x = frame.Centre.Sum(frame.Dir_X);
                Gl.glColor3f(1, 0.5f, 0);
                Gl.glVertex3f(frame.Centre._x, frame.Centre._y, frame.Centre._z);
                Gl.glVertex3f(axis_x._x, axis_x._y, axis_x._z);

                Gl.glEnd();
                Gl.glPopMatrix();
                if (IsBlending && !advanced3DClipper.IsEnable)
                    averageColorRenderer.DoActionsAfterDrawing(null, DrawElements.GeometryObjects);
            });

            DisplayGeometryObjectEvent += met;
        }
/// <inheritdoc/>

        public void DisplayDistance(Segment3D line)
        {
            var met = new Action(() =>
            {
                if (IsBlending && !advanced3DClipper.IsEnable)
                    averageColorRenderer.DoActionsBeforeDrawing(null, DrawElements.GeometryObjects);
                Gl.glPushMatrix();
                Gl.glTranslatef(-camera.Position._x, -camera.Position._y, -camera.Position._z);
                Gl.glColor3f(1, 0, 0);
                Gl.glLineWidth(5.0f);
                Gl.glBegin(Gl.GL_LINES);

                Gl.glVertex3f(line.P0._x, line.P0._y, line.P0._z);
                Gl.glVertex3f(line.P1._x, line.P1._y, line.P1._z);
                Gl.glEnd();
                Gl.glPopMatrix();

                var p0 = camera.GetSceenCoord(line.P0);
                var p1 = camera.GetSceenCoord(line.P1);

                var p0_2D = camera.GetScreenCoord(p0);
                var p1_2D = camera.GetScreenCoord(p1);
                if (IsBlending && !advanced3DClipper.IsEnable)
                    averageColorRenderer.DoActionsAfterDrawing(null, DrawElements.GeometryObjects);
            });

            DisplayGeometryObjectEvent += met;

            var coord = line.P0.Sum(line.P1).Div(2);

            DisplayText3D(line.GetLength().ToString(), Color.FromArgb(0, 0, 0), coord);
        }
/// <inheritdoc/>


        public void DisplayPath(Point3D[] points)
        {
            Action met;
            if (points.Length > 1)
            {
                if (IsBlending && !advanced3DClipper.IsEnable)
                    averageColorRenderer.DoActionsBeforeDrawing(null, DrawElements.GeometryObjects);
                var path = new ScenePath(points);
                var quantity = path.PointsQuantity;
                met = new Action(() =>
                {
                    if (IsBlending && !advanced3DClipper.IsEnable)
                        averageColorRenderer.DoActionsBeforeDrawing(null, DrawElements.GeometryObjects);
                    path.Display(camera.Position);
                    var p0 = path[quantity - 2];
                    var p1 = path[quantity - 1];
                    DisplayText3D(path.Length.ToString(), Color.FromArgb(0, 0, 0),
                    new Point3D((p0._x + p1._x) / 2, (p0._y + p1._y) / 2, (p0._z + p1._z) / 2));
                    if (IsBlending && !advanced3DClipper.IsEnable)
                        averageColorRenderer.DoActionsAfterDrawing(null, DrawElements.GeometryObjects);
                });

                DisplayGeometryObjectEvent += met;
            }
        }
/// <inheritdoc/>

        public void SwitchOnVBObject(string objsName)
        {
            var glObj = glObjs.Find(x => x.ObjName == objsName);

            if (glObj != null)
                glObj.ViewState = true;
        }
/// <inheritdoc/>

        public void SwitchOffVBObject(string objsName)
        {
            var glObj = glObjs.Find(x => x.ObjName == objsName);

            if (glObj != null)
                glObj.ViewState = false;
        } 
/// <inheritdoc/>

        public bool IsVBObjectShown(string objsName)
        {
            var glObj = glObjs.Find(x => x.ObjName == objsName);
            return glObj?.ViewState == true ? true : false;
        }
/// <inheritdoc/>

        public void DisplayLine(Point3D p0, Point3D p1, Color objColor)
        {
            Action met;

            met = new Action(() =>
            {
                if (IsBlending && !advanced3DClipper.IsEnable)
                    averageColorRenderer.DoActionsBeforeDrawing(null, DrawElements.GeometryObjects);
                Gl.glPushMatrix();
                Gl.glTranslatef(-camera.Position._x, -camera.Position._y, -camera.Position._z);
                Gl.glColor3ub(objColor.R, objColor.G, objColor.B);
                Gl.glLineWidth(5.0f);
                Gl.glBegin(Gl.GL_LINES);

                Gl.glVertex3f(p0._x, p0._y, p0._z);
                Gl.glVertex3f( p1._x, p1._y, p1._z);
                Gl.glEnd();
                Gl.glPopMatrix();
                if (IsBlending && !advanced3DClipper.IsEnable)
                    averageColorRenderer.DoActionsAfterDrawing(null, DrawElements.GeometryObjects);
            });

            DisplayGeometryObjectEvent += met;
        }
/// <inheritdoc/>

        public void DisplaySpiral(Point3D p0, Point3D p1, Color objColor)
        {
            Action met;

            met = new Action(() =>
            {
                if (IsBlending && !advanced3DClipper.IsEnable)
                    averageColorRenderer.DoActionsBeforeDrawing(null, DrawElements.GeometryObjects);
                Gl.glPushMatrix();
                Gl.glTranslatef(-camera.Position._x, -camera.Position._y, -camera.Position._z);
                Gl.glColor3ub(objColor.R, objColor.G, objColor.B);
                Gl.glLineWidth(5.0f);
                Gl.glBegin(Gl.GL_LINES);

                Gl.glVertex3f(p0._x, p0._y, p0._z);
                Gl.glVertex3f(p1._x, p1._y, p1._z);
                Gl.glEnd();
                Gl.glPopMatrix();
                if (IsBlending && !advanced3DClipper.IsEnable)
                    averageColorRenderer.DoActionsAfterDrawing(null, DrawElements.GeometryObjects);
            });

            DisplayGeometryObjectEvent += met;
        }
/// <inheritdoc/>


        public void DisplayConus(float UpperDiam, float BottomDiam, float length, Frame frame)
        {
            var upeer_rad = UpperDiam / 2;
            var lover_rad = BottomDiam / 2;

            DisplayGeometryObjectEvent += new Action(() =>
            {
                if (IsBlending && !advanced3DClipper.IsEnable)
                    averageColorRenderer.DoActionsBeforeDrawing(null, DrawElements.GeometryObjects);
                var quadObj = Glu.gluNewQuadric(); // создаем новый объект
                                                   // для создания сфер и цилиндров
                                                   //Glu.gluQuadricOrientation(quadObj, Glu.GLU_OUTSIDE);
                Gl.glPushMatrix();
                Gl.glColor3d(1, 0, 0);
                Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_LINE);

                Gl.glTranslatef(-camera.Position._x, -camera.Position._y, -camera.Position._z);

                //shifting
                Gl.glTranslatef(frame.Centre._x, frame.Centre._y, frame.Centre._z);

                //rotation z' and z global
                //var dirZ = frame.Z.Sub(frame.Centre);
                //var dirZnorm = Vector.GetVectorNorm(frame);
                var angleZ = Vector.GetCosAngleVectors(new Point3D(0, 0, 1), frame.Dir_Z);
                angleZ = (float)(Math.Acos(angleZ) * 180 / Math.PI);
                
                var axisZ = Vector.CrossProd(new Point3D(0, 0, 1), frame.Dir_Z);
                Gl.glRotatef(angleZ, axisZ._x, axisZ._y, axisZ._z);

                Gl.glTranslatef(0, 0, -length);

                Glu.gluCylinder(quadObj, lover_rad, upeer_rad, length, 10, 10); // рисуем конус

                Gl.glPopMatrix();
                Glu.gluDeleteQuadric(quadObj);
                averageColorRenderer.DoActionsAfterDrawing(null, DrawElements.GeometryObjects);
            });
        }
/// <inheritdoc/>

        public void DisplaySphere(float width, Frame frame)
        {
            Action met;

            met = new Action(() =>
            {
                if (IsBlending && !advanced3DClipper.IsEnable)
                    averageColorRenderer.DoActionsBeforeDrawing(null, DrawElements.GeometryObjects);
                var quadObj = Glu.gluNewQuadric(); // создаем новый объект
                                                   // для создания сфер и цилиндров
                                                   //Glu.gluQuadricOrientation(quadObj, Glu.GLU_OUTSIDE);
                Gl.glPushMatrix();
                Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_LINE);
                Gl.glColor3d(1, 0, 0);
                Gl.glTranslatef(-camera.Position._x, -camera.Position._y, -camera.Position._z);

                Gl.glTranslatef(frame.Centre._x, frame.Centre._y, frame.Centre._z);

                //var dirZ = frame.Z.Sub(frame.Centre);
                var axis = Vector.CrossProd(new Point3D(0, 0, 1), frame.Dir_Z);
                var angle = Vector.GetCosAngleVectors(new Point3D(0, 0, 1), frame.Dir_Z);
                angle = (float)(Math.Acos(angle) * 180 / Math.PI);

                Gl.glRotatef(angle, axis._x, axis._y, axis._z);
                //Glu.gluQuadricDrawStyle(quadObj, Glu.GLU_FILL); // устанавливаем
                Glu.gluSphere(quadObj, width / 2, 10, 10); // рисуем сферу
                                                                  // радиусом 0.5
                Gl.glPopMatrix();
                Glu.gluDeleteQuadric(quadObj);
                averageColorRenderer.DoActionsAfterDrawing(null, DrawElements.GeometryObjects);
            });

            DisplayGeometryObjectEvent += met;
        }
/// <inheritdoc/>

        public ISceneScale CreateScaleObject(float min, float max, decimal ranges, string title, string comments)
        {
            var sScale = new SceneScale(min, max, ranges, title, comments);
            sScale.FontBase = fontBase;
            return sScale;
        }
/// <inheritdoc/>

        public void DisplaySceneScale(ISceneScale scale)
        {
            Action del = new Action(() => { });

            del = new Action(() =>
            {
                scale.Display(camera.Width, camera.Height, CreateGraphics(), Font);
            });

            DisplayGeometryObjectEvent += del;
        }      
/// <inheritdoc/>

        public Point3D GetSceneCoordOfScreenVector(float x, float y)
        {
            return camera.GetSceneCoordOfScreenVector(x, y);
        }
/// <inheritdoc/>

        public void SetTransparency(string vboObjName, int alpha)
        {
            var vbo = FindVBObj(vboObjName);

            if (vbo != null)
            {
                var alphaf = alpha * 0.01f;
                var colors = vbo.PointsColors;
                for (var i = 3; i < colors.Length; i += 4)
                    colors[i] = alphaf;
                vbo.PointsColors = colors;
                if (vbo is SurfaceObjects sVbo && vbo.ViewMode == ObjView.LinesSurface)
                {
                    var frameColors = new float[sVbo.ColorLength];
                    VBO.GetSubData(sVbo.FrameBuffer, 0, frameColors.Length * sizeof(float), frameColors);
                    for (var i = 3; i < frameColors.Length; i += 4)
                        frameColors[i] = alphaf;
                    VBO.SetSubData(sVbo.FrameBuffer, 0, frameColors.Length * sizeof(float), frameColors);
                }
            }
        }
/// <inheritdoc/>

        public IEnumerable<IVBObject> GetVBObjs()
        {
            foreach (var item in glObjs)
            {
                yield return item;
            }
        }

        private void scene_MouseClick(object sender, MouseEventArgs e)
        {
            SceneMouseClickEvent?.Invoke(sender, e);
        }

        //public void CopyVBObjects(VBObject original, string copyName)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
