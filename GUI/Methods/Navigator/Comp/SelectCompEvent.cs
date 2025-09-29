using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using Project.TaskParameters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void Navigator_SelectInstructionEvent(NodeName arg1, string arg2)
        {
            try
            {
                var parameters = ReadTaskParametersFromFile(arg2.Split(' ')[1]);
                bool isExe;
                 if (arg2.Split(' ')[2] == "выполнить")
                    isExe = true;
                else
                    isExe = false;
                List<RowProperty> rows = new List<RowProperty>();
                rows.Add(new RowProperty("Выполнить", isExe));
                if (parameters is ChemicalParameters cmp)
                    rows.AddRange(GetPropertyChemicalTask(cmp));
                else if (parameters is MechanicalParameters mhp)
                    rows.AddRange(GetPropertyMechanicalTask(mhp));
                else if (parameters is TermalParameters tmp)
                    rows.AddRange(GetPropertyTermalTask(tmp));

                rows.AddRange(GetPropertySolverSettings(parameters));
                rows.AddRange(GetPropertyBasic(parameters));
                rows.AddRange(GetPropertyTimeSettings(parameters));
                rows.Add(new RowProperty("Применить ко всем?", new DataGridViewButtonCellSet("Да", btn => { MessageBox.Show("okey"); })));
                propertiesPanel.DrawTable(rows);

/* TO DO
* При нажатии добавить следующие строки
Выполнить - checkBox
Применить ко всем - button (OK)
*/
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private string selectInstruction = string.Empty;
        private void Navigator_SelectAllInstructionsEvent()
        {
            try
            {
                var tasks = new List<string>();
                navigator.TrySearchNodes(NodeName.расчет, out List<TreeNode> task);
                foreach (TreeNode item in task[0].Nodes)
                    tasks.Add(item.Text);
                
                var taskType = new List<string> { "все", "термическая", "механическая", "химическая" };

                if (selectInstruction == string.Empty)
                    selectInstruction = taskType[0];

                List<RowProperty> rows = new List<RowProperty>();
                rows.Add(new RowProperty("Тип", selectInstruction, taskType));

                foreach (var taskName in tasks)
                {
                    bool isExe;
                    if (taskName.Split(' ')[2] == "выполнить")
                        isExe = true;
                    else
                        isExe = false;
                    if (selectInstruction == "все")
                    {
                        var name = Path.GetFileName(taskName.Split(' ')[1]);
                        rows.Add(new RowProperty($"Выполнять {name}", isExe));
                    }
                    else 
                    {
                        if (taskName.Contains(selectInstruction))
                        {
                            var name = Path.GetFileName(taskName.Split(' ')[1]);
                            rows.Add(new RowProperty($"Выполнять {name}", isExe));
                        }
                    }    
                }

                propertiesPanel.DrawTable(rows);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private List<RowProperty> GetPropertySolverSettings(GeneralParameters parameters) 
        {
            return new List<RowProperty>
            {
                new RowProperty("Алгоритм решения", parameters.SolverSettings.Solver, new List<string>() { "Gauss_direct", "SOR_iterative", "CG_iterative" }),
                new RowProperty("Кол-во итераций решения", parameters.SolverSettings.MaxIter),
                new RowProperty("Точность решения, у.ед.", parameters.SolverSettings.Precision),
                new RowProperty("Коэф. релаксации (w)", parameters.SolverSettings.Relaxation),
                new RowProperty("Приоритет", parameters.SolverSettings.Priority, new List<string>() {"Низкий","НижеСреднего","Средний","ВышеСреднего","Высокий","Наивысший"})            
            };
        }

        private List<RowProperty> GetPropertyBasic(GeneralParameters parameters)
        {
            return new List<RowProperty>
            {
                new RowProperty("Кол-во итераций на шаге", parameters.Iterations),
                new RowProperty("Частота сохранений, шаг", parameters.SaveRate),
                new RowProperty("Начальная температура, C°", parameters.InitTemp)
            };
        }

        private List<RowProperty> GetPropertyTimeSettings(GeneralParameters parameters)
        {
            return new List<RowProperty>
            {
                new RowProperty("Время начала, сек", parameters.TimeSettings.StartTime),
                new RowProperty("Время окончания, сек", parameters.TimeSettings.StopTime),
                new RowProperty("Начальный шаг расчета, сек", parameters.TimeSettings.InitTimeStep),
                new RowProperty("Минимальный шаг расчета, сек", parameters.TimeSettings.MinTimeStep),
                new RowProperty("Максимальный шаг расчета, сек", parameters.TimeSettings.MaxTimeStep)
            };
        }
    }
}
