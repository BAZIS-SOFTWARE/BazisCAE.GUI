using BazisGUI.Extensions;
using BazisGUI.Navigator;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace BazisGUI
{
    public partial class BaseForm
    {


        private void navigator_ChangeAllObjectsViewStateEvent(bool state)
        {
            try
            {
                var node = navigator.SelectedNode.Name.ToEnum<NodeName>();
                var types = new List<ObjType>();
                if (node == NodeName.геометрия)
                {
                    types = new List<ObjType>()
                    {
                        ObjType.Точка,
                        ObjType.Кривая,
                        ObjType.Поверхность
                    };
                }

                else if (node == NodeName.сетка)
                {
                    types = new List<ObjType>()
                    {
                        ObjType.Узел,
                        ObjType.Элемент1D,
                        ObjType.Элемент2D,
                        ObjType.Элемент3D
                    };
                }

                foreach (var type in types)
                {
                    foreach (var set in project.GetModelSetsInfo(type))
                    {
                        set.SetViewState(state);
                        VBOController.DeleteVBObjects(set.Name);

                        if (set.ViewState)
                        {
                            var pre = project.CreateModelObjectsPresentor(set);
                            var vbo = CreateVBObject(pre);
                            VBOController.AddVbo(vbo);
                        }
                    }
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
