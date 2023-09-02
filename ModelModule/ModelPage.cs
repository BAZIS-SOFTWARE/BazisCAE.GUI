using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BaseModule;
using ToolStrips;
using Model;
using ModelController.MeshObjsCreator;
using System.Diagnostics;
using System.IO;
using ModelController.ModelScenePresentator;

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
            meshToolStrip.Renderer = new BtnToolStrRender();
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
                var meshFolder = Directory.GetFiles(Application.StartupPath, "Mesh.exe", SearchOption.AllDirectories);
                if (meshFolder.Length > 0)
                {
                    var myProcess = new Process();
                    myProcess.StartInfo.FileName = meshFolder[0];
                    myProcess.Start();
                };
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
                var mesher = Directory.GetFiles(Application.StartupPath, "mesh.exe", SearchOption.AllDirectories);

                if(mesher.Length > 0)
                {
                    var myProcess = new Process();
                    myProcess.StartInfo.FileName = mesher[0];
                    myProcess.Start();
                }

            }
        }

        private void CreateBoundaryElements2D()
        {
            var els3D = Project.Model.ObjectData.FindMany<Element3D>();

            if(els3D.Count() != 0)
            {
                var creator = new Extract2DFrom3D(els3D.ToArray());

                var startNumber = Project.Model.ObjectData.GetLastObjNumber() + 1;
                var boundaryElements2D = creator.Create(startNumber);

                Project.Model.ObjectData.AddRange(boundaryElements2D);

                ModelPresenter = new ModelScenePresentator(Project.Model);

                ClearAllDataOnScene();

                foreach (var item in ModelPresenter.Keys)
                    PresentDataToScene(item);

                SceneControl.DisplayObjects();

                PresentModelOnSelectToolStrip();
                SetModelObjsInfo();

                ConsoleControl.PrintInfo("Созданы 2D элементы", Color.Black);
            }
            else
                ConsoleControl.PrintInfo("Модель не содержит объемных элементов!", Color.Red);

        }           
    }
}
