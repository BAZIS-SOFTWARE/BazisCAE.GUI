using Model.Interfaces;
using Project.Interfaces.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BaseModule.Interfaces.GeneralParams;

namespace BazisGUI.Extensions
{
    public static class StringEx
    {
        public static ObjType ToObjType(this string str)
        {
            ObjType objType;
            return Enum.TryParse(str, out objType) ? objType :
                throw new Exception($"Ошибка конвертации объектов {str}");
        }

        public static DataKind ToDataKind(this string str)
        {
            DataKind objType;
            return Enum.TryParse(str, out objType) ? objType :
                throw new Exception($"Ошибка конвертации объектов {str}");
        }
    }
}
