using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using BazisAvaloniaGUI.Localization;
using MaterialDB.FunctionData;
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
    internal sealed class FunctionDataBasePage : DataBasePage
    {
        public event Action OnMutationEvent;
        public FunctionDataBasePage()
        {
            Loader = new LoadFunctionDataBaseFromTextFormat();
            Saver = new SaveFunctionDataBaseToTextFormat();
        }

        public FunctionDBData Functions { get; set; }
        = new FunctionDBData() { Name = "newFuncDataBase.jsf" };

        /// <summary>
        /// Load
        /// </summary>
        public void Load(string fileName, bool addFlag)
        {
            try
            {
                var ext = Path.GetExtension(fileName);
                DataExtension = ext;

                FunctionDBData functions = new FunctionDBData();

                switch (ext)
                {
                    case ".txt":
                        var dataSet = Loader.LoadDataBase(fileName);
                        functions = ConvertToFunctions(dataSet);
                        break;
                    case ".jsf":
                        var settingsSerializer = new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.Auto,
                            Formatting = Formatting.Indented,
                        };
                        functions = JsonConvert.DeserializeObject<FunctionDBData>
                            (File.ReadAllText(fileName), settingsSerializer);
                        break;
                }

                if (addFlag)
                {
                    if (Functions == null)
                        throw new Exception(Resources.LoadDBAddIntoMissingDBException);

                    foreach (var function in functions)
                    {
                        if (!Functions.ContainsKey(function.Key))
                            Functions.Add(function.Key, function.Value);
                    }
                    OnMutationEvent?.Invoke();
                }
                else
                {
                    if (functions == null)
                        throw new Exception(Resources.LoadDBCorruptedException);
                    Functions = functions;
                    var name = Path.GetFileName(fileName);
                    Functions.Name = name;
                }

                PresentFunctions();
            }
            catch (Exception ex) { MessageBox.Show(this, ex.Message); }
        }

        public void PresentFunctions()
        {
            TreeView.ItemsSource = Functions.Values.Select(function => $"{function.Name},{function.Units}").ToList();
        }

        public void SafeDBEventHandler(string dbFullPath)
        {

            var settingsSerializer = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented
            };
            var propertyString = JsonConvert.SerializeObject(Functions, settingsSerializer);
            File.WriteAllText(dbFullPath, propertyString);
        }

        public override async void AddDB_Click(object sender, RoutedEventArgs e)
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

            if (files.Count == 0)
                return;

            Load(files[0].TryGetLocalPath(), true);

            base.AddDB_Click(sender, e);
        }

        public override async void OpenFileDB_Click(object sender, RoutedEventArgs e)
        {
            var top = TopLevel.GetTopLevel(this);
            var files = await top.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions { AllowMultiple = false });

            if (files.Count == 0)
                return;

            Load(files[0].TryGetLocalPath(), false);

            base.OpenFileDB_Click(sender, e);
        }

        private FunctionDBData ConvertToFunctions(DataSet dataSet)
        {
            var functions = new FunctionDBData();

            foreach (DataTable table in dataSet.Tables)
            {
                var tableAr = table.TableName.Split(',');
                if (!functions.ContainsKey(tableAr[0]))
                {
                    var unit = tableAr[1];
                    var propName = tableAr[0];
                    var yunit = unit.Split('-')[0];
                    var xunit = unit.Split('-').Count() == 2 ? unit.Split('-')[1] : unit.Split('-')[0];
                    var prop = new Property(propName, xunit, yunit, unit, table);

                    functions.Add(tableAr[0], prop);
                }
            }

            return functions;
        }
    }
}
