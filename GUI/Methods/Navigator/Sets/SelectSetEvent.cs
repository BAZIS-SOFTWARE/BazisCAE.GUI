using BazisGUI.Extensions;
using BazisGUI.Navigator;
using BazisGUI.PropertiesPanel;
using BazisGUI.Utilities;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_SelectSetEvent(string arg2)
        {
            try
            {
                ObjType objType;
                var setName = arg2.Split(' ')[1];
                // пока заглушим обработку объема
                if (arg2.Split(' ')[0].TryToEnum(out objType))
                {
                    if (objType == ObjType.Узел | objType == ObjType.Элемент1D | objType == ObjType.Элемент2D | objType == ObjType.Элемент3D)
                    {
                        //var objType = Converters.ConvertNavigatorNodeNameToObjType(arg1);
                        var set = project.GetModelSetInfo(objType, setName);
                        if(set != null)
                        {
                            var rows = GetSetProperty(set);

                            if (objType != ObjType.Узел)
                            {
                                var firstObj = project.GetModelObject(objType, set.GetNumbers().First());
                                var level = project.GetModelElements(firstObj.Dim, setName).FirstOrDefault().Level;   

                                rows.Add(new RowProperty("Порядок точности",new DropDownPropertyValue(level,new List<string>() { "1", "2" })));
                                rows.Add(new RowProperty("Смежные узлы", new ButtonPropertyValue("Показать",() => {ShowAdjacenciesSet(objType, setName);DisplayObjects();})));
                                rows.Add(new RowProperty("Группа", new ButtonPropertyValue("Создать", () => 
                                {
                                    var objects = set.GetNumbers().Select(num => project.GetModelObject(objType, num)).ToList();
                                    project.CreateGroup(set.Name, objects);
                                    var group = project.GetAllModelGroups().Last();
                                    console.PrintInfo(string.Format("Создана новая группа {0}", group.Name), Color.Black);

                                    PresentGroupDataOnTree();
                                    OnGroupCreated?.Invoke(group.ObjType, group.Number, group.Name);
                                })));
                            }
                            propertiesPanel.DrawTable(rows);
                        }
 
                    }
                    else if (objType == ObjType.Поверхность | objType == ObjType.Кривая | objType == ObjType.Точка)
                    {
                        //var objType = Converters.ConvertNavigatorNodeNameToObjType(arg1);

                        var set = project.GetModelSetInfo(objType, setName);
                        var rows = GetSetProperty(set);
                        propertiesPanel.DrawTable(rows);
                    }
                }    

                    
                //if (arg1 == NodeName.Объем | arg1 == NodeName.Поверхности)
                //{
                //    var ar = arg2.Split(' ');
                //    setName = string.Join(" ", ar, 1, ar.Length - 2);
                //}

                
                else
                {
                    var vol = project.GetModelVolumes().FirstOrDefault(x => x.Name == setName);
                    /*
                     * TO DO Реализовать для объема
                     */
                }


            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }
    }
}
