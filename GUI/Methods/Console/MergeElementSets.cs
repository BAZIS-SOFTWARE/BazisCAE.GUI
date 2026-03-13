using System;
using System.Linq;
using Model.Interfaces;
using System.Drawing;
using BazisGUI.Navigator;
using ResultDB.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using UserControlsEx.Graph;
using Geometry;
using Model.MeshObjects;
using BazisGUI.Console;
using BazisGUI.Scene.VBO;

namespace BazisGUI
{
    public partial class BaseForm
    {
   
        private async void MergeEventSetsEventHandler(object sender, MergeElementSetsEventArgs args)
        {
            try
            {
                // выбор объектов
                ObjType objType;
                if (!ObjType.TryParse(args.ObjType, out objType))
                    throw new Exception("Неизвестный тип объектов");

                project.MergeElements(objType, args.MasterSet, args.SlaveSet);

                PresentMeshData();

                project.SetModelObjectsBackColor(objType);
                VBOController.DeleteVBObjects(args.SlaveSet);
                VBOController.DeleteVBObjects(args.MasterSet);

                var set = project.GetModelSetInfo(objType, args.MasterSet);
                var pre = project.CreateModelObjectsPresentor(set);
                var vbo = CreateVBObject(pre);
                VBOController.AddVbo(vbo);

                DisplayObjects();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
    }
}
