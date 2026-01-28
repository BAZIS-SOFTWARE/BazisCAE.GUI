using MasterInterface;
using Microsoft.Scripting.Utils;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using Project.Tasks.FrameCreators;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        /// <summary>
        /// Загрузить реализацию мастера постановки задач
        /// </summary>
        /// <param name="master">Инициализированная реализация мастера постановки задач</param>
        public void LoadMaster(IMaster master)
        {
            try
            {
                if (project == null)
                {
                    MessageBox.Show("Не определен проект", "Ошибка");
                    return;
                }

                else if (project.MaterialsDB == null)
                {
                    console.PrintInfo($"База данных материалов не загружена", Color.Red);
                    return;
                }

                else if (project.FunctionsDB == null)
                {
                    console.PrintInfo($"База данных функций не загружена", Color.Red);
                    return;
                }

                var uc = (UserControl)master;
                uc.Dock = DockStyle.Fill;
                uc.Name = $"cntr{master.MasterName}";
                uc.Text = $"cntr{master.MasterName}";
                uc.Size = cntrНавигатор.Size;
                uc.Location = cntrНавигатор.Location;
                uc.Anchor = cntrНавигатор.Anchor;

                master.GenerateConditionsEvent += (inputStrings) =>
                {
                    try
                    {
                        var res = MessageBox.Show("Генерация граничных условий приведет к удалению старых условий, если они есть. Продолжить?", 
                            "Внимание", MessageBoxButtons.YesNo);
                        if (res == DialogResult.No)
                            return;

                        project.TaskData.Clear();
                        foreach (var item in inputStrings)
                        {
                            var args = item.Split(':').Select(x => x.Trim()).ToArray();
                            var kind = Enum.Parse<DataKind>(args[0]);
                            var data = project.TaskData.Create(kind, args[1], project.ModelData.GroupData);
                            
                            //TODO перенести в BazisCore
                            if (kind == DataKind.Нагрев)
                            {
                                var dataAr = args[1].Split(" ");
                                var MrfArgs = dataAr[2].Split(";");
                                var mrfIndex = MrfArgs.FindIndex(x => x == "MRF");
                                var lines = MrfArgs[mrfIndex + 1].Split('|');

                                var baseLine = project.ModelData.GroupData.Find(lines[0]);
                                var refLine = project.ModelData.GroupData.Find(lines[1]);

                                baseLine.SortByDistance();
                                refLine.SortByDistance();

                                var velocity = float.Parse(MrfArgs[mrfIndex + 2]);
                                var movedFrame = new MovedFrame(baseLine, refLine, velocity);

                                data.StopTime = data.StartTime + (float)Math.Round(movedFrame.CalcMotionTime(), 4);
                            }
                            project.TaskData.Add(data);
                        }
                        PresentCondDataOnTree();
                        console.PrintInfo("Граничные условия сформированы", Color.Green);
                    }
                    catch (Exception ex)
                    {
                        console.PrintInfo($"В мастере произошла ошибка: {ex.Message}", Color.Red);
                    }
                };

                master.UpdateSceneEvent += () =>
                {
                    try
                    {
                        ClearAllDataOnScene();
                        foreach (var item in Enum.GetValues<ObjType>())
                            CreateVBObjsByObjsType(item);
                    }
                    catch (Exception ex)
                    {
                        console.PrintInfo($"В мастере произошла ошибка: {ex.Message}", Color.Red);
                    }
                };

                master.PrintInfoEvent += (arg1, arg2) =>
                {
                    try
                    {
                        console.PrintInfo(arg1, arg2);
                    }
                    catch (Exception ex)
                    {
                        console.PrintInfo($"В мастере произошла ошибка: {ex.Message}", Color.Red);
                    }
                };

                OnGroupCreated += (arg1, arg2, arg3) =>
                {
                    try
                    {
                        var type = Converter.GetGroupTypeFromString(arg1.ToString());
                        master.AddGroup(type, arg2, arg3);
                    }
                    catch (Exception ex)
                    {
                        console.PrintInfo($"В мастере произошла ошибка: {ex.Message}", Color.Red);
                    }
                };

                OnGroupRenamed += (arg1, arg2, arg3) =>
                {
                    try
                    {
                        var type = Converter.GetGroupTypeFromString(arg1.ToString());
                        master.RenameGroup(type, arg2, arg3);
                    }
                    catch (Exception ex)
                    {
                        console.PrintInfo($"В мастере произошла ошибка: {ex.Message}", Color.Red);
                    }
                };

                OnGroupDeleted += (arg1, arg2) =>
                {
                    try
                    {
                        var type = Converter.GetGroupTypeFromString(arg1.ToString());
                        master.DeleteGroup(type, arg2);
                    }
                    catch (Exception ex)
                    {
                        console.PrintInfo($"В мастере произошла ошибка: {ex.Message}", Color.Red);
                    }
                };

                var deleteAllGroupsDelegate = () => 
                {
                    try
                    {
                        master.DeleteAllGroups();
                    }
                    catch (Exception ex)
                    {
                        console.PrintInfo($"В мастере произошла ошибка: {ex.Message}", Color.Red);
                    }
                };

                navigator.DelAllMeshEvent += deleteAllGroupsDelegate;
                navigator.DelAllGroupsEvent += deleteAllGroupsDelegate;

                OnChangeFunctions += (arg1) =>
                {
                    try
                    {
                        master.ChangeFunctions(arg1);
                    }
                    catch (Exception ex)
                    {
                        console.PrintInfo($"В мастере произошла ошибка: {ex.Message}", Color.Red);
                    }
                };

                OnChangeMaterials += (arg1) =>
                {
                    try
                    {
                        master.ChangeMaterials(arg1);
                    }
                    catch (Exception ex)
                    {
                        console.PrintInfo($"В мастере произошла ошибка: {ex.Message}", Color.Red);
                    }
                };

                var dict = new Dictionary<GroupType, Dictionary<int, string>>();
                foreach (var item in project.GetAllModelGroups())
                {
                    var type = Converter.GetGroupTypeFromString(item.ObjType.ToString());
                    if (!dict.ContainsKey(type))
                        dict[type] = new Dictionary<int, string>();

                    dict[type][item.Number] = item.Name;
                }

                master.InitialMasterFilling(
                    project.MaterialsDB.Select(x => x.Key),
                    project.FunctionsDB.Select(x => x.Key),
                    dict);

                var btn = new Button()
                {
                    FlatStyle = FlatStyle.Flat,
                    Margin = new Padding(0, 0, 3, 3),
                    Name = $"btnTab{master.MasterName}",
                    Size = new System.Drawing.Size(27, 130),
                    TabIndex = 1,
                    Tag = "True",
                    UseVisualStyleBackColor = true,
                    Visible = true,
                };
                btn.Paint += buttonTab_Paint;
                btn.MouseDown += button_MouseDown;

                OnProjectLoaded += () =>
                {
                    // TODO переопределить данные в мастере - удалить старое и
                    // попробовать загрузить новые

                    /*
                    HideTabButton(btn.Name);
                    splitContainer3.Panel1.Controls.Remove(btn);
                    splitContainer3.Panel1.Controls.Remove(uc);
                    foreach (ToolStripMenuItem item in мастерToolStripMenuItem.DropDownItems)
                        item.Checked = false;
                    */
                };

                splitContainer3.Panel1.Controls.Add(btn);
                splitContainer3.Panel1.Controls.Add(uc);

                ShowTabButton(btn.Name);
                uc.BringToFront();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
    }
}
