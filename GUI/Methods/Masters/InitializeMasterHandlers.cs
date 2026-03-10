using BazisGUI.Args;
using BazisGUI.Masters.Actions;
using BazisGUI.Masters.Handlers;
using BazisGUI.Masters.Interfaces;
using MasterInterface;
using MasterInterface.Interfaces;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static IronPython.Modules._ast;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public void InitializeHandlers()
        {
            handlers.Clear();

            var exceptionHandling = new Action<Action, EventArgs>((act, args) =>
            {
                try { act(); }
                catch (Exception ex) { console.PrintInfo($"В мастере произошла ошибка: {ex.Message}", Color.Red); }
            });

            handlers[typeof(IFunctionsHandling)] = CreateHandler<FunctionsHandler>(InitFuncionAction(), exceptionHandling);
            handlers[typeof(IMaterialsHandling)] = CreateHandler<MaterialsHandler>(InitMaterialAction(), exceptionHandling);
            handlers[typeof(IGroupHandling)] = CreateHandler<GroupHandler>(InitGroupAction(), exceptionHandling);
            handlers[typeof(IBaseMasterInterface)] = CreateHandler<MasterHandler>(InitMasterAction(), exceptionHandling);
            handlers[typeof(IPreparedDataLoader)] = CreateHandler<PreparedConditionsHandler>(InitPreparedConditionsAction(), exceptionHandling);
        }

        private IMasterInterfaceHandler CreateHandler<T>(IHandlerAction act, Action<Action, EventArgs> container)
            where T : IMasterInterfaceHandler, new()
        {
            var handler = new T();
            handler.SetAction(act);
            handler.SetExecuteContainer(container);
            return handler;
        }

        private FunctionAction InitFuncionAction()
        {
            var funcAct = new FunctionAction();
            funcAct.FunctionsAction = (sender, args) =>
            {
                if (project.FunctionsDB == null)
                    throw new NullReferenceException("База данных функций не загружена");
            };
            OnChangeFunctions += (s, e) => funcAct.FunctionsAction?.Invoke(s, e);
            funcAct.OnFunctionRequested += (s, e) => funcAct.FunctionsAction?.Invoke(s, new ChangeFunctionsEventArgs(project.FunctionsDB.Select(x => x.Key).ToArray()));
            OnProjectLoaded += () => OnChangeFunctions?.Invoke(this, new ChangeFunctionsEventArgs(project.FunctionsDB.Select(x => x.Key).ToArray()));

            return funcAct;
        }

        private MaterialAction InitMaterialAction()
        {
            var matAct = new MaterialAction();
            matAct.MaterialsAction = (sender, args) =>
            {
                if (project.MaterialsDB == null)
                    throw new NullReferenceException("База данных материалов не загружена");
            };
            OnChangeMaterials += (s, e) => matAct.MaterialsAction?.Invoke(s, e);
            matAct.OnMaterialsRequested += (s, e) => matAct.MaterialsAction?.Invoke(s, new ChangeMaterialsEventArgs(project.MaterialsDB.Select(x => x.Key).ToArray()));
            OnProjectLoaded += () => OnChangeMaterials?.Invoke(this, new ChangeMaterialsEventArgs(project.MaterialsDB.Select(x => x.Key).ToArray()));

            return matAct;
        }

        private GroupAction InitGroupAction()
        {
            var groupAct = new GroupAction();
            OnGroupCreated += (type, number, name) => groupAct.GroupCreationAction?.Invoke(this, new GroupCreationEventArgs(type, number, name));
            OnGroupRenamed += (type, number, name) => groupAct.GroupRenameAction?.Invoke(this, new GroupRenameEventArgs(type, number, name));
            OnGroupDeleted += (type, number) => groupAct.GroupDeleteAction?.Invoke(this, new GroupDeleteEventArgs(type, number));
            navigator.DelAllMeshEvent += () => groupAct.GroupDeleteAllAction?.Invoke(this, new GroupDeleteAllEventArgs());
            navigator.DelAllGroupsEvent += () => groupAct.GroupDeleteAllAction?.Invoke(this, new GroupDeleteAllEventArgs());

            groupAct.OnGroupsFillingRequested += (s, e) => groupAct.GroupInitializeAction?.Invoke(s, new GroupInitializeEventArgs(FillingGroups()));
            OnProjectLoaded += () =>  groupAct.GroupInitializeAction?.Invoke(this, new GroupInitializeEventArgs(FillingGroups()));

            return groupAct;


            Dictionary<ObjType, Dictionary<int, string>> FillingGroups()
            {
                var dict = new Dictionary<ObjType, Dictionary<int, string>>
                    {
                        { ObjType.Узел, new Dictionary<int, string>() },
                        { ObjType.Элемент1D, new Dictionary<int, string>() },
                        { ObjType.Элемент2D, new Dictionary<int, string>() },
                        { ObjType.Элемент3D, new Dictionary<int, string>() }
                    };
                foreach (var item in project.GetAllModelGroups())
                    dict[item.ObjType][item.Number] = item.Name;

                return dict;
            }
        }

        private MasterAction InitMasterAction()
        {
            var masterAct = new MasterAction();
            masterAct.PrintInfoAction += (s, e) =>
                console.PrintInfo(e.Message, e.Color);
            masterAct.UpdateSceneAction += (s, e) =>
            {
                ClearAllDataOnScene();
                foreach (var item in Enum.GetValues<ObjType>())
                    CreateVBObjsByObjsType(item);
            };
            masterAct.GenerateConditionsAction += (s, e) =>
            {
                var res = MessageBox.Show("Генерация граничных условий приведет к удалению старых условий, если они есть. Продолжить?",
                        "Внимание", MessageBoxButtons.YesNo);
                if (res == DialogResult.No)
                    return;

                project.ClearTaskData();
                foreach (var item in e.InputStrings)
                {
                    var args = item.Split(':').Select(x => x.Trim()).ToArray();
                    var kind = Enum.Parse<DataKind>(args[0]);
                    var cond = project.Create(kind, args[1]);
                    project.AddTaskData(cond);

                }
                PresentCondDataOnTree();
                console.PrintInfo("Граничные условия сформированы", Color.Green);
            };

            return masterAct;
        }

        private PreparedConditionsAction InitPreparedConditionsAction()
        {
            var preparedCondAct = new PreparedConditionsAction();
            preparedCondAct.OnConditionsRequested += (s, e) => preparedCondAct.PreparedConditionsStringsAction?.Invoke(this, new PreparedConditionsEventArgs(project.GetAllCondData().Select(x => x.ToString()).ToArray()));
            OnProjectLoaded += () => preparedCondAct.PreparedConditionsStringsAction?.Invoke(this, new PreparedConditionsEventArgs(project.GetAllCondData().Select(x => x.ToString()).ToArray()));

            return preparedCondAct;
        }
    }
}
