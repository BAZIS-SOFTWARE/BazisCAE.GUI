using Model.Interfaces;

namespace MasterInterface
{
    public abstract partial class Master : UserControl, IMaster
    {
        public Master()
        {
            InitializeComponent();
        }

        public event Action<string, Color> PrintInfoEvent;
        public event Action<string[]> SubmintParametrizedStringsEvent;
        public event Action UpdateSceneEvent;

        public virtual string MasterName { get; }

        public virtual void AddGroup(ObjType type, string groupName)
        {
            throw new NotImplementedException();
        }

        public virtual void ChangeFunctions(IEnumerable<string> functions)
        {
            throw new NotImplementedException();
        }

        public virtual void ChangeMaterials(IEnumerable<string> materials)
        {
            throw new NotImplementedException();
        }

        public virtual void DeleteGroup(ObjType type, string groupName)
        {
            throw new NotImplementedException();
        }

        public virtual void InitialMasterFilling(IEnumerable<string> materials, IEnumerable<string> functions, Dictionary<ObjType, List<string>> groupsByObjType)
        {
            throw new NotImplementedException();
        }

        public virtual void RenameGroup(ObjType type, string oldName, string newName)
        {
            throw new NotImplementedException();
        }
    }
}
