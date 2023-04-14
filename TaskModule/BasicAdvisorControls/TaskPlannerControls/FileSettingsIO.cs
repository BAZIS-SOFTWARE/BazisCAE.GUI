using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisorControls.TaskPlannerControls
{
    public static class FileSettingsIO
    {
        public static string ReadFromFile(string path)
        {
            try
            {
                path = path.Replace("\"","");
            var settings = new List<string>();
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;

                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        var ar = line.Split(':');
                        if (ar.Length > 1)
                        {
                            var param = ar[0].Replace(" ", "");
                            var val = ar[1].Replace(" ", "");
                            settings.Add(val);
                        }
                    }
                    sr.Close();
                }
            return string.Join(";",settings);
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static void WriteToFile(string path,string settings)
        {
            try
            {
                var strAr = settings.Split(' ');
                path = path.Replace("\"", "");
                StreamWriter sw = new StreamWriter(path,false);
                sw.WriteLine(String.Format("dxt_max : {0}", strAr[0]));
                sw.WriteLine(String.Format("dxi_max : {0}", strAr[1]));
                sw.WriteLine(String.Format("dyt_max : {0}", strAr[2]));
                sw.WriteLine(String.Format("dyi_max : {0}", strAr[3]));
                sw.WriteLine(String.Format("начальная_температура : {0}", strAr[4]));
                sw.WriteLine(String.Format("количество_итераций_задачи : {0}", strAr[5]));
                sw.WriteLine(String.Format("частота_сохранений : {0}", strAr[6]));

                sw.WriteLine(String.Format("алгоритм_решения : {0}", strAr[7]));
                sw.WriteLine(String.Format("количество_итераций_решателя : {0}", strAr[8]));
                sw.WriteLine(String.Format("точность_решения : {0}", strAr[9]));
                sw.WriteLine(String.Format("коэффициент_релаксации : {0}", strAr[10]));
                sw.WriteLine(String.Format("приоритет : {0}", strAr[11]));
                //Write a second line of text
                //Close the file
                sw.Close();
            }
            catch (Exception)
            {
                //Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
