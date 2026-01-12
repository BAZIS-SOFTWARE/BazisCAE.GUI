using MasterInterface;
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
        /// Ассоциация названий мастеров и их типов
        /// </summary>
        private readonly Dictionary<string, Type> importedMastersTypes = new Dictionary<string, Type>();

        /// <summary>
        /// Добавление пользовательских мастеров постановки задач из определенной dll
        /// </summary>
        /// <param name="dllPath">путь к dll, в которой определен(-ы) пользовательские мастера</param>
        public void ImportMasterDLL(string dllPath)
        {
            var assembly = Assembly.LoadFrom(dllPath);
            var importedMasters = new List<Type>();

            foreach (var ctrl in assembly.GetTypes())
            {
                if (typeof(IMaster).IsAssignableFrom(ctrl)
                    && typeof(UserControl).IsAssignableFrom(ctrl)
                    && !ctrl.IsAbstract
                    && !ctrl.IsInterface
                    && !importedMastersTypes.ContainsValue(ctrl))
                    importedMasters.Add(ctrl);
            }

            CreateImportedMasters(importedMasters);
        }

        private void CreateImportedMasters(List<Type> masterTypes)
        {
            if (masterTypes.Count == 0)
            {
                console.PrintInfo("В загруженной библиотеке не определены реализации интерфейса мастера" +
                    " постановки задач или реализация уже загружена", Color.DarkOrange);
                return;
            }

            foreach (var item in masterTypes)
            {
                var master = (IMaster)Activator.CreateInstance(item);
                importedMastersTypes[master.MasterName] = item;
                console.PrintInfo($"Открыт мастер {master.MasterName}", Color.Black);
                LoadMaster(master);
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

        /// <summary>
        /// Общее событие открытия импортированного мастера
        /// </summary>
        /// <param name="sender">Кнопка определения мастера</param>
        /// <param name="e">События клика</param>
        private void OpenImportedMasterMenuItem_Click(object sender, EventArgs e)
        {
            var master = (ToolStripMenuItem)sender;
            var ctrl = splitContainer3.Panel1.Controls.OfType<IMaster>().FirstOrDefault(x => x.MasterName == master.Text);

            if (project.FunctionsDB == null || project.MaterialsDB == null)
            {
                console.PrintInfo("Для открытия мастера необходимо загрузить БД материалов и функций", Color.Red);
                return;
            }

            if (!master.Checked)
            {
                if (ctrl == null)
                    LoadMaster((IMaster)Activator.CreateInstance(importedMastersTypes[master.Text]));
                else
                    ((UserControl)ctrl).BringToFront();
                master.Checked = true;
            }
            else
            {
                master.Checked = false;
                HideTabButton($"btnTab{master.Text}");
                splitContainer3.Panel1.Controls.Remove((UserControl)ctrl);
                splitContainer3.Panel1.Controls.Remove(splitContainer3.Panel1.Controls.OfType<Button>().FirstOrDefault(x => x.Name == $"btnTab{master.Text}"));
            }
        }
    }
}
