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
        private void navigator_SelectGeneralInfoEvent(NodeType arg1, string arg2)
        {
            try
            {
                if (project == null)
                    return;

                    List<RowProperty> rows = null;
                    if (arg1 == NodeType.вид)
                    {
                        rows = panelProvider.GetRowProperties(project.ProjectKind);
                    }
                    else if (arg1 == NodeType.тип)
                    {
                        rows = panelProvider.GetRowProperties(project.ProjectType);
                    }
                    else if (arg1 == NodeType.базаФункций)
                    {
                        rows = panelProvider.GetRowProperties(project.FunctionsDB);
                    }
                    else if (arg1 == NodeType.базаМатериалов)
                    {
                        rows = panelProvider.GetRowProperties(project.MaterialsDB);
                    }
                    propertiesPanel.DrawTable(rows);             
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
    }
}
