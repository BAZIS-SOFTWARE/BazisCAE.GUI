using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterInterface
{
    /// <summary>
    /// Определеные значения групп, которые принимает IMaster в работе
    /// </summary>
    public enum GroupType
    {
        Узел,
        Элемент1D,
        Элемент2D,
        Элемент3D
    }

    public static class Converter
    {
        public static GroupType GetGroupTypeFromString(string input)
        {
            if (Enum.TryParse<GroupType>(input, out GroupType res))
                return res;
            else
                throw new ArgumentException($"Не определенное значние в \"GroupType\" для \"{input}\"");
        }
    }
}
