using System;
using Model.MeshObjects;
using Model.ObjectsCollections;
using BaseModule.PropertiesPanel;
using System.Collections.Generic;

namespace BazisGUI.PropertiesPanel
{
    public class PropertyPanelProvider
    {
        public event Action<ShowPropertyEventArgs> In;
        public event Action<DrowPropertyOnPanelEventArgs> Out;

        public ObjectsSet<Node> CreateTestData()
        {
            return new ObjectsSet<Node>("NameTest");
        }

        public void DrawPropertyOnPanel() // создание коллекции RowProperty и отправка внутри EventArgs в PropertyPanel.DataGridView
        {
            var set = CreateTestData();

            List<RowProperty> list = new List<RowProperty>()
            {
                new RowProperty("Имя",set.Name, () => {}),
                new RowProperty("Цвет",set.Color, () => {}),
                new RowProperty("Тип",set.ObjType, () => {})
            };

            Out(new DrowPropertyOnPanelEventArgs(list));
        } 

    }
}
