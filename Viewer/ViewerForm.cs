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
using ModelController.MeshObjsUtility;
using System.Security.Cryptography.X509Certificates;
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
            comboBox1.SelectedIndex = 0;
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
                else if(ext == ".bpf2")
                    model.Loader = new LoadModelFromBPF2TextFile();
                model.Loader.LoadEvent += (ar1, ar2) => { };
                model.Load(dialog.FileName);

                OnShowNodes();
                OnShowLines();
                OnShow2DElements();
                OnShow3DElements();

                sceneControl.FitObjectsToScreen();
                sceneControl.DisplayObjects();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnShowNodes(object sender, EventArgs e) => OnShowNodes(true);

        private void OnShowNodes(bool displayObjects = false)
        {
            if (checkBox1.Checked)
                ShowNodes();
            else
                HideNodes();
            if(displayObjects)
                sceneControl.DisplayObjects();
        }

        private void ShowNodes()
        {
            var name = ObjType.Узел.ToString();
            var obj = sceneControl.FindVBObj(name);

            if (obj == null)
            {
                if (model.ObjectData.NodesSet.Count > 0)
                {
                    var creator = new PresentersCreator();
                    var presenter = creator.CreatePointObjectsPresenter(model.ObjectData.NodesSet.Values);

                    var inds = presenter.CreateIndexes();
                    var ptrs = presenter.CreatePointers(inds.Item1);
                    var coords = presenter.CreateVertexes(inds.Item2, "координаты");
                    var colors = presenter.CreateVertexes(inds.Item3, "цвет");
                    var normals = presenter.CreateVertexes(inds.Item2, "нормаль");

                    sceneControl.CreatePointVBObjects(ptrs, coords, colors, normals, name);
                }
            }
            else
                obj.ViewState = true;
        }

        private void HideNodes()
        {
            var name = ObjType.Узел.ToString();
            var obj = sceneControl.FindVBObj(name);

            if (obj != null)
                obj.ViewState = false;
        }

        private void OnShowLines(object sender, EventArgs e) => OnShowLines(true);

        private void OnShowLines(bool displayObjects = false)
        {
            if (checkBox2.Checked)
                ShowLines();
            else
                HideLines();
            if(displayObjects)
                sceneControl.DisplayObjects();
        }

        private void ShowLines()
        {
            var name = ObjType.Элемент1D.ToString();
            var obj = sceneControl.FindVBObj(name);

            if (obj == null)
            {
                if (model.ObjectData.E1DCollection.Count > 0)
                {
                    var creator = new PresentersCreator();

                    var presenter = creator.CreateLineObjectsPresenter(model.ObjectData.E1DCollection.GetObjects());

                    var inds = presenter.CreateIndexes();
                    var ptrs = presenter.CreatePointers(inds.Item1);
                    var coords = presenter.CreateVertexes(inds.Item2, "координаты");
                    var colors = presenter.CreateVertexes(inds.Item3, "цвет");
                    var normals = presenter.CreateVertexes(inds.Item2, "нормаль");

                    var edges = presenter.CreateEdgeFlags(inds.Item4);

                    sceneControl.CreateLineVBObjects(ptrs, coords, colors, normals, edges, name);
                }
            }
            else
                obj.ViewState = true;
        }

        private void HideLines()
        {
            var name = ObjType.Элемент1D.ToString();
            var obj = sceneControl.FindVBObj(name);

            if (obj != null)
                obj.ViewState = false;
        }

        private void OnShow2DElements(object sender, EventArgs e) => OnShow2DElements(true);

        private void OnShow2DElements(bool displayObjects = false)
        {
            if (checkBox3.Checked)
                Show2DElements();
            else
                Hide2DElements();
            if(displayObjects)
                sceneControl.DisplayObjects();
        }

        private void Show2DElements()
        {
            var name = ObjType.Элемент2D.ToString();
            var obj = sceneControl.FindVBObj(name);

            if (obj == null)
            {
                if (model.ObjectData.E2DCollection.Count > 0)
                {
                    var creator = new PresentersCreator();

                    var presenter = creator.CreateSurfaceObjectsPresenter(model.ObjectData.E2DCollection.GetObjects());

                    var inds = presenter.CreateIndexes();
                    var ptrs = presenter.CreatePointers(inds.Item1);
                    var coords = presenter.CreateVertexes(inds.Item2, "координаты");
                    var colors = presenter.CreateVertexes(inds.Item3, "цвет");
                    var normals = presenter.CreateVertexes(inds.Item2, "нормаль");

                    var edges = presenter.CreateEdgeFlags(inds.Item4);
                    var separators = presenter.CreateSeparators();

                    var view = ExtractObjView();

                    sceneControl.CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, name, separators, view);
                }
            }
            else
                obj.ViewState = true;
        }

        private void Hide2DElements()
        {
            var name = ObjType.Элемент2D.ToString();
            var obj = sceneControl.FindVBObj(name);

            if (obj != null)
                obj.ViewState = false;
        }

        private void OnShow3DElements(object sender, EventArgs e) => OnShow3DElements(true);

        private void OnShow3DElements(bool displayObjects = false)
        {
            if (checkBox4.Checked)
                Show3DElements();
            else
                Hide3DElements();
            if(displayObjects)
                sceneControl.DisplayObjects();
        }

        private void Show3DElements()
        {
            var name = ObjType.Элемент3D.ToString();
            var obj = sceneControl.FindVBObj(name);

            if (obj == null)
                Create3DElements(name);
            else
                obj.ViewState = true;
        }

        private void Create3DElements(string name)
        {
            if (model.ObjectData.E3DCollection.Count > 0)
            {
                var creator = new PresentersCreator();
                var surfChanger = new ChangeInsideSurface();

                var objects = model.ObjectData.E3DCollection.GetObjects();
                if (checkBox8.Checked)
                    surfChanger.ShowInsideSurfaces(objects);
                else
                    surfChanger.HideInsideSurfaces(objects);
                var presenter = creator.CreateSurfaceObjectsPresenter(model.ObjectData.E3DCollection.GetObjects());

                var inds = presenter.CreateIndexes();
                var ptrs = presenter.CreatePointers(inds.Item1);
                var coords = presenter.CreateVertexes(inds.Item2, "координаты");
                var colors = presenter.CreateVertexes(inds.Item3, "цвет");
                var normals = presenter.CreateVertexes(inds.Item2, "нормаль");

                var edges = presenter.CreateEdgeFlags(inds.Item4);

                var separators = presenter.CreateSeparators();
                var view = ExtractObjView();

                sceneControl.CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, name, separators, view);
            }
        }

        private void Hide3DElements()
        {
            var name = ObjType.Элемент3D.ToString();
            var obj = sceneControl.FindVBObj(name);

            if (obj != null)
                obj.ViewState = false;
        }

        private ObjView ExtractObjView()
        {
            if (radioButton1.Checked)
                return ObjView.Lines;
            if (radioButton2.Checked)
                return ObjView.Surface;
            return ObjView.LinesSurface;
        }

        private void OnViewModeChange(object sender, EventArgs e)
        {
            var objView = ExtractObjView();

            var obj = sceneControl.FindVBObj(ObjType.Элемент2D.ToString());
            if (obj != null)
                obj.ViewMode = objView;

            obj = sceneControl.FindVBObj(ObjType.Элемент3D.ToString());
            if (obj != null)
                obj.ViewMode = objView;

            sceneControl.DisplayObjects();
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
            var name = ObjType.Элемент3D.ToString();

            sceneControl.DeleteVBObjects(name);
            Create3DElements(name);

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

                    OnShowNodes();
                    OnShowLines();
                    OnShow2DElements();
                    OnShow3DElements();

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

        private void OnSelectElement(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var obj = sceneControl.FindVBObj(comboBox1.SelectedItem.ToString());
                if (obj != null)
                    sceneControl.ElementSelector.SelectElement(obj as SurfaceObjects, sceneControl.SelectionColor);
            }
        }

        private void OnChangeSelectState(object sender, EventArgs e)
        {
            if (checkBox9.Checked)
                sceneControl.SceneMouseClickEvent += OnSelectElement;
            else
                sceneControl.SceneMouseClickEvent -= OnSelectElement;
        }
    }
}
