using BaseModule;
using BaseModule.Navigator;
using BaseModule.ToolStrips;
using Model;
using Model.Elements;
using ModelInterfaces;
using ModelModule.ToolStrips;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

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
            gmshControl.updateSurfaceData += UpdateSurfaceData;
            gmshControl.redrawScene += RedrawScene;
            gmshControl.showErrorMessage += ShowErrorMessage;
            gmshControl.ShowObjectsEvent += ShowObjects;
            gmshForm.Controls.Add(gmshControl);
            gmshControl.Dock = DockStyle.Fill;
            gmshForm.Show();
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
            var els3D = Project.ModelData.ObjectData.FindMany<Element3D>();

            if (els3D.Count() != 0)
            {
                var startNumber = Project.ModelData.ObjectData.GetLastObjNumber() + 1;
                var boundaryElements2D = ModelController.Extractor2DFrom3D.Create(startNumber, els3D.ToArray());

                Project.ModelData.ObjectData.AddRange(boundaryElements2D);

                ModelPresenter.Remove("Элементы2D");
                var presenter = ModelPresenter.CreateSurfaceObjectsPresenter(boundaryElements2D);
                ModelPresenter.Add("Элементы2D", presenter);

                SceneControl.HideAllGeometryObjs();
                SceneControl.HideDisplayText2D();
                SceneControl.HideDisplayText3D();

                SceneControl.DeleteVBObjects("Элементы2D");
                PresentObjectsToScene("Элементы2D", presenter);

                SceneControl.DisplayObjects();

                PresentModelOnSelectToolStrip();

                NavigatorControl.TreeView.Nodes["объекты"].Nodes.RemoveByKey("Элементы2D");
                NavigatorControl.CreateChildNode("объекты", "Элементы2D", $"Элементы2D : {boundaryElements2D.Count()}", "4.1");
                NavigatorControl.ShowObjectsNode("Элементы2D");

                ConsoleControl.PrintInfo("Созданы 2D элементы", Color.Black);
            }
            else
                ConsoleControl.PrintInfo("Модель не содержит объемных элементов!", Color.Red);

        }

        private void ShowObjects(string objsType, int objNumber)
        {
            try
            {
                SetBackColorToAllObjects();

                foreach (var obj in Project.ModelData.ObjectData.FindMany(objsType))
                    if (obj.Number == objNumber)
                        obj.MasterColor = SceneControl.SelectionColor;///Кажется нужно, чтобы цвет брался из SettingControls?

                var vboObjs = SceneControl.FindVBObj(objsType);
                var colors = ModelPresenter[objsType].CreateVertexes(vboObjs.ColorLength, "цвет");
                vboObjs.PointsColors = colors;

                SceneControl.DisplayObjects();

            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private bool RemoveFromModelData(string objType, IEnumerable<IModelObject> objects)
        {
            var status = false;
            if (string.IsNullOrEmpty(objType))
            {
                Project.ModelData.ObjectData.Clear();
                ModelPresenter.Clear();
                status = true;
            }
            else if (objects == null)
            {
                Project.ModelData.ObjectData.RemoveRange(objType);
                ModelPresenter.Remove(objType);
                status = true;
            }
            return status;
        }

        private void UpdatePointData(string objType, IEnumerable<IModelObject> objects)
        {
            if (!RemoveFromModelData(objType, objects))
            {
                Project.ModelData.ObjectData.AddRange(objects);
                var presenter = ModelPresenter.CreatePointObjectsPresenter(objects);
                ModelPresenter.Add(objType, presenter);
            }
            PresentModelOnSelectToolStrip();
        }

        private void UpdateLineData(string objType, IEnumerable<ILineObject> objects)
        {
            if (!RemoveFromModelData(objType, objects))
            {
                Project.ModelData.ObjectData.AddRange(objects);
                var presenter = ModelPresenter.CreateLineObjectsPresenter(objects);
                ModelPresenter.Add(objType, presenter);
            }
            PresentModelOnSelectToolStrip();
        }

        private void UpdateSurfaceData(string objType, IEnumerable<ISurfaceElement> objects)
        {
            if (!RemoveFromModelData(objType, objects))
            {
                Project.ModelData.ObjectData.AddRange(objects);
                var presenter = ModelPresenter.CreateSurfaceObjectsPresenter(objects);
                ModelPresenter.Add(objType, presenter);
            }
            PresentModelOnSelectToolStrip();
        }

        private void ShowErrorMessage(string message) => ConsoleControl.PrintInfo(message, Color.Red);

        private void RedrawScene(bool fitOnScreen)
        {
            ClearAllDataOnScene();
            foreach (var item in ModelPresenter)
                PresentObjectsToScene(item.Key, item.Value);
            if (fitOnScreen)
                SceneControl.FitObjectsToScreen();
            SceneControl.DisplayObjects();
        }
    }
}