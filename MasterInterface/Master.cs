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
        private Dictionary<GroupType, List<string>> groups = new Dictionary<GroupType, List<string>>();

        public event Action<string, Color> PrintInfoEvent;
        public event Action<string[]> SubmintParametrizedStringsEvent;
        public event Action UpdateSceneEvent;

        public virtual string MasterName { get; }

        public virtual void AddGroup(string type, string groupName)
        {
            var convertedType = Converter.GetGroupTypeFromString(type);
            groups[convertedType].Add(groupName);
        }

        public virtual void ChangeFunctions(IEnumerable<string> functions)
        {
            this.functions.Clear();
            this.functions.AddRange(functions);
        }

        public virtual void ChangeMaterials(IEnumerable<string> materials)
        {
            this.materials.Clear();
            this.materials.AddRange(materials);
        }

        public virtual void DeleteGroup(string type, string groupName)
        {
            var convertedType = Converter.GetGroupTypeFromString(type);
            groups[convertedType].Remove(groupName);
        }

        public virtual void DeleteAllGroups()
        {
            groups.Clear();
        }

        public virtual void InitialMasterFilling(IEnumerable<string> materials, IEnumerable<string> functions, Dictionary<GroupType, List<string>> groupsByObjType)
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

        public virtual void RenameGroup(string type, string oldName, string newName)
        {
            var convertedType = Converter.GetGroupTypeFromString(type);
            var index = groups[convertedType].IndexOf(oldName);
            groups[convertedType][index] = newName;
        }
    }
}
