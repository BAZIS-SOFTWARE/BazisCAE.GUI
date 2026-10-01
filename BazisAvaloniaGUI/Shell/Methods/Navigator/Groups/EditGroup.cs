using Avalonia.Threading;
using BazisAvaloniaGUI.Localization;
using Model.Interfaces;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace BazisAvaloniaGUI.Shell
{
    internal partial class MainWindow
    {
        private async void EditGroup()
        {
            var ind = navigator.SelectedNode.Index;
            var group = project.GetModelGroup(ind);

            ApplySelectionColor();
            using (project.ModelView.BeginUpdate())
            {
                project.ModelView.ClearSelection();
                foreach (var objType in group.Select(x => x.ObjType).Distinct())
                {
                    var numbers = group.Where(x => x.ObjType == objType).Select(x => x.Number);
                    project.ModelView.Select(objType, numbers);
                }
            }
            await EditGroupAsync(group);

            // не очень безопасно, так как пользователь может поменять узел дерева
            // в процессе редактирования группы
            navigator.SelectedNode.Text = $"{group.Name} {group.Count}";
        }

        public async Task EditGroupAsync(IGroup group)
        {
            var actConfirm = new Func<Tuple<bool, object>>(() =>
            {
                var selObj = project.ModelView.GetSelection().ToList();

                if (selObj.Count() == 0)
                {
                    Dispatcher.UIThread.Invoke(new Action(() => console.PrintInfo(Resources.EditGroup_EditGroupAsync_NoObjectsSelected_Message, Color.Black)));
                    return new Tuple<bool, object>(false, new object());
                }
                else
                {
                    group.Clear();

                    group.AddRange(selObj);

                    Dispatcher.UIThread.Invoke(new Action(() => console.PrintInfo(Resources.EditGroup_EditGroupAsync_GroupChanged_Message, Color.Green)));
                    return new Tuple<bool, object>(true, new object());
                }
            });

            var actBreak = new Action(() =>
            {
                Dispatcher.UIThread.Invoke(new Action(() => console.PrintInfo(Resources.EditGroup_EditGroupAsync_OperationCanceled_Message, Color.Black)));
            });

            var message = $@"{Resources.EditGroup_EditGroupAsync_Preamble_Message}";

            await AsyncMethodContainer(actConfirm, actBreak, message);
        }
    }
}
