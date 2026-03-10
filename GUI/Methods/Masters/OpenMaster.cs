using BazisGUI.Args;
using MasterInterface;
using MasterInterface.Interfaces;
using Microsoft.Scripting.Utils;
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
        public void OpenMaster(BaseMaster master)
        {
            if (project == null) throw new Exception("Не определен проект");

            master.Dock = DockStyle.Fill;
            master.Name = $"cntr{master.MasterName}";
            master.Text = $"cntr{master.MasterName}";
            master.Size = cntrНавигатор.Size;
            master.Location = cntrНавигатор.Location;
            master.Anchor = cntrНавигатор.Anchor;

            if (master is IFunctionsHandling fh) HandleFunctionsMaster(fh);

            else if (master is IMaterialsHandling mh) HandleMaterialsMaster(mh);

            else if (master is IGroupHandling gh) HandleGroupsMaster(gh);

            else if (master is IPreparedDataLoader pdlh) HandlePreparedDataMaster(pdlh);

            else HandleBaseMaster(master);

            var btnName = $"btnTab{master.MasterName}";
            if (!splitContainer3.Panel1.Controls.ContainsKey(btnName))
            {
                var btn = new Button()
                {
                    FlatStyle = FlatStyle.Flat,
                    Margin = new Padding(0, 0, 3, 3),
                    Name = $"btnTab{master.MasterName}",
                    Size = new System.Drawing.Size(27, 130),
                    TabIndex = 1,
                    Tag = "True",
                    UseVisualStyleBackColor = true,
                    Visible = true,
                };
                btn.Paint += buttonTab_Paint;
                btn.MouseDown += button_MouseDown;
                splitContainer3.Panel1.Controls.Add(btn);
            }

            splitContainer3.Panel1.Controls.Add(master);

            ShowTabButton(btnName);
            master.BringToFront();
        }
    }
}
