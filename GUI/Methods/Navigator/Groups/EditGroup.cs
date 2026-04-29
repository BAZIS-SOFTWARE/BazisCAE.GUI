using Model.Interfaces;
using Model.Utilities;
using System;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private async void EditGroup()
        {
            var ind = navigator.SelectedNode.Index;
            var group = project.GetModelGroup(ind);
            //SelectedObjects = group.ObjType.ToString();

            foreach (var iobj in group)
                iobj.Color = settingsConfig.SelectObjectColor;

            foreach (var set in group.Select(x => project.
            GetModelSetInfo(x.ObjType, x.Number)).
            Distinct(new DefaultSetInfoComparer()))
            {
                var pres = project.CreateModelObjectsPresentor(set);
                SetVBObjectAttribute(pres, "цвет");
            }

            DisplayObjects();
            //Thread.Sleep(100);
            await EditGroupAsync(group);

            // не очень безопасно, так как пользователь может поменять узел дерева
            // в процессе редактирования группы
            navigator.SelectedNode.Text = $"{group.Name} {group.Count}";
        }

        public async Task EditGroupAsync(IGroup group)
        {
            var actConfirm = new Func<Tuple<bool, object>>(() =>
            {
                var selObj = GetModelObjects(SelectedObjects).Where(x => x.Color == settingsConfig.SelectObjectColor).ToList();

                if (selObj.Count() == 0)
                {
                    Invoke(new Action(() => console.PrintInfo(Localization.Localization.GetStringResourceByName("EditGroup.EditGroupAsync.NoObjectsSelected.Message"), Color.Black)));
                    return new Tuple<bool, object>(false, new object());
                }
                else
                {
                    group.Clear();

                    group.AddRange(selObj);

                    Invoke(new Action(() => console.PrintInfo(Localization.Localization.GetStringResourceByName("EditGroup.EditGroupAsync.GroupChanged.Message"), Color.Green)));
                    return new Tuple<bool, object>(true, new object());
                }
            });

            var actBreak = new Action(() =>
            {
                Invoke(new Action(() => console.PrintInfo(Localization.Localization.GetStringResourceByName("EditGroup.EditGroupAsync.OperationCanceled.Message"), Color.Black)));
            });

            var message = $@"{Localization.Localization.GetStringResourceByName("EditGroup.EditGroupAsync.Preamble.Message")}";

            await AsyncMethodContainer(actConfirm, actBreak, message);
        }
    }
}
