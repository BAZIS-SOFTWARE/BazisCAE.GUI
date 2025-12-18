using MasterInterface;
using Model.Interfaces;
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
                uc.Size = cntrНавигатор.Size;
                uc.Location = cntrНавигатор.Location;
                uc.Anchor = cntrНавигатор.Anchor;

                master.SubmintParametrizedStringsEvent += (taskStrings) =>
                {
                    try
                    {
                        project.TaskData.Clear();
                        foreach (var item in taskStrings)
                        {
                            var args = item.Split(':');
                            var kind = Enum.Parse<Project.Interfaces.Tasks.DataKind>(args[0]);
                            var data = project.TaskData.Create(kind, args[1], project.ModelData.GroupData);
                            project.TaskData.Add(data);
                        }
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

                OnGroupCreated += (arg1, arg2) =>
                {
                    try
                    {
                        master.AddGroup(arg1, arg2);
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
                        master.RenameGroup(arg1, arg2, arg3);
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
                        master.DeleteGroup(arg1, arg2);
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

                var dict = new Dictionary<GroupType, List<string>>();
                foreach (var item in project.GetAllModelGroups())
                {
                    var convertedType = MasterInterface.Converter.GetGroupTypeFromString(item.ObjType.ToString());
                    if (dict.ContainsKey(convertedType))
                        dict[convertedType].Add(item.Name);
                    else
                        dict[convertedType] = new List<string> { item.Name };
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
                    HideTabButton(btn.Name);
                    splitContainer3.Panel1.Controls.Remove(btn);
                    splitContainer3.Panel1.Controls.Remove(uc);
                    foreach (ToolStripMenuItem item in мастерToolStripMenuItem.DropDownItems)
                        item.Checked = false;
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
