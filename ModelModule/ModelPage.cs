using BaseModule;
using BaseModule.ToolStrips;
using ModelControllerInterfaces.GmshController;
using ModelInterfaces;
using ModelModule.ToolStrips;
using SceneInterface;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ModelModule
{
    public partial class ModelPage : BasePage
    {
        public IGmshController GmshController { get; set; }
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
            SceneControl.IsBlending = false;//Прозрачность пока больше мешает
            var gmshControl = new GmshControl();
            var gmshForm = new Form()
            {
                TopMost = true,
                ShowIcon = false,
                ClientSize = gmshControl.Size,
                MaximizeBox = false,
                FormBorderStyle = FormBorderStyle.FixedSingle
            };

            gmshControl.updateVBOEvent += UpdateVBO;
            gmshControl.updateTreeViewEvent += () => { PresentProjectOnTree(); };
            gmshControl.redrawScene += RedrawScene;
            gmshControl.showErrorMessage += ShowErrorMessage;
            gmshControl.ShowObjectsEvent += ShowLines;
            gmshControl.hide3dTextEvent += () => 
            { 
                SceneControl.HideDisplayText3D();
                SceneControl.DisplayObjects();
            };
            gmshControl.show3dTextEvent += GmshControl_show3dTextEvent;
            gmshControl.showHeatMapEvent += GmshControl_showHeatMapEvent;
            gmshControl.hideHeatMapEvent += GmshControl_hideHeatMapEvent;
            gmshControl.ResetColorObjectsEvent += GmshControl_ResetColorObjectsEvent;
            gmshForm.Controls.Add(gmshControl);
            gmshControl.Dock = DockStyle.Fill;
            gmshControl.ObjectData = Project.ModelData.ObjectData;
            gmshControl.GmshController = GmshController;
            gmshForm.Show();
            //ModelPresenter.Clear();//Подчищаем Presenter во избежании артефактов
        }

        private void GmshControl_hideHeatMapEvent()
        {
            SceneControl.HideGeometryObj("DisplaySceneScale");

            foreach (var item in Project.ModelData.ObjectData.LineCollection)
                item.SetBackColor();

            var linePres = PresentersCreator.CreateLineObjectsPresenter(Project.ModelData.ObjectData.LineCollection);
            SceneControl.DeleteVBObjects(ObjType.Линия.ToString());
            PresentObjectsToScene(ObjType.Линия.ToString(), linePres);
            SceneControl.DisplayObjects();
        }

        private void GmshControl_showHeatMapEvent(object arg1, ShowHeatMapEventArgs arg2)
        {
            try
            {
                var scale = SceneControl.CreateScaleObject(arg2.Min, arg2.Max, 3, "", "");
                SceneControl.HideGeometryObj("DisplaySceneScale");
                SceneControl.DisplaySceneScale(scale);
                foreach (var item in arg2)
                {
                    var color = scale.GetValueColor(item.Value);
                    Project.ModelData.ObjectData.LineCollection.Find(item.Key).MasterColor = color;
                }

                var linePres = PresentersCreator.CreateLineObjectsPresenter(Project.ModelData.ObjectData.LineCollection);
                SceneControl.DeleteVBObjects(ObjType.Линия.ToString());
                PresentObjectsToScene(ObjType.Линия.ToString(),linePres);
                SceneControl.DisplayObjects();
            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        /// <summary>
        /// Показать 3д текст (если строка пустая - то прячем текст)
        /// </summary>
        /// <param name="list"></param>
        private void GmshControl_show3dTextEvent(object sender,Show3dTextEventArgs args)
        {
            foreach (var item in args)
                SceneControl.DisplayText3D(item.Item1, Color.Black, item.Item2);
            SceneControl.DisplayObjects();
        }



        private void GmshControl_ResetColorObjectsEvent(ObjType objType, bool obj)
        {
            if (obj)
            {
                foreach (var item in Project.ModelData.ObjectData.GetObjects(objType))
                    item.SetBackColor();
                SetObjectsSceneColor(ObjType.Линия);
            }      
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
                SceneControl.DeleteVBObjects(ObjType.Элемент2D.ToString());

                var startNumber = Project.ModelData.ObjectData.GetLastNumber(ObjType.Элемент) + 1;
                var boundaryElements2D = ModelController.Extractor2DFrom3D.Create(startNumber, els3D.ToArray());

                Project.ModelData.ObjectData.E2DCollection.AddRange(boundaryElements2D);

                SceneControl.HideAllGeometryObjs();
                SceneControl.HideDisplayText2D();
                SceneControl.HideDisplayText3D();

                PresentObjectsToScene(ObjType.Элемент2D.ToString(), CreateObjectsPresentor(ObjType.Элемент2D));

                SceneControl.DisplayObjects();
                PresentProjectOnTree();

                ConsoleControl.PrintInfo("Созданы 2D элементы", Color.Black);
            }
            else
                ConsoleControl.PrintInfo("Модель не содержит объемных элементов!", Color.Red);

        }

        private void ShowLines(int objNumber)
        {
            try
            {
                Project.ModelData.ObjectData.LineCollection.Find(objNumber).MasterColor 
                    = SceneControl.SelectionColor;
                SetObjectsSceneColor(ObjType.Линия);
            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void UpdateVBO(ObjType objType)
        {
            var vbo = SceneControl.FindVBObj(objType.ToString());

            if(vbo != null)
                SceneControl.DeleteVBObjects(objType.ToString());

            var presentor = CreateObjectsPresentor(objType);
            if (presentor.Count() > 0)
                PresentObjectsToScene(objType.ToString(), presentor);               
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