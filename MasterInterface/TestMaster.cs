using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MasterInterface
{
    [Obsolete("Псоле тестирования данный контролл должен быть удален")]
    public partial class TestMaster : Master
    {
        public TestMaster()
        {
            InitializeComponent();
        }

        public override void InitialMasterFilling(IEnumerable<string> materials, IEnumerable<string> functions, Dictionary<int, string> groups)
        {
            base.InitialMasterFilling(materials, functions, groups);
        }

        public override string MasterName => "TestMaster";

        public override void AddGroup(int number, string groupName)
        {
            base.AddGroup(number, groupName);
        }

        public override void RenameGroup(int number, string newName)
        {
            base.RenameGroup(number, newName);
        }

        public override void DeleteGroup(int number)
        {
            base.DeleteGroup(number);
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
