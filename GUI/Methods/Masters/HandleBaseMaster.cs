using MasterInterface;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public void HandleBaseMaster(BaseMaster master)
        {
            master.UpdateSceneEvent += (s, e) =>
            {
                ClearAllDataOnScene();
                foreach (var item in Enum.GetValues<ObjType>())
                    CreateVBObjsByObjsType(item);
            };
            master.PrintInfoEvent += (s, e) => console.PrintInfo(e.Message, e.Color);
            master.GenerateConditionsEvent += (s, e) =>
            {
                var res = MessageBox.Show("Генерация граничных условий приведет к удалению старых условий, если они есть. Продолжить?",
                    "Внимание", MessageBoxButtons.YesNo);
                if (res == DialogResult.No)
                    return;

                project.ClearTaskData();
                foreach (var item in e.InputStrings)
                {
                    var args = item.Split(':').Select(x => x.Trim()).ToArray();
                    var kind = Enum.Parse<DataKind>(args[0]);
                    var cond = project.Create(kind, args[1]);
                    project.AddTaskData(cond);

                }
                PresentCondDataOnTree();
                console.PrintInfo("Граничные условия сформированы", Color.Green);
            };
        }
    }
}
