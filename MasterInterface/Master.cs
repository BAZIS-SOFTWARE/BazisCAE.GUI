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
        private Dictionary<int, string> groups = new Dictionary<int, string>();

        public event Action<string, Color> PrintInfoEvent;
        public event Action<string[]> SubmintParametrizedStringsEvent;
        public event Action UpdateSceneEvent;

        public virtual string MasterName { get; }

        public virtual void AddGroup(int number, string groupName)
        {
            groups[number] = groupName;
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

        public virtual void DeleteGroup(int number)
        {
            groups.Remove(number);
        }

        public virtual void DeleteAllGroups()
        {
            groups.Clear();
        }

        public virtual void InitialMasterFilling(IEnumerable<string> materials, IEnumerable<string> functions, Dictionary<int, string> groups)
        {
            this.materials.Clear();
            foreach (var material in materials)
                this.materials.Add(material);

            this.functions.Clear();
            foreach (var function in functions)
                this.functions.Add(function);

            this.groups.Clear();
            foreach (var item in groups)
                groups[item.Key] = item.Value;
        }

        public virtual void RenameGroup(int number, string newName)
        {
            groups[number] = newName;
        }
    }
}
