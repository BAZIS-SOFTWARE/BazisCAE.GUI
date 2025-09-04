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
using System.Xml.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_Create1DFrom2DEvent()
        {
            try
            {
                CreateBoundaryMesh(1);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void navigator_Create2DFrom3DEvent()
        {
            try
            {
                CreateBoundaryMesh(2);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
        public void CreateBoundaryMesh(int dim)
        {
            ObjType objType;
            if (dim == 2)
                objType = ObjType.Элемент3D;
            else if (dim == 1)
                objType = ObjType.Элемент2D;
            else
                return;
            var els = project.GetModelObjects(objType);
            if (els.Count() == 0)
                console.PrintInfo($"Модель не содержит {dim + 1}D элементов!", Color.Red);
            else
            {
                if (dim == 2)
                    objType = ObjType.Элемент2D;
                else
                    objType = ObjType.Элемент3D;

                var startNumber = project.GetModelObjects(objType).
    Max(x => x.Number) + 1;
                // TO DO проверить метод создания при условии, что кол-я 2д элме-ов пустая
                if (dim == 2)
                    project.Create2DForm3D($"new{dim}DSet_{startNumber}");
                else
                    project.Create1DFrom2D($"new{dim}DSet_{startNumber}");

                var set = project.GetModelSetInfo(objType, $"new{dim}DSet_{startNumber}");

                if (set != null)
                {
                    var root = Converters.ConvertToNavigatorNodeType(set.ObjType);
                    navigator.TryCreateNode(root.ToString(), root.ToString(), $"{root} {set.NumberOfObjects}", NodeKind.virt);
                }


                var pre = project.CreateModelObjectsPresentor(set);
                var vbo = CreateVBObject(pre);
                VBOController.AddVbo(vbo);
            }
        }
    }
}
