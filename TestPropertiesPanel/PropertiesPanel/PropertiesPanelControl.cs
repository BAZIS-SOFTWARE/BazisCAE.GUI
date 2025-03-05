using Model.Interfaces;
using Model.MeshObjects;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Reflection;

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

            dataGridView1.Rows.Clear();

            List<KeyValuePair<string, string>> dat1 = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Имя", e.meshObject.Name),
                new KeyValuePair<string, string>("Цвет",e.meshObject.Color.ToString()),
                new KeyValuePair<string, string>("Значение", e.meshObject.ViewMode.ToString()),
            };

            dataGridView1.DataSource = dat1;
        }

        //public void HandleDraw<T>(PropertyDataService<T> e) where T : IModelObject
        //{
        //    // Очищаем DataGridView перед добавлением новых данных
        //    dataGridView1.DataSource = null;

        //    // Создаём список свойств
        //    BindingList<PropertyItem> properties = new BindingList<PropertyItem>();

        //    // Используем рефлексию для получения всех свойств объекта
        //    var obj = e.meshObject;
        //    if (obj != null)
        //    {
        //        Type type = obj.GetType();
        //        PropertyInfo[] props = type.GetProperties();

        //        foreach (var prop in props)
        //        {
        //            if(prop.GetIndexParameters().Length == 0)
        //            {
        //                try
        //                {
        //                    object value = prop.GetValue(obj);
        //                    properties.Add(new PropertyItem(prop.Name, value?.ToString() ?? "null"));
        //                }
        //                catch
        //                {

        //                }
        //            }

        //        }
        //    }

        // Привязываем данные к DataGridView
        //dataGridView1.DataSource = properties;
        //}
    }
}
