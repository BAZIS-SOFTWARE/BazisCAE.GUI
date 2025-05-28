using Scene.Interfaces;
using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using ModelController.ModelScenePresentator;
using ModelController.ModelScenePresentator.GlObjsPresenters;
using Model;
using ModelControllerInterfaces;
using Model.Interfaces;
using Model.IO;
using Model.MeshObjects;
using System.Reflection;
using Scene.VBO;
using Model.IO.STL;
using BaseModule.SceenControls;
using Geometry;
using Scene;
using System.Xml.Linq;
//using ModelControllerInterface;

namespace Viewer
{
    public partial class ViewerForm : Form
    {
        private ModelData model = new ModelData();

        public ViewerForm()
        {
            InitializeComponent();
            sceneControl.Initialization();
            sceneControl.DisplayObjects();

            var ver = Assembly.GetExecutingAssembly().GetName().Version;
            Text+= $" {ver.Major}.{ver.Minor}.{ver.Build}";
        }       

        private void CreateVBOObjects(IObjsPresenter presenter, ObjView view, ObjType objType)
        {
            var inds = presenter.CreateIndexes();
            var ptrs = presenter.CreatePointers(inds.Item1);
            var coords = presenter.CreateVertexes(inds.Item2, "координаты");
            var colors = presenter.CreateVertexes(inds.Item3, "цвет");
            var normals = presenter.CreateVertexes(inds.Item2, "нормаль");

            var name = objType.ToString();
            //В VBOObject создаем метод CreateLayout - виртуальный, он сохраняет разметку в отдельный VBO
            //Для 3д элементов дополнительно просчитывает BoundingBox элементов
            if (presenter.PresenterType == PresenterType.Point)
                sceneControl.CreatePointVBObjects(ptrs, coords, colors, normals, name);
            else if (presenter.PresenterType == PresenterType.Line)
            {
                var edges = presenter.CreateEdgeFlags(inds.Item4);
                sceneControl.CreateLineVBObjects(ptrs, coords, colors, normals, edges, name);
            }
            else if(presenter.PresenterType == PresenterType.Surface)
            {
                var surfPres = (ISurfaceObjsPresenter)presenter;
                var edges = presenter.CreateEdgeFlags(inds.Item4);

                var separs = surfPres.CreateSeparators();
                sceneControl.CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, name, separs,view);
            }
        }

        private ObjView ExtractObjView(PresentersCreator creator)
        {
            ObjView view = ObjView.Surface;
            if (radioButton3.Checked)
            {
                //creator.SetView(ObjType.Элемент2D.ToString(), PresenterView.LineSurface);
                view = ObjView.LinesSurface;
            }
            else if (radioButton1.Checked)
            {
                //creator.SetView(ObjType.Элемент2D.ToString(),PresenterView.Line);
                view = ObjView.Lines;
            }
            return view;
        }

        private void Create3DVBOObject(PresentersCreator creator)
        {
            if (model.ObjectData.E3DCollection.Count > 0)
            {
                var view = ExtractObjView(creator);
                var e3d = creator.CreateSurfaceObjectsPresenter(model.ObjectData.E3DCollection.GetObjects());

                if (checkBox8.Checked)
                    e3d.ShowInsideSurfaces();
                else
                    e3d.HideInsideSurfaces();

                CreateVBOObjects(e3d, view, ObjType.Элемент3D);
            }
        }

        private void CreateVBOObjects()
        {
            var creator = new PresentersCreator();
            if (model.ObjectData.NodesSet.Values.Count > 0)
            {
                var nodes = creator.CreatePointObjectsPresenter(model.ObjectData.NodesSet.Values);
                CreateVBOObjects(nodes, ObjView.None, ObjType.Узел);
            }
            if(model.ObjectData.PointsSet.Values.Count > 0)
            {
                var points = creator.CreatePointObjectsPresenter(model.ObjectData.PointsSet.Values);
                CreateVBOObjects(points, ObjView.None, ObjType.Точка);
            }
            if (model.ObjectData.CurveCollection.Count > 0)
            {
                var curves = creator.CreateLineObjectsPresenter(model.ObjectData.CurveCollection.GetObjects());
                CreateVBOObjects(curves, ObjView.None, ObjType.Кривая);
            }
            if(model.ObjectData.E1DCollection.Count > 0)
            {
                var e1d = creator.CreateLineObjectsPresenter(model.ObjectData.E1DCollection.GetObjects());
                CreateVBOObjects(e1d, ObjView.None, ObjType.Элемент1D);
            }
            if(model.ObjectData.E2DCollection.Count > 0)
            {
                var view = ExtractObjView(creator);
                var e2d = creator.CreateSurfaceObjectsPresenter(model.ObjectData.E2DCollection.GetObjects());
                CreateVBOObjects(e2d, view, ObjType.Элемент2D);
            }
            if (model.ObjectData.E3DCollection.Count > 0)
            {
                var view = ExtractObjView(creator);
                var e3d = creator.CreateSurfaceObjectsPresenter(model.ObjectData.E3DCollection.GetObjects());

                if (checkBox8.Checked)
                    e3d.ShowInsideSurfaces();
                else
                    e3d.HideInsideSurfaces();

                CreateVBOObjects(e3d, view, ObjType.Элемент3D);
                //Create3DVBOObject(creator);
            }
            if (model.ObjectData.SurfaceCollection.Count > 0)
            {
                var view = ExtractObjView(creator);
                var f2d = creator.CreateSurfaceObjectsPresenter(model.ObjectData.SurfaceCollection.GetObjects());
                CreateVBOObjects(f2d, view, ObjType.Поверхность);
            }
            if (model.ObjectData.VolumeCollection.Count > 0)
            {
                var view = ExtractObjView(creator);
                var f3d = creator.CreateSurfaceObjectsPresenter(model.ObjectData.VolumeCollection.GetObjects());
                CreateVBOObjects(f3d, view, ObjType.Объем);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            sceneControl.DeleteAllVBObjects();
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;
            var ext = Path.GetExtension(dialog.FileName);
            if (ext == ".stl")
                model.Loader = new LoadFromSTLFile();
            else if (ext == ".ASC")
                model.Loader = new LoadModelFromASCIITextFile_v2();
            else if (ext == ".cdb")
                model.Loader = new LoadModelFromCDBTextFile();
            else if(ext == ".inp")
                model.Loader = new LoadModelFromINPTextFile();
            else if (ext == ".bpf")
                model.Loader = new LoadModelFromBPFTextFile();
            model.Loader.LoadEvent += (ar1, ar2) => { };
            model.Load(dialog.FileName);
            CreateVBOObjects();
            /*var obj = sceneControl.FindVBObj("Элементы2D") as VBObject;
            sceneControl.CreateReflectedVBObjects(obj, new Plane(new Point3D(0.707f, 0.707f, 0), 20), "Копия3");
            var obj1 = sceneControl.FindVBObj("Копия3") as VBObject;
            sceneControl.DisplayReflectionPlane(obj, new Plane(new Point3D(0.707f, 0.707f, 0), 20));
            sceneControl.CreateReflectedVBObjects(obj1, new Plane(new Point3D(1, 0, 0), 20), "Копия4");
            var obj2 = sceneControl.FindVBObj("Копия4") as VBObject;
            sceneControl.DisplayReflectionPlane(obj1 , new Plane(new Point3D(1, 0, 0), 20));*/
            sceneControl.FitObjectsToScreen();
            sceneControl.DisplayObjects();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnShowElements(object sender, EventArgs e)
        {
            var control = sender as CheckBox;
            var objName = control.Tag.ToString();
            var obj = sceneControl.FindVBObj(objName);
            if (obj != null)
                obj.ViewState = control.Checked;
            sceneControl.DisplayObjects();
        }

        private void OnViewModeChange(object sender, EventArgs e)
        {
            var control = sender as RadioButton;
            if (control.Checked)
            {
                var type = ObjView.None;
                var tag = control.Tag.ToString();
                if (tag == "1")
                    type = ObjView.Lines;
                else if (tag == "2")
                    type = ObjView.LinesSurface;
                else if (tag == "3")
                    type = ObjView.Surface;
                if (sceneControl.FindVBObj(ObjType.Элемент2D.ToString()) != null)
                    sceneControl.ChangeViewModeVBObjects(ObjType.Элемент2D.ToString(), type);
                if (sceneControl.FindVBObj(ObjType.Элемент3D.ToString()) != null)
                    sceneControl.ChangeViewModeVBObjects(ObjType.Элемент3D.ToString(), type);
                sceneControl.DisplayObjects();
            }
        }

        private void OnEnableTransparency(object sender, EventArgs e)
        {
            var control = sender as CheckBox;
            var status = control.Checked;
            sceneControl.IsBlending = status;
            label1.Enabled = status;
            label2.Enabled = status;
            label3.Enabled = status;
            label4.Enabled = status;
            label3.Enabled = status;
            label4.Enabled = status;
            trackBar1.Enabled = status;
            trackBar2.Enabled = status;
            trackBar3.Enabled = status;
            trackBar4.Enabled = status;
            checkBox6.Enabled = status;
            sceneControl.ChangeVBOTransparentMode(control.Checked);
            sceneControl.DisplayObjects();
        }

        private void OnChangeBackEdges(object sender, EventArgs e)
        {
            var control = sender as CheckBox;
            sceneControl.ShowSurfaceBackEdges = control.Checked;
            sceneControl.DisplayObjects();
        }

        private void OnChangeTrackbar(object sender, EventArgs e)
        {
            var control = sender as TrackBar;
            var labels = new Label[] { label1, label2, label3, label4 };
            var index = Int32.Parse(control.Tag.ToString()) - 1;
            var key = labels[index].Text.Split(' ')[0];
            var obj = labels[index].Tag;
            labels[index].Text = key + ' ' + (control.Value * 0.01f).ToString("0.00");
            if (obj != null)
            {
                var tag = obj.ToString();

                sceneControl.SetTransparency(tag, control.Value);
                sceneControl.DisplayObjects();
            }
        }

        private void OnChangeProjection(object sender, EventArgs e)
        {
            sceneControl.Projection = checkBox7.Checked ? ViewProjection.Parallel : ViewProjection.Perspective;
            sceneControl.UpdateProjection();
            sceneControl.DisplayObjects();
        }

        private void OnShowInside3D(object sender, EventArgs e)
        {
            sceneControl.DeleteVBObjects(ObjType.Элемент3D.ToString());
            var creator = new PresentersCreator();
            Create3DVBOObject(creator);
            sceneControl.DisplayObjects();
        }

        private void OnClipPlaneShow(object sender, EventArgs e)
        {
            if(button2.Tag == null)
            {
                var clip = new ClipControl() { Dock = DockStyle.Fill };
                var clipForm = new Form()
                {
                    TopMost = true,
                    ShowIcon = false,
                    ClientSize = new Size(250, 210),
                    MaximizeBox = false,
                    FormBorderStyle = FormBorderStyle.FixedSingle,
                    Text = "Сечение",
                    Owner = Application.OpenForms[0]
                };
                clipForm.Controls.Add(clip);

                button2.Tag = clipForm;

                sceneControl.IsClipPlane = true;
                sceneControl.ChangeClipMode(ClipMode.Default, ObjType.Элемент3D.ToString());

                clip.SwitchOnOff += (v) => { sceneControl.IsClipPlane = v; };
                clip.ChangeClipMode += (mode) =>
                {
                    sceneControl.ChangeClipMode((ClipMode)mode, ObjType.Элемент3D.ToString());
                };

                clip.ChangeLayerThickness += (layerThickness) => sceneControl.ChangeLayerThickness(layerThickness);

                clip.SetClipPlaneEvent += (plane) => sceneControl.ChangeClipPlane(new Geometry.Plane(new Point3D(plane.X, plane.Y, plane.Z), plane.D));


                clip.RedrawClipPlane += () => sceneControl.DisplayObjects();
 
                clipForm.FormClosing += (o, ev) =>
                {
                    sceneControl.IsClipPlane = false;
                    sceneControl.ChangeClipMode(ClipMode.None, ObjType.Элемент3D.ToString());
                    button2.Tag = null;
                    sceneControl.DisplayObjects();
                };
                clipForm.Show();
            }
        }

        private ClipMode ModeConverter(ClipRegime mode)
        {
            switch (mode)
            {
                case ClipRegime.Default:
                    return ClipMode.Default;
                case ClipRegime.Layered:
                    return ClipMode.Layered;
                default:
                    return ClipMode.KeepElement;
            }
        }

        private void OnReflectPlaneShow(object sender, EventArgs e)
        {
            if (button3.Tag == null)
            {
                var reflect = new ReflectControl();
                reflect.SetGlObjs(sceneControl.GetVBObjs().Select(x => x.ObjName));

                var reflectForm = new Form()
                {
                    TopMost = true,
                    ShowIcon = false,
                    ClientSize = new Size(250, 210),
                    MaximizeBox = false,
                    FormBorderStyle = FormBorderStyle.FixedSingle,
                    Text = "Отражение"
                };
                reflectForm.Controls.Add(reflect);
                reflect.Dock = DockStyle.Fill;

                var color = model.ObjectData.GetObjects(ObjType.Элемент3D).First().Color;

                reflect.ShowObjs += (ar) =>
                {
                    foreach (var item in reflect.GetAllSrcObjs())
                        ChangeVBOColor(item, color);

                    ChangeVBOColor(ar, Color.Red);
                    sceneControl.DisplayObjects();
                };

                reflect.CreateReflectObj += (ar1, ar2) =>
                {
                    var copyObjs = sceneControl.GetVBObjs().Where(x => x.ObjName.Contains($"{ar1}_copy")).
                    Select(x => x.ObjName);
                    sceneControl.CreateReflectedVBObject(ar1,$"{ar1}_copy_{copyObjs.Count() + 1}",ar2);
                    reflect.SetGlObjs(copyObjs);
                    sceneControl.DisplayObjects();
                };

                reflect.MatrixEvent += (s, ev) =>
                {
                    var obj = sceneControl.FindVBObj(s);
                    ev.Matrix = obj.ModelMatrix;
                };

                reflect.UpdateReflectPlane += (s, p) =>
                {
                    sceneControl.DisplayReflectionPlane(s, p);
                    sceneControl.DisplayObjects();
                };

                reflectForm.FormClosing += (o, ev) =>
                {
                    button3.Tag = null;
                    sceneControl.HideReflectionPlane();
                    sceneControl.DeleteAllVBObjects();
                    CreateVBOObjects();
                    //sceneControl.CreateReflectedVBObject("", "", null);
                    sceneControl.DisplayObjects();
                };
                reflectForm.Show();
            }
        }

        private void ChangeVBOColor(string ar, Color color)
        {
            var obj = sceneControl.FindVBObj(ar);
            var colors = new float[obj.ColorLength];

            //var count = obj.ColorLength / 4;
            for (int i = 0; i < obj.ColorLength; i += 4)
            {
                colors[i] = Convert.ToInt32(color.R) / 255.0f;
                colors[i + 1] = Convert.ToInt32(color.G) / 255.0f;
                colors[i + 2] = Convert.ToInt32(color.B) / 255.0f;
                colors[i + 3] = Convert.ToInt32(color.A) / 255.0f;
            }
            obj.PointsColors = colors;
        }
    }
}
