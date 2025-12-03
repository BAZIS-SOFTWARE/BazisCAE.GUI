using BazisGUI.Extensions;
using BazisGUI.Scene;
using BazisGUI.Scene.VBO;
using Geometry;
using Model.GeometryObjects;
using Model.Interfaces;
using Model.Interfaces.MeshObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;
using BazisGUI.Reflect;
using BazisGUI.Measurement;
using BazisGUI.CrossSection;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void измеритьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var btn = sender as ToolStripMenuItem;
                if (btn.Checked)
                {

                    var form = new Form()
                    {
                        Name = "measureForm",
                        Text = "Панель измерений",
                        Icon = this.Icon,
                        ShowIcon = true,
                        Owner = Application.OpenForms[0],
                        TopMost = true
                    };

                    form.FormClosed += (s1, s2) =>
                    {
                        btn.Checked = false;
                        DisplayGeometryObjectEvent = null;
                        DisplayText3DEvent = null;
                        DisplayObjects();
                    };

                    var measuringControl = new MeasuringSet() 
                    { 
                        Dock = DockStyle.Fill
                    };
                    measuringControl.PreparingMeasureEvent += (ar) =>
                    {
                        SelectedObjects = ar.ToString();
                        DisplayGeometryObjectEvent = null;
                        DisplayText3DEvent = null;
                        DisplayObjects();
                    };
                    measuringControl.MakeMeasureEvent += MeasuringControl_MakeMeasureEvent;
                    form.ClientSize = measuringControl.Size;
                    form.Controls.Add(measuringControl);

                    form.Show();
                    var location = PointToScreen(Point.Empty);
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
                            DistancePointToPoint(SelectedObjects);
                            break;
                        }
                    case MeasureKind.DistancePointToPlane:
                        {
                            DistancePointToPlane(SelectedObjects);
                            break;
                        }
                    case MeasureKind.Path:
                        CreatePathAsync();
                        break;
                    case MeasureKind.Square:
                        {
                            CalcSquare(SelectedObjects);
                            break;
                        }

                    case MeasureKind.Volume:
                        {

                            CalcVolume(SelectedObjects);
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

            var path = 0.0f;
            while (true)
            {
                //var objType = Converters.ConvertToObjsType(SelectedObjects);
                var res = SelectObjectAsync(ObjType.Узел);
                await res;

                if (res.Result is IPoint node)
                {
                    nodes.Add(node);
                    var set = project?.GetModelSetsInfo(ObjType.Узел).First();
                    set.SetBackColor();
                    var pres = project.CreateModelObjectsPresentor(set);
                    if (pres != null)
                        SetVBObjectAttribute(pres, "цвет");
                }
                else break;

                if (nodes.Count > 1)
                {
                    var line = new Segment3D(nodes[nodes.Count - 1].Position, nodes[nodes.Count - 2].Position);
                    console.PrintInfo($"Расстояние : { path+=line.GetLength()}", Color.Black);
                    DisplayDistance(line);

                    var coord = line.P0.Sum(line.P1).Div(2);

                    DisplayText3D(path.ToString(), Color.FromArgb(0, 0, 0), coord);

                    DisplayObjects();
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

                var selObjs = objs.Where(x => x.Color == settingsConfig.SelectObjectColor);

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

                var selObjs = objs.Where(x => x.Color == settingsConfig.SelectObjectColor);

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
            var objs = project.GetModelObjects(arg2.ToEnum<ObjType>());
            var selObjs = objs.Where(x => x.Color == settingsConfig.SelectObjectColor);

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
            var objs = project.GetModelObjects(arg2.ToEnum<ObjType>());

            var selObjs = objs.Where(x => x.Color == settingsConfig.SelectObjectColor);
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

            project.SetModelObjectsBackColor(objType);

            var pres = project.CreateModelObjectsPresentor(objType);

            SetVBObjectAttribute(pres, "цвет");
            DisplayObjects();

            var res = SelectObjectAsync(objType);
            await res;

            if (res.Result is IPoint point)
            {
                var proj = point.Position.GetPointProectionOnPlane(plane.Result);
                var line = new Segment3D(point.Position, proj);
                console.PrintInfo($"Расстояние : {line.GetLength()}", Color.Black);
                DisplayDistance(line);
                DisplayObjects();
            }
        }

        private void DistancePointToPoint(string objTypeStr)
        {

            var objType = objTypeStr.ToEnum<ObjType>();
            var objs = project.GetModelObjects(objType);
            var color = settingsConfig.SelectObjectColor;
            var selObjs = objs.Where(x => x.Color == color).ToList();

            if (selObjs.Count() > 1)
            {
                var nodes = selObjs.Select(x => (IPoint)x);
                var p0 = nodes.First();
                var p1 = nodes.Last();
                var line = new Segment3D(p0.Position, p1.Position);

                console.PrintInfo($"Расстояние : {line.GetLength()}", Color.Black);

                DisplayDistance(line);
                DisplayObjects();
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
                        VBOController.DeleteVBObjects("crossSection");
                        DisplayObjects();
                    };

                    crossSection.SelectNodesEvent += () => { SelectedObjects = ObjType.Узел.ToString(); };

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

                        VBOController.DeleteVBObjects("crossSection");
                        DisplayObjects();
                    };

                    form.Show();
                    var location = PointToScreen(Point.Empty);
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
            var objs = project.GetModelObjects(ObjType.Узел);
            var selObjs = objs.Where(x => x.Color == settingsConfig.SelectObjectColor).ToArray();
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

            var plane = CreateSectionPlane(p0, p1, p2);

            var surface = project.GetSectionSurfaces(plane);
            var presenter = presentersCreator.CreateSurfaceObjectsPresenter(new List<SurfaceFigure>() { surface });
            presenter.Name = "crossSection";
            var vbo = CreateVBObject(presenter);
            VBOController.AddVbo(vbo);
            DisplayObjects();
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
            var plane = CreateSectionPlane(arg.point1, arg.point2, arg.point3);

            var surface = project.GetSectionSurfaces(plane);

            var presenter = presentersCreator.CreateSurfaceObjectsPresenter(new List<SurfaceFigure>() { surface });
            presenter.Name = "crossSection";
            CreateVBObject(presenter);
        }

        public Image CreateScreenShot()
        {
            this.BringToFront();
            var bmpPicture = new Bitmap(scene.Width, scene.Height);
            var gr = Graphics.FromImage(bmpPicture);
            var pos = PointToScreen(Point.Empty);
            var size = new Size(scene.Size.Width - 5, scene.Size.Height - 20);
            gr.CopyFromScreen(pos, Point.Empty, size);

            return bmpPicture;
        }
      

        private void скрытьПлоскостьюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var btn = sender as ToolStripMenuItem;
                if (btn.Checked)
                {
                    var clip = new Clip.ClipControl() { Dock = DockStyle.Fill };
                    var clipForm = new Form()
                    {
                        Name = "clipPlaneForm",
                        TopMost = true,
                        ShowIcon = true,
                        Icon = this.Icon,
                        ClientSize = clip.Size,
                        MaximizeBox = false,
                        Text = "Сечение",
                        Owner = Application.OpenForms[0]
                    };

                    clipForm.Controls.Add(clip);

                    foreach (var item in project.GetModelSetsInfo(ObjType.Элемент3D))
                        ChangeClipMode(Scene.ClipMode.Default, item.Name);

                    clip.SwitchOnOff += (v) => 
                    {
                        if (v)
                            CreateClipPlane();
                        else
                            DeleteClipPlane();
                    };
                    clip.ChangeClipMode += (mode) =>
                    {
                        foreach (var item in project.GetModelSetsInfo(ObjType.Элемент3D))
                            ChangeClipMode((Scene.ClipMode)mode, item.Name);
                    };

                    clip.ChangeLayerThickness += (layerThickness) => advanced3DClipper.LayerThickness = layerThickness;

                    clip.SetClipPlaneEvent += (plane) =>
                    {
                        var scPlane = new Geometry.Plane(new Point3D(plane.X, plane.Y, plane.Z), plane.D);
                        DisplayClipPlaneEvent = null;
                        DisplayClipPlane(scPlane);
                    };

                    clip.RedrawClipPlane += () => DisplayObjects();

                    clipForm.FormClosing += (o, ev) =>
                    {
                        DisplayClipPlaneEvent = null;
                        DeleteClipPlane();
                        foreach (var item in project.GetModelSetsInfo(ObjType.Элемент3D))
                            ChangeClipMode(ClipMode.None, item.Name);
                        btn.Checked = false;
                        DisplayObjects();
                    };

                    clipForm.Show();
                    var location = PointToScreen(Point.Empty);
                    clipForm.Location = location;
                }
                else
                {
                    var forms = Application.OpenForms.Cast<Form>().ToList();
                    var form = forms.Find(x => x.Name == "clipPlaneForm");
                    if (form != null)
                    {
                        VBOController.DeleteVBObjects("ClipPlane");
                        form.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        /// <summary>
        /// Смена режима отсечения для 3д элементов
        /// </summary>
        /// <param name="mode">Режим отсечения</param>
        /// <param name="element3dObj">Имя объекта 3д элементов</param>
        public void ChangeClipMode(ClipMode mode, string element3dObj)
        {
            advanced3DClipper.ClipMode = mode;
            var obj = VBOController.FindVBObj(element3dObj);

            if (obj != null)
            {
                var el3d = (SurfaceObjects)obj;
                if (mode == ClipMode.None)
                {
                    el3d.ActiveDrawingObject = null;
                    GL.Disable(EnableCap.ClipPlane0);
                }
                else
                    el3d.ActiveDrawingObject = advanced3DClipper;
            }
        }

        
    }
}
