using Model.Interfaces;

namespace TestPropertiesPanel.PropertiesPanel
{
    public partial class PropertiesPanelControl : UserControl
    {
        public PropertiesPanelControl()
        {
            InitializeComponent();
        }

        public void HandleDraw<T>(PropertyDataService<T> e) where T : IModelObject
        {
            dataGridView1.DataSource = null; // Очищаем DataGridView перед добавлением новых данных

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
