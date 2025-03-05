using Geometry;
using Model;
using Model.Interfaces;
using Model.MeshObjects;
using Model.ObjectsCollections;
using TestPropertiesPanel.PropertiesPanel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestPropertiesPanel
{
    public partial class Base : Form
    {
        public event Action<PropertyDataService<IModelObject>> Drow;

        PropertiesPanelControl propetryPanel;

        public Base()
        {
            InitializeComponent();
            InitializePropetryPanel();
        }

        private void InitializePropetryPanel()
        {
            propetryPanel = new PropertiesPanelControl
            {
                Dock = DockStyle.Left,
                Width = 250
            };
            Controls.Add(propetryPanel);

            Drow += propetryPanel.HandleDraw ;
        }

        private void Base_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var set = new ObjectsSet<Model.MeshObjects.Node>("NameTest");
            ////Drow(new PropertyDataServise<Model.MeshObjects.Node>(set));
            //Drow(new PropertyDataService<Node>(set));

            var set = new ObjectsSet<Node>("NameTest");

            var dataService1 = new PropertyDataService<Node>(set);
            propetryPanel.HandleDraw(dataService1);

        }
    }
}
