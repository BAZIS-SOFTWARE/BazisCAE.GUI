using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using Model.Interfaces;
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


        private void navigator_ShowObjectsEvent(NodeName obj)
        {
            ChangeObjectsViewState(obj,true);
        }

        private void navigator_HideObjectsEvent(NodeName obj)
        {
            ChangeObjectsViewState(obj, false);
        }

        private void ChangeObjectsViewState(NodeName obj, bool viewState)
        {
            List<ObjType> types;
            if (obj == NodeName.сетка)
                types = new List<ObjType>()
                { ObjType.Узел, ObjType.Элемент1D, ObjType.Элемент2D, ObjType.Элемент3D};
            else
                types = new List<ObjType>()
                { ObjType.Точка, ObjType.Кривая, ObjType.Поверхность};
            
            foreach (var item in types)
                foreach (var set in project.GetModelSetsInfo(item))
                {
                    set.SetViewState(viewState);
                    set.SetBackColor();
                    /* 
                     * тут удаление vbo при скрытии так как в дальнейшем 
                     * если не удалить может 
                     * возникнуть рассинхронизация
                    */
                    VBOController.DeleteVBObjects(set.Name);

                    if (viewState)
                    {
                        var pres = project.CreateModelObjectsPresentor(set);
                        var vb = CreateVBObject(pres);
                        VBOController.AddVbo(vb);
                    }
                }

            DisplayObjects();
        }
    }
}
