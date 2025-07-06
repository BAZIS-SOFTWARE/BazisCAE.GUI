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

        //public int TransparencyValue { get; set; }

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
            
            var reflMatrix = camera.GetReflectionMatrix(plane);//from stack
            //DisplayReflectionPlane(src, plane);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);//видовая и модельная матрица
            Gl.glPushMatrix();
            Gl.glLoadMatrixf(srcVbo.ModelMatrix);
            Gl.glMultMatrixf(reflMatrix);
            Gl.glGetFloatv(Gl.GL_MODELVIEW_MATRIX, copeVbo.ModelMatrix);
            Gl.glPopMatrix();
        }
 

/// <inheritdoc/>

           



        //public void CopyVBObjects(VBObject original, string copyName)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
