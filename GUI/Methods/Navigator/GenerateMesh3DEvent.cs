using BaseModule.Extensions;
using BaseModule.Mesh;
using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BaseModule.Tasks.BasicAdvisorControls.Events;
using BazisGUI.Utilities;
using Model;
using Model.Interfaces;
using Model.MeshObjects;
using OperationalController.GmshController;
using Project.Interfaces.Tasks;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        [HandleProcessCorruptedStateExceptions]
        [SecurityCritical]
        private void navigator_GenerateMesh3DEvent()
        {
            try
            {
                DeleteGMSHMeshObjects(ObjType.Элемент3D);
                gmshController.Gmsh.Model.Mesh.Generate(3);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
                return;
            }
            var error = gmshController.Gmsh.Logger.GetLastError();
            if (!string.IsNullOrEmpty(error))
                console.PrintInfo(error, Color.Red);

            UpdateMesh();
            DeleteVBObjects(ObjType.Узел);
            CreateVBObjects("Объекты");
            PresentObjectsDataOnTree();
            FitObjectsToScreen();
            DisplayObjects();
        }

        private void UpdateMesh()
        {
            project.ModelData.ObjectData.Clear(ObjType.Узел);//Удаляем только элементы сетки, геометрию не трогаем

            var objs = gmshController.GetMeshObjects();
    
            if (objs.Item1.Count > 0)
                objs.Item1.ForEach(x => project.ModelData.ObjectData.NodesSet.Add(x.Number, x));
            if (objs.Item2.Count > 0)
                project.ModelData.ObjectData.E1DCollection.AddRange("e1d", objs.Item2.Select(x => (Beam)x));
            if (objs.Item3.Count > 0)
                project.ModelData.ObjectData.E2DCollection.AddRange("e2d", objs.Item3);
            if (objs.Item4.Count > 0)
                project.ModelData.ObjectData.E3DCollection.AddRange("e3d", objs.Item4);
        }
    }
}
