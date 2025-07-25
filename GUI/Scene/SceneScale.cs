
using BazisGUI.Scene.Interfaces;
using Geometry;
using PostProc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Tao.OpenGl;

namespace BazisGUI.Scene
{
    /// <summary>
    /// SceneScale
    /// </summary>
    public class SceneScale : ISceneScale
    {
        //private ItemRange [] items;
        //private int intervals = 10;
        /// <inheritdoc/>
        public int FontBase { get; set; }//идентификатор нужен для корректного отображения шрифтов

        /// <inheritdoc/>

        public string Title { get; set; }
        /// <inheritdoc/>
        public string Info { get; set; }

/// <inheritdoc/>

        public int Coord_X { get; set; } = 70;
        /// <inheritdoc/>
        public int Coord_Y { get; set; } = 140;

        //public SceneScale(ItemRange[] items, string genInfo, string subInfo)
        //{
        //    Title = genInfo;
        //    Info = subInfo;
        //    this.items = items;
        //    //FillRange(min, max, ranges);
        //}

        

        private void DisplayText(string str, Color color, Point3D coord)
        {
            Gl.glPushMatrix();
            Gl.glColor3b(color.R, color.G, color.B);
            Gl.glRasterPos3f(coord._x, coord._y, coord._z);
            Gl.glPushAttrib(Gl.GL_LIST_BASE);//Избегаем пересечений списков, сохраняем старую базу
            Gl.glListBase(FontBase);//Устанавливаем базу на FontBase!
            Gl.glCallLists(str.Length, Gl.GL_UNSIGNED_SHORT, str);
            Gl.glPopAttrib();//Возвращаем старую базу
            Gl.glPopMatrix();
        }
        /// <inheritdoc/>
        //public void Display(int width, int height, ItemRange[] items, Graphics g, Font font)
        //{
        //    Initialize_GUI_Plane(width, height);

        //    var lenght = height - Coord_Y - 50;
        //    var gap_Y = 2;
        //    var cellSize_Y = (lenght - ((items.Length - 1) * gap_Y)) / items.Length;

        //    var step_Y = cellSize_Y + gap_Y;

        //    DisplayScale(Coord_X, Coord_Y, gap_Y, cellSize_Y, step_Y, items);

        //    //var dec = (int)resultData.Precision;
        //    var pos_y = Coord_Y;
        //    for (int i = 0; i < items.Length; i++)
        //    {
        //        var incrY = pos_y + (step_Y / 2) - (step_Y / 2);

        //        DisplayText(items[i].Min.ToString(), Color.FromArgb(0, 0, 0), new Point3D(Coord_X + 20, incrY, -5));
        //        incrY = incrY + step_Y;
        //        DisplayText(items[i].Max.ToString(), Color.FromArgb(0, 0, 0), new Point3D(Coord_X + 20, incrY, -5));

        //        pos_y += step_Y;
        //    }

        //    SizeF messageSize = g.MeasureString(Title, font);
        //    DisplayText(Title, Color.FromArgb(0, 0, 0), new Point3D(Coord_X - messageSize.Width / 2, pos_y + 30, -5));

        //    messageSize = g.MeasureString(Info, font);
        //    DisplayText(Info, Color.FromArgb(0, 0, 0), new Point3D(Coord_X - messageSize.Width / 2, pos_y + 15, -5));
        //    Finish_GUI_Plane();
        //}

        public void DisplayScale(int x, int y, int gap_Y, int cellSize_Y, int step_Y, IEnumerable<ItemRange> items)
        {
            Gl.glPushMatrix();
            Gl.glTranslatef(x, y, -5);

            var y0 = 0;
            var y1 = cellSize_Y;

            foreach (var item in items)
            {
                var color = item.Color;
                Gl.glColor3f(color.R / 255.0f, color.G / 255.0f, color.B / 255.0f);
                Gl.glRectd(0, y0, 10, y1);

                y0 = y1 + gap_Y;
                y1 = y1 + step_Y;
            }

            Gl.glPopMatrix();
        }

        private void Initialize_GUI_Plane(int width, int height)
        {
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glPushMatrix();
            Gl.glLoadIdentity();
            Gl.glOrtho(0, width, 0, height, 0.1, 200);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glPushMatrix();
            Gl.glLoadIdentity();
        }

        private void Finish_GUI_Plane()
        {
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glPopMatrix();
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glPopMatrix();
        }
    }
}
