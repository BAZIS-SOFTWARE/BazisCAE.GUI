using System;
using Model.MeshObjects;
using Model.ObjectsCollections;
using BaseModule.PropertiesPanel;
using System.Collections.Generic;
using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
using System.Drawing;

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

        public void DrawPropertyOnPanel(ISetInfo obj) //создание коллекции RowProperty и отправка внутри EventArgs в PropertyPanel.DataGridView
        {
            
            List<RowProperty> list = new List<RowProperty>()
            {
                new RowProperty("   Имя",obj.Name, () => {}),
                new RowProperty("   Цвет",obj.Color.Name, () => {}),
                new RowProperty("   Представление",obj.ViewMode, () => {}),
                new RowProperty("   Тип",obj.ObjType, () => {})
            };

            Out(new DrowPropertyOnPanelEventArgs(list));
        }
    }
}
