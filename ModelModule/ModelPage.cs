using BaseModule;
using Geometry;
using Model;
using Model.GeometryObjects;
using ModelControllerInterfaces.GmshController;
using ModelInterfaces;
using SceneInterface;
using System;
using System.Collections.Generic;
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
        }

        public override void UnBlockInterface(bool status)
        {
            foreach (var item in GetToolStripMenuItems().Where(x => x.Text == "Сетка"))
                        item.Enabled = status;
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
                Text = "Сетка",
                Enabled = false
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
                var res = MessageBox.Show("Вы собираетесь запустить сеточный генератор. При нажатии на кнопку \"OK\" Все данные о задаче будут удалены!",
                    "Внимание!", MessageBoxButtons.OKCancel);

                if(res == DialogResult.OK)
                {
                    Project.TaskData.Clear();
                    SceneControl.HideAllGeometryObjs();
                    SceneControl.HideDisplayText2D();
                    SceneControl.HideDisplayText3D();
                    PresentProjectOnTree();
                    LoadGMSHMeshControl();
                    SceneControl.DisplayObjects();
                }
            };

            return meshMenuItem;
        }

        private void LoadGMSHMeshControl()
        {
            //SceneControl.IsBlending = false;//Прозрачность пока больше мешает

            if (GmshController == null)
                MessageBox.Show("Контроллер генератора сетки не загружен!");

            else
            {
                var meshGenerator = new GMSHGeneralMeshControl();
                var gmshForm = new Form()
                {
                    TopMost = true,
                    ShowIcon = false,
                    ClientSize = meshGenerator.Size,
                    MaximizeBox = false,
                    FormBorderStyle = FormBorderStyle.FixedSingle,
                    Text = "Cеточный тетра генератор"
                };

                meshGenerator.showTransPoints += MeshGenerator_showTransPoints;
                meshGenerator.hideTransPoints += MeshGenerator_hideTransPoints;
                meshGenerator.updateObjectsDataEvent += UpdateMeshVBO;
                meshGenerator.updateGeometryVBOEvent += UpdateGeometryVBO;
                meshGenerator.updateTreeViewEvent += () => { PresentProjectOnTree(); };
                meshGenerator.redrawScene += RedrawScene;
                meshGenerator.showErrorMessage += ShowErrorMessage;
                meshGenerator.ShowObjectsEvent += ShowLines;
                meshGenerator.hide3dTextEvent += () =>
                {
                    SceneControl.HideDisplayText3D();
                    SceneControl.DisplayObjects();
                };
                meshGenerator.show3dTextEvent += GmshControl_show3dTextEvent;
                meshGenerator.showHeatMapEvent += GmshControl_showHeatMapEvent;
                meshGenerator.hideHeatMapEvent += GmshControl_hideHeatMapEvent;
                meshGenerator.ResetColorObjectsEvent += GmshControl_ResetColorObjectsEvent;
                gmshForm.Controls.Add(meshGenerator);
                meshGenerator.Dock = DockStyle.Fill;
                meshGenerator.ObjectData = Project.ModelData.ObjectData;
                meshGenerator.GmshController = GmshController;
                gmshForm.Show();
            }        
            //ModelPresenter.Clear();//Подчищаем Presenter во избежании артефактов
        }

        private void MeshGenerator_hideTransPoints()
        {
            SceneControl.DeleteVBObjects("transPoints");
            SceneControl.DisplayObjects();
        }

        private void MeshGenerator_showTransPoints()
        {
            var dic = GetCurvesNumbersAndNodes();

            var points = new List<GeometryPoint>();
            foreach (var item in dic.Keys)
            {
                points.AddRange(GetTransPointsCoords(item));
            }

            var presentor = PresentersCreator.CreatePointObjectsPresenter(points);

            SceneControl.DeleteVBObjects("transPoints");

            CreateObjectsToScene("transPoints", presentor);
            SceneControl.DisplayObjects();
        }

        private Dictionary<int, int> GetCurvesNumbersAndNodes()
        {
            var curveDict = new Dictionary<int, int>();
            //1)Добавляем в словарь сначала размеченные кривые
            string[] attribList;
            GmshController.ModelGetAttributeNames(out attribList);
            foreach (var item in attribList)
            {
                var tag = Int32.Parse(item.Split(' ')[1]);
                var attributes = GetCurrentCurveAttributes(tag);
                var points = attributes.Length == 3 ? Int32.Parse(attributes[0]) : 0;
                curveDict.Add(tag, points);
            }
            //2)Добавляем в словарь неразмеченные кривые, которых нет в словаре (со значением ноль)
            int[] dimTags;
            GmshController.ModelGetGeometryEntities(out dimTags, 1);
            for (var i = 1; i < dimTags.Length; i += 2)
                if (!curveDict.ContainsKey(dimTags[i]))
                    curveDict.Add(dimTags[i], 0);
            return curveDict;
        }

        private string[] GetCurrentCurveAttributes(int tag)
        {
            string[] attributes;
            GmshController.ModelGetAttribute($"transfinite {tag}", out attributes);
            return attributes;
        }

        private List<GeometryPoint> GetTransPointsCoords(int curveTag)
        {
            var ierr = 0;
            long[] nodeTags;
            double[] coords, parametrics;

            GmshController.ModelMeshGenerate(1, ref ierr);
            GmshController.ModelMeshGetNodes(1, curveTag, false, false, out nodeTags, out coords, out parametrics);

            var gPoints = new List<GeometryPoint>();
            var num = 0;
            for (int i = 0; i < coords.Length; i += 3)
            {
                var gPoint = new GeometryPoint(num++, new Point3D((float)coords[i], (float)coords[i + 1], (float)coords[i + 2]));
                gPoints.Add(gPoint);
            }
            return gPoints;
        }

        private void GmshControl_hideHeatMapEvent()
        {
            SceneControl.HideGeometryObj("DisplaySceneScale");

            foreach (var item in Project.ModelData.ObjectData.LineCollection)
                item.SetBackColor();

            var linePres = PresentersCreator.CreateLineObjectsPresenter(Project.ModelData.ObjectData.LineCollection);
            SceneControl.DeleteVBObjects(ObjType.Линия.ToString());
            CreateObjectsToScene(ObjType.Линия.ToString(), linePres);
            SceneControl.DisplayObjects();
        }

        private void GmshControl_showHeatMapEvent()
        {
            try
            {
                var curvesInfo = GetCurvesNumbersAndNodes();
                var max = curvesInfo.Max(x => x.Value);
                var min = curvesInfo.Min(x => x.Value);

                var scale = SceneControl.CreateScaleObject(min, max, 3, "", "");
                SceneControl.HideGeometryObj("DisplaySceneScale");
                SceneControl.DisplaySceneScale(scale);

                foreach (var item in curvesInfo)
                {
                    var color = scale.GetValueColor(item.Value);
                    Project.ModelData.ObjectData.LineCollection.Find(item.Key).MasterColor = color;
                }

                var linePres = PresentersCreator.CreateLineObjectsPresenter(Project.ModelData.ObjectData.LineCollection);
                SceneControl.DeleteVBObjects(ObjType.Линия.ToString());
                CreateObjectsToScene(ObjType.Линия.ToString(), linePres);
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

                CreateObjectsToScene(ObjType.Элемент2D.ToString(), CreateObjectsPresentor(ObjType.Элемент2D));

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

        private void UpdateMeshVBO()
        {
            var objs = GmshController.GetMeshObjects();

            if(objs.Item1.Count > 0)
                Project.ModelData.ObjectData.NodeCollection.AddRange(objs.Item1);
            if (objs.Item1.Count > 0)
                Project.ModelData.ObjectData.E1DCollection.AddRange(objs.Item2);
            if (objs.Item1.Count > 0)
                Project.ModelData.ObjectData.E2DCollection.AddRange(objs.Item3);
            if (objs.Item4.Count > 0)
                Project.ModelData.ObjectData.E3DCollection.AddRange(objs.Item4);

            PresentObjects(ObjType.Узел);
            PresentObjects(ObjType.Элемент1D);
            PresentObjects(ObjType.Элемент2D);
            PresentObjects(ObjType.Элемент3D);
        }

        private void UpdateGeometryVBO()
        {
            PresentObjects(ObjType.Точка);
            PresentObjects(ObjType.Линия);
        }

        private void PresentObjects(ObjType item)
        {
            var vbo = SceneControl.FindVBObj(item.ToString());

            if (vbo != null)
                SceneControl.DeleteVBObjects(item.ToString());

            var presentor = CreateObjectsPresentor(item);
            if (presentor.Count() > 0)
                CreateObjectsToScene(item.ToString(), presentor);
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