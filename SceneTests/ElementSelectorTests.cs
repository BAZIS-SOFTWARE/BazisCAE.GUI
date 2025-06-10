using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scene;
using Scene.VBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Tao.OpenGl;
using Model.MeshObjects;
using Scene.Interfaces;
using GmshApi;
using Model.IO;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using Model;
using ModelController.ModelScenePresentator;
using System.Reflection;
using System.Xml.Linq;
using ModelController.MeshObjsUtility;
using ModelControllerInterfaces;
using System.Numerics;
using Model.Interfaces;


namespace SceneTests
{
    [TestClass]
    public class ElementSelectorTests
    {
        private SceneControl sceneControl;
        [TestInitialize]
        public void Init()
        {
            sceneControl = new SceneControl();
            sceneControl.Initialization();
        }

        [TestCleanup]
        public void CleanUp()
        {
            sceneControl.Dispose();
        }

        [DataTestMethod]
        [DataRow(new double[] { 0, 0, 0 }, 
                 new double[] { 0, 10, 0 }, 
                 new double[] { 10, -2, 0 }, 
                 new int[] { 1, 1 }, 
                 new double[] { 0.78, 0.12, 0.1})]
        [DataRow(new double[] { 0, 0, 0 },
                 new double[] { 0, 10, 0 },
                 new double[] { 10, -2, 0 },
                 new int[] { 0, 10 },
                 new double[] { 0.0, 1.0, 0.0 })]
        [DataRow(new double[] { 0, 0, 0 },
                 new double[] { 0, 10, 0 },
                 new double[] { 10, -2, 0 },
                 new int[] { 0, 4 },
                 new double[] { 0.6, 0.4, 0.0 })]
        [DataRow(new double[] { 0, 0, 0 },
                 new double[] { 0, 10, 0 },
                 new double[] { 10, -2, 0 },
                 new int[] { 4, 3 },
                 new double[] { 0.22, 0.38, 0.4 })]
        [DataRow(new double[] { 0, 0, 0 },
                 new double[] { 0, 10, 0 },
                 new double[] { 10, -2, 0 },
                 new int[] { 6, 7 },
                 new double[] { -0.42, 0.82, 0.6 })]
        [DataRow(new double[] { 0, 0, 0 },
                 new double[] { 0, 10, 0 },
                 new double[] { 10, -2, 0 },
                 new int[] { 5, 4 },
                 new double[] { 0.0 , 0.5, 0.5 })]
        public void TriangleTest(double[] a, double[] b, double[] c, int[] mouseCoords, double[] expected)
        {
            sceneControl.ElementSelector.MouseClick = new Point(mouseCoords[0], mouseCoords[1]);
            var result = sceneControl.ElementSelector.SolveBarycentric(a, b, c);

            Assert.AreEqual(expected[0], result[0], 1e-4);
            Assert.AreEqual(expected[1], result[1], 1e-4);
            Assert.AreEqual(expected[2], result[2], 1e-4);
        }

        [DataTestMethod]
        [DataRow("../../../Models/Cilindr.inp", "Элемент2D", false)]
        [DataRow("../../../Models/Cilindr.inp", "Элемент3D", true)]
        [DataRow("../../../Models/Cilindr.inp", "Элемент3D", false)]
        public void ModelDataTest(string filePath, string name, bool showInside)
        {
            var modelData = new ModelData();

            var obj = CreateObject(modelData, filePath, name, showInside);

            var rectangle = sceneControl.ClientRectangle;

            ISurfaceObject<ElementSurface, Node>[] modelArray;
            if(name.Contains("Элемент2D"))
                modelArray = modelData.ObjectData.E2DCollection.GetObjects()
                                                               .Select(v => (ISurfaceObject<ElementSurface, Node>)v).ToArray();
            else
                modelArray = modelData.ObjectData.E3DCollection.GetObjects()
                                                               .Select(v => (ISurfaceObject < ElementSurface, Node>)v).ToArray();

            var randomRange = new Random();

            for (var i = 0; i < 10; ++i)
            {
                var x = (int)(rectangle.Width * randomRange.Next(3, 7) / 10f);
                var y = (int)(rectangle.Height * randomRange.Next(5, 11) / 10f);

                sceneControl.ElementSelector.MouseClick = new Point(x, y);
                var modelDataIndex = sceneControl.ElementSelector.SelectElement(obj, sceneControl.SelectionColor);

                if (modelDataIndex != -1)
                {
                    var trOffsets = sceneControl.ElementSelector.TriangleOffsets;
                    var points = obj.PointsCoords;
                    var vecList = new List<Vector3>();

                    var start = trOffsets[0] * 9;
                    var end = trOffsets[1] * 9;

                    for (var j = start; j < end; j += 3)
                        vecList.Add(new Vector3(points[j], points[j + 1], points[j + 2]));

                    var actual = vecList.Distinct().ToArray();
                    var elemSurfaces = modelArray[modelDataIndex].GetSurfaces().Where(v => v.ViewState == true).ToArray();

                    var expected = elemSurfaces.SelectMany(v => v.GetVertexes())
                                               .Select(v => new Vector3(v.Position._x, v.Position._y, v.Position._z))
                                               .Distinct()
                                               .ToArray();

                    var hashA = new HashSet<Vector3>(actual);
                    var result = hashA.Intersect(expected).ToArray();

                    Assert.IsTrue(result.Length == expected.Length && result.Length == actual.Length);
                }
            }
        }

        private SurfaceObjects CreateObject(ModelData modelData, string path, string name, bool showInside)
        {
            modelData.Loader = new LoadModelFromINPTextFile();
            modelData.Loader.LoadEvent += (ar1, ar2) => { };
            modelData.Load(path);
            var creator = new PresentersCreator();

            ISurfaceObjsPresenter presenter;

            if (name.Contains("Элемент3D"))
            {
                var surfChanger = new ChangeInsideSurface();
                var objects = modelData.ObjectData.E3DCollection.GetObjects();
                if (showInside)
                    surfChanger.ShowInsideSurfaces(objects);
                else
                    surfChanger.HideInsideSurfaces(objects);

                presenter = creator.CreateSurfaceObjectsPresenter(modelData.ObjectData.E3DCollection.GetObjects());
            }
            else
                presenter = creator.CreateSurfaceObjectsPresenter(modelData.ObjectData.E2DCollection.GetObjects());

            var inds = presenter.CreateIndexes();
            var ptrs = presenter.CreatePointers(inds.Item1);
            var coords = presenter.CreateVertexes(inds.Item2, "координаты");
            var colors = presenter.CreateVertexes(inds.Item3, "цвет");
            var normals = presenter.CreateVertexes(inds.Item2, "нормаль");

            var edges = presenter.CreateEdgeFlags(inds.Item4);
            var separators = presenter.CreateSeparators();

            sceneControl.CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, name, separators, ObjView.Surface);
            var obj = sceneControl.FindVBObj(name) as SurfaceObjects;
            sceneControl.FitObjectsToScreen();
            return obj;
        }
    }
}
