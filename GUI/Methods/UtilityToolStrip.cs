using BaseModule;
using BaseModule.Console;
using BaseModule.Extensions;
using BaseModule.SceenControls;
using BazisGUI.Scene;
using BazisGUI.Scene.Interfaces;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.OpenGl;

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
                        ShowIcon = false,
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

                    var measuringControl = new MeasuringSet() { Dock = DockStyle.Fill };
                    measuringControl.PreparingMeasureEvent += (ar) =>
                    {
                        spbSelectObject.ToolTipText = ar.ToString();
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
                    console.PrintInfo($"Расстояние : {line.GetLength()}", Color.Black);
                    DisplayDistance(line);
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
            var objs = project.ModelData.ObjectData.GetObjects(arg2.ToEnum<ObjType>());
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
            var objs = project.ModelData.ObjectData.GetObjects(arg2.ToEnum<ObjType>());

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

            project.ModelData.ObjectData.SetBackColor(objType);

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
            var objs = project.ModelData.ObjectData.GetObjects(objType);
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
            var objs = project.ModelData.ObjectData.GetObjects(ObjType.Узел);
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

        public void CreateScreenShot(string fileName)
        {
            this.BringToFront();
            var bmpPicture = new Bitmap(Width, Height);
            var gr = Graphics.FromImage(bmpPicture);
            var pos = PointToScreen(Point.Empty);
            var size = new Size(Size.Width - 5, Size.Height - 20);
            gr.CopyFromScreen(pos, Point.Empty, size);

            bmpPicture.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
        }

        private void отзеркаливаниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var btn = sender as ToolStripButton;
                if (btn.Checked)
                {
                    var reflect = new ReflectControl();
                    reflect.SetGlObjs(VBOController.GetVBObjs().Select(x => x.ObjName));

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
                        SetBackColorToAllObjects();

                        var vbo = VBOController.FindVBObj(ar);

                        //var a = (int)vbo.PointsColors[0];
                        //var r = (int)vbo.PointsColors[1];
                        //var g = (int)vbo.PointsColors[2];
                        //var b = (int)vbo.PointsColors[3];

                        //var color = Color.FromArgb(a, r, g, b);

                        //foreach (var item in reflect.GetAllSrcObjs())
                        //    ChangeVBOColor(item, color);
                        ChangeVBOColor(ar, Color.Red);
                        DisplayObjects();
                    };

                    reflect.CreateReflectObj += (ar1, ar2) =>
                    {
                        var copyObjs = VBOController.GetVBObjs().Where(x => x.ObjName.Contains($"{ar1}_copy")).
                        Select(x => x.ObjName);
                        CreateReflectedVBObject(ar1, $"{ar1}_copy_{copyObjs.Count() + 1}", ar2);
                        reflect.SetGlObjs(copyObjs);
                        DisplayObjects();
                    };

                    reflect.MatrixEvent += (s, ev) =>
                    {
                        var obj = VBOController.FindVBObj(s);
                        ev.Matrix = obj.ModelMatrix;
                    };

                    reflect.UpdateReflectPlane += (s, p) =>
                    {
                        DisplayReflectionPlane(s, p);
                        DisplayObjects();
                    };

                    reflectForm.FormClosing += (o, ev) =>
                    {
                        btn.Checked = false;
                        DisplayReflectionPlaneEvent = null;
                        VBOController.DeleteAllVBObjects();
                        //clipPlaneRenderer?.DestroyBoundingBoxVBO();
                        //PresentAllModelObjectsToScene();
                        //CreateReflectedVBObject("", "", null);
                        DisplayObjects();
                    };
                    reflectForm.Show();

                    var location = PointToScreen(Point.Empty);
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

        /// <summary>
        /// Создает зеркальную (относительно плоскости) копию вбо-объекта, если задано имя оригинала и копии и коэффициенты плоскости
        /// </summary>
        /// <param name="srcVboName">[In]Имя объекта источника или пустая строка как триггер отмены эвента рисования плоскости</param>
        /// <param name="copyVboName">[In]Имя объекта копии</param>
        /// <param name="coef">[In]Коэффициенты плоскости</param>
        public void CreateReflectedVBObject(string srcVboName, string copyVboName, float[] coef)
        {
            var normal = new Point3D(coef[0], coef[1], coef[2]);
            normal = Geometry.Vector.GetVectorNorm(normal);
            var plane = new Geometry.Plane(normal, coef[3]);

            var copyVbo = VBOController.FindVBObj(copyVboName);
            if (copyVbo != null)
                throw new Exception($"Объект с именем {copyVbo} уже существует");

            var srcVbo = VBOController.FindVBObj(srcVboName) as VBObject;

            if (srcVbo == null)
                throw new Exception($"Объект с именем {srcVbo} не существует");

            VBOController.CopyVBObjects(srcVbo, copyVboName);
            var copeVbo = VBOController.FindVBObj(copyVboName);

            var reflMatrix = GetReflectionMatrix(plane);//from stack
            //DisplayReflectionPlane(src, plane);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);//видовая и модельная матрица
            Gl.glPushMatrix();
            Gl.glLoadMatrixf(srcVbo.ModelMatrix);
            Gl.glMultMatrixf(reflMatrix);
            Gl.glGetFloatv(Gl.GL_MODELVIEW_MATRIX, copeVbo.ModelMatrix);
            Gl.glPopMatrix();
        }

        public float[] GetReflectionMatrix(Geometry.Plane plane)
        {
            var reflection = new float[16];
            var x = -plane.Normal._x;
            var y = -plane.Normal._y;
            var z = -plane.Normal._z;
            var d = plane.Shifting;
            reflection[0] = 1 - 2 * x * x;
            reflection[1] = -2 * x * y;
            reflection[2] = -2 * x * z;
            reflection[3] = 0.0f;
            reflection[4] = -2 * x * y;
            reflection[5] = 1 - 2 * y * y;
            reflection[6] = -2 * y * z;
            reflection[7] = 0.0f;
            reflection[8] = -2 * x * z;
            reflection[9] = -2 * y * z;
            reflection[10] = 1 - 2 * z * z;
            reflection[11] = 0.0f;
            reflection[12] = -2 * x * d;
            reflection[13] = -2 * y * d;
            reflection[14] = -2 * z * d;
            reflection[15] = 1.0f;
            return reflection;
        }

        private void ChangeVBOColor(string ar, Color color)
        {
            var obj = VBOController.FindVBObj(ar);

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
        private void скрытьПлоскостьюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var btn = sender as ToolStripButton;
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
                    Gl.glDisable(Gl.GL_CLIP_PLANE0);
                }
                else
                    el3d.ActiveDrawingObject = advanced3DClipper;
            }
        }

        
    }
}
