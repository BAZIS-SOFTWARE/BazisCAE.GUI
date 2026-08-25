using BazisGUI.AvaloniaUI.Measurement.Models;
using BazisGUI.AvaloniaUI.Measurement.Services;
using BazisGUI.CrossSection;
using BazisGUI.Extensions;
using BazisGUI.Properties;
using BazisGUI.Reflect;
using BazisGUI.Scene;
using BazisGUI.Scene.Interfaces;
using BazisGUI.Scene.VBO;
using BazisGUI.Utilities;
using Geometry;
using MathNet.Numerics;
using Model.GeometryObjects;
using Model.Interfaces;
using Model.Interfaces.MeshObjects;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using static IronPython.Modules.PythonCsvModule;
using OperationalController.ModelScenePresentator.GlObjsPresenters;
using OperationalController;
using OperationalController.ModelScenePresentator;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void измеритьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (измеритьToolStripMenuItem.Checked)
                {
                    var synchronizationContext = SynchronizationContext.Current;
                    var operationService = new SynchronizationContextMeasurementOperationService(
                        synchronizationContext,
                        RequestPrepareMeasurementObjects,
                        RequestMakeMeasurement,
                        RequestResetMeasurement);
                    MeasurementWindowService.Show(operationService, () => synchronizationContext.Post(_ => OnMeasurementWindowClosed(), null));
                }
                else
                    MeasurementWindowService.Close();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        /// <summary>
        /// Готовит сцену к выбору объектов для указанного вида измерения.
        /// Вызывается в UI-потоке WinForms из окна Avalonia.
        /// </summary>
        private void RequestPrepareMeasurementObjects(MeasureKind kind)
        {
            ObjType objType = kind switch
            {
                MeasureKind.Square => ObjType.Элемент2D,
                MeasureKind.Volume => ObjType.Элемент3D,
                _ => ObjType.Узел
            };

            SelectedObjects = Converters.ConvertObjTypeToSelectionType(objType);
            DisplayGeometryObjectEvent = null;
            DisplayText3DEvent = null;
            DisplayObjects();
        }

        /// <summary>
        /// Выполняет измерение выбранного вида. Вызывается в UI-потоке WinForms
        /// из окна Avalonia по нажатию кнопки «Измерить».
        /// </summary>
        private void RequestMakeMeasurement(MeasureKind kind)
        {
            if (!Converters.TryConvertSelectionTypeToObjType(SelectedObjects, out ObjType res))
            {
                console.PrintInfo($"{Resources.UtilityToolStrip_Measuring_InvalidSeletedTypeError} \"{SelectedObjects}\"", Color.Red);
                return;
            }
            try
            {
                switch (kind)
                {
                    case MeasureKind.DistancePointToPoint:
                        DistancePointToPoint(SelectedObjects);
                        break;
                    case MeasureKind.DistancePointToPlane:
                        DistancePointToPlane(SelectedObjects);
                        break;
                    case MeasureKind.Path:
                        CreatePathAsync();
                        break;
                    case MeasureKind.Square:
                        CalcSquare(SelectedObjects);
                        break;
                    case MeasureKind.Volume:
                        CalcVolume(SelectedObjects);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        /// <summary>
        /// Сбрасывает состояние сцены после закрытия окна измерений.
        /// </summary>
        private void RequestResetMeasurement()
        {
            DisplayGeometryObjectEvent = null;
            DisplayText3DEvent = null;
            DisplayObjects();
        }

        /// <summary>
        /// Приводит состояние пункта меню измерений в соответствие с фактическим
        /// состоянием окна. Программное снятие флажка не вызывает событие
        /// <see cref="ToolStripItem.Click"/>, поэтому повторного открытия окна не происходит.
        /// Выполняется в UI-потоке WinForms.
        /// </summary>
        private void OnMeasurementWindowClosed()
        {
            if (IsDisposed || Disposing)
                return;

            измеритьToolStripMenuItem.Checked = false;
        }

        public async Task<List<IPoint>> CreatePathAsync()
        {
            var nodes = new List<IPoint>();

            var message = @"Идет построение пути...";
            console.PrintInfo(message, Color.Black);

            var path = 0.0f;
            while (true)
            {
                message = $@"Выберите {ObjType.Узел} и нажмите на клавишу ""E"" для подтверждения или клавишу ""ESC"" для отмены";
                var res = SelectObjectAsync(ObjType.Узел,message);
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
                    console.PrintInfo($"{Resources.UtilityToolStrip_Distance_Output} : { path+=line.GetLength()}", Color.Black);
                    DisplayDistance(line);

                    var coord = line.P0.Sum(line.P1).Div(2);

                    DisplayText3D(path.ToString(), Color.FromArgb(0, 0, 0), coord);

                    DisplayObjects();
                }
            }
            return nodes;
        }

        public async Task<object> SelectObjectAsync(ObjType objType,string message)
        {
            var actBreak = new Action(() =>
            {
                Invoke(new Action(() => console.PrintInfo(Resources.UtilityToolStrip_SelectObjectAsync_OperationCanceled_Message, Color.Black)));
            });

            var actPointConfirm = new Func<Tuple<bool, object>>(() =>
            {
                var objs = project.GetModelObjects(objType);

                var selObjs = objs.Where(x => x.Color == settingsConfig.SelectObjectColor);

                if (selObjs.Count() == 0)
                {
                    Invoke(new Action(() => console.PrintInfo($"{Resources.UtilityTiilStrip_SelectObjectAsync_NoObjectSelected_Message} {Localization.Localization.GetSelectionTypeLocalization(Converters.ConvertObjTypeToSelectionType(objType))}!", Color.Orange)));
                    return new Tuple<bool, object>(false, new object());
                }
                else if (selObjs.Count() > 1)
                {
                    Invoke(new Action(() => console.PrintInfo($"{Resources.UtilityTiilStrip_SelectObjectAsync_SelectOne_Message} {Localization.Localization.GetSelectionTypeLocalization(Converters.ConvertObjTypeToSelectionType(objType))}!", Color.Orange)));
                    return new Tuple<bool, object>(false, new object());
                }
                else
                {
                    var node = selObjs.First();
                    Invoke(new Action(() => console.PrintInfo($"{Resources.UtilityTiilStrip_SelectObjectAsync_Selected_Message} {Localization.Localization.GetSelectionTypeLocalization(Converters.ConvertObjTypeToSelectionType(objType))} {Resources.UtilityTiilStrip_SelectObjectAsync_WithNumber_Message} {node.Number}", Color.Green)));
                    return new Tuple<bool, object>(true, node);
                }
            });

            var pointAwait = AsyncMethodContainer(actPointConfirm, actBreak, message);
            await pointAwait;
            return pointAwait.Result;
        }

        private void CalcVolume(SelectionType selection)
        {
            var objs = project.GetModelObjects(Converters.ConvertSelectionTypeToObjType(selection));
            var selObjs = objs.Where(x => x.Color == settingsConfig.SelectObjectColor);

            var vol = 0.0f;
            foreach (var obj in selObjs)
            {
                var e3DObj = (IElement3D)obj;
                vol += (float)e3DObj.CalcVolume();
            }
            console.PrintInfo($"{Resources.UtilityToolStrip_CalcVolume_Output} : {vol}", Color.Black);
        }

        private void CalcSquare(SelectionType select)
        {
            var objs = project.GetModelObjects(Converters.ConvertSelectionTypeToObjType(select));

            var selObjs = objs.Where(x => x.Color == settingsConfig.SelectObjectColor);
            var square = 0.0;
            foreach (var obj in selObjs)
            {
                var sObj = (ISquare)obj;
                square += sObj.CalcSquare();
            }
            console.PrintInfo($"{Resources.UtilityToolStrip_CalcSquare_Output} : {square}", Color.Black);
        }

        private async void DistancePointToPlane(SelectionType objTypeStr)
        {
            var objType = Converters.ConvertSelectionTypeToObjType(objTypeStr);

            var plane = await CreateSurfaceAsync(objType);
            if (plane is null)
                return;

                project.SetModelObjectsBackColor(objType);

            var pres = project.CreateModelObjectsPresentor(objType);

            SetVBObjectAttribute(pres, "цвет");
            DisplayObjects();
            var message = $@"{Resources.UtilityToolStrip_DistancePointToPlane_InstructionPart1} {Localization.Localization.GetSelectionTypeLocalization(SelectionType.Nodes)} {Resources.UtilityToolStrip_DistancePointToPlane_InstructionPart1}";
            var res = SelectObjectAsync(objType, message);
            await res;

            if (res.Result is IPoint point)
            {
                var proj = point.Position.GetPointProectionOnPlane(plane);
                var line = new Segment3D(point.Position, proj);
                console.PrintInfo($"{Resources.UtilityToolStrip_Distance_Output} : {line.GetLength()}", Color.Black);
                DisplayDistance(line);
                DisplayObjects();
            }
        }

        private void DistancePointToPoint(SelectionType objTypeStr)
        {
            var objType = Converters.ConvertSelectionTypeToObjType(objTypeStr);
            var objs = project.GetModelObjects(objType);
            var color = settingsConfig.SelectObjectColor;
            var selObjs = objs.Where(x => x.Color == color).ToList();

            if (selObjs.Count() > 1)
            {
                var nodes = selObjs.Select(x => (IPoint)x);
                var p0 = nodes.First();
                var p1 = nodes.Last();
                var line = new Segment3D(p0.Position, p1.Position);

                console.PrintInfo($"{Resources.UtilityToolStrip_Distance_Output} : {line.GetLength()}", Color.Black);

                DisplayDistance(line);
                DisplayObjects();
            }
            else console.PrintInfo($"{Resources.UtilityToolStrip_DistancePointToPoint_EmptySelectionErrorMessage}: {Localization.Localization.GetSelectionTypeLocalization(objTypeStr)}", Color.Red);
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
                        Text = Resources.UtilityToolStrip_CrossSection_Text,
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

                    crossSection.SelectNodesEvent += () => SelectedObjects = SelectionType.Nodes;

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
                console.PrintInfo(Resources.UtilityToolStrip_CreateCrossSection_InvalidNodeNumerErrorMessage, Color.Red);
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
                        Text = Resources.UtilityToolStip_ClipForm_Text,
                        Owner = Application.OpenForms[0]
                    };

                    clipForm.Controls.Add(clip);

                    foreach (var item in project.GetModelSetsInfo(ObjType.Элемент3D))
                        ChangeClipMode(Scene.ClipMode.Default, item.Name);

                    clip.SwitchOnOff += (v) => 
                    {
                        if (v)
                        {
                            foreach (var item in project.GetModelSetsInfo(ObjType.Элемент3D))
                                ChangeClipMode(clip.Regime, item.Name);
                            CreateClipPlane();
                        }
                        else
                        {
                            DisplayClipPlaneEvent = null;
                            DeleteClipPlane();
                            foreach (var item in project.GetModelSetsInfo(ObjType.Элемент3D))
                                ChangeClipMode(ClipMode.None, item.Name);
                            btn.Checked = false;
                            DisplayObjects();
                        }
                    };
                    clip.ChangeClipMode += (mode) =>
                    {
                        foreach (var item in project.GetModelSetsInfo(ObjType.Элемент3D))
                            ChangeClipMode(mode, item.Name);
                    };

                    clip.ChangeLayerThickness += (layerThickness) => advanced3DClipper.LayerThickness = layerThickness;

                    clip.SetClipPlaneEvent += (plane) =>
                    {
                        var scPlane = new Geometry.Plane(new Point3D(plane.X, plane.Y, plane.Z), plane.D);
                        DisplayClipPlane(scPlane);
                    };

                    clip.RedrawClipPlane += () => DisplayObjects();
                    clip.Controls.Find("button2", true).First().Click += CaptureData;

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

        public void CaptureData(object sender, EventArgs e)
        {
            var dataBuffers = new List<int>();
            var tboBuffers = new List<int>();
            var queries = new List<int>();

            CreateCaptureData(dataBuffers, tboBuffers, queries);
            RunTransformFeedback(tboBuffers, queries);
            var indices = FetchData(dataBuffers, queries);
            //CreateCaptureGroups(indices);
            CreateCaptureElements(indices);
            RemoveCaptureData(dataBuffers, tboBuffers, queries);

            DisplayObjects();
        }

        private void RunTransformFeedback(List<int> tboBuffers, List<int> queries)
        {
            GL.Enable(EnableCap.RasterizerDiscard);
            var sets = project.GetModelSetsInfo(ObjType.Элемент3D).Where(v => v.ViewState).ToArray();

            for (var i = 0; i < sets.Length; ++i)
            {
                var vbo = VBOController.FindVBObj(sets[i].Name);
                if (vbo != null && vbo.ViewState)
                {
                    var last = vbo.ViewMode;
                    vbo.ViewMode = ObjView.Surface;

                    var pObj = vbo.ActiveDrawingObject as Advanced3DClipper;
                    pObj.QueryId = queries[i];
                    pObj.TBOId = tboBuffers[i];

                    vbo.Load();

                    vbo.ViewMode = last;
                    pObj.QueryId = 0;
                    pObj.TBOId = 0;
                }
            }
            GL.Disable(EnableCap.RasterizerDiscard);
        }

        /// <summary>
        /// Вариант захвата в виде видимых
        /// </summary>
        /// <param name="indices">Преобразованные индексы элементов, полученные из шейдера</param>
        private void CreateCaptureElements(List<List<int>> indices)
        {
            var index = 0;
            foreach (var set in project.GetModelSetsInfo(ObjType.Элемент3D).Where(v => v.ViewState).ToArray())
            {
                var obj = VBOController.FindVBObj(set.Name);
                var program = obj.ActiveDrawingObject;
                VBOController.DeleteVBObjects(set.Name);

                var indexSet = indices[index].ToHashSet();

                var indexElems = 0;
                var visible = 0;
                foreach(var element in project.GetModelElements(3, set.Name))
                {
                    element.ViewState = indexSet.Contains(indexElems);
                    visible += Convert.ToInt32(element.ViewState);
                    ++indexElems;
                }

                if (visible > 0)
                {
                    var presenter = project.CreateModelObjectsPresentor(set);
                    var vbo = CreateVBObject(presenter);
                    vbo.ActiveDrawingObject = program;
                    VBOController.AddVbo(vbo);
                }

                ++index;
            }
        }

        /// <summary>
        /// Вариант захвата в виде групп с презентацией в дереве
        /// </summary>
        /// <param name="indices">Преобразованные индексы элементов, полученные из шейдера</param>
        private void CreateCaptureGroups(List<List<int>> indices)
        {
            var sets = project.GetModelSetsInfo(ObjType.Элемент3D).Where(v => v.ViewState).ToArray();

            for (var i = 0; i < sets.Length; ++i)
            {
                var set = indices[i].ToHashSet();
                var elems = project.GetModelElements(3, sets[i].Name).Where((v,i) => set.Contains(i)).ToArray();

                if (elems.Length > 0)
                {
                    var grName = sets[i].Name + $"_Capture";
                    project.DeleteModelGroup(grName);
                    project.CreateGroup(grName, elems);
                }
            }

            PresentGroupDataOnTree();
        }

        private List<List<int>> FetchData(List<int> dataBuffers, List<int> queries)
        {
            var list = new List<List<int>>();
            var sets = project.GetModelSetsInfo(ObjType.Элемент3D).Where(v => v.ViewState).ToArray();

            for (var i = 0; i < sets.Length; ++i)
            {
                var vbo = VBOController.FindVBObj(sets[i].Name);
                if (vbo != null && vbo.ViewState)
                {
                    var surfVbo = vbo as SurfaceObjects;

                    var indices = new List<int>();
                    list.Add(indices);

                    var items = 0L;
                    GL.GetQueryObject(queries[i], GetQueryObjectParam.QueryResult, out items);

                    if (items > 0)
                    {
                        var size = vbo.CoordLength / 3;
                        var data = new int[size];
                        VBO.GetSubData(dataBuffers[i], 0, size * sizeof(int), data);

                        var separators = new int[surfVbo.SeparatorsLength];
                        VBO.GetSubData(surfVbo.SeparatorBuffer, 0, surfVbo.SeparatorsLength * sizeof(int), separators);

                        var inIndex = 0;
                        for (var j = 1; j < separators.Length && items > 0; ++j)
                        {
                            var minElemIndex = separators[j - 1] * 3;
                            var maxElemIndex = separators[j] * 3;

                            var minIndex = data[inIndex];
                            while (inIndex < data.Length && data[inIndex] >= minElemIndex && data[inIndex] < maxElemIndex)
                                ++inIndex;

                            var offset = inIndex < data.Length ? 0 : 1;
                            if (minIndex != data[inIndex - offset])
                            {
                                var maxIndex = data[inIndex - 1] + 1;
                                items -= (maxIndex - minIndex) / 3;
                                indices.Add(j - 1);
                            }
                        }
                    }
                }
            }
            return list;
        }

        private void RemoveCaptureData(List<int> dataBuffers, List<int> tboBuffers, List<int> queries)
        {
            var length = dataBuffers.Count;
            for (var i = 0; i < length; ++i)
            {
                GL.DeleteQuery(queries[i]);
                GL.DeleteTransformFeedback(tboBuffers[i]);
                GL.DeleteBuffer(dataBuffers[i]);
            }
        }

        private void CreateCaptureData(List<int> dataBuffers, List<int> tboBuffers, List<int> queries)
        {
            foreach (var set in project.GetModelSetsInfo(ObjType.Элемент3D))
            {
                if (set.ViewState)
                {
                    var vbo = VBOController.FindVBObj(set.Name);
                    if (vbo != null && vbo.ViewState)
                    {
                        var pObj = vbo.ActiveDrawingObject as Advanced3DClipper;

                        var data = GL.GenBuffer();
                        var dataSize = vbo.CoordLength / 3;

                        GL.BindBuffer(BufferTarget.ArrayBuffer, data);
                        GL.BufferData(BufferTarget.ArrayBuffer, dataSize * sizeof(int), nint.Zero, BufferUsageHint.DynamicCopy);
                        dataBuffers.Add(data);

                        var tbo = GL.GenTransformFeedback();
                        GL.BindTransformFeedback(TransformFeedbackTarget.TransformFeedback, tbo);
                        GL.BindBufferBase(BufferRangeTarget.TransformFeedbackBuffer, 0, data);
                        tboBuffers.Add(tbo);

                        var query = GL.GenQuery();
                        queries.Add(query);
                    }
                }
            }
        }
    }
}
