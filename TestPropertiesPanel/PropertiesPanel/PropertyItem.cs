namespace TestPropertiesPanel.PropertiesPanel
{
    /// <summary>
    /// Помогает отображать свойства в DataGridView.
    /// Property — название свойства объекта.
    /// Value — его значение.
    /// 
    /// Этот класс используется в BindingList<PropertyItem>, чтобы правильно заполнять DataGridView.
    /// </summary>
    public class PropertyItem
    {
        public string Property { get; set; }
        public string Value { get; set; }

        public PropertyItem(string property, string value)
        {
            Property = property;
            Value = value;
        }
    }
}
