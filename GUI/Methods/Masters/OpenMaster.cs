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
        public void OpenMaster(IMaster master)
        {
            if (project == null)
                throw new NullReferenceException("Не определен проект");

            else if (project.MaterialsDB == null)
                throw new NullReferenceException("База данных материалов не загружена");

            else if (project.FunctionsDB == null)
                throw new NullReferenceException("База данных функций не загружена");

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

                    project.ClearTaskData();
                    foreach (var item in inputStrings)
                    {
                        var args = item.Split(':').Select(x => x.Trim()).ToArray();
                        var kind = Enum.Parse<DataKind>(args[0]);
                        var cond = project.Create(kind, args[1]);
                        project.AddTaskData(cond);
                        
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

            // заставляем реагировать на создание групп
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
            // заставляем реагировать на переименование групп
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
            // заставляем реагировать на удаление групп
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
            // заставляем реагировать на удаление всех групп
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

            // заставляем реагировать на изменение функций

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

            // заставляем реагировать на изменение материалов

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

            FillMasterByProject(master);

            var btnName = $"btnTab{master.MasterName}";
            if (!splitContainer3.Panel1.Controls.ContainsKey(btnName))
            {

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
                splitContainer3.Panel1.Controls.Add(btn);
            }

            // заставляем реагировать на загрузку проекта

            OnProjectLoaded += () =>
            {
                try
                {
                    FillMasterByProject(master);
                }
                catch (Exception ex)
                {
                    console.PrintInfo(ex.Message, Color.Red);
                }
            };

            splitContainer3.Panel1.Controls.Add(uc);

            ShowTabButton(btnName);
            uc.BringToFront();
        }

        private void FillMasterByProject(IMaster master)
        {
            var dict = new Dictionary<GroupType, Dictionary<int, string>>
                {
                    { GroupType.Узел, new Dictionary<int, string>() },
                    { GroupType.Элемент1D, new Dictionary<int, string>() },
                    { GroupType.Элемент2D, new Dictionary<int, string>() },
                    { GroupType.Элемент3D, new Dictionary<int, string>() }
                };
            foreach (var item in project.GetAllModelGroups())
            {
                var type = Converter.GetGroupTypeFromString(item.ObjType.ToString());
                dict[type][item.Number] = item.Name;
            }

            master.SetStringsFromCondDataStrings(project.GetAllCondData().Select(x => x.ToString()));

            master.InitialMasterFilling(
                project.MaterialsDB is null ? new string[0]: project.MaterialsDB.Select(x => x.Key),
                project.FunctionsDB is null ? new string[0]: project.FunctionsDB.Select(x => x.Key),
                dict);

        }
    }
}
