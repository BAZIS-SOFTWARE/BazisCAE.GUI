using MasterInterface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
            var assembly = Assembly.Load(dllPath);
            var tempTypeCollection = new List<Type>();

            foreach(var type in assembly.GetTypes())
            {
                if (typeof(IMaster).IsAssignableFrom(type)
                    && typeof(UserControl).IsAssignableFrom(type)
                    && !type.IsAbstract
                    && !type.IsInterface
                    && !importedMastersTypes.ContainsValue(type))
                    tempTypeCollection.Add(type);
            }

            if (tempTypeCollection.Count == 0)
                console.PrintInfo("В загруженной библиотеке не определены реализации интерфейса мастера постановки задач", Color.DarkOrange);

            else
            {
                foreach(var item in tempTypeCollection)
                {
                    var temp = (IMaster)Activator.CreateInstance(item);
                    var masterToolStripMenuItem = new ToolStripMenuItem { Text = temp.MasterName, Name = $"{temp.MasterName}ToolStripMenuItem" };
                    masterToolStripMenuItem.Click += OpenImportedMasterMenuItem_Click;

                    мастерToolStripMenuItem.DropDownItems.Add(masterToolStripMenuItem);
                    importedMastersTypes[temp.MasterName] = item; 
                }

                console.PrintInfo($"Определено и загружено мастеров: {tempTypeCollection.Count()}", Color.Black);
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
            if (master.Checked)
            {
                if (ctrl == null)
                    LoadMaster((IMaster)Activator.CreateInstance(importedMastersTypes[master.Text]));
                else
                    ((UserControl)ctrl).BringToFront();
            }
            else
                HideTabButton($"btnTab{master.Text}");
        }
    }
}
