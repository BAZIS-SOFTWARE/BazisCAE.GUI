using Geometry;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Model.Interfaces;
using Model.IO;
using ModelController.ModelScenePresentator;
using Scene;
using System;
using System.Diagnostics;

namespace SceneTests
{
    public class SkipInitializeAttribute : Attribute
    {
    }

    [TestClass]
    public class NormalTests
    {
        private SceneControl sceneControl;

        [TestInitialize]
        public void Init() 
        {
            sceneControl = new SceneControl();
        }
        
        [DataTestMethod]
        [DataRow(0, new float[] { 0, -7.794f, 0, 0, -7.794f, 0, 0, -7.794f, 0, //1 грань       
                                  0, 2.598f, 7.348f, 0, 2.598f, 7.348f, 0, 2.598f, 7.348f, //2 грань
                                  6.364f, 2.598f, -3.674f, 6.364f, 2.598f, -3.674f, 6.364f, 2.598f, -3.674f,//3 грань
                                  -6.364f, 2.598f, -3.674f, -6.364f, 2.598f, -3.674f,-6.364f, 2.598f, -3.674f//4 грань
                                })]
        [DataRow(120, new float[] { -6.364f, -2.598f, 3.674f, 0, -2.598f, -7.348f, 6.364f, -2.598f, 3.674f, //1 грань       
                                  -6.364f, -2.598f, 3.674f,  6.364f, -2.598f, 3.674f, 0, 7.794f, 0, //2 грань
                                  6.364f, -2.598f, 3.674f, 0, -2.598f, -7.348f, 0, 7.794f, 0,//3 грань
                                  0, -2.598f, -7.348f, -6.364f, -2.598f, 3.674f, 0, 7.794f, 0//4 грань
                                })]
        public void Smooth3DElement(float angle, float[] expNormals)//Правильный тетраэдр
        {
            var a = new Point3D(-1.5f, 0, 0);
            var b = new Point3D(1.5f, 0, 0);
            var c = new Point3D(0, 0, -3 / 2f * (float)Math.Sqrt(3));
            var d = new Point3D(0, (float)Math.Sqrt(6), -(float)Math.Sqrt(3) / 2f);
            float[] glCoords, glNormals;
            GetGlAttributes(out glCoords, out glNormals, a, c, b, a, b, d, b, c, d, c, a, d);
            sceneControl.IsSmoothShadow = true;
            sceneControl.ShadowAngle = angle;
            var normals = sceneControl.SmoothShadow(glCoords, glNormals);
            for (var i = 0; i < normals.Length; i += 3)
            {
                a = new Point3D(normals[i], normals[i + 1], normals[i + 2]);
                b = new Point3D(expNormals[i], expNormals[i + 1], expNormals[i + 2]);
                var cos = Vector.GetCosAngleVectors(a, b);
                Assert.AreEqual(0, Math.Abs(1 - cos), 1e-1);
            }
        }

        [DataTestMethod]
        [DataRow(3500)]
        public void SmoothBigData(int timeout)
        {
            IModelLoader loader;
            loader = new LoadModelFromINPTextFile();
            loader.LoadEvent += (ar1, ar2) => { };
            var model = new ModelData();
            model.Load(@"..\..\..\Models\Korpus200K.inp");
            var presenter = new PresentersCreator();

            var pres = presenter.CreateSurfaceObjectsPresenter(model.ObjectData.E2DCollection.GetObjects());
            var inds = pres.CreateIndexes();
            var coords = pres.CreateVertexes(inds.Item2, "координаты");
            var normals = pres.CreateVertexes(inds.Item2, "нормаль");
            sceneControl.IsSmoothShadow = true;
            sceneControl.ShadowAngle = 60;
            var sw = new Stopwatch();
            sw.Start();
            sceneControl.SmoothShadow(coords, normals);
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.ElapsedMilliseconds}");
            Assert.IsTrue(sw.ElapsedMilliseconds <= timeout);
        }

        private void GetGlAttributes(out float[] glCoords, out float[] glNormals, params Point3D[] points)
        {
            glCoords = new float[points.Length * 3];
            glNormals = new float[points.Length * 3];
            var stride = 0;
            for (var i = 0; i < points.Length; ++i, stride = i * 3)
            {
                glCoords[stride] = points[i]._x;
                glCoords[stride + 1] = points[i]._y;
                glCoords[stride + 2] = points[i]._z;
                if ((i + 1) % 3 == 0)
                {
                    var normal = GetNormal(points[i - 2], points[i - 1], points[i]);
                    SetNormal(glNormals, stride - 6, normal);
                }
            }
        }

        private Point3D GetNormal(Point3D a, Point3D b, Point3D c)
        {
            var edgeA = b.Sub(a);
            var edgeB = c.Sub(a);
            return Vector.CrossProd(edgeA, edgeB);
        }

        private void SetNormal(float[] glNormals, int stride, Point3D normal)
        {
            for (var i = 0; i < 9; i += 3)
            {
                glNormals[stride + i] = normal._x;
                glNormals[stride + i + 1] = normal._y;
                glNormals[stride + i + 2] = normal._z;
            }
        }
    }
}
