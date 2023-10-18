using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BaseModule;
using BaseModule.ToolStrips;
using ModelModule.ToolStrips;
using BaseModule.Navigator;
using Model;
using ModelControllerInterfaces;

namespace ModelModule
{
    public partial class ModelPage: BasePage
    {
        //Dictionary<string, int> imgDict;


        public ModelPage() : base()
        {
            InitializeComponent();

            //imgDict = new Dictionary<string, int>()
            //{
            //    { "Узлы",3},
            //    { "Элементы3D",4},
            //    { "Элементы2D",4},
            //    { "Элементы1D",4}
            //};

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

            boundaryElements2DMenuItem.Click += (ar1, ar2) => { CreateBoundaryElements2D();};
           
            meshGeneratorMenuItem.Click += (ar1, ar2) => {
                //var gmshControl = new GmshControl();
                //var gmshForm = new Form()
                //{
                //    TopMost = true,
                //    ShowIcon = false,
                //    ClientSize = gmshControl.Size,
                //    MaximizeBox = false,
                //    FormBorderStyle = FormBorderStyle.FixedSingle
                //};
                //gmshControl.updateModelData += UpdateModelData;
                //gmshControl.redrawScene += RedrawScene;
                //gmshControl.showErrorMessage += ShowErrorMessage;
                //gmshForm.Controls.Add(gmshControl);
                //gmshControl.Dock = DockStyle.Fill;
                //gmshForm.Show();
            };

            return meshMenuItem;
        }

        private void MeshToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Tag.ToString() == "0")
            {
                CreateBoundaryElements2D();
            }
            else if(e.ClickedItem.Tag.ToString() == "1")
            {
                //var gmshControl = new GmshControl();
                //var gmshForm = new Form()
                //{
                //    TopMost = true,
                //    ShowIcon = false,
                //    ClientSize = gmshControl.Size,
                //    MaximizeBox = false,
                //    FormBorderStyle = FormBorderStyle.FixedSingle
                //};
                //gmshControl.updateModelData += UpdateModelData;
                //gmshControl.redrawScene += RedrawScene;
                //gmshControl.showErrorMessage += ShowErrorMessage;
                //gmshForm.Controls.Add(gmshControl);
                //gmshControl.Dock = DockStyle.Fill;
                //gmshForm.Show();
            }
        }

        private void CreateBoundaryElements2D()
        {
            var els3D = Project.Model.ObjectData.FindMany<Element3D>();

            if(els3D.Count() != 0)
            {           
                var startNumber = Project.Model.ObjectData.GetLastObjNumber() + 1;
                var boundaryElements2D = ModelController.Extractor2DFrom3D.Create(startNumber,els3D.ToArray());

                Project.Model.ObjectData.AddRange(boundaryElements2D);
                
                ModelPresenter.Remove("Элементы2D");
                var presenter = ModelPresenter.CreateSurfaceObjectsPresenter(boundaryElements2D);
                ModelPresenter.Add("Элементы2D", presenter);

                SceneInterface.HideAllGeometryObjs();
                SceneInterface.HideDisplayText2D();
                SceneInterface.HideDisplayText3D();

                SceneInterface.DeleteVBObjects("Элементы2D");
                PresentObjectsToScene("Элементы2D", presenter);

                SceneInterface.DisplayObjects();

                PresentModelOnSelectToolStrip();

                NavigatorControl.TreeView.Nodes["объекты"].Nodes.RemoveByKey("Элементы2D");
                NavigatorControl.CreateChildNode("объекты", "Элементы2D", $"Элементы2D : {boundaryElements2D.Length}","4.1");
                
                ConsoleControl.PrintInfo("Созданы 2D элементы", Color.Black);
            }
            else
                ConsoleControl.PrintInfo("Модель не содержит объемных элементов!", Color.Red);

        }

        private void UpdateModelData(ModelData data)
        {
            Project.ClearAllData();
            Project.Model.ObjectData.AddRange(data.ObjectData);
            PresentModelOnSelectToolStrip();
        }
        
        private void ShowErrorMessage(string message) => ConsoleControl.PrintInfo(message, Color.Red);
        
        private void RedrawScene(bool fitOnScreen, string[] objType)
        {
            ClearAllDataOnScene();
            for(var i = 0; i < objType.Length; ++i)
                PresentObjectsToScene(objType[i], ModelPresenter[objType[i]]);
            if (fitOnScreen)
                SceneInterface.FitObjectsToScreen();
            SceneInterface.DisplayObjects();
        }
    }
}
