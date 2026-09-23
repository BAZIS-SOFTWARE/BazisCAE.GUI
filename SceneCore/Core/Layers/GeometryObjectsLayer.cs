using System;
using System.Collections.Generic;
using BazisGUI.Scene.Core.Rendering;

namespace BazisGUI.Scene.Core.Layers
{
    /// <summary>
    /// Заменяет DisplayGeometryObjectEvent. В старом коде рисование добавлялось и снималось
    /// подпиской на делегат, а скрытие искало обработчик по имени метода
    /// (BaseForm.HideGeometryObj/FindGeometryObj, GetInvocationList().Contains(searchMethod)).
    /// Здесь то же самое — явный ключ вместо поиска по имени метода делегата.
    /// </summary>
    public class GeometryObjectsLayer : ISceneLayer
    {
        public string Name => "GeometryObjects";
        public int Order { get; set; } = 20;
        public bool IsVisible { get; set; } = true;

        private readonly Dictionary<string, Action<IRenderContext>> items = new Dictionary<string, Action<IRenderContext>>();

        public void Add(string key, Action<IRenderContext> draw) => items[key] = draw;

        public bool Remove(string key) => items.Remove(key);

        public bool Contains(string key) => items.ContainsKey(key);

        public void Clear() => items.Clear();

        public void Draw(IRenderContext context)
        {
            foreach (var draw in items.Values)
                draw(context);
        }
    }
}
