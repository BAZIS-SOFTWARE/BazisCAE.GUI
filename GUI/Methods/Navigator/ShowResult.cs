using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BazisGUI.Scene;
using BazisGUI.Scene.VBO;
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
                    var scale = new SceneScale(0, 1, 2, "", "");

                    scale.Title = result.TaskKind.ToString();
                    scale.Info = $"{resName} {result.Time}";
                    scale.Coord_X = settingsConfig.Scale_X_Coord;
                    scale.Coord_Y = settingsConfig.Scale_Y_Coord;

                    if (!settingsConfig.IsScaleMaxMinManual)
                    {
                        var res = GetMaxMin(result, tableName, resName);
                        scale.FillRange(res.Item2, res.Item1, settingsConfig.Scale_Intervals);
                    }
                    else
                        scale.FillRange(settingsConfig.Scale_MinValue, settingsConfig.Scale_MaxValue, settingsConfig.Scale_Intervals);


                    ClearAllGeometryDataOnScene();
                    ClearAllMeshDataOnScene();

                    var scaleItems = GetScaleItems(scale);
                    resultsController.ResultsFieldsCreator.SetScaleItems(scaleItems);
                    resultsController.ResultsFieldsCreator.ScaleFactor = settingsConfig.Scale_scale;

                    var presenter = CreateResultsField(result, resName, tableName);
                    VBOController.DeleteAllVBObjects();
                    var vb = CreateVBObject(presenter);
                    VBOController.AddVbo(vb);
                    HideGeometryObj("DisplaySceneScale");
                    DisplaySceneScale(scale);
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
