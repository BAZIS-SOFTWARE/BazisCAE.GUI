using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void выбратьСопряженныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
        // TO DO

        // Нужно чтобы по клику выбирались геометрические и сеточные объекты.
        // Выбор должен быть вниз и вверх от объекта выделения.
        // Приммер:
        // кривая - вверх (поверхности куда она входит)
        // кривая - вниз (точки по которым она построена)

        // обрабатываемые сочетания
        // точки - @кривая@ - поверхность
        // @точка@ - кривые
        // кривые - @поверхность@ - объемы
        // узлы - @элемент@
        // @узел@ - элементы

        //пример как обращаться к геометрическим объектам \GUI\Methods\Scene\ContextMenu\ShowAdjac.cs
        }
    }
}
