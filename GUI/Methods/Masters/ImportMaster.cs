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
