using Model.Interfaces;
using Model.Interfaces.MeshObjects;
using System.Linq;

namespace BazisAvaloniaGUI.Shell
{
    internal partial class MainWindow
    {
        private void ShowGroupWithNodes(IGroup group)
        {
            using (project.ModelView.BeginUpdate())
            {
                foreach (var iobj in group)
                {
                    var elem = (IElement)iobj;
                    project.ModelView.SetVisible(elem.ObjType, [elem.Number], true);
                    var numbers = elem.GetVertexes().Select(x => x.Number);
                    project.ModelView.SetVisible(ObjType.Узел, numbers, true);
                }
            }
        }
    }
}
