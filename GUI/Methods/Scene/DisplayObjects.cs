using BazisGUI.Scene;
using BazisGUI.Scene.Interfaces;
using BazisGUI.Scene.VBO;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        /// <summary>
        /// DisplayObjects. Главный метод рисования.
        /// Очистка буфера, базис/компас/точка вращения, освещение+перебор VBOController по типам,
        /// сечение и прямоугольник выделения теперь считает sceneController (GUI/Documents/scene.avalonia.md,
        /// шаг 4). DisplayGeometryObjectEvent/DisplayText3DEvent/DisplayText2DEvent оставлены —
        /// на них напрямую завязаны файлы вне Methods/Scene (см. SceneInitialization.cs).
        /// Из-за этого порядок отрисовки этих трёх событий сместился: раньше геометрия рисовалась
        /// до модельных объектов/компаса, а текст — после компаса; теперь оба блока рисуются после
        /// всего, что рисует sceneController. Тест глубины включён всегда, так что для непрозрачной
        /// геометрии (подавляющее большинство случаев) видимой разницы нет.
        /// </summary>
        public void DisplayObjects()
        {
            sceneController.DisplayObjects();

            if (settingsConfig.Transparency && !advanced3DClipper.IsEnable)
                averageColorRenderer.DoActionsBeforeDrawing(null, DrawElements.GeometryObjects);
            DisplayGeometryObjectEvent?.Invoke();
            if (settingsConfig.Transparency && !advanced3DClipper.IsEnable)
                averageColorRenderer.DoActionsAfterDrawing(null, DrawElements.GeometryObjects);

            if (settingsConfig.Transparency && !advanced3DClipper.IsEnable)
                averageColorRenderer.DoActionsBeforeDrawing(null, DrawElements.GeometryObjects);
            DisplayText3DEvent?.Invoke();
            if (settingsConfig.Transparency && !advanced3DClipper.IsEnable)
                averageColorRenderer.DoActionsAfterDrawing(null, DrawElements.GeometryObjects);

            DisplayText2DEvent?.Invoke();

            DisplayControlStatus();

            GL.Finish(); // Обработка драйвером буффера команд. См Khronos
            scene.SwapBuffers(); // Поменять местами буфферы кадров.
        }

        private void DisplayControlStatus()
        {
            var cornerRect = new ScreenRectangle() { Red = 0, Green = 0, Blue = 0 };

            cornerRect.winScrenePosit = new Point(scene.Width - 18, scene.Height - 9);
            cornerRect.winScreneCoord.X = cornerRect.winScrenePosit.X + 8;
            cornerRect.winScreneCoord.Y = cornerRect.winScrenePosit.Y - 8;
            cornerRect.Display(scene.Width, scene.Height);

            if (IsSceneExpand)
            {
                cornerRect.winScrenePosit = new Point(scene.Width - 21, scene.Height - 12);
                cornerRect.winScreneCoord.X = cornerRect.winScrenePosit.X + 8;
                cornerRect.winScreneCoord.Y = cornerRect.winScrenePosit.Y - 8;
                cornerRect.Display(scene.Width, scene.Height);
            }
        }
    }
}
