using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private async void EditGroup(int obj)
        {
            var group = project.ModelData.GroupData[obj];
            //SelectedObjects = group.ObjType.ToString();

            foreach (var iobj in group)
                iobj.Color = settingsConfig.SelectObjectColor;

            var pres = project.CreateModelObjectsPresentor(group.ObjType);
            SetVBObjectAttribute(pres, "цвет");

            DisplayObjects();

            await EditGroupAsync(group);
        }

        public async Task EditGroupAsync(IGroup group)
        {
            var actConfirm = new Func<Tuple<bool, object>>(() =>
            {
                var selObj = GetModelObjects(SelectedObjects).Where(x => x.Color == settingsConfig.SelectObjectColor).ToList();

                if (selObj.Count() == 0)
                {
                    Invoke(new Action(() =>
                    {
                        console.PrintInfo("Не выбран ни один объект!", Color.Black);
                    }));
                    return new Tuple<bool, object>(false, new object());
                }
                else
                {
                    group.Clear();

                    group.AddRange(selObj);

                    Invoke(new Action(() =>
                    {
                        console.PrintInfo("Группа изменена успешно", Color.Green);
                    }));
                    return new Tuple<bool, object>(true, new object());
                }
            });

            var actBreak = new Action(() =>
            {
                Invoke(new Action(() =>
                {
                    console.PrintInfo("Операция отменена", Color.Black);
                }));
            });

            var message = "Измените группу, добавив или удалив объекты, и нажмите на кнопку E или нажмите кнопку ESC";

            await AsyncMethodContainer(actConfirm, actBreak, message);
        }
    }
}
