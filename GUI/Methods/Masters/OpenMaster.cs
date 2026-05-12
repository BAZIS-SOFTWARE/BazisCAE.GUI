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

            if (master is IMaterialsHandling mh) HandleMaterialsMaster(mh);

            if (master is IGroupHandling gh) HandleGroupsMaster(gh);

            if (master is IPreparedDataLoader pdlh) HandlePreparedDataMaster(pdlh);

            HandleBaseMaster(master);

            TabButtonsService.AddControl(master.Name, master);
        }
    }
}
