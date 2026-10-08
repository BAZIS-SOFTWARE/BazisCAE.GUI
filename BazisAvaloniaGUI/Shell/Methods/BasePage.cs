using Avalonia.Input;
using Avalonia.Threading;
using BazisAvaloniaGUI.Localization;
using Geometry;
using Model.Interfaces;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace BazisAvaloniaGUI.Shell
{
    internal partial class MainWindow
    {
        /// <summary>Кнопка на клавиатуре</summary>
        public Key PressedKey { get; set; }

        public async Task<Geometry.Plane> CreateSurfaceAsync(ObjType objType)
        {
            var actBreak = new Action(() =>
            {
                Dispatcher.UIThread.Invoke(new Action(() => console.PrintInfo(Resources.BasePage_CreateSurfaceAync_OperationCanceled_Message, Color.Black)));
            });
            var message = @$"{Resources.BasePage_CreateSurfaceAsync_AsyncContainer_Message}";
            var actSurfaceConfirm = new Func<Tuple<bool, object>>(() =>
            {
                var selObjs = project.GetSelection()
                    .Where(x => x.ObjType == objType)
                    .ToArray();

                if (selObjs.Length < 3)
                {
                    Dispatcher.UIThread.Invoke(new Action(() => console.PrintInfo(Resources.BasePage_CreateSurfaceAsync_SelectThreeNodes_Message, Color.Orange)));
                    return new Tuple<bool, object>(false, new object());
                }
                else if (objType != ObjType.Узел & objType != ObjType.Точка)
                {
                    Dispatcher.UIThread.Invoke(new Action(() => console.PrintInfo(Resources.BasePage_CreateSurfaceAsync_SelectNodeType_Message, Color.Orange)));
                    return new Tuple<bool, object>(false, new object());
                }
                else
                {
                    var p0 = selObjs[0];
                    var p1 = selObjs[1];
                    var p2 = selObjs[2];

                    var plane = new Geometry.Plane(p0.CalcCentr(), p1.CalcCentr(), p2.CalcCentr());
                    Dispatcher.UIThread.Invoke(new Action(() => console.PrintInfo(Resources.BasePage_CreateSurfaceAsync_SurfaceSet_Message, Color.Green)));
                    return new Tuple<bool, object>(true, plane);
                }
            });
            // TODO: придумать, как решить проблему upcast-а ниже (мб передан null)
            var surfaceAwait = AsyncMethodContainer(actSurfaceConfirm, actBreak, message);
            await surfaceAwait;
            return (Geometry.Plane)surfaceAwait.Result;
        }

        public async Task<object> AsyncMethodContainer(Func<Tuple<bool, object>> actConfirm, Action actBreak, string cmdMessage)
        {
            object resObject = null;
            PressedKey = Key.None;
            Dispatcher.UIThread.Invoke(new Action(() =>
            {

                var color = GetTextColor();

                DisplayText2D(cmdMessage, color, new Point2D(10, 10));
                RequestRedraw();
            }));
            await System.Threading.Tasks.Task.Run(() =>
            {
                while (true)
                {
                    if (PressedKey == Key.E)
                    {
                        var resAction = actConfirm.Invoke();
                        if (resAction.Item1)
                        {
                            resObject = resAction.Item2;
                            break;
                        }
                        PressedKey = Key.None;
                    }
                    if (PressedKey == Key.Escape)
                    {
                        actBreak.Invoke();
                        break;
                    }
                }
            });

            HideAllText2D();
            RequestRedraw();

            PressedKey = Key.None;
            return resObject;
        }

        private Color GetTextColor()
        {
            var backgroundBrightness = 0.299 * settingsConfig.BackGroundColor.R + 0.587 *
                settingsConfig.BackGroundColor.G + 0.114 *
                settingsConfig.BackGroundColor.B;

            if (backgroundBrightness > 125) // Или другое пороговое значение
            {
                return Color.Black; // Светлый фон -> черный шрифт
            }
            else
            {
                return Color.White; // Темный фон -> белый шрифт
            }
        }
    }
}
