using BazisGUI;
using BazisGUI.Properties;
using BazisGUI.Scene.Interfaces;
using BazisGUI.Scene.Interfaces;
using BazisGUI.Scene.VBO;
using Geometry;
using MathNet.Numerics.LinearAlgebra;
using Model.Interfaces;
using Model.Interfaces.MeshObjects;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

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
                console.PrintInfo(Resources.ShowInsideObjects_HideInnerObjects_Message, Color.Black);
            else
                console.PrintInfo(Resources.ShowInsideObjects_ShowAllObjects_Message, Color.Black);

            DisplayObjects();
        }
    }
}
