using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.IO;
using Model;
using ModelController.ModelScenePresentator;
using Scene;
using Scene.Interfaces;
using System.Collections.Generic;
using Tao.OpenGl;
using Scene.VBO;
using System.Reflection;
using System;
using ModelControllerInterfaces;

namespace SceneTests
{
    [TestClass]
    public class VBObjTests
    {
        [TestMethod]
        public void ShowVBObj()
        {
            var sc = new SceneControl();
            var ptrs = new int[0];
            var coords = new float[0];
            var colors = new float[0];
            var normals = new float[0];
            var edges = new bool[0];
            var sep = new int[0];


            TestQuad(out ptrs, out coords, out colors, out normals, out edges);
            sc.CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, "Quad", sep,ObjView.Lines);
            //sc.CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, "Quad1");
            //sc.SwitchOnVBObject("Quad");
            //sc.SwitchOnVBObject("Quad1");

            Assert.AreEqual(sc.IsVBObjectShown("Quad"), true);
            Assert.AreEqual(sc.IsVBObjectShown("Quad1"), false);
        }
        [TestMethod]
        public void ShowAllVBObjs()
        {
            var sc = new SceneControl();
            var ptrs = new int[0];
            var coords = new float[0];
            var colors = new float[0];
            var normals = new float[0];
            var edges = new bool[0];
            var sep = new int[0];


            TestQuad(out ptrs, out coords, out colors, out normals, out edges);
            sc.CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, "Quad", sep,ObjView.Lines);
            sc.CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, "Quad1", sep,ObjView.Lines);
            sc.ShowAllVBObjects();

            Assert.AreEqual(sc.IsVBObjectShown("Quad"), true);
            Assert.AreEqual(sc.IsVBObjectShown("Quad1"), true);
        }

        [TestMethod, Timeout(5000)]
        public void EmptyVBObj()
        {
            var sc = new SceneControl();
            sc.Initialization();
            var ptrs = new int[0];
            var coords = new float[0];
            var colors = new float[0];
            var normals = new float[0];
            var edges = new bool[0];

            sc.CreatePointVBObjects(ptrs, coords, colors, normals, "EmptyPoints");

            sc.FitObjectsToScreen();
        }

        [TestMethod]
        public void FindGeometryObjs()
        {
            var sc = new SceneControl();

            sc.DisplayDistance(new Geometry.Segment3D(new Geometry.Point3D(), new Geometry.Point3D()));

            Assert.AreEqual(sc.FindGeometryObj("DisplayDistance"), true);
            Assert.AreEqual(sc.IsVBObjectShown("CreateLocalFrame"), false);
        }

        [TestMethod]
        public void HideAllVBObjs()
        {
            var sc = new SceneControl();
            var ptrs = new int[0];
            var coords = new float[0];
            var colors = new float[0];
            var normals = new float[0];
            var edges = new bool[0];
            var sep = new int[0];


            TestQuad(out ptrs, out coords, out colors, out normals, out edges);
            sc.CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, "Quad", sep,ObjView.Lines);
            sc.CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, "Quad1", sep,ObjView.Lines);
            sc.HideAllVBObjects();

            Assert.AreEqual(sc.IsVBObjectShown("Quad"), false);
            Assert.AreEqual(sc.IsVBObjectShown("Quad1"), false);
        }

        [TestMethod]
        public void HideVBObj()
        {
            var sc = new SceneControl();
            var ptrs = new int[0];
            var coords = new float[0];
            var colors = new float[0];
            var normals = new float[0];
            var edges = new bool[0];
            var sep = new int[0];

            TestQuad(out ptrs, out coords, out colors, out normals, out edges);
            sc.CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, "Quad", sep,ObjView.Lines);
            sc.CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, "Quad1", sep,ObjView.Lines);

            sc.SwitchOffVBObject("Quad");

            Assert.AreEqual(sc.IsVBObjectShown("Quad"), false);
            Assert.AreEqual(sc.IsVBObjectShown("Quad1"), true);
        }

        [TestMethod]
        public void HideAfterShowSeveralTimesVBObj()
        {
            var sc = new SceneControl();
            var ptrs = new int[0];
            var coords = new float[0];
            var colors = new float[0];
            var normals = new float[0];
            var edges = new bool[0];
            var sep = new int[0];

            TestQuad(out ptrs, out coords, out colors, out normals, out edges);
            sc.CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, "Quad", sep,ObjView.Lines);

            sc.SwitchOffVBObject("Quad");

            Assert.AreEqual(sc.IsVBObjectShown("Quad"), false);
        }

        [TestMethod]
        [DataRow(@"..\..\..\Models\Cilindr.inp")]
        public void DeleteBuffersTest(string path)
        {
            var sc = new SceneControl();
            CreateModel(path, sc);
            while (Gl.glGetError() != Gl.GL_NO_ERROR);//Очистка логов об ошибке
            var point = sc.FindVBObj("Узлы") as VBObject;
            var line = sc.FindVBObj("Элементы1D") as VBObject;
            var surface = sc.FindVBObj("Элементы2D") as VBObject;
            var pBuf = FillBuffers(point);
            var lBuf = FillBuffers(line);
            var sBuf = FillBuffers(surface, true);
            CheckBuffers(pBuf, Gl.GL_NO_ERROR);
            CheckBuffers(lBuf, Gl.GL_NO_ERROR);
            CheckBuffers(sBuf, Gl.GL_NO_ERROR);
            VBO.DeleteAllBuffers(point);
            VBO.DeleteAllBuffers(line);
            VBO.DeleteAllBuffers(surface);
            CheckBuffers(pBuf, Gl.GL_INVALID_VALUE);
            CheckBuffers(lBuf, Gl.GL_INVALID_VALUE);
            CheckBuffers(sBuf, Gl.GL_INVALID_VALUE);
        }

        private List<Tuple<int,int>> FillBuffers(VBObject vbo, bool isSurfaceObj = false)
        {

            var buffers = new List<Tuple<int, int>>();
            var propList = new List<Tuple<string, int>>() { Tuple.Create("PointersBuffer", vbo.PtrLength),
                                                            Tuple.Create("CoordsBuffer", vbo.CoordLength), 
                                                            Tuple.Create("ColorsBuffer", vbo.ColorLength), 
                                                            Tuple.Create("NormalsBuffer", vbo.NormalLength) };
            for (var i = 0; i < propList.Count; ++i)
            {
                var bufId = GetPropertyValue(vbo, propList[i].Item1);
                buffers.Add(Tuple.Create(bufId, propList[i].Item2));
            }
            if(isSurfaceObj)
            {
                var surfVbo = vbo as SurfaceObjects;
                var surfPropList = new List<Tuple<string, int>>() { Tuple.Create("FrameBuffer", surfVbo.FrameLength),
                                                                    Tuple.Create("EdgeBuffer", surfVbo.EdgesLength)};
                for (var i = 0; i < surfPropList.Count; ++i)
                {
                    var bufId = GetPropertyValue(vbo, surfPropList[i].Item1);
                    buffers.Add(Tuple.Create(bufId, surfPropList[i].Item2));
                }
            }
            return buffers;
        }

        private void CheckBuffers(List<Tuple<int, int>> buffers, int expectedValue)
        {
            for (var i = 0; i < buffers.Count; ++i)
            {
                if (i == 0)
                {
                    var indices = new int[buffers[i].Item2];
                    VBO.GetSubData(buffers[i].Item1, 0, buffers[i].Item2 * sizeof(int), indices);
                }
                else
                {
                    if (i > 4)
                    {
                        var vertices = new bool[buffers[i].Item2];
                        VBO.GetSubData(buffers[i].Item1, 0, buffers[i].Item2 * sizeof(bool), vertices);
                    }
                    else
                    {
                        var vertices = new float[buffers[i].Item2];
                        VBO.GetSubData(buffers[i].Item1, 0, buffers[i].Item2 * sizeof(float), vertices);
                    }
                }
                var error = Gl.glGetError();
                Assert.AreEqual(expectedValue, error);
            }
        }


        private static int GetPropertyValue(object src, string propName)
        {
            return (int)src.GetType()
                      .GetProperty(propName, BindingFlags.Instance |
                            BindingFlags.NonPublic |
                            BindingFlags.Public)
                      .GetValue(src, null);
        }

        private void CreateModel(string path, SceneControl sceneControl)
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
            sceneControl.CreatePointVBObjects(ptrs, coords, colors, normals, "Узлы");

            presenter = creator.CreateLineObjectsPresenter(model.ObjectData.E1DCollection.GetObjects());
            inds = presenter.CreateIndexes();
            ptrs = presenter.CreatePointers(inds.Item1);
            coords = presenter.CreateVertexes(inds.Item2, "координаты");
            colors = presenter.CreateVertexes(inds.Item3, "цвет");
            normals = presenter.CreateVertexes(inds.Item2, "нормаль");
            edges = presenter.CreateEdgeFlags(inds.Item4);
            sceneControl.CreateLineVBObjects(ptrs, coords, colors, normals, edges, "Элементы1D");

            var surPres = creator.CreateSurfaceObjectsPresenter(model.ObjectData.E2DCollection.GetObjects());
            inds = surPres.CreateIndexes();
            ptrs = surPres.CreatePointers(inds.Item1);
            coords = surPres.CreateVertexes(inds.Item2, "координаты");
            colors = surPres.CreateVertexes(inds.Item3, "цвет");
            normals = surPres.CreateVertexes(inds.Item2, "нормаль");
            edges = surPres.CreateEdgeFlags(inds.Item4);
            var sep = surPres.CreateSeparators();

            sceneControl.CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, "Элементы2D", sep,ObjView.LinesSurface);
        }

        private void TestTwoComparePoints(out int[] ptrs, out float[] coords, out float[] colors, out float[] normals, out bool[] edges)
        {
            ptrs = new int[] { 0, 1, 2 };
            coords = new float[]
            {
                10,10,0,
                10,10,0,
                0,10,0
            };

            colors = new float[]
            {
                1,0,0,0.25f,
                1,0,0,0.25f,
                1,0,0,0.25f,
            };

            normals = new float[]
            {
                1,0,1,
                1,0,1,
                1,0,1,
            };

            edges = new bool[]
            {
                true,
                true,
                true,
            };
        }

        private void TestTriangle(out int[] ptrs, out float[] coords, out float[] colors, out float[] normals, out bool[] edges)
        {
            ptrs = new int[] { 0, 1, 2};
            coords = new float[]
            {
                0,0,0,
                10,0,0,
                10,10,0,
            };

            colors = new float[]
            {
                1,0,0,0.25f,
                1,0,0,0.25f,
                1,0,0,0.25f
            };

            normals = new float[]
            {
                1,0,1,
                1,0,1,
                1,0,1
            };

            edges = new bool[]
            {
                true,
                true,
                true
            };
        }

        private void TestTriangles(out int[] ptrs, out float[] coords, out float[] colors, out float[] normals, out bool[] edges)
        {
            ptrs = new int[] { 0, 1, 2, 3, 4, 5 };
            coords = new float[]
            {
                0,0,0,
                10,0,0,
                10,10,0,
                0,0,0,
                10,10,0,
                0,10,0
            };

            colors = new float[]
            {
                1,0,0,0.25f,
                1,0,0,0.25f,
                1,0,0,0.25f,
                1,0,0,0.25f,
                1,0,0,0.25f,
                1,0,0,0.25f
            };

            normals = new float[]
            {
                1,0,1,
                1,0,1,
                1,0,1,
                1,0,1,
                1,0,1,
                1,0,1
            };

            edges = new bool[]
            {
                true,
                true,
                true,
                true,
                true,
                true
            };
        }

        private void TestQuad(out int[] ptrs, out float[] coords, out float[] colors, out float[] normals, out bool[] edges)
        {
            ptrs = new int[] { 0, 1, 2, 3, 4, 5 };
            coords = new float[]
            {
                0,0,0,
                10,0,0,
                10,10,0,
                0,0,0,
                10,10,0,
                0,10,0
            };

            colors = new float[]
            {
                1,0,0,0.25f,
                1,0,0,0.25f,
                1,0,0,0.25f,
                1,0,0,0.25f,
                1,0,0,0.25f,
                1,0,0,0.25f
            };

            normals = new float[]
            {
                1,0,1,
                1,0,1,
                1,0,1,
                1,0,1,
                1,0,1,
                1,0,1
            };

            edges = new bool[]
            {
                true,
                true,
                false,
                false,
                true,
                true
            };
        }
    }
}