using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace BazisGUI
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //var args0 = @"-proj c:\BazisGUI\GUI\Projects\Welding\Arc\proj.bpf";
            Application.Run(new BaseForm(args));
        }
    }
}
