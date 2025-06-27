using Model.Interfaces;
using ModelController.GmshController;
using Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void mesh3DGeneratorMenuItem_Click(object sender, EventArgs e)
        {
            if (mesh3DGeneratorMenuItem.Checked)
            {
                var res = MessageBox.Show("Вы собираетесь запустить сеточный генератор. При нажатии на кнопку \"OK\" " +
    "Все данные о задаче будут удалены!",
"Внимание!", MessageBoxButtons.OKCancel);

                if (res == DialogResult.OK)
                    project.TaskData.Clear();
                else
                {
                    mesh3DGeneratorMenuItem.Checked = false;
                    return;
                }

                if (gmshController != null)
                    SetGMSHController(project.ModelData, gmshController);
            }
        }

        public void SetGMSHController(IModelData modelData, GmshController gmshController)
        {
            scene.SceneControl.HideAllGeometryObjs();
            scene.SceneControl.HideDisplayText2D();
            scene.SceneControl.HideDisplayText3D();

            PresentObjectsDataOnTree(modelData.ObjectData);

            if (gmshController == null)
                MessageBox.Show("Контроллер генератора сетки не загружен!");

            this.gmshController = gmshController;
            scene.SceneControl.DisplayObjects();
        }
        private void createSurfaceElementsMenuItem_Click(object sender, EventArgs e)
        {
            CreateSurfaceElements(ObjType.Элемент2D);
        }

        private void создать1DПо2DЭлементамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateSurfaceElements(ObjType.Элемент1D);
        }

        public void CreateSurfaceElements( ObjType objType)
        {

            try
            {
                if (objType == ObjType.Элемент2D)
                {
                    var els3D = project.ModelData.ObjectData.E3DCollection.GetObjects();
                    if (els3D.Count() == 0)
                        console.PrintInfo("Модель не содержит 3D элементов!", Color.Red);
                    else
                    {
                        scene.SceneControl.DeleteVBObjects(ObjType.Элемент2D.ToString());

                        var startNumber = project.ModelData.ObjectData.GetMaxElementNumber() + 1;
                        var boundaryElements2D = modelController.Extractor2DFrom3D.Create(startNumber, els3D.ToArray());

                        project.ModelData.ObjectData.E2DCollection.Add("new2DSet");

                        foreach (var item in boundaryElements2D)
                            project.ModelData.ObjectData.E2DCollection["new2DSet"].Add(item.Number, item);

                    }
                }
                else if (objType == ObjType.Элемент1D)
                {
                    var els2D = project.ModelData.ObjectData.E2DCollection.GetObjects();
                    if (els2D.Count() == 0)
                        console.PrintInfo("Модель не содержит 2D элементов!", Color.Red);
                    else
                    {
                        scene.SceneControl.DeleteVBObjects(ObjType.Элемент1D.ToString());

                        var startNumber = project.ModelData.ObjectData.GetMaxElementNumber() + 1;
                        var boundaryElements1D = modelController.Extractor1DFrom2D.Create(startNumber, els2D.ToArray());

                        project.ModelData.ObjectData.E1DCollection.Add("new1DSet");

                        foreach (var item in boundaryElements1D)
                            project.ModelData.ObjectData.E1DCollection["new1DSet"].Add(item.Number, item);
                    }
                }

                scene.SceneControl.HideAllGeometryObjs();
                scene.SceneControl.HideDisplayText2D();
                scene.SceneControl.HideDisplayText3D();

                scene.CreateObjectsOnScene(objType.ToString(), scene.CreateObjectsPresentor(project.ModelData, objType));

                scene.SceneControl.DisplayObjects();
                PresentObjectsDataOnTree(project.ModelData.ObjectData);

                console.PrintInfo($"Созданы {objType}", Color.Black);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
    }
}
