using BaseModule.Mesh;
using BaseModule.Mesh.SettingsControls;
using BazisGUI.Scene;
using BazisGUI.Utilities;
using Geometry;
using GmshApi;
using Model.GeometryObjects;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security;
using System.Windows.Forms;
using static BaseModule.Interfaces.GeneralParams;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void показатьПлотностьСеткиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                HideGeometryObj("DisplaySceneScale");

                var curvesInfo = GetCurvesNumbersAndNodes();
                var max = curvesInfo.Max(x => x.Value);
                var min = curvesInfo.Min(x => x.Value);

                resultsController.FillRange(min, max, 3,2);
  
                //var scale = new SceneScale();
                //scale.FontBase = FontBase;
                //scale.Coord_X = settingsConfig.Scale_X_Coord;
                //scale.Coord_Y = settingsConfig.Scale_Y_Coord;

                DisplaySceneScale("","");

                foreach (var item in curvesInfo)
                {
                    var color = resultsController.GetValueColor(item.Value);
                    project.ModelData.ObjectData.CurveSet[item.Key].Color = color;
                }

                var linePres = presentersCreator.CreateLineObjectsPresenter(project.ModelData.ObjectData.CurveSet.Values);
                VBOController.DeleteVBObjects(ObjType.Кривая.ToString());
                CreateVBObject(linePres);
                DisplayObjects();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
//        private void mesh3DGeneratorMenuItem_Click(object sender, EventArgs e)
//        {
//            if (mesh3DGeneratorMenuItem.Checked)
//            {
//                var res = MessageBox.Show("Вы собираетесь запустить сеточный генератор. При нажатии на кнопку \"OK\" " +
//    "Все данные о задаче будут удалены!",
//"Внимание!", MessageBoxButtons.OKCancel);

//                if (res == DialogResult.OK)
//                    project.TaskData.Clear();
//                else
//                {
//                    mesh3DGeneratorMenuItem.Checked = false;
//                    return;
//                }

//                var meshGenerator = new GMSHGeneralMeshControl();

//                meshGenerator.setMeshAlgoEvent += (ar) =>
//                {
//                    gmshController.Gmsh.Option.SetNumber("Mesh.Algorithm", ar);
//                };


//                meshGenerator.delMeshGradientEvent += MeshGenerator_delMeshGradientEvent;
//                meshGenerator.showShowSurfaceNumbersEvent += MeshGenerator_showSurfaceNumbers;
//                meshGenerator.showNumberOfCurveNodesEvent += MeshGenerator_showNumberOfCurveNodes;
                
//                meshGenerator.generate2DTriangleMeshEvent += MeshGenerator_generate2DMeshEvent;
//                meshGenerator.deleteMeshEvent += MeshGenerator_deleteMeshEvent;
//                meshGenerator.showNodesOnCurvesEvent += MeshGenerator_showNodesOnCurves;
      
//                //meshGenerator.updateTreeViewEvent += () => { PresentProjectOnTree(); };
//                meshGenerator.refineMesh += MeshGenerator_refineMesh;
       
//                meshGenerator.generate2DQuadMesh += MeshGenerator_generate2DQuadMesh;

//                meshGenerator.SetCurveAttributeEvent += MeshGenerator_SetCurveAttributeEvent;
//                meshGenerator.GetCurveAttribEvent += MeshGenerator_GetCurveAttribEvent;
//                meshGenerator.CurveAttribDeleteEvent += MeshGenerator_CurveAttribDeleteEvent;

//                meshGenerator.deleteElementEvent += DeleteElementsByNumber;
//                meshGenerator.setMeshGradientSettingsEvent += MeshGenerator_setMeshGradientSettingsEvent;

//                meshGenerator.SetPointSizeEvent += SetPointSizesEventHandler;
//                meshGenerator.PointAttribDeleteEvent += MeshGenerator_PointAttribDeleteEvent;
//                meshGenerator.GetPointSizeEvent += MeshGenerator_GetPointSizeEvent;

//                meshGenerator.setMinMaxSizesEvent += SetMinMaxSizesEvent;

//                //SetGMSHController(project.ModelData);
//            }
//        }

        private void MeshGenerator_SetCurveAttributeEvent(object arg1, CurveAttribsEventArgs arg2)
        {
            GmshController.Gmsh.Model.SetAttribute($"transfinite {arg2.Tag}", arg2.Attributes);
            if (!string.IsNullOrEmpty(arg2.Attributes[0]) && !string.IsNullOrEmpty(arg2.Attributes[2]))
            {
                MeshType meshtType = (MeshType)Enum.Parse(typeof(MeshType), arg2.Attributes[1], true);
                GmshController.Gmsh.Model.Mesh.SetTransfiniteCurve(arg2.Tag, arg2.Points, meshtType, arg2.Coef);
            }
        }

        private void MeshGenerator_CurveAttribDeleteEvent(int obj)
        {
            var dimTags = new int[] { 1, obj };
            GmshController.Gmsh.Model.RemoveAttribute($"transfinite {obj}");
            GmshController.Gmsh.Model.Mesh.RemoveConstraints(dimTags);
        }

        private void MeshGenerator_GetCurveAttribEvent(object arg1, int arg2)
        {
            try
            {
                var attributes = GmshController.Gmsh.Model.GetAttribute($"transfinite {arg2}");
                var curveControl = arg1 as GMSHCurveSettingsControl;
                curveControl.SetCurveAttributes(attributes);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }

        private void MeshGenerator_PointAttribDeleteEvent(int obj)
        {
            var dimTags = new int[] { 0, obj };
            GmshController.Gmsh.Model.Mesh.RemoveConstraints(dimTags);
        }

        private void MeshGenerator_GetPointSizeEvent(object arg1, int arg2)
        {
            try
            {
                var dimTags = new int[] { 0, arg2 };
                var meshSize = GmshController.Gmsh.Model.Mesh.GetSizes(dimTags);
                var pointControl = arg1 as GMSHPointSettingsControl;
                pointControl.SetPointSize(meshSize[0]);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }

        private void SetPointSizesEventHandler(object sender, int pointNumber, double[] pointSize)
        {
            var dimTags = new int[] { 0, pointNumber };
            GmshController.Gmsh.Model.Mesh.SetSize(dimTags, pointSize[0]);
        }


        //private void DeleteElementsByNumber(object sender, DeleteElementEventArgs args)
        //{
        //    var cntr = (GMSHGeneralMeshControl)sender;
        //    var intType = cntr.GetElementTypeByString(ref args.keyData[0]);

        //    var dimTags = args.isNumeric ? new int[] { args.dim, Int32.Parse(args.keyData[1]) }
        //                 : GetElementsByType(intType, args.dim, args.tag);


        //    DeleteElementsByNumbers(dimTags, args.keyData[0], cntr.ElementsType);
        //}

        //private int[] GetElementsByType(int intType, int dim, int tag)
        //{
        //    var data = gmshController.Gmsh.Model.Mesh.GetElements(dim, tag);
        //    var elTypes = data.Item1;
        //    var elTags = data.Item2;
        //    var nodeTags = data.Item3;
        //    int[] dimTags = null;
        //    for (var i = 0; i < elTypes.Length; ++i)
        //        if (elTypes[i] == intType)
        //        {
        //            var tags = elTags[i];
        //            dimTags = new int[tags.Length * 2];
        //            for (var j = 0; j < tags.Length; ++j)
        //            {
        //                dimTags[j * 2] = dim;
        //                dimTags[j * 2 + 1] = Convert.ToInt32(tags[j]);
        //            }
        //            break;
        //        }
        //    return dimTags;
        //}

        //private void DeleteElementsByNumbers(int[] dimTags, string keyData, IEnumerable<string> elementType)
        //{
        //    foreach (var element in elementType)
        //        if (element.Contains(keyData))
        //        {
        //            var idElems = dimTags.Where((i, v) => (v & 1) == 1)
        //                                    .Select(v => (IntPtr)v)
        //                                    .ToArray();
        //            gmshController.DeleteMeshElements(idElems);
        //            return;
        //        }
        //    gmshController.Gmsh.Model.Mesh.Clear(dimTags);
        //}



        //[HandleProcessCorruptedStateExceptions]
        //[SecurityCritical]
        //private void MeshGenerator_generate2DMeshEvent(object sender, double meshDencity)
        //{
        //    try
        //    {
        //        var cntr = (GMSHGeneralMeshControl)sender;
        //        GmshController.Gmsh.Option.SetNumber("Mesh.MeshSizeFactor", meshDencity);

        //        DeleteGMSHMeshObjects(ObjType.Узел);
        //        GmshController.Gmsh.Model.Mesh.Generate(1);
        //        GmshController.Gmsh.Model.Mesh.Generate(2);
        //    }
        //    catch (Exception ex)
        //    {
        //        console.PrintInfo(ex.Message, Color.Red);
        //        return;
        //    }
        //    var error = GmshController.Gmsh.Logger.GetLastError();
        //    if (!string.IsNullOrEmpty(error))
        //        console.PrintInfo(error, Color.Red);

        //    project.ModelData.ObjectData.Clear(ObjType.Узел);//Удаляем только элементы сетки, геометрию не трогаем

        //    FitObjectsToScreen();
        //    DisplayObjects();
        //}

        private void DeleteGMSHMeshObjects(ObjType type)
        {
            int[] dimTags = null;
            var dim = 0;
            if (type == ObjType.Узел) //удаляем всю сетку узлы,1d,2d,3d
            {
                dimTags = new int[0];
            }
            if (type == ObjType.Элемент1D)//удаляем все 1d элементы
            {
                dim = 1;
                dimTags = GmshController.Gmsh.Model.GetEntities(dim);
            }
            else if (type == ObjType.Элемент2D)//удаляем все 2d элементы
            {
                dim = 2;
                dimTags = GmshController.Gmsh.Model.GetEntities(dim);
            }
            else if (type == ObjType.Элемент3D)//удаляем все 3d элементы
            {
                dim = 3;
                GmshController.Gmsh.Model.GetEntities(dim);
            }
            GmshController.Gmsh.Model.Mesh.Clear(dimTags);
        }    
    }
}
