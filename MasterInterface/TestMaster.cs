using MasterInterface.Interfaces;
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
    public partial class TestMaster : BaseMaster, IGroupHandling, IFunctionsHandling, IMaterialsHandling, IPreparedDataLoader
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

        public TestMaster() : base()
        {
            InitializeComponent();
        }

        public override string MasterName { get; } = "TestMaster";

        public void InitialGroupFilling(Dictionary<GroupType, Dictionary<int, string>> groups)
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

            cmbGroups.Items.Clear();
            cmbGroups.Items.AddRange(groups.SelectMany(x => x.Value.Values).ToArray());
        }

        public void AddGroup(GroupType type, int number, string groupName)
        {
            groups[type][number] = groupName;
            cmbGroups.Items.Add(groupName);
        }

        public void RenameGroup(GroupType type, int number, string newName)
        {
            var oldName = groups[type][number];
            if (cmbGroups.Text == oldName)
                cmbGroups.Text = newName;

            groups[type][number] = newName;
            cmbGroups.Items.Remove(oldName);
            cmbGroups.Items.Add(newName);
        }

        public void DeleteGroup(GroupType type, int number)
        {
            var oldName = groups[type][number];
            if (cmbGroups.Text == oldName)
                cmbGroups.Text = "";
            groups[type].Remove(number);
            cmbGroups.Items.Remove(oldName);
        }

        public void DeleteAllGroups()
        {
            groups.Clear();
            cmbGroups.Items.Clear();
            cmbGroups.Text = "";
        }

        public void SetFunctions(IEnumerable<string> functions)
        {
            this.functions.Clear();
            this.functions.AddRange(functions);
            cmbFunctions.Items.Clear();
            cmbFunctions.Items.AddRange(functions.ToArray());
        }

        public void SetMaterials(IEnumerable<string> materials)
        {
            this.materials.Clear();
            this.materials.AddRange(materials);
            cmbMaterials.Items.Clear();
            cmbMaterials.Items.AddRange(materials.ToArray());
        }

        public void SetDataFromConditionsStrings(IEnumerable<string> strings)
        {
            cmbConditions.Items.Clear();
            cmbConditions.Items.AddRange(strings.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var res = new List<string>();
            foreach (var item in  cmbConditions.Items)
                res.Add(item.ToString());

            RaiseGenerateConditionsEvent(res.ToArray());
        }
    }
}
