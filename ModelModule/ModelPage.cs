using BaseModule;
using BaseModule.Navigator;
using BaseModule.ToolStrips;
using Geometry;
using MathNet.Numerics.Distributions;
using Model;
using Model.GeometryObjects;
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
using static System.Net.Mime.MediaTypeNames;

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

            gmshControl.updateVBOEvent += UpdateVBO;
            //gmshControl.saveObjectData += (d) => Project.ModelData.SetObjectData(d);
            gmshControl.redrawScene += RedrawScene;
            gmshControl.showErrorMessage += ShowErrorMessage;
            gmshControl.ShowObjectsEvent += ShowLines;
            gmshControl.showOrHide3dText += ShowOrHide3dText;
            gmshControl.ResetColorObjectsEvent += GmshControl_ResetColorObjectsEvent;
            gmshForm.Controls.Add(gmshControl);
            gmshControl.Dock = DockStyle.Fill;
            gmshControl.ObjectData = Project.ModelData.ObjectData;
            gmshForm.Show();
            //ModelPresenter.Clear();//Подчищаем Presenter во избежании артефактов
        }
        /// <summary>
        /// Показать или спрятать 3д текст (если строка пустая - то прячем текст)
        /// </summary>
        /// <param name="list"></param>
        private void ShowOrHide3dText(List<Tuple<string, Point3D>> list)
        {
            if(list != null)
                foreach(var item in list)
                    SceneControl.DisplayText3D(item.Item1, Color.Black, item.Item2);
            else
                SceneControl.HideDisplayText3D();
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

                var startNumber = Project.ModelData.ObjectData.GetLastNumber(ObjType.Элемент) + 1;
                var boundaryElements2D = ModelController.Extractor2DFrom3D.Create(startNumber, els3D.ToArray());

                Project.ModelData.ObjectData.E2DCollection.AddRange(boundaryElements2D);

                SceneControl.HideAllGeometryObjs();
                SceneControl.HideDisplayText2D();
                SceneControl.HideDisplayText3D();


                PresentObjectsToScene(ObjType.Элемент2D.ToString(), CreateObjectsPresentor(ObjType.Элемент2D));

                SceneControl.DisplayObjects();

                PresentModelOnSelectToolStrip();

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