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
using System.Reflection;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        /// <summary>
        /// Ассоциация типов мастеров и их обработчиков
        /// </summary>
        private readonly Dictionary<Type, List<IMasterInterfaceHandler>> importedMastersTypes = new();

        /// <summary>
        /// Существующие обработчики для мастеров постановки задач
        /// Обработчики позволяют не переживать относительно типа интерфейса и действие обработчика благодаря 2 параметрам
        /// Обработчик - generic класс с 2-мя параметрами: интерфейс мастера, действие обработчика
        /// Таким образом, гарантируется обработка требуемым типом, а не абстрактным интерфейсом с проверкой типа
        /// Необходимо хранить тип мастера и типы его обработчиков, чтобы можно было вызывать действие обработчика как абстракцию (см OpenMaster с: 33-34)
        /// события вызываются со стороны действий (Actions) обработчиков, так как они имеют доступ к контексту приложения в файле InitializeMasterHandlers
        /// Изменение со стороны IMasterInterface не потребует изменений Actions (приложение будет собираться)
        /// Но для обработки модифицированного интерфейса нужно будет произвести модификацию обработчика и его действия (или создать новый)
        /// При добавлении нового интерфейса мастера, необходимо добавить обработчик и соответствующие ему действия (включая вызов событий со стороны BaseForm)
        /// 
        /// Точки расширения:
        /// - интерфейсы мастера в связке с обработчиком и его действием
        /// 
        /// Преимущества:
        /// - в контексте обработчика только реализация (типы определены), при подключении мастера - абстракция (интерфейс обработчика)
        /// - независимость действий обработчиков друг от друга
        /// - типабезопастность при использовании подхода
        /// - нет необходимости следить за обработчиком
        /// 
        /// Недостатки:
        /// - большое количество инфраструктурного кода
        /// - обработчики живут на протяжении жизни приложения
        /// - необходимо хранить типы мастеров вместе с их обработчиками
        /// </summary>
        private readonly Dictionary<Type, IMasterInterfaceHandler> handlers = new();


        /// <summary>
        /// Добавление пользовательских мастеров постановки задач из определенной dll
        /// </summary>
        /// <param name="dllPath">путь к dll, в которой определен(-ы) пользовательские мастера</param>
        public void ImportMasterDLL(string dllPath)
        {
            var assembly = Assembly.LoadFrom(dllPath);
            var importedMasters = new List<(Type, List<IMasterInterfaceHandler>)>();

            foreach (var ctrl in assembly.GetTypes())
            {
                Type import;
                if (typeof(BaseMaster).IsAssignableFrom(ctrl)
                    && typeof(UserControl).IsAssignableFrom(ctrl)
                    && typeof(BaseMaster) != ctrl
                    && typeof(AbstractMaster) != ctrl
                    && !ctrl.IsAbstract
                    && !ctrl.IsInterface
                    && !importedMastersTypes.ContainsKey(ctrl))
                    import = ctrl;
                else
                    continue;

                var masterHandlers = new List<IMasterInterfaceHandler>();
                foreach (var impInterface in import.GetInterfaces())
                {
                    if (typeof(IMasterInterface).IsAssignableFrom(impInterface) && typeof(IMasterInterface) != impInterface)
                        masterHandlers.Add(handlers[impInterface]);
                }
                importedMasters.Add((import, masterHandlers));
            }
            CreateImportedMasters(importedMasters);
        }

        private void CreateImportedMasters(List<(Type, List<IMasterInterfaceHandler>)> masterTypes)
        {
            try
            {
                if (masterTypes.Count == 0)
                {
                    console.PrintInfo("В загруженной библиотеке не определены реализации интерфейса мастера" +
                        " постановки задач или реализация этого мастера уже загружена", Color.DarkOrange);
                    return;
                }

                foreach (var item in masterTypes)
                {
                    var master = (BaseMaster)Activator.CreateInstance(item.Item1);
                    importedMastersTypes[item.Item1] = item.Item2;
                    OpenMaster(master);
                    console.PrintInfo($"Открыт мастер {master.MasterName}", Color.Black);
                }
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void загрузитьМастерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog() { Filter = "dll files (*.dll) |*.dll" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                    ImportMasterDLL(dialog.FileName);
            }
        }
    }
}
