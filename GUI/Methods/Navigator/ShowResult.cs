using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BazisGUI.Scene;
using BazisGUI.Scene.VBO;
using BazisGUI.SettingsControls;
using BazisGUI.Utilities;
using GmshApi;
using Model.GeometryObjects;
using Model.Interfaces;
using Model.Interfaces.ObjectsFinders;
using Model.MeshObjects;
using OperationalController.GmshController;
using Project.Results;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public void ShowResults(Result result, string resName)
        {
            try
            {
                var tableName = ResultType.nodes.ToString();

                if (settingsConfig.MergeResultsValue)
                    MergeResults(result);

                if (settingsConfig.ShowResultsField)
                {
                    if (!settingsConfig.IsScaleMaxMinManual)
                    {
                        var res = GetMaxMin(result, tableName, resName);
                        var intervals = settingsConfig.Scale_Intervals;
                        var pre = settingsConfig.Scale_Precision;
                        resultsController.FillRange(res.Item2, res.Item1, intervals, pre);
                        //scale.FillRange(res.Item2, res.Item1, settingsConfig.Scale_Intervals);
                    }

                    ClearAllGeometryDataOnScene();
                    ClearAllMeshDataOnScene();
                    var scaleItems = resultsController.GetItems();

                    if (показатьШкалуToolStripMenuItem.Checked)
                    {
                        HideGeometryObj("DisplaySceneScale");
                        var title = result.TaskKind.ToString();
                        var info = $"{resName} {result.Time}";
                        DisplaySceneScale(title,info);
                    }


                    resultsController.ResultsFieldsCreator.SetScaleItems(scaleItems.ToArray());
                    resultsController.ResultsFieldsCreator.ScaleFactor = settingsConfig.Scale_scale;

                    var presenter = CreateResultsField(result, resName, tableName);
                    VBOController.DeleteAllVBObjects();
                    var vb = CreateVBObject(presenter);
                    VBOController.AddVbo(vb);
                }

                if (settingsConfig.ShowNodeResultsValue)
                {
                    DisplayText3DEvent = null;
                    ShowResultValue(ResultType.nodes, resName, result);
                }


                if (settingsConfig.ShowElementsResultsValue)
                {
                    DisplayText3DEvent = null;
                    ShowResultValue(ResultType.elements, resName, result);
                }

                DisplayObjects();

            }
            catch (Exception ex)
            {
                console.PrintInfo($@"Ошибка : {ex.Message},\n Источник : {ex.Source}", Color.Red);
            }
        }
    }
}
