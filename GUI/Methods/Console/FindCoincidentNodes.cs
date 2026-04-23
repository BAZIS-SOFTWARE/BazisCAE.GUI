using System;
using System.Linq;
using System.Threading.Tasks;
using Model.Interfaces;
using System.Drawing;
using BazisGUI.Scene.VBO;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private async Task FindCoincidentNodes(float distance)
        {
            if (project == null)
                return;
            Invoke(new Action(() => { console.PrintInfo(Localization.Localization.GetStringResourceByName("FindCoincidentNodes.Action.Message"), Color.Black); }));

            var coincidentNodes = project.FindCoincidentObjects(ObjType.Узел, distance);

            Invoke(new Action(() => { console.PrintInfo($"{Localization.Localization.GetStringResourceByName("FindCoincidentNodes.Action.Found.Message")} {coincidentNodes.Count()} {Localization.Localization.GetStringResourceByName("FindCoincidentNodes.Action.Matches.Message")}", Color.Black); }));
            Invoke(new Action(() =>
            {
                ClearAllDataOnScene();

                foreach (var item in coincidentNodes)
                    item.ForEach(x => project.GetModelObject(ObjType.Узел, x).
                    Color = settingsConfig.SelectObjectColor);

                //var ndSet = project.GetModelSetsInfo(ObjType.Узел).First();
                //var pres = project.CreateModelObjectsPresentor(ndSet);
                //SetVBObjectAttribute(pres, "цвет");

                var pres = project.CreateModelObjectsPresentor(ObjType.Узел);
                var vbo = CreateVBObject(pres);
                VBOController.AddVbo(vbo);
                DisplayObjects();
            }));
            var actConfirm = new Func<Tuple<bool, object>>(() =>
            {
                project.MergeNodes(coincidentNodes);

                Invoke(new Action(() =>
                {
                    var set = project.GetModelSetsInfo(ObjType.Узел).First();

                    //navigator.TrySearchNodes(NodeName.сетка, out List<TreeNode> objects);
                    //objects[0].Nodes[0].Nodes[0].Text = $"{set.Name} : {set.NumberOfObjects}";
                    console.PrintInfo(Localization.Localization.GetStringResourceByName("FindCoincidentNodes.ActionConfirm.MergeNodes.Message"), Color.Green);
                    PresentMeshData();
                    PresentCondDataOnTree();

                    VBOController.DeleteAllVBObjects();
                    CreateVBObjects("Объекты");
                    DisplayObjects();

                }));
                return new Tuple<bool, object>(true, new object());
            });

            var actBreak = new Action(() =>
            {
                Invoke(new Action(() => console.PrintInfo(Localization.Localization.GetStringResourceByName("FindCoincidentNodes.Action.OperationCanceled.Message"), Color.Black)));
            });
            await AsyncMethodContainer(actConfirm, actBreak, $@"{Localization.Localization.GetStringResourceByName("FindCoincidentNodes.AsyncContainer.Message")}");
        }
    }
}
