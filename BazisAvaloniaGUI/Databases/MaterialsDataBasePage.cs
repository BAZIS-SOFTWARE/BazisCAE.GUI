using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using BazisAvaloniaGUI.Localization;
using MaterialDB.MaterialData;
using Newtonsoft.Json;
using PropertiesCalculator;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BazisAvaloniaGUI.Databases
{
    internal sealed class MaterialsDataBasePage : DataBasePage
    {
        public event Action OnMutationEvent;

        public MaterialsDataBasePage()
        {
            Loader = new LoadMaterialDataBaseFromTextFormat();
            Saver = new SaveMaterialDataBaseToTextFormat();
        }

        public MaterialDBData Materials { get; set; }
        = new MaterialDBData() { Name = "newMatDataBase.jsf" };

        public void SafeDBEventHandler(string dbFullPath)
        {
            var settingsSerializer = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented
            };
            var propertyString = JsonConvert.SerializeObject(Materials, settingsSerializer);
            File.WriteAllText(dbFullPath, propertyString);
        }

        public override async void AddDB_Click(object sender, RoutedEventArgs e)
        {
            var fileName = await OpenDBFile();
            if (fileName == null)
                return;

            Load(fileName, true);

            base.AddDB_Click(sender, e);
        }

        public override async void OpenFileDB_Click(object sender, RoutedEventArgs e)
        {
            var fileName = await OpenDBFile();
            if (fileName == null)
                return;

            Load(fileName, false);

            base.OpenFileDB_Click(sender, e);
        }

        /// <summary>
        /// Load
        /// </summary>
        public void Load(string fileName, bool addFlag)
        {
            try
            {
                var ext = Path.GetExtension(fileName);
                DataExtension = ext;

                MaterialDBData materials = new MaterialDBData();

                switch (ext)
                {
                    case ".txt":
                        var dataSet = Loader.LoadDataBase(fileName);
                        materials = ConvertToMaterials(dataSet);
                        break;
                    case ".jsf":
                        var settingsSerializer = new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.Auto,
                            Formatting = Formatting.Indented,
                        };
                        materials = JsonConvert.DeserializeObject<MaterialDBData>
                            (File.ReadAllText(fileName), settingsSerializer);
                        break;
                }

                if (addFlag)
                {
                    if (Materials == null)
                        throw new Exception(Resources.LoadDBAddIntoMissingDBException);

                    foreach (var material in materials)
                    {
                        if (!Materials.ContainsKey(material.Key))
                            Materials.Add(material.Key, material.Value);
                    }
                    OnMutationEvent?.Invoke();
                }
                else
                {
                    if (materials == null)
                        throw new Exception(Resources.LoadDBCorruptedException);
                    Materials = materials;
                    var name = Path.GetFileName(fileName);
                    Materials.Name = name;
                }

                PresentMaterials();
            }
            catch (Exception ex) { MessageBox.Show(this, ex.Message); }
        }

        public void PresentMaterials()
        {
            TreeView.ItemsSource = Materials.Keys.ToList();
        }

        public MaterialDBData ConvertToMaterials(DataSet dataSet)
        {
            var materials = new MaterialDBData();

            foreach (DataTable table in dataSet.Tables)
            {
                var tableAr = table.TableName.Split(',');
                if (!materials.ContainsKey(tableAr[0]))
                {
                    var matItem = new MaterialDBItem(tableAr[0]);
                    matItem.CategoryData.Add("Общие сведения", new Category() { Name = "Общие сведения" });
                    matItem.CategoryData.Add("Тепловые свойства", new Category() { Name = "Тепловые свойства" });
                    matItem.CategoryData.Add("Механические свойства", new Category() { Name = "Механические свойства" });
                    matItem.CategoryData.Add("Металлургия", new Category() { Name = "Металлургия" });
                    materials.Add(tableAr[0], matItem);
                }

                var unit = tableAr[3];
                var propName = tableAr[2];
                var yunit = unit.Split('-')[0];
                var xunit = unit.Split('-').Count() == 2 ? unit.Split('-')[1] : unit.Split('-')[0];
                var prop = new Property(propName, xunit, yunit, unit, table);

                materials[tableAr[0]][tableAr[1]].PropertyData.Add(tableAr[2], prop);
            }
            return materials;
        }

        // Avalonia: аналог OpenFileDialog с фильтром "jsf files|txt files|All files".
        private async Task<string> OpenDBFile()
        {
            var top = TopLevel.GetTopLevel(this);
            var files = await top.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                AllowMultiple = false,
                FileTypeFilter =
                [
                    new FilePickerFileType("jsf files (*.jsf)") { Patterns = ["*.jsf"] },
                    new FilePickerFileType("txt files (*.txt)") { Patterns = ["*.txt"] },
                    FilePickerFileTypes.All
                ]
            });
            return files.Count == 0 ? null : files[0].TryGetLocalPath();
        }
    }
}
