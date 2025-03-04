using Model;
using Model.MeshObjects;
using Model.ObjectsCollections;
using TestPropertiesPanel.PropertiesPanel;

namespace TestPropertiesPanel
{
    public partial class Base : Form
    {
        public event Action<PropertyDataServise<ModelObject>> Drow;

        public Base()
        {
            InitializeComponent();
            InitializePropetryPanel();
        }

        private void InitializePropetryPanel()
        {
            var propetryPanel = new PropertiesPanelControl
            {
                Dock = DockStyle.Left,
                Width = 250
            };
            Controls.Add(propetryPanel);

            Drow += propetryPanel.HandleDrow ;
        }

        private void Base_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var set = new ObjectsSet<Model.MeshObjects.Node>("NameTest");
            //Drow(new PropertyDataServise<Model.MeshObjects.Node>(set));
            Drow(new PropertyDataServise<Model.MeshObjects.Node>(set));
        }
    }
}
