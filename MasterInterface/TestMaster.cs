namespace MasterInterface
{
    [Obsolete("Псоле тестирования данный контролл должен быть удален")]
    public partial class TestMaster : Master
    {
        public TestMaster()
        {
            InitializeComponent();
        }

        public override void InitialMasterFilling(IEnumerable<string> materials, IEnumerable<string> functions, Dictionary<GroupType, List<string>> groupsByObjType)
        {
            base.InitialMasterFilling(materials, functions, groupsByObjType);
        }

        public override string MasterName => "TestMaster";

        public override void AddGroup(string type, string groupName)
        {
            base.AddGroup(type, groupName);
        }

        public override void RenameGroup(string type, string oldName, string newName)
        {
            base.RenameGroup(type, oldName, newName);
        }

        public override void DeleteGroup(string type, string groupName)
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
