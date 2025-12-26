using PreProc.Interfaces;
using PreProc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using BazisGUI.Navigator;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void запуститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                project.Save(lblStatus.Text);
                console.PrintInfo("Проект сохранен в " + WorkingDir, Color.Black);

                CheckProjectDataBeforeCreationTCF();

                var compDir = $@"{WorkingDir}\ComputationData";

                if (!Directory.Exists(compDir))
                    Directory.CreateDirectory(compDir);

                var result = new List<string>
            {
                $@"\\загрузка сетки и данных",
                $@"загрузить проект {lblStatus.Text}",
                /*
                $@"\\загрузка материалов",
                $@"загрузить материалы {project.Path}\{project.MaterialsDB}",
                $@"\\загрузка функций",
                $@"загрузить функции {project.Path}\{project.FunctionsDB}",
                */
                $@"\\расчет"
            };

                var tasks = new List<string>();
                navigator.TrySearchNodes(NodeName.расчеты, out List<TreeNode> task);
                foreach (TreeNode item in task[0].Nodes)
                    tasks.Add("расчет " + item.Text);

                result.AddRange(tasks);

                var cmdFile = $@"{compDir}\computation.tcf";

                File.WriteAllLines(cmdFile, result);

                console.PrintInfo($"Сформирован командный файл {cmdFile}", Color.Green);

                StartComputation();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void CheckProjectDataBeforeCreationTCF()
        {
            try
            {
                if (!File.Exists($@"{lblStatus.Text}"))
                    throw new Exception($"В папке проекта {WorkingDir} отсутствует файл проекта {project.Name}.");

                var mat = Path.Combine(WorkingDir, project.MaterialsDB.Name);
                if (!File.Exists(mat))
                    throw new Exception($"В папке проекта {WorkingDir} отсутствует файл материалов {project.MaterialsDB.Name}.");

                var func = Path.Combine(WorkingDir, project.FunctionsDB.Name);
                if (!File.Exists(func))
                    throw new Exception($"В папке проекта {WorkingDir} отсутствует файл функций {project.FunctionsDB.Name}.");

            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        public void StartComputation()
        {
            try
            {
                var myProcess = new Process();

                myProcess.StartInfo.FileName = settingsConfig.SolverPath;

                var cmdFile = Path.Combine(WorkingDir, "ComputationData", "computation.tcf");

                var argStr = string.Join(" ", new string[] { cmdFile });

                myProcess.StartInfo.Arguments = argStr;
                myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                myProcess.Start();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }


        private void остановитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var runProc = Process.GetProcessesByName("BazisSolverCP");

            if (runProc.Length != 0)
            {
                var process = new Process();
                var startInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    //Arguments = $"/C sc stop BazisSolver",
                    Arguments = $"/C taskkill /pid {runProc[0].Id} /f",
                    Verb = "runas"
                };
                process.StartInfo = startInfo;
                process.Start();
            }
        }
    }
}
