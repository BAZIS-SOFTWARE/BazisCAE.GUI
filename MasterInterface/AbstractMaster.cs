using MasterInterface.Interfaces;

namespace MasterInterface
{
    public partial class AbstractMaster : BaseMaster, IFunctionsHandling, IMaterialsHandling, IGroupHandling, IPreparedDataLoader
    {
        public event EventHandler<EventArgs> OnFunctionsRequested;
        public event EventHandler<EventArgs> OnMaterialsRequested;
        public event EventHandler<EventArgs> OnGroupsRequested;
        public event EventHandler<EventArgs> PreparedDataLoaded;
        /// <summary>
        /// Названия материалов
        /// </summary>
        protected List<string> materials = new List<string>();

        /// <summary>
        /// Названия функций
        /// </summary>
        protected List<string> functions = new List<string>();

        /// <summary>
        /// Сгруппированные по типу группы (их имена)
        /// </summary>
        protected Dictionary<GroupType, Dictionary<int, string>> groups = new Dictionary<GroupType, Dictionary<int, string>>();

        public override string MasterName { get; } = "AbstractMaster";

        public AbstractMaster()
        {
            InitializeComponent();
            OnFunctionsRequested?.Invoke(this, new EventArgs());
            OnMaterialsRequested?.Invoke(this, new EventArgs());
            OnGroupsRequested?.Invoke(this, new EventArgs());
            PreparedDataLoaded?.Invoke(this, new EventArgs());
        }

        public virtual void AddGroup(GroupType type, int number, string groupName)
        {
            if (groups.ContainsKey(type))
                groups[type][number] = groupName;
            else
            {
                groups[type] = new Dictionary<int, string>();
                groups[type][number] = groupName;
            }
        }

        public virtual void RenameGroup(GroupType type, int number, string newName)
        {
            groups[type][number] = newName;
        }

        public virtual void DeleteGroup(GroupType type, int number)
        {
            groups[type].Remove(number);
        }

        public virtual void DeleteAllGroups()
        {
            groups.Clear();
        }

        public virtual void InitialGroupFilling(Dictionary<GroupType, Dictionary<int, string>> groups)
        {
            this.groups.Clear();
            foreach (var item in groups.Keys)
            {
                foreach (var group in groups[item])
                {
                    if (!this.groups.ContainsKey(item))
                        this.groups[item] = new Dictionary<int, string>();

                    this.groups[item][group.Key] = group.Value;
                }
            }
        }

        public virtual void SetFunctions(IEnumerable<string> functions)
        {
            this.functions.Clear();
            this.functions.AddRange(functions);
        }

        public virtual void SetMaterials(IEnumerable<string> materials)
        {
            this.materials.Clear();
            this.materials.AddRange(materials);
        }

        public virtual void SetDataFromConditionsStrings(IEnumerable<string> strings)
        {

        }
    }
}
