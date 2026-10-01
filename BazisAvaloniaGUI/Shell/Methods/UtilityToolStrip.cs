using Avalonia.Threading;
using BazisAvaloniaGUI.Localization;
using BazisAvaloniaGUI.Utilities;
using Model.Interfaces;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace BazisAvaloniaGUI.Shell
{
    // Из GUI/Methods/UtilityToolStrip.cs перенесён только SelectObjectAsync, нужный консольным командам;
    // измерения, сечения и скрытие плоскостью в Avalonia ещё не перенесены.
    internal partial class MainWindow
    {
        public async Task<object> SelectObjectAsync(ObjType objType, string message)
        {
            var actBreak = new Action(() =>
            {
                Dispatcher.UIThread.Invoke(new Action(() => console.PrintInfo(Resources.UtilityToolStrip_SelectObjectAsync_OperationCanceled_Message, Color.Black)));
            });

            var actPointConfirm = new Func<Tuple<bool, object>>(() =>
            {
                var selObjs = project.ModelView.GetSelected(objType)
                    .Select(number => project.GetModelObject(objType, number));

                if (selObjs.Count() == 0)
                {
                    Dispatcher.UIThread.Invoke(new Action(() => console.PrintInfo($"{Resources.UtilityTiilStrip_SelectObjectAsync_NoObjectSelected_Message} {Localization.Localization.GetSelectionTypeLocalization(Converters.ConvertObjTypeToSelectionType(objType))}!", Color.Orange)));
                    return new Tuple<bool, object>(false, new object());
                }
                else if (selObjs.Count() > 1)
                {
                    Dispatcher.UIThread.Invoke(new Action(() => console.PrintInfo($"{Resources.UtilityTiilStrip_SelectObjectAsync_SelectOne_Message} {Localization.Localization.GetSelectionTypeLocalization(Converters.ConvertObjTypeToSelectionType(objType))}!", Color.Orange)));
                    return new Tuple<bool, object>(false, new object());
                }
                else
                {
                    var node = selObjs.First();
                    Dispatcher.UIThread.Invoke(new Action(() => console.PrintInfo($"{Resources.UtilityTiilStrip_SelectObjectAsync_Selected_Message} {Localization.Localization.GetSelectionTypeLocalization(Converters.ConvertObjTypeToSelectionType(objType))} {Resources.UtilityTiilStrip_SelectObjectAsync_WithNumber_Message} {node.Number}", Color.Green)));
                    return new Tuple<bool, object>(true, node);
                }
            });

            var pointAwait = AsyncMethodContainer(actPointConfirm, actBreak, message);
            await pointAwait;
            return pointAwait.Result;
        }
    }
}
