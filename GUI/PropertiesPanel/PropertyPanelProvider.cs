using System;
using Model.MeshObjects;
using Model.ObjectsCollections;
using BaseModule.PropertiesPanel;
using System.Collections.Generic;
using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
using System.Drawing;
using System.Windows.Forms;

namespace BazisGUI.PropertiesPanel
{
    public class PropertyPanelProvider
    {
        public event Action<ShowPropertyEventArgs> In;
        public event Action<DrowPropertyOnPanelEventArgs> Out;

        private string _parameterName = "   Имя";

        public ObjectsSet<Node> CreateTestData()
        {
            return new ObjectsSet<Node>("NameTest");

            //PropertiesPanelControl.ValueChanged += 
        }

        public void DrawPropertyOnPanel(ISetInfo obj) //создание коллекции RowProperty и отправка внутри EventArgs в PropertyPanel.DataGridView
        {
            
            List<RowProperty> list = new List<RowProperty>()
            {
                new RowProperty(_parameterName ,obj.Name, () => {}),
                new RowProperty("   Цвет",obj.Color.Name, () => {}),
                new RowProperty("   Представление",obj.ViewMode, () => {}),
                new RowProperty("   Тип",obj.ObjType, () => {})
            };

            Out(new DrowPropertyOnPanelEventArgs(list));
        }

        public bool ValidationData (string header, object oldValue, object newValue )
        {
            if (header == _parameterName)
            {
                if (newValue.ToString().Contains(" ") == true)
                {
                    MessageBox.Show("Имя не должно содержать пробелов", "FormatException", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }
        public void ValueChanged (PropertyChangedEventArgs e)
        {
            MessageBox.Show($"Изменяемое значение: {e.Header} \nСтарое значение: {e.OldValue.ToString()} \nНовое значение: {e.NewValue.ToString()}");
        }
    }
}
