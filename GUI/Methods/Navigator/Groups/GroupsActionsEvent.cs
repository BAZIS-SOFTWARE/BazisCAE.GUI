using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_HideAllGroupsEvent()
        {
            try
            {
                foreach (var group in project.ModelData.GroupData)
                {
                    foreach (var iobj in group)
                    {
                        iobj.ViewState = false;
                    }
                }
                VBOController.DeleteAllVBObjects();
                CreateVBObjects("Объекты");
                DisplayObjects();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }


        private void navigator_ShowAllGroupsEvent()
        {
            try
            {
                foreach (var group in project.GetAllModelGroups())
                {
                    foreach (var iobj in group)
                    {
                        iobj.ViewState = true;
                    }
                }
                VBOController.DeleteAllVBObjects();
                CreateVBObjects("Объекты");
                DisplayObjects();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }


        private void navigator_DelAllGroupsEvent()
        {
            try
            {
                project.ModelData.GroupData.Clear();
                project.TaskData.Clear();

                PresentGroupDataOnTree();

                //if (arg1 is TaskPage taskPage)
                PresentCondDataOnTree();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }
    }
}
