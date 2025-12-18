using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasterInterface
{
    public partial class TestMaster : Master
    {
        public TestMaster()
        {
            InitializeComponent();
        }

        public override void InitialMasterFilling(IEnumerable<string> materials, IEnumerable<string> functions, Dictionary<ObjType, List<string>> groupsByObjType)
        {
            base.InitialMasterFilling(materials, functions, groupsByObjType);
        }

        public override string MasterName => "TestMaster";

        public override void AddGroup(ObjType type, string groupName)
        {
            base.AddGroup(type, groupName);
        }

        public override void RenameGroup(ObjType type, string oldName, string newName)
        {
            base.RenameGroup(type, oldName, newName);
        }

        public override void DeleteGroup(ObjType type, string groupName)
        {
            base.DeleteGroup(type, groupName);
        }

        public override void DeleteAllGroups()
        {
            base.DeleteAllGroups();
        }

        public override void ChangeFunctions(IEnumerable<string> functions)
        {
            base.ChangeFunctions(functions);
        }

        public override void ChangeMaterials(IEnumerable<string> materials)
        {
            base.ChangeMaterials(materials);
        }
    }
}
