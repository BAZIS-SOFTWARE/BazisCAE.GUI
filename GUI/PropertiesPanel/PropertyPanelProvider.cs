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

        public void DrawPropertyOnPanel(ISetInfo obj) // создание коллекции RowProperty и отправка внутри EventArgs в PropertyPanel.DataGridView
        {
            
            List<RowProperty> list = new List<RowProperty>()
            {
                new RowProperty("   Имя",obj.Name, () => {}),
                new RowProperty("   Цвет",obj.Color.Name, () => {}),
                new RowProperty("   Тип",obj.ObjType, () => {})
            };

            Out(new DrowPropertyOnPanelEventArgs(list));
        }
        ////Русская локализация
        //private string GetRussianColorName(Color color)
        //{
        //    return colorNames.TryGetValue(color, out string name) ? name : "Неизвестный цвет";
        //}
        //Dictionary<Color, string> colorNames = new Dictionary<Color, string>
        //{
        //    { Color.Black, "Чёрный" },
        //    { Color.White, "Белый" },
        //    { Color.Red, "Красный" },
        //    { Color.Green, "Зелёный" },
        //    { Color.Blue, "Синий" },
        //    { Color.Yellow, "Жёлтый" },
        //    { Color.Gray, "Серый" },
        //    { Color.DarkGray, "Тёмно-серый" },
        //    { Color.LightGray, "Светло-серый" },
        //    { Color.Orange, "Оранжевый" },
        //    { Color.Pink, "Розовый" },
        //    { Color.Purple, "Фиолетовый" },
        //    { Color.Brown, "Коричневый" },
        //    { Color.Cyan, "Голубой" },
        //    { Color.Magenta, "Пурпурный" },
        //    { Color.Lime, "Лаймовый" },
        //    { Color.Olive, "Оливковый" }
        //};
    }
}
