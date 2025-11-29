using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI
{
    public static class IOFileController
    {
        public static bool CopyFile(string fileName, string oldFolder, string newFolder)
        {
            var oldfilePath = $@"{oldFolder}\{fileName}";

            if (File.Exists(oldfilePath))
            {
                var newfilePath = $@"{newFolder}\{fileName}";

                File.Create(newfilePath).Close();
                File.Copy(oldfilePath, newfilePath, true);
                return true;
            }
            else return false;
        }
    }
}
