using BazisGUI.Scene.Interfaces;
using System;
using Tao.OpenGl;
using Geometry;
using System.Drawing;
using BazisGUI.Scene.VBO;
using BazisGUI.Scene;
using System.Reflection;
using Tao.Platform.Windows;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public void SceneInitialization()
        {
            basis = new SceneBasis();
            DisplayRotationPointEvent = CreateRotationPoint();
            camera = new SceneCamera(0, 0, -5, Width, Height, 2.5f);
            UpdateProjection();
            compass = new SceneCompass();

            selectionRectangle = new ScreenRectangle();

            /*
            IntPtr hdc = Wgl.wglGetCurrentDC();
            Wgl.wglUseFontBitmapsW(hdc, 0, 1150, 1000); // Ниже заменю на проверенный корректный вызов*/

            fontBase = Gl.glGenLists(1150);//кол-во глифов (элементов для рисования букв 256 - только латиница, 1150 - поддержка еще и кирилицы)
            ChangeTextFont(fontBase);//Используем шрифт по-умолчанию
            //ChangeTextFont(fontBase, "Comic Sans", 18, FontStyle.Italic);//Проверка различного типа шрифтов
            compass.FontBase = fontBase;
            //После этого мы должны передавать fontBase в любой класс, который использует шрифты!          

            //Gle.Load();
            //AverageColorRenderer.CreateAverageColorRenderer(scene.Width, scene.Height);
            averageColorRenderer = new AverageColorRenderer(Width, Height);
            clipPlaneRenderer = new ClipPlaneRenderer();
            advanced3DClipper = new Advanced3DClipper();
            Disposed += (s, e) =>
            {
                foreach (var obj in VBOController.GetVBObjs())
                    VBO.DeleteAllBuffers(obj);
                averageColorRenderer.Dispose();
                clipPlaneRenderer.Dispose();
                advanced3DClipper.Dispose();
                Gl.glDeleteLists(fontBase, 1150);
            };
            //Disposed += (s, e) => AverageColorRenderer.Dispose();
            //Disposed += (s, e) => clipPlaneRenderer.Dispose();
            //DisplayClipPlane();//Регистрируем обработчик визуализации сечения
        }


        /// <summary>
        /// Для корректного отображения шрифтов нужен HDC окна, созданного на этапе вызова метода scene.InitializeContexts();
        /// Однако оно приватное, мы можем получить его через рефлексию
        /// </summary>
        /// <returns>IntPtr - deviceContext</returns>
        private IntPtr GetDeviceContext()
        {
            var bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            var fields = typeof(SimpleOpenGlControl).GetFields(bindingFlags);
            return (IntPtr)fields[1].GetValue(scene);//deviceContext распологается на первом индексе!
        }
        /// <summary>
        /// Использовать шрифты по умолчанию или задать свой, для отображения текста
        /// </summary>
        /// <param name="fBase">Индекс сгенерированный с помощью комманды Gl.GenLists()</param>
        /// <param name="fontFamily">Семейство шрифтов например "Times New Roman"</param>
        /// <param name="size">Размер шрифта</param>
        /// <param name="style">Курсив(Italic), жирный(Bold) и т.д</param>
        private void ChangeTextFont(int fBase, string fontFamily = "", float size = 8.25f, FontStyle style = FontStyle.Regular)
        {
            var hdc = GetDeviceContext();
            if (string.IsNullOrEmpty(fontFamily))
            {
                var status = Wgl.wglUseFontBitmapsW(hdc, 0, 1150, fBase);
            }
            else
            {
                var font = new Font(fontFamily, size, style);
                var hFont = font.ToHfont();

                //Вызов системных функций, для корректной замены шрифта!
                var oldFont = Gdi.SelectObject(hdc, hFont);//Делаем Swap шрифтов
                var status = Wgl.wglUseFontBitmapsW(hdc, 0, 1150, fBase);

                Gdi.SelectObject(hdc, oldFont);//Делаем текущим старый шрифт
                Gdi.DeleteObject(hFont);//Обязательно освобождаем неуправляемый ресурс
            }
        }
    }
}
