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
        /// <summary>
        /// Загрузить реализацию мастера постановки задач
        /// </summary>
        /// <param name="master">Инициализированная реализация мастера постановки задач</param>
        public void OpenMaster(BaseMaster master)
        {
            master.Dock = DockStyle.Fill;
            master.Name = $"cntr{master.MasterName}";
            master.Text = $"cntr{master.MasterName}";
            master.Size = cntrНавигатор.Size;
            master.Location = cntrНавигатор.Location;
            master.Anchor = cntrНавигатор.Anchor;

            foreach(var implementation in importedMastersTypes[master.GetType()])
                implementation.Handle(master);

            OnProjectLoaded?.Invoke();

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
