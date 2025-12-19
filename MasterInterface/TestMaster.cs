using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MasterInterface
{
    [Obsolete("После тестирования данный контролл должен быть удален")]
    public partial class TestMaster : Master
    {
        public TestMaster()
        {
            InitializeComponent();
        }

        public override void InitialMasterFilling(IEnumerable<string> materials, IEnumerable<string> functions, Dictionary<GroupType, Dictionary<int, string>> groups)
        {
            base.InitialMasterFilling(materials, functions, groups);
        }

        public override string MasterName => "TestMaster";

        public override void AddGroup(GroupType type, int number, string groupName)
        {
            base.AddGroup(type, number, groupName);
        }

        public override void RenameGroup(GroupType type, int number, string newName)
        {
            base.RenameGroup(type, number, newName);
        }

        public override void DeleteGroup(GroupType type, int number)
        {
            base.DeleteGroup(type, number);
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
