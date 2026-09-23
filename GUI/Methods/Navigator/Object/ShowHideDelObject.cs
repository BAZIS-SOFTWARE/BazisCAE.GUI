using BazisGUI.Extensions;
using BazisGUI.Properties;
using BazisGUI.Utilities;
using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
using System;
using System.Drawing;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_ShowObjectEvent()
        {
            var number = int.Parse(navigator.SelectedNode.Text.Split(' ')[0]);
            var objInfo = navigator.SelectedNode.Text.Split(' ')[1];
            ShowHideObject(objInfo, number, true);
        }

        private void navigator_HideObjectEvent()
        {
            var number = int.Parse(navigator.SelectedNode.Text.Split(' ')[0]);
            var objInfo = navigator.SelectedNode.Text.Split(' ')[1];
            ShowHideObject(objInfo, number, false);
        }

        public void ShowHideObject(string objInfo ,int number,bool flag)
        {
            try
            {
                ISetInfo set;
                ObjType objType;
                // пока заглушим обработку объема
                if (objInfo.TryToEnum(out objType))
                {
                    //var objType = Converters.ConvertNavigatorNodeNameToObjType(nodeName);
                    set = project.GetModelSetInfo(objType, number);
                    project.ModelView.SetVisible(objType, [number], flag);
                }
                else
                {
                    set = project.GetModelSetsInfo(ObjType.Поверхность).First();
                    var vol = project.GetModelVolumes().First(x => x.Number == number);
                    var numbers = vol.GetSurfaceFigures().Select(x => x.Number);
                    project.ModelView.SetVisible(ObjType.Поверхность, numbers, flag);
                }


            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
        
        private void navigator_DelObjectEvent()
        {
            var node = navigator.SelectedNode;
            var info = node.Text.Split(' ');
            var number = int.Parse(info[0]);

            if(node.Parent.Parent.Text == Resources.Navigator_TreeView_Node_Text_Geometry)
            {
                if (info[1].TryToEnum(out ObjType objType))
                {
                    Navigator_DeleteGeometry((int)objType, number);
                    RefreshGeometry(objType);
                }
                else
                {
                    Navigator_DeleteGeometry(3, number);
                }
                RequestRedraw();
            }
            else if(node.Parent.Parent.Text == Resources.Navigator_TreeView_Node_Text_Mesh)
            {
                if (info[1].TryToEnum(out ObjType objType))
                {
                    var obj = project.GetModelObject(objType, number);
                    obj.ExistState = false;

                    if (objType == ObjType.Узел)
                    {
                        DeleteVBObjects("Элементы");
                        CreateVBObjects("Элементы");
                    }

                    var set = project.GetModelSetInfo(objType, number);
                    project.ClearNotExistedModelData();
                    project.ModelView.Prune();
                    PresentMeshData();
                    PresentGroupDataOnTree();
                    PresentCondDataOnTree();
                }
            }
        }

        private void Navigator_DeleteGeometry(int dim, int number)
        {
            try
            {
                project.DeleteGeometryObject(dim, number);
                PresentGeoData();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
    }
}
