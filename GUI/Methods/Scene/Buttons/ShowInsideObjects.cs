using BazisGUI.Scene.Interfaces;
using BazisGUI.Scene.Interfaces;
using System;
using Geometry;
using System.Drawing;
using MathNet.Numerics.LinearAlgebra;
using BazisGUI;
using System.Windows.Forms;
using Model.Interfaces;
using System.Linq;
using Model.Interfaces.MeshObjects;
using BazisGUI.Scene.VBO;

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
                    //settingsConfig.IsInsideObjectsShown = true;
                }

                else
                {
                    btn.Tag = false;
                    //settingsConfig.IsInsideObjectsShown = false;
                }
                    
                ChangeInsideObjects(!flag);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        public void ChangeInsideObjects(bool flag)
        {
            project.ChangeInsideSurfacesState(flag);
            
            foreach (var item in project.GetModelSetsInfo(ObjType.Элемент3D))
            {
                if(item.ViewState)
                {
                    VBOController.DeleteVBObjects(item.Name);
                    var presenter = project.CreateModelObjectsPresentor(item);

                    // тут введем проверку возможности создать vbo объект. Это необходимо в случае если у нас набор 3д
                    // находится внутри другого набора. 
                    VBObject vbo;
                    if (TryCreateVBObject(presenter, out vbo))
                        VBOController.AddVbo(vbo);

                    //var vbo = CreateVBObject(presenter);
                    //VBOController.AddVbo(vbo);
                }

            }

            if (!flag)
                console.PrintInfo("Скрыты внутренние объекты", Color.Black);
            else
                console.PrintInfo("Показаны все объекты", Color.Black);

            DisplayObjects();
        }
    }
}
