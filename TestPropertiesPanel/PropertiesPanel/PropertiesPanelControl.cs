using Model.MeshObjects;

namespace TestPropertiesPanel.PropertiesPanel
{
    public partial class PropertiesPanelControl : UserControl
    {
        
        public PropertiesPanelControl()
        {
            InitializeComponent();
        }

        public void HandleDrow(PropertyDataServise<Model.ModelObject> e)
        {
            
            dataGridView1.Rows.Clear();

            List<KeyValuePair<string, string>> dat1 = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Имя", e.meshObject.Name),
                new KeyValuePair<string, string>("Цвет",e.meshObject.Color.ToString()),
                new KeyValuePair<string, string>("Значение", e.meshObject.ViewMode.ToString()),
            };

            dataGridView1.DataSource = dat1;
        }
    }


}
