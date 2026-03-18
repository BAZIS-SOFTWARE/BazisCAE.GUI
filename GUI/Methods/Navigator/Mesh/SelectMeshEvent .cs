using BazisGUI.PropertiesPanel;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_SelectMeshEvent()
        {
            try
            {
                List<RowProperty> rows = new List<RowProperty>();

                rows.Add(new RowProperty("Узлы", project.GetModelObjects(ObjType.Узел).Count(), true));
                rows.Add(new RowProperty("Элементы 1D", project.GetAllModelElements().
                    Where(x => x.ObjType == ObjType.Элемент1D).Count(), true));
                rows.Add(new RowProperty("", new ButtonPropertyValue("Показать",() => {ShowElements(1,true);DisplayObjects();})));
                rows.Add(new RowProperty("", new ButtonPropertyValue("Скрыть",() => {ShowElements(1, false);DisplayObjects();})));
                rows.Add(new RowProperty("", new ButtonPropertyValue("Удалить",() => {DelElements(1);DisplayObjects();})));
                rows.Add(new RowProperty("Элементы 2D", project.GetAllModelElements().Where(x => x.ObjType == ObjType.Элемент2D).Count(), true));
                rows.Add(new RowProperty("", new ButtonPropertyValue("Показать",() => {ShowElements(2, true);DisplayObjects();})));
                rows.Add(new RowProperty("", new ButtonPropertyValue("Скрыть",() => {ShowElements(2, false);DisplayObjects();})));
                rows.Add(new RowProperty("", new ButtonPropertyValue("Удалить",() => {DelElements(2);DisplayObjects();})));
                rows.Add(new RowProperty("Элементы 3D", project.GetAllModelElements().Where(x => x.ObjType == ObjType.Элемент3D).Count(), true));
                rows.Add(new RowProperty("", new ButtonPropertyValue("Показать",() => {ShowElements(3, true);DisplayObjects();})));
                rows.Add(new RowProperty("", new ButtonPropertyValue("Скрыть",() => {ShowElements(3, false);DisplayObjects();})));
                rows.Add(new RowProperty("", new ButtonPropertyValue("Удалить",() => {DelElements(3);DisplayObjects();})));

                propertiesPanel.DrawTable(rows);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }

        
    }
}
