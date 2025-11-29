using BazisGUI.Console;
using BazisGUI.Scene.Interfaces;
using BazisGUI.Scene.VBO;
using Model.Interfaces;
using Model.Interfaces.MeshObjects;
using Model.Interfaces.ObjectsCollections;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {

        private void btnShowSidesRibs_Click(object sender, EventArgs e)
        {
            ChangeViewModeObjects(ViewMode.LineSurface);
        }

        private void btnShowRibs_Click(object sender, EventArgs e)
        {
            ChangeViewModeObjects(ViewMode.Line);
        }

        private void btnShowSides_Click(object sender, EventArgs e)
        {
            ChangeViewModeObjects(ViewMode.Surface);
        }      

        private void ChangeViewModeObjects(ViewMode arg2)
        {
            try
            {
                foreach (var item in project.GetModelSetsInfo(ObjType.Поверхность))
                    item.SetViewMode(arg2);
                foreach (var item in project.GetModelSetsInfo(ObjType.Элемент2D))
                    item.SetViewMode(arg2);
                foreach (var item in project.GetModelSetsInfo(ObjType.Элемент3D))
                    item.SetViewMode(arg2);

                var vbobjs = VBOController.GetVBObjs().Where(x => x.GL_ObjType == GLObjType.triangle);

                foreach (var obj in vbobjs)
                    if (arg2 == ViewMode.Line)
                        obj.ViewMode = Scene.Interfaces.ObjView.Lines;
                    else if (arg2 == ViewMode.LineSurface)
                        obj.ViewMode = Scene.Interfaces.ObjView.LinesSurface;
                    else obj.ViewMode = Scene.Interfaces.ObjView.Surface;

                DisplayObjects();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }



        private void btnShowNormals_Click(object sender, EventArgs e)
        {
            try
            {
                var btn = (ToolStripButton)sender;
                if (btn.Checked)
                {
                    var surfElems = project.ModelData.ObjectData.GetAllElements().Where(x => x is ISurfaceElement);
                    if (surfElems.Count() > 0)
                    {
                        var elemsNormals = project.CalcElemsNormals(3);

                        var linePresenter = presentersCreator.CreateLineObjectsPresenter(elemsNormals);
                        linePresenter.Name = "Normals";
                        var vbo = CreateVBObject(linePresenter);
                        VBOController.AddVbo(vbo);
                    }
                    else
                        throw new Exception("Для отображения нормалей модели не заданы объекты типа \"Элемент\"");
                }
                else
                {
                    VBOController.DeleteVBObjects("Normals");
                }
                DisplayObjects();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
    }
}
