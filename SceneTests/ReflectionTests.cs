using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.IO;
using Scene;
using Model;
using ModelController.ModelScenePresentator;
using MathNet.Numerics.LinearAlgebra;
using Geometry;
using System;
using Tao.OpenGl;
using Tao.Platform.Windows;
using MathNet.Numerics.Differentiation;
using Scene.VBO;
using System.Reflection;
using Scene.Interfaces;
using System.Threading;
using ModelControllerInterfaces;


namespace SceneTests
{
    [TestClass]
    public class ReflectionTests
    {
        private SceneControl sceneControl;
        [TestInitialize]
        public void Init()
        {
            sceneControl = new SceneControl();
            sceneControl.Initialization();
        }

        //Проверим только Surface объекты, остальные работают аналогично, идентификаторы VBO буфферов уникальны, но содержимое совпадает
        [DataTestMethod]
        [DataRow(@"..\..\..\Models\Cilindr.inp")]
        public void CopyTest(string path)
        {
            CreateModel(path);

            var surface =  sceneControl.FindVBObj("Элементы2D") as SurfaceObjects;
            sceneControl.CopyVBObjects(surface, "Элементы2DКопия");
            var surfaceCopy = sceneControl.FindVBObj("Элементы2DКопия") as SurfaceObjects;


            CollectionAssert.AreEqual(surface.PointsIndexes, surfaceCopy.PointsIndexes);
            CollectionAssert.AreEqual(surface.PointsCoords, surfaceCopy.PointsCoords);
            CollectionAssert.AreEqual(surface.PointsColors, surfaceCopy.PointsColors);
            CollectionAssert.AreEqual(surface.NormalsCoords, surfaceCopy.NormalsCoords);
            CollectionAssert.AreEqual(surface.EdgeFlags, surfaceCopy.EdgeFlags);
            CollectionAssert.AreEqual(surface.FrameColors, surfaceCopy.FrameColors);

            var cBuffer = (int)GetPropertyValue(surface, "CoordsBuffer");
            var cBufferCopy = (int)GetPropertyValue(surfaceCopy, "CoordsBuffer");

            var clrsBuffer = (int)GetPropertyValue(surface, "ColorsBuffer");
            var clrsBufferCopy = (int)GetPropertyValue(surfaceCopy, "ColorsBuffer");

            var nBuffer = (int)GetPropertyValue(surface, "NormalsBuffer");
            var nBufferCopy = (int)GetPropertyValue(surfaceCopy, "NormalsBuffer");

            var pBuffer = (int)GetPropertyValue(surface, "PointersBuffer");
            var pBufferCopy = (int)GetPropertyValue(surfaceCopy, "PointersBuffer");

            var fBuffer = (int)GetPropertyValue(surface, "FrameBuffer");
            var fBufferCopy = (int)GetPropertyValue(surfaceCopy, "FrameBuffer");

            var eBuffer = (int)GetPropertyValue(surface, "EdgeBuffer");
            var eBufferCopy = (int)GetPropertyValue(surfaceCopy, "EdgeBuffer");

            Assert.AreNotEqual(cBuffer, cBufferCopy);
            Assert.AreNotEqual(clrsBuffer, clrsBufferCopy);
            Assert.AreNotEqual(nBuffer, nBufferCopy);
            Assert.AreNotEqual(pBuffer, pBufferCopy);
            Assert.AreNotEqual(fBuffer, fBufferCopy);
            Assert.AreNotEqual(eBuffer, eBufferCopy);
        }

        [DataTestMethod]
        [DataRow(new float[] { -1, 0, 0, 0 }, @"..\..\..\Models\baffles.inp")]
        [DataRow(new float[] { 0.354f, 0, 0.935f, 12.5f }, @"..\..\..\Models\Cilindr.inp")]
        [DataRow(new float[] { 0.3f, 0.5f, 0.0f, 4.5f }, @"..\..\..\Models\Cilindr.inp")]
        [DataRow(new float[] { -0.85f, 0.21f, 0.0f, 3.75f }, @"..\..\..\Models\Korpus3D.inp")]
        public void ReflectionTest(float[] rPlane, string path)
        {
            CreateModel(path);
            var plane = UpdatePlane(rPlane);

            sceneControl.CreateReflectedVBObject("Элементы2D", "Копия", rPlane);
            var src = sceneControl.FindVBObj("Элементы2D");
            var coords = src.PointsCoords;
            var copy = sceneControl.FindVBObj("Копия");
            Assert.AreNotEqual(default, copy);

            var copyM = Matrix<float>.Build.Dense(4, 4, copy.ModelMatrix);
            var srcM = Matrix<float>.Build.Dense(4, 4, src.ModelMatrix);
            var symEquation = BuildSymmetryPlane(src.ModelMatrix, plane);
            for (var i = 0; i < coords.Length; i += 3)
            {
                var lPoint = Vector<float>.Build.Dense(new float[] { coords[i], coords[i + 1], coords[i + 2], 1 });
                var sPoint = srcM.Multiply(lPoint);
                var cPoint = copyM.Multiply(lPoint);
                var sDot = sPoint.DotProduct(symEquation);
                var cDot = cPoint.DotProduct(symEquation);
                Assert.AreEqual(sDot, cDot, 1E-4);
            }
        }

        [DataTestMethod]
        [DataRow(new float[] { 0.354f, 0, 0.935f, -5.5f }, new float[] {0.7f, -0.43f, 0.38f, 18.5f }, @"..\..\..\Models\Cilindr.inp")]
        public void ReflectionTestByMirroredModel(float[] rPlane, float[] rPlane2, string path)
        {
            CreateModel(path);
            
            sceneControl.CreateReflectedVBObject("Элементы2D", "Копия", rPlane);
            var src = sceneControl.FindVBObj("Копия");
            var coords = src.PointsCoords;
            Assert.AreNotEqual(default, src);

            sceneControl.CreateReflectedVBObject("Копия", "Копия2", rPlane2);
            var plane = UpdatePlane(rPlane2);
            var copy = sceneControl.FindVBObj("Копия2");
            Assert.AreNotEqual(default, copy);

            var copyM = Matrix<float>.Build.Dense(4, 4, copy.ModelMatrix);
            var srcM = Matrix<float>.Build.Dense(4, 4, src.ModelMatrix);
            var symEquation = BuildSymmetryPlane(src.ModelMatrix, plane);
            for (var i = 0; i < coords.Length; i += 3)
            {
                var lPoint = Vector<float>.Build.Dense(new float[] { coords[i], coords[i + 1], coords[i + 2], 1 });
                var sPoint = srcM.Multiply(lPoint);
                var cPoint = copyM.Multiply(lPoint);
                var sDot = sPoint.DotProduct(symEquation);
                var cDot = cPoint.DotProduct(symEquation);
                Assert.AreEqual(sDot, cDot, 1E-4);
            }
        }

        private static object GetPropertyValue(object src, string propName)
        {
            return src.GetType()
                      .GetProperty(propName, BindingFlags.Instance |
                            BindingFlags.NonPublic |
                            BindingFlags.Public)
                      .GetValue(src, null);
        }

        private Vector<float> BuildSymmetryPlane(float[] mat, Plane plane)
        {
            float[] m = new float[16];
            var scaleNormal = plane.Normal.Mult(plane.Shifting);
            Gl.glPushMatrix();
            Gl.glLoadMatrixf(mat);
            var z = new Point3D(0, 0, -1);
            var angleY = Vector.GetCosAngleVectors(z, plane.Normal);
            angleY = (float)(Math.Acos(angleY) * 180 / Math.PI);
            var axisY = Vector.CrossProd(z, plane.Normal);
            Gl.glRotatef(angleY, axisY._x, axisY._y, axisY._z);
            Gl.glGetFloatv(Gl.GL_MODELVIEW_MATRIX, m);
            Gl.glPopMatrix();
            var matrix = Matrix<float>.Build.Dense(4, 4, m);
            var normal = Vector<float>.Build.Dense(new float[] { 1, 0, 0, 0 });
            var origin = Vector<float>.Build.Dense(new float[] { scaleNormal._x, scaleNormal._y, scaleNormal._z, 1 });
            origin = matrix.Multiply(origin);
            origin[3] = 0;
            normal = matrix.Multiply(normal);
            var distance = -(origin.DotProduct(normal));
            normal[3] = distance;
            return normal;
        }

        private Plane UpdatePlane(float[] coefs)
        {
            var normal = new Point3D(coefs[0], coefs[1], coefs[2]);
            normal = Vector.GetVectorNorm(normal);
            var plane = new Plane(normal, coefs[3]);
            coefs[0] = normal._x;
            coefs[1] = normal._y;
            coefs[2] = normal._z;
            return plane;
        }

        private void CreateModel(string path, string modelType = "Элементы2D")
        {
            var model = new ModelData();
            model.Loader = new LoadModelFromINPTextFile();
            model.Loader.LoadEvent += (ar1, ar2) => { };
            model.Load(path);
            var creator = new PresentersCreator();
            var presenter = creator.CreatePointObjectsPresenter(model.ObjectData.NodesSet.Values);
            var inds = presenter.CreateIndexes();
            var ptrs = presenter.CreatePointers(inds.Item1);
            var coords = presenter.CreateVertexes(inds.Item2, "координаты");
            var colors = presenter.CreateVertexes(inds.Item3, "цвет");
            var normals = presenter.CreateVertexes(inds.Item2, "нормаль");
            var edges = presenter.CreateEdgeFlags(inds.Item4);
            
            //if (modelType == "Элементы2D")
            //    sceneControl.CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, modelType, ObjView.LinesSurface);
            //else if (modelType == "Элементы1D")
            //    sceneControl.CreateLineVBObjects(ptrs, coords, colors, normals, edges, modelType);
            //else
                sceneControl.CreatePointVBObjects(ptrs, coords, colors, normals, modelType);
        }
    }
}
