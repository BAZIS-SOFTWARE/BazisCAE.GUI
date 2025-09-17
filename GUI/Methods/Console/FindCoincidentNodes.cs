using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Interfaces;
using System.Drawing;
using System.Windows.Forms;
using BaseModule.Navigator;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private async Task FindCoincidentNodes()
        {
            if (project == null)
                return;
            Invoke(new Action(() => { console.PrintInfo("Выполняется поиск совпадающих узлов сетки...", Color.Black); }));

            var nodes = project.ModelData.ObjectData.NodesSet;
            var coincidentNodes = project.FindCoincidentObjects(ObjType.Узел, 0.1f);

            Invoke(new Action(() => { console.PrintInfo($"Найдено {coincidentNodes.Count()} совпадений", Color.Black); }));
            Invoke(new Action(() =>
            {
                ClearAllDataOnScene();
                var pres = project.CreateModelObjectsPresentor(ObjType.Узел);
                CreateVBObject(pres);
                DisplayObjects();
            }));
            var actConfirm = new Func<Tuple<bool, object>>(() =>
            {
                project.MergeNodes(coincidentNodes);

                Invoke(new Action(() =>
                {
                    var set = project.ModelData.ObjectData.GetSetsInfo(ObjType.Узел).First();

                    navigator.TrySearchNodes(NodeName.сетка, out List<TreeNode> objects);
                    objects[0].Nodes[0].Nodes[0].Text = $"{set.Name} : {set.NumberOfObjects}";
                    console.PrintInfo("Узлы слиты", Color.Green);

                }));
                return new Tuple<bool, object>(true, new object());
            });

            var actBreak = new Action(() =>
            {
                Invoke(new Action(() =>
                {
                    console.PrintInfo("Операция отменена", Color.Black);
                }));
            });
            await AsyncMethodContainer(actConfirm, actBreak, $"Нажмите {"E"} для слияния, {"Esc"} для отмены");
        }
    }
}
