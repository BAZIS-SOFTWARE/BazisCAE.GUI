using BazisGUI.Properties;
using BazisGUI.Scene.VBO;
using Model.Interfaces;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private async Task FindCoincidentNodes(float distance)
        {
            if (project == null)
                return;
            Invoke(new Action(() => { console.PrintInfo(Resources.FindCoincidentNodes_Action_Message, Color.Black); }));

            var coincidentNodes = project.FindCoincidentObjects(ObjType.Узел, distance);

            Invoke(new Action(() => { console.PrintInfo($"{Resources.FindCoincidentNodes_Action_Found_Message} {coincidentNodes.Count()} {Resources.FindCoincidentNodes_Action_Matches_Message}", Color.Black); }));
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
                    console.PrintInfo(Resources.FindCoincidentNodes_ActionConfirm_MergeNodes_Message, Color.Green);
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
                Invoke(new Action(() => console.PrintInfo(Resources.FindCoincidentNodes_Action_OperationCanceled_Message, Color.Black)));
            });
            await AsyncMethodContainer(actConfirm, actBreak, $@"{Resources.FindCoincidentNodes_AsyncContainer_Message}");
        }
    }
}
