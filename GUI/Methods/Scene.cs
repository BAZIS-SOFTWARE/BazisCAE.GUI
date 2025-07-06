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
using BaseModule.Extensions;

namespace BazisGUI
{
    public partial class BaseForm
    {
        VBOController VBOController = new VBOController();
        //List<VBObject> glObjs = new List<VBObject>();

        int fontBase;//Идентификатор первого сгенерированного Glyph(глифа)
        bool blending;
        bool lighting;

        public System.Drawing.Point ScreenMousePosition { get; private set; } = new System.Drawing.Point(0, 0);

        SceneCamera camera;
        SceneCompass compass;
        SceneBasis basis;
        ScreenRectangle selectionRectangle;
        ClipPlaneRenderer clipPlaneRenderer;
        Advanced3DClipper advanced3DClipper;
        AverageColorRenderer averageColorRenderer;

        private Color backGroundColor = Color.Green;
        public Color SelectionGroupColor { get; set; } = Color.Green;

        private float scaleFactor = 1.0f;
        bool displayRotatioPoint;
        bool displayCompass = true;
        bool displayClipPlane = false;

        public bool MouseMoveFlag { get; private set; }

        public ViewAxis RotationAxis { get; set; } = ViewAxis.XYZ;

        public float RotationAngle { get; set; } = 2.5f;

        public Color BackGroundColor
        {
            get { return backGroundColor; }
            set {
                backGroundColor = value;
                AverageColorRenderer.BackgroundColor = value;
            }
        }

        public bool ShowSurfaceBackEdges
        {
            get => AverageColorRenderer.ShowSurfaceBackEdges;
            set => AverageColorRenderer.ShowSurfaceBackEdges = value;
        }

        [DefaultValue(true)]
        public bool DisplayCompass
        {
            get { return displayCompass; }
            set { displayCompass = value; }
        }

        public Color SelectionColor { get; set; } = Color.Green;

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

        public float LightTranslateX { get; set; }

        public float LightTranslateY { get; set; }

        public float LightTranslateZ { get; set; }

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


        [DefaultValue(false)]
        public bool IsCutting { get; set; }


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


        [DefaultValue(false)]
        public bool IsSceneExpand { get; set; }

        public float ScaleFactor
        {
            get{ return scaleFactor; }
            set { scaleFactor = value; }
        }

        public float ShadowAngle { get ; set ; }

        public bool IsSmoothShadow { get ; set; }

        public int TransparencyValue { get; set; }

        public bool IsInsideObjectsShown { get; set; }

        public bool DisplayBasis { get; set; }

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
                    if (VBOController.GetVBObjs().Count() > 0)
                    {
                        var bbox = VBOController.GetVBObjs().OrderByDescending(v => v.BoundingBox.GetDiagonalLength())
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

        public void ClearAllGeometryDataOnScene()
        {
            VBOController.DeleteVBObjects(ObjType.Точка.ToString());
            VBOController.DeleteVBObjects(ObjType.Кривая.ToString());
            VBOController.DeleteVBObjects(ObjType.Поверхность.ToString());
            VBOController.DeleteVBObjects(ObjType.Объем.ToString());
        }

        public void ClearAllMeshDataOnScene()
        {
            VBOController.DeleteVBObjects(ObjType.Узел.ToString());
            VBOController.DeleteVBObjects(ObjType.Элемент1D.ToString());
            VBOController.DeleteVBObjects(ObjType.Элемент2D.ToString());
            VBOController.DeleteVBObjects(ObjType.Элемент3D.ToString());
        }      

        public List<IModelObject> SearchObjects(IEnumerable<IModelObject> objects, RectangleBox selectionBox, bool isSorted)
        {
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

       

        public void ClearAllDataOnScene()
        {
            DisplayGeometryObjectEvent = null;
            DisplayText2DEvent = null;
            DisplayText3DEvent = null;
            VBOController.DeleteAllVBObjects();
            clipPlaneRenderer?.DestroyBoundingBoxVBO();
        }

        internal void ColorObjects(IModelData modelData, string objTypeStr)
        {
            if (objTypeStr == "Объекты")
            {
                foreach (ObjType type in Enum.GetValues(typeof(ObjType)))
                    SetVBObjectAttribute(CreateObjectsPresentor(modelData, type), "цвет");
            }
            else if (objTypeStr == "Элементы")
            {
                SetVBObjectAttribute(CreateObjectsPresentor(modelData, ObjType.Элемент1D),  "цвет");
                SetVBObjectAttribute(CreateObjectsPresentor(modelData, ObjType.Элемент2D),  "цвет");
                SetVBObjectAttribute(CreateObjectsPresentor(modelData, ObjType.Элемент3D),  "цвет");
            }
            else if (objTypeStr == "Фигуры")
            {
                SetVBObjectAttribute(CreateObjectsPresentor(modelData, ObjType.Поверхность),  "цвет");
                SetVBObjectAttribute(CreateObjectsPresentor(modelData, ObjType.Объем),  "цвет");
            }
            else
            {
                var objType = Converters.ConvertToObjsType(objTypeStr);
                var presentor = CreateObjectsPresentor(modelData, objType);
                SetVBObjectAttribute(presentor, "цвет");
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

            //Gle.Load();
            //AverageColorRenderer.CreateAverageColorRenderer(scene.Width, scene.Height);
            averageColorRenderer = new AverageColorRenderer(Width, Height);
            clipPlaneRenderer = new ClipPlaneRenderer();
            advanced3DClipper = new Advanced3DClipper();
            Disposed += (s, e) =>
            {
                foreach (var obj in VBOController.GetVBObjs())
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

        public void ScaleObjs(float scaleFactor)
        {
            Gl.glScalef(scaleFactor, scaleFactor, scaleFactor);
            var crd = camera.GetSceneCoordOfScreenVector(0, 1);
            this.scaleFactor = (float)Math.Sqrt(Math.Pow(crd._x, 2) + Math.Pow(crd._y, 2) + Math.Pow(crd._z, 2));
        }
      
/// <inheritdoc/>

        

        
        /// <summary>
        /// Смена режима прозрачности для vbo-объектов
        /// </summary>
        /// <param name="isTransparent"></param>
        public void ChangeVBOTransparentMode(bool isTransparent)
        {
            if (advanced3DClipper.IsEnable)
                return;
            var drawObj = isTransparent ? averageColorRenderer : null;
            foreach(var globj in VBOController.GetVBObjs())
                globj.ActiveDrawingObject = drawObj;
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

        

        /// <summary>
        /// HideAllGeometryObjs
        /// </summary>
        public void HideAllGeometryObjs()
        {
            DisplayGeometryObjectEvent = null;
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

        public void DisplayReflectionPlane(string objName, float[] coeff)
        {
            var plane = new Plane(new Point3D(coeff[0], coeff[1], coeff[2]), coeff[3]);
            var original = VBOController.FindVBObj(objName);

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

            var copyVbo = VBOController.FindVBObj(copyVboName);
            if(copyVbo != null)
                throw new Exception($"Объект с именем {copyVbo} уже существует");

            var srcVbo = VBOController.FindVBObj(srcVboName) as VBObject;

            if (srcVbo == null)
                throw new Exception($"Объект с именем {srcVbo} не существует") ;

            VBOController.CopyVBObjects(srcVbo, copyVboName);
            var copeVbo  = VBOController.FindVBObj(copyVboName);
            
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

        public void DisplaySceneScale(ISceneScale scale)
        {
            Action del = new Action(() => { });

            del = new Action(() =>
            {
                scale.Display(camera.Width, camera.Height, CreateGraphics(), Font);
            });

            DisplayGeometryObjectEvent += del;
        }      



        //public void CopyVBObjects(VBObject original, string copyName)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
