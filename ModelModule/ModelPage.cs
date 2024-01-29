using BaseModule;
using BaseModule.Navigator;
using BaseModule.ToolStrips;
using Geometry;
using MathNet.Numerics.Distributions;
using Model;
using Model.MeshObjects;
using ModelControllerInterfaces;
using ModelInterfaces;
using ModelInterfaces.GeometryObjects;
using ModelInterfaces.MeshObjects;
using ModelModule.ToolStrips;
using SceneInterface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ModelModule
{
    public partial class ModelPage : BasePage
    {
        public ModelPage() : base()
        {
            InitializeComponent();

            var meshToolStrip = new MeshToolStrip();
            meshToolStrip.Renderer = new BaseToolStrRender();
            meshToolStrip.ItemClicked += MeshToolStrip_ItemClicked;

            AddToolStrip(meshToolStrip);
        }

        public override void CreateMenuInterface()
        {
            AddToolStripMenuItem(AddMeshInterface());
            base.CreateMenuInterface();
        }

        private ToolStripMenuItem AddMeshInterface()
        {
            ToolStripMenuItem meshMenuItem = new ToolStripMenuItem()
            {
                Name = "meshMenuItem",
                Text = "Сетка"
            };

            ToolStripMenuItem boundaryElements2DMenuItem = new ToolStripMenuItem()
            {
                Name = "boundaryElements2D",
                Text = "Создать поверхностные элементы"
            };

            ToolStripMenuItem meshGeneratorMenuItem = new ToolStripMenuItem()
            {
                Name = "meshGenerator",
                Text = "Генератор сетки"
            };

            meshMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            boundaryElements2DMenuItem,meshGeneratorMenuItem
            });

            boundaryElements2DMenuItem.Click += (ar1, ar2) => { CreateBoundaryElements2D(); };

            meshGeneratorMenuItem.Click += (ar1, ar2) =>
            {
                LoadMeshControl();
            };

            return meshMenuItem;
        }

        private void LoadMeshControl()
        {
            var gmshControl = new GmshControl();
            var gmshForm = new Form()
            {
                TopMost = true,
                ShowIcon = false,
                ClientSize = gmshControl.Size,
                MaximizeBox = false,
                FormBorderStyle = FormBorderStyle.FixedSingle
            };
            gmshControl.updatePointData += UpdatePointData;
            gmshControl.updateLineData += UpdateLineData;
            gmshControl.updateElement1Data += UpdateElement1Data;
            gmshControl.updateSurfaceData += UpdateSurfaceData;
            gmshControl.saveObjectData += (d) => Project.ModelData.SetObjectData(d);
            gmshControl.redrawScene += RedrawScene;
            gmshControl.showErrorMessage += ShowErrorMessage;
            gmshControl.ShowObjectsEvent += ShowObjects;
            gmshForm.Controls.Add(gmshControl);
            gmshControl.Dock = DockStyle.Fill;
            gmshControl.ObjectData = Project.ModelData.ObjectData;
            gmshForm.Show();
            //ModelPresenter.Clear();//Подчищаем Presenter во избежании артефактов
        }

        private void MeshToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Tag.ToString() == "0")
            {
                CreateBoundaryElements2D();
            }
            else if (e.ClickedItem.Tag.ToString() == "1")
            {
                LoadMeshControl();
            }
        }

        private void CreateBoundaryElements2D()
        {
            var els3D = Project.ModelData.ObjectData.E3DCollection;

            if (els3D.Count() != 0)
            {

                var startNumber = Project.ModelData.ObjectData.GetLastNumber(ObjType.Элемент) + 1;
                var boundaryElements2D = ModelController.Extractor2DFrom3D.Create(startNumber, els3D.ToArray());

                Project.ModelData.ObjectData.E2DCollection.AddRange(boundaryElements2D);
                //Project.ModelData.ObjectData.Remove

                SceneControl.HideAllGeometryObjs();
                SceneControl.HideDisplayText2D();
                SceneControl.HideDisplayText3D();


                PresentObjectsToScene(ObjType.Элемент2D.ToString(), CreateObjectsPresentor(ObjType.Элемент2D));

                SceneControl.DisplayObjects();

                PresentModelOnSelectToolStrip();

                PresentProjectOnTree();

                //NavigatorControl.TreeView.Nodes["объекты"].Nodes.RemoveByKey("Элементы2D");
                //NavigatorControl.CreateChildNode("объекты", "Элементы2D", $"Элементы2D : {boundaryElements2D.Count()}", "4.1");
                //NavigatorControl.ShowObjectsNode("Элементы2D");

                ConsoleControl.PrintInfo("Созданы 2D элементы", Color.Black);
            }
            else
                ConsoleControl.PrintInfo("Модель не содержит объемных элементов!", Color.Red);

        }

        private void ShowObjects(IEnumerable<ILineObject<IGeometryPoint>> data, IModelObject changedObj)
        {
            try
            {
                if (changedObj != null)
                    changedObj.MasterColor = SceneControl.SelectionColor;
                var objsType = ObjType.Линия.ToString();
                var vboObjs = SceneControl.FindVBObj(objsType);
                if (vboObjs != null)
                {
                    //SceneControl.DeleteVBObjects(objsType);

                    var presenter = PresentersCreator.CreateLineObjectsPresenter(data);
                    var colors = presenter.CreateVertexes(vboObjs.ColorLength, "цвет");
                    vboObjs.PointsColors = colors;
                    SceneControl.DisplayObjects();
                }
            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }


        private void UpdatePointData(ObjType objType, IEnumerable<IModelObject> objects)
        {
            var obj = objType.ToString();
            if (SceneControl.FindVBObj(obj) != null)
                SceneControl.DeleteVBObjects(obj);
            if (objects != null)
            {
                var presenter = PresentersCreator.CreatePointObjectsPresenter(objects);
                PresentObjectsToScene(obj, presenter);
            }
        }

        private void UpdateLineData(ObjType objType, IEnumerable<ILineObject<IGeometryPoint>> objects)
        {
            var obj = objType.ToString();
            if (SceneControl.FindVBObj(obj) != null)
                SceneControl.DeleteVBObjects(obj);
            if (objects != null)
            {
                var presenter = PresentersCreator.CreateLineObjectsPresenter(objects);
                PresentObjectsToScene(obj, presenter);
            }
            else
                SceneControl.DeleteAllVBObjects();
        }

        private void UpdateElement1Data(ObjType objType, IEnumerable<ILineObject<INode>> objects)
        {
            var obj = objType.ToString();
            if (SceneControl.FindVBObj(obj) != null)
                SceneControl.DeleteVBObjects(obj);
            if (objects != null)
            {
                var presenter = PresentersCreator.CreateLineObjectsPresenter(objects);
                PresentObjectsToScene(obj, presenter);
            }
        }

        private void UpdateSurfaceData(ObjType objType, IEnumerable<ISurfaceElement> objects)
        {
            var obj = objType.ToString();
            if (SceneControl.FindVBObj(obj) != null)
                SceneControl.DeleteVBObjects(obj);
            if (objects != null)
            {
                var presenter = PresentersCreator.CreateSurfaceObjectsPresenter(objects, objType == ObjType.Элемент3D);
                PresentObjectsToScene(obj, presenter);
            }
        }

        private void ShowErrorMessage(string message) => ConsoleControl.PrintInfo(message, Color.Red);

        private void RedrawScene(bool fitOnScreen)
        {
            if (fitOnScreen)
                SceneControl.FitObjectsToScreen();
            SceneControl.DisplayObjects();
        }
    }
}