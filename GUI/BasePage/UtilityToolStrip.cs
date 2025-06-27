using BaseModule;
using BaseModule.Console;
using BaseModule.Extensions;
using BaseModule.SceenControls;
using Geometry;
using Model.GeometryObjects;
using Model.Interfaces;
using Model.Interfaces.MeshObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void btnMeasuring_Click(object sender, EventArgs e)
        {
            try
            {
                var btn = (ToolStripButton)sender;
                if (btn.Checked)
                {

                    var form = new Form()
                    {
                        Name = "measureForm",
                        Text = "Панель измерений",
                        ShowIcon = false,
                        Owner = Application.OpenForms[0],
                        TopMost = true
                    };

                    form.FormClosed += (s1, s2) =>
                    {
                        btn.Checked = false;
                        scene.SceneControl.HideAllGeometryObjs();
                        scene.SceneControl.HideDisplayText3D();
                        scene.SceneControl.DisplayObjects();
                    };

                    var measuringControl = new MeasuringSet() { Dock = DockStyle.Fill };
                    measuringControl.PreparingMeasureEvent += (ar) =>
                    {
                        spbSelectObject.ToolTipText = ar.ToString();
                        scene.SceneControl.HideAllGeometryObjs();
                        scene.SceneControl.HideDisplayText3D();
                        scene.SceneControl.DisplayObjects();
                    };
                    measuringControl.MakeMeasureEvent += MeasuringControl_MakeMeasureEvent;
                    form.ClientSize = measuringControl.Size;
                    form.Controls.Add(measuringControl);

                    form.Show();
                    var location = scene.PointToScreen(Point.Empty);
                    form.Location = location;
                }
                else
                {
                    var forms = Application.OpenForms.Cast<Form>().ToList();
                    var form = forms.Find(x => x.Name == "measureForm");
                    if (form != null)
                    {
                        form.Close();
                        btn.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
        private async void MeasuringControl_MakeMeasureEvent(object arg1, MeasureEventArgs arg2)
        {
            try
            {
                switch (arg2.Kind)
                {
                    case MeasureKind.DistancePointToPoint:
                        {
                            DistancePointToPoint(spbSelectObject.ToolTipText);
                            break;
                        }
                    case MeasureKind.DistancePointToPlane:
                        {
                            DistancePointToPlane(spbSelectObject.ToolTipText);
                            break;
                        }
                    case MeasureKind.Path:
                        CreatePathAsync();
                        break;
                    case MeasureKind.Square:
                        {
                            CalcSquare(spbSelectObject.ToolTipText);
                            break;
                        }

                    case MeasureKind.Volume:
                        {

                            CalcVolume(spbSelectObject.ToolTipText);
                            break;
                        }

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        public async Task<List<IPoint>> CreatePathAsync()
        {
            var nodes = new List<IPoint>();

            var message = @"Начните строить путь нажав на клавишу ""E"" для подтверждения или клавишу ""ESC"" для отмены";
            console.PrintInfo(message, Color.Black);

            while (true)
            {
                //var objType = Converters.ConvertToObjsType(scene.SelectedObjects);
                var res = SelectObjectAsync(ObjType.Узел);
                await res;

                if (res.Result is IPoint node)
                {
                    nodes.Add(node);
                    //node.SetBackColor();
                }
                else break;

                if (nodes.Count > 1)
                {
                    var line = new Segment3D(nodes[nodes.Count - 1].Position, nodes[nodes.Count - 2].Position);
                    console.PrintInfo($"Расстояние : {line.GetLength()}", Color.Black);
                    scene.SceneControl.DisplayDistance(line);
                    scene.SceneControl.DisplayObjects();
                }
            }
            return nodes;
        }

        public async Task<object> SelectObjectsAsync(IModelData modelData, ObjType objType)
        {
            var actBreak = new Action(() =>
            {
                Invoke(new Action(() =>
                {
                    console.PrintInfo("Операция отменена", Color.Black);
                }));
            });

            var message = $@"Выберите {objType} и нажмите на клавишу ""E"" для подтверждения или клавишу ""ESC"" для отмены";

            var actPointConfirm = new Func<Tuple<bool, object>>(() =>
            {
                var objs = modelData.ObjectData.GetObjects(objType);

                var selObjs = objs.Where(x => x.Color == scene.SceneControl.SelectionColor);

                if (selObjs.Count() == 0)
                {
                    Invoke(new Action(() =>
                    {
                        console.PrintInfo($"Не выбран ни один {objType}!", Color.Orange);
                    }));
                    return new Tuple<bool, object>(false, new object());
                }
                else
                {
                    Invoke(new Action(() =>
                    {
                        console.PrintInfo($"Выбраны {selObjs.Count()} {objType}", Color.Green);
                    }));
                    return new Tuple<bool, object>(true, selObjs);
                }
            });

            var awaitResult = AsyncMethodContainer(actPointConfirm, actBreak, message);
            await awaitResult;
            return awaitResult.Result;
        }

        public async Task<object> SelectObjectAsync(ObjType objType)
        {
            var actBreak = new Action(() =>
            {
                Invoke(new Action(() =>
                {
                    console.PrintInfo("Операция отменена", Color.Black);
                }));
            });

            var message = $@"Выберите {objType} и нажмите на клавишу ""E"" для подтверждения или клавишу ""ESC"" для отмены";

            var actPointConfirm = new Func<Tuple<bool, object>>(() =>
            {
                var objs = project.ModelData.ObjectData.GetObjects(objType);

                var selObjs = objs.Where(x => x.Color == scene.SceneControl.SelectionColor);

                if (selObjs.Count() == 0)
                {
                    Invoke(new Action(() =>
                    {
                        console.PrintInfo($"Не выбран ни один {objType}!", Color.Orange);
                    }));
                    return new Tuple<bool, object>(false, new object());
                }
                else if (selObjs.Count() > 1)
                {
                    Invoke(new Action(() =>
                    {
                        console.PrintInfo($"Выберите один {objType}!", Color.Orange);
                    }));
                    return new Tuple<bool, object>(false, new object());
                }
                else
                {
                    var node = selObjs.First();
                    Invoke(new Action(() =>
                    {
                        console.PrintInfo($"Выбран {objType} с номером {node.Number}", Color.Green);
                    }));
                    return new Tuple<bool, object>(true, node);
                }
            });

            var pointAwait = AsyncMethodContainer(actPointConfirm, actBreak, message);
            await pointAwait;
            return pointAwait.Result;
        }

        private void CalcVolume(string arg2)
        {
            var objs = project.ModelData.ObjectData.GetObjects(arg2.ToEnum<ObjType>());
            var selObjs = objs.Where(x => x.Color == scene.SceneControl.SelectionColor);

            var vol = 0.0f;
            foreach (var obj in selObjs)
            {
                var e3DObj = (IElement3D)obj;
                vol += (float)e3DObj.CalcVolume();
            }
            console.PrintInfo(string.Format("Объем : {0}", vol), Color.Black);
        }

        private void CalcSquare(string arg2)
        {
            var objs = project.ModelData.ObjectData.GetObjects(arg2.ToEnum<ObjType>());

            var selObjs = objs.Where(x => x.Color == scene.SceneControl.SelectionColor);
            var square = 0.0;
            foreach (var obj in selObjs)
            {
                var sObj = (ISquare)obj;
                square += sObj.CalcSquare();
            }
            console.PrintInfo($"Площадь : {square}", Color.Black);
        }

        private async void DistancePointToPlane(string objTypeStr)
        {
            var objType = objTypeStr.ToEnum<ObjType>();
            var plane = CreateSurfaceAsync(project.ModelData, objType);
            await plane;

            project.ModelData.ObjectData.SetBackColor(objType);

            var pres = scene.CreateObjectsPresentor(project.ModelData, objType);

            scene.SetObjectsSceneAttribute(pres, objType.ToString(), "цвет");
            scene.SceneControl.DisplayObjects();

            var res = SelectObjectAsync(objType);
            await res;

            if (res.Result is IPoint point)
            {
                var proj = point.Position.GetPointProectionOnPlane(plane.Result);
                var line = new Segment3D(point.Position, proj);
                console.PrintInfo($"Расстояние : {line.GetLength()}", Color.Black);
                scene.SceneControl.DisplayDistance(line);
                scene.SceneControl.DisplayObjects();
            }
        }

        private void DistancePointToPoint(string objTypeStr)
        {

            var objType = objTypeStr.ToEnum<ObjType>();
            var objs = project.ModelData.ObjectData.GetObjects(objType);
            var color = scene.SceneControl.SelectionColor;
            var selObjs = objs.Where(x => x.Color == color).ToList();

            if (selObjs.Count() > 1)
            {
                var nodes = selObjs.Select(x => (IPoint)x);
                var p0 = nodes.First();
                var p1 = nodes.Last();
                var line = new Segment3D(p0.Position, p1.Position);

                console.PrintInfo($"Расстояние : {line.GetLength()}", Color.Black);

                scene.SceneControl.DisplayDistance(line);
                scene.SceneControl.DisplayObjects();
            }
            else console.PrintInfo($"{objTypeStr} не выбраны", Color.Red);
        }

        private void btnCrossSection_Click(object sender, EventArgs e)
        {
            try
            {
                var btn = (ToolStripButton)sender;
                if (btn.Checked)
                {
                    var form = new Form()
                    {
                        Name = "CrossSectionForm",
                        Text = "Построить сечение",
                        ShowIcon = false,
                        Size = new Size(268, 203),
                        Owner = Application.OpenForms[0],
                        TopMost = true
                    };

                    var crossSection = new CrossSectionControl() { Dock = DockStyle.Fill };
                    form.ClientSize = crossSection.Size;
                    form.Controls.Add(crossSection);

                    crossSection.RemoveCrossEvent += () =>
                    {
                        scene.SceneControl.DeleteVBObjects("crossSection");
                        scene.SceneControl.DisplayObjects();
                    };

                    crossSection.SelectNodesEvent += () => { spbSelectObject.ToolTipText = ObjType.Узел.ToString(); };

                    crossSection.CreateCrossFromTextArgs += (ar1, ar2) =>
                    {
                        try
                        {
                            CreateSectionSurfacesFromCoords(ar2);

                        }
                        catch (Exception ex)
                        {
                            console.PrintInfo(ex.Message, Color.Red);
                        }
                    };
                    crossSection.CreateCrossFromNodesEvent += () =>
                    {
                        try
                        {
                            CreateSectionSurfacesFromNodes();
                        }
                        catch (Exception ex)
                        {
                            console.PrintInfo(ex.Message, Color.Red);
                        }
                    };

                    form.FormClosed += (ar1, ar2) =>
                    {
                        btn.Checked = false;

                        scene.SceneControl.DeleteVBObjects("crossSection");
                        scene.SceneControl.DisplayObjects();
                    };

                    form.Show();
                    var location = scene.PointToScreen(Point.Empty);
                    form.Location = location;
                }
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void CreateSectionSurfacesFromNodes()
        {
            var objs = project.ModelData.ObjectData.GetObjects(ObjType.Узел);
            var selObjs = objs.Where(x => x.Color == scene.SceneControl.SelectionColor).ToArray();
            if (selObjs.Length < 3)
            {
                console.PrintInfo("Ошибка, выбрано неверное количество узлов", Color.Red);
                return;
            }

            var mP0 = selObjs[0].CalcCentr();
            var mP1 = selObjs[1].CalcCentr();
            var mP2 = selObjs[2].CalcCentr();

            var p0 = new Vector3(mP0._x, mP0._y, mP0._z);
            var p1 = new Vector3(mP1._x, mP1._y, mP1._z);
            var p2 = new Vector3(mP2._x, mP2._y, mP2._z);

            var elems3D = project.ModelData.ObjectData.E3DCollection.GetObjects();

            var plane = CreateSectionPlane(p0, p1, p2);

            var surface = modelController.CrossSectionMaker.GetSectionSurfaces(elems3D, plane);
            var presenter = scene.PresentersCreator.CreateSurfaceObjectsPresenter(new List<SurfaceFigure>() { surface });
            scene.PresentCrossSection(presenter);
        }

        public Geometry.Plane CreateSectionPlane(Vector3 p0, Vector3 p1, Vector3 p2)
        {
            var mP0 = new Point3D(p0.X, p0.Y, p0.Z);
            var mP1 = new Point3D(p1.X, p1.Y, p1.Z);
            var mP2 = new Point3D(p2.X, p2.Y, p2.Z);
            return new Geometry.Plane(mP0, mP1, mP2);
        }

        private void CreateSectionSurfacesFromCoords(CreatePlaneFromTextArgs arg)
        {
            var elems3D = project.ModelData.ObjectData.E3DCollection.GetObjects();
            var plane = CreateSectionPlane(arg.point1, arg.point2, arg.point3);

            var surface = modelController.CrossSectionMaker.GetSectionSurfaces(elems3D, plane);

            var presenter = scene.PresentersCreator.CreateSurfaceObjectsPresenter(new List<SurfaceFigure>() { surface });
            scene.PresentCrossSection(presenter);
        }

        private void btnScreenShot_Click(object sender, EventArgs e)
        {
            var generalData = project.GeneralData;
            CreateScreenShot(generalData.Path + "\\screenShot.bmp");
            console.PrintInfo($"Сделан снимок экрана {generalData.Path}\\screenShot.bmp", Color.Black);
        }

        public void CreateScreenShot(string fileName)
        {
            this.BringToFront();
            var bmpPicture = new Bitmap(scene.Width, scene.Height);
            var gr = Graphics.FromImage(bmpPicture);
            var pos = scene.PointToScreen(Point.Empty);
            var size = new Size(scene.Size.Width - 5, scene.Size.Height - 20);
            gr.CopyFromScreen(pos, Point.Empty, size);

            bmpPicture.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
        }

        private void btnReflect_Click(object sender, EventArgs e)
        {
            try
            {
                var btn = sender as ToolStripButton;
                if (btn.Checked)
                {
                    var reflect = new ReflectControl();
                    reflect.SetGlObjs(scene.SceneControl.GetVBObjs().Select(x => x.ObjName));

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

                    reflect.ShowObjs += (ar) =>
                    {
                        var vbo = scene.SceneControl.FindVBObj(ar);

                        var a = (int)vbo.PointsColors[0];
                        var r = (int)vbo.PointsColors[1];
                        var g = (int)vbo.PointsColors[2];
                        var b = (int)vbo.PointsColors[3];

                        var color = Color.FromArgb(a, r, g, b);

                        foreach (var item in reflect.GetAllSrcObjs())
                            ChangeVBOColor(item, color);

                        ChangeVBOColor(ar, Color.Red);
                        scene.SceneControl.DisplayObjects();
                    };

                    reflect.CreateReflectObj += (ar1, ar2) =>
                    {
                        var copyObjs = scene.SceneControl.GetVBObjs().Where(x => x.ObjName.Contains($"{ar1}_copy")).
                        Select(x => x.ObjName);
                        scene.SceneControl.CreateReflectedVBObject(ar1, $"{ar1}_copy_{copyObjs.Count() + 1}", ar2);
                        reflect.SetGlObjs(copyObjs);
                        scene.SceneControl.DisplayObjects();
                    };

                    reflect.MatrixEvent += (s, ev) =>
                    {
                        var obj = scene.SceneControl.FindVBObj(s);
                        ev.Matrix = obj.ModelMatrix;
                    };

                    reflect.UpdateReflectPlane += (s, p) =>
                    {
                        scene.SceneControl.DisplayReflectionPlane(s, p);
                        scene.SceneControl.DisplayObjects();
                    };

                    reflectForm.FormClosing += (o, ev) =>
                    {
                        btn.Checked = false;
                        scene.SceneControl.HideReflectionPlane();
                        scene.SceneControl.DeleteAllVBObjects();
                        //scene.PresentAllModelObjectsToScene();
                        //sceneControl.CreateReflectedVBObject("", "", null);
                        scene.SceneControl.DisplayObjects();
                    };
                    reflectForm.Show();

                    var location = scene.PointToScreen(Point.Empty);
                    reflectForm.Location = location;


                }
                else
                {
                    var forms = Application.OpenForms.Cast<Form>().ToList();
                    var form = forms.Find(x => x.Name == "reflectForm");
                    if (form != null)
                    {
                        form.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void ChangeVBOColor(string ar, Color color)
        {
            var obj = scene.SceneControl.FindVBObj(ar);

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

        private void btnClipPlane_Click(object sender, EventArgs e)
        {
            try
            {
                var btn = sender as ToolStripButton;
                var sceneControl = scene.SceneControl;
                if (btn.Checked)
                {
                    var clip = new ClipControl() { Dock = DockStyle.Fill };
                    var clipForm = new Form()
                    {
                        Name = "clipPlaneForm",
                        TopMost = true,
                        ShowIcon = false,
                        ClientSize = clip.Size,
                        MaximizeBox = false,
                        Text = "Сечение",
                        Owner = Application.OpenForms[0]
                    };

                    clipForm.Controls.Add(clip);

                    sceneControl.IsClipPlane = true;
                    sceneControl.ChangeClipMode(Scene.ClipMode.Default, ObjType.Элемент3D.ToString());

                    clip.SwitchOnOff += (v) => { sceneControl.IsClipPlane = v; };
                    clip.ChangeClipMode += (mode) =>
                    {
                        sceneControl.ChangeClipMode((Scene.ClipMode)mode, ObjType.Элемент3D.ToString());
                    };

                    clip.ChangeLayerThickness += (layerThickness) => sceneControl.ChangeLayerThickness(layerThickness);

                    clip.SetClipPlaneEvent += (plane) =>
                    {
                        var scPlane = new Geometry.Plane(new Point3D(plane.X, plane.Y, plane.Z), plane.D);
                        sceneControl.ChangeClipPlane(scPlane);
                    };

                    clip.RedrawClipPlane += () => sceneControl.DisplayObjects();

                    clipForm.FormClosing += (o, ev) =>
                    {
                        sceneControl.IsClipPlane = false;
                        sceneControl.ChangeClipMode(Scene.ClipMode.None, ObjType.Элемент3D.ToString());
                        btn.Checked = false;
                        sceneControl.DisplayObjects();
                    };

                    clipForm.Show();
                    var location = scene.PointToScreen(Point.Empty);
                    clipForm.Location = location;
                }
                else
                {
                    var forms = Application.OpenForms.Cast<Form>().ToList();
                    var form = forms.Find(x => x.Name == "clipPlaneForm");
                    if (form != null)
                    {
                        sceneControl.IsClipPlane = false;
                        form.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
    }
}
