using BazisGUI.Scene.Interfaces;
using BazisGUI.Scene.Interfaces;
using System;
using Tao.OpenGl;
using Geometry;
using System.Drawing;
using MathNet.Numerics.LinearAlgebra;
using BaseModule;
using System.Windows.Forms;
using Model.Interfaces;
using System.Linq;
using Model.Interfaces.MeshObjects;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void btnShowInsideObjects_Click(object sender, EventArgs e)
        {
            try
            {
                var btn = sender as Button;
                var flag = bool.Parse(btn.Tag.ToString());
                if (!flag)
                {
                    btn.Tag = true;
                    settingsConfig.IsInsideObjectsShown = true;
                }

                else
                {
                    btn.Tag = false;
                    settingsConfig.IsInsideObjectsShown = false;
                }
                    
                ChangeInsideObjects();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        public void ChangeInsideObjects()
        {
            project.ChangeInsideSurfacesState(settingsConfig.IsInsideObjectsShown);

            foreach (var item in project.GetModelSetsInfo(ObjType.Элемент3D))
            {
                if(item.ViewState)
                {
                    VBOController.DeleteVBObjects(item.Name);
                    var presenter = project.CreateModelObjectsPresentor(item);
                    var vbo = CreateVBObject(presenter);
                    VBOController.AddVbo(vbo);
                }

            }

            if (!settingsConfig.IsInsideObjectsShown)
                console.PrintInfo("Скрыты внутренние объекты", Color.Black);
            else
                console.PrintInfo("Показаны все объекты", Color.Black);

            DisplayObjects();
        }
    }
}
