using Model.Interfaces;

namespace MasterInterface
{
    public abstract partial class Master : UserControl, IMaster
    {
        /// <summary>
        /// Названия материалов
        /// </summary>
        private List<string> materials = new List<string>();

        /// <summary>
        /// Названия функций
        /// </summary>
        private List<string> functions = new List<string>();

        /// <summary>
        /// Сгруппированные по типу группы (их имена)
        /// </summary>
        private Dictionary<ObjType, List<string>> groups = new Dictionary<ObjType, List<string>>();

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

        public virtual void DeleteAllGroups()
        {
            groups.Clear();
        }

        public virtual void InitialMasterFilling(IEnumerable<string> materials, IEnumerable<string> functions, Dictionary<ObjType, List<string>> groupsByObjType)
        {
            this.materials.Clear();
            foreach (var material in materials)
                this.materials.Add(material);

            this.functions.Clear();
            foreach (var function in functions)
                this.functions.Add(function);

            groups.Clear();
            foreach(var key in groupsByObjType.Keys)
                groups[key] = groupsByObjType[key].ToList();
        }

        public virtual void RenameGroup(ObjType type, string oldName, string newName)
        {
            throw new NotImplementedException();
        }
    }
}
