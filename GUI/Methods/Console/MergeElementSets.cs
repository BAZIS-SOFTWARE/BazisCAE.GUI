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
        private async void MergeEventSets(string objTypeStr, string masterSet, string slaveSet)
        {
            try
            {
                // выбор объектов
                ObjType objType;
                if (!ObjType.TryParse(objTypeStr, out objType))
                    throw new Exception("Неизвестный тип объектов");

                project.MergeElements(objType, masterSet, slaveSet);

                PresentMeshData();

                project.SetModelObjectsBackColor(objType);
                VBOController.DeleteVBObjects(slaveSet);
                VBOController.DeleteVBObjects(masterSet);

                var set = project.GetModelSetInfo(objType, masterSet);
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
