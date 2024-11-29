using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModule.Mesh
{
    public enum PointSizesRequest
    {
        Get,
        Set,
        Reset
    }

    public class PointSizesEventArgs
    {
        public PointSizesRequest Request { get; private set; }

        public int[] DimTags { get; private set; }

        public double[] Sizes { get; set; }

        /// <summary>
        /// Конструктор для Get запроса в gmsh
        /// </summary>
        /// <param name="dimTags">Массив пар размерность:идентификатор для которых мы хотим получить размеры</param>
        /// <param name="request">Тип запроса (получить или сбросить) для указанных пар</param>
        public PointSizesEventArgs(int[] dimTags, PointSizesRequest request)
        { 
            Request = request;
            DimTags = dimTags;
        }
    }
}
