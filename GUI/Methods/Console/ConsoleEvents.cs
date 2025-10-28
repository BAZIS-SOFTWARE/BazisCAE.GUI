using BaseModule.Console.Events;
using BaseModule.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BazisGUI.Utilities;
using Model.Interfaces;
using Geometry;
using System.Drawing;
using BaseModule.Navigator;
using System.Windows.Forms;
using Model.Interfaces.MeshObjects;
using Model.Utilities;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public async void console_InEvent(object arg1, EventArgs arg2)
        {
            try
            {
                if (arg2 is FindObjectEventArgs findObjectEventArgs)
                {
                    Invoke(new Action(() =>
                    {
                        var objsType = Converters.ConvertToObjsType(findObjectEventArgs.ObjsType);
                        var obj = project.ModelData.ObjectData.Find(objsType, (int)findObjectEventArgs.Number);

                        if (obj != null)
                        {
                            foreach (var item in project.ModelData.ObjectData.GetObjects(obj.ObjType))
                                item.ViewState = false;
                            obj.ViewState = true;
                            ClearAllDataOnScene();

                            var pres = project.CreateModelObjectsPresentor(obj.ObjType);
                            CreateVBObject(pres);
                            DisplayObjects();
                        }
                    }));
                }
                else if (arg2 is ModelFindCoincidentsNodesEventArgs coincidentNodesEventArgs)
                {
                    FindCoincidentNodes();
                }
                else if(arg2 is FindVolElemsEventArgs findVolElemsArgs)
                {
                    var e3ds = project.GetAllModelElements().Select(x => (IElement3D)x);
                    var findElmems = e3ds.Where(
                        e3d => e3d.CalcVolume() < findVolElemsArgs.Volume);

                    if(findElmems.Count() > 0)
                    {
                        // TO DO потом можно поискать способ более быстрый и
                        // технологичный для отображения найденных элементов
                        foreach (var item in findElmems)
                            item.Color = settingsConfig.SelectObjectColor;

                        foreach (var set in findElmems.Select(x => project.
                        GetModelSetInfo(x.ObjType, x.Number)).
                        Distinct(new DefaultSetInfoComparer()))
                        {
                            var pres = project.CreateModelObjectsPresentor(set);
                            SetVBObjectAttribute(pres, "цвет");
                        }
                        DisplayObjects();                     
                    }
                    Invoke(new Action(() => { console.PrintInfo($"Найдено {findElmems.Count()} объемных элементов", Color.Black); }));
                }
                else if (arg2 is BeamConnectionEventArgs beamConnectionEventArgs)
                {
                    // TO DO это пока прототип метода сшивки. Далее добавить асинхронные операции 
                    // для выбора групп узлов
                    var mGr = beamConnectionEventArgs.Master;
                    var sGr = beamConnectionEventArgs.Slave;
                    var r = beamConnectionEventArgs.Radius;
                    var max = beamConnectionEventArgs.MaxBeams;

                    project.ConnectByBeams(mGr,sGr,r,max);

                    var beams = project.GetModelSetsInfo(ObjType.Элемент1D).Last();

                    if (beams.NumberOfObjects > 0)
                    {
                        var pre = project.CreateModelObjectsPresentor(beams);
                        var vbo = CreateVBObject(pre);
                        VBOController.AddVbo(vbo);
                        DisplayObjects();
                    }
                    Invoke(new Action(() => { console.PrintInfo($"Созданы объекты {beams.ObjType}", Color.Black); }));
                }
            }
            catch (Exception ex)
            {
                Invoke(new Action(() => { console.PrintInfo(ex.Message, Color.Red); }));
            }
        }

        

        private void console_RenumberMeshEvent(object arg1, ModelRenumberEventArgs arg2)
        {
            //project.Renumber(project.ModelData.ObjectData, Converters.ConvertToObjsType(arg2.ObjsType));
        }

        private void console_ModelShiftCoordinateEvent(object arg1, BaseModule.Console.Events.ModelShiftCoordinateEventArgs arg2)
        {
            project.ModelData.ObjectData.Move(ObjType.Узел, new Point3D(arg2.X, arg2.Y, arg2.Z));

            DisplayGeometryObjectEvent = null;
            DisplayText2DEvent = null;

            foreach (ObjType item in Enum.GetValues(typeof(ObjType)))
            {
                var pres = project.CreateModelObjectsPresentor(item);
                SetVBObjectAttribute(pres, "координаты");
            }

            DisplayObjects();
        }

        private void console_ModelRotateEvent(object arg1, ModelRotateEventArgs arg2)
        {
            var axis = new Point3D(arg2.Axis.X, arg2.Axis.Y, arg2.Axis.Z);
            project.ModelData.ObjectData.Rotate(ObjType.Узел, axis, arg2.Angle);

            DisplayGeometryObjectEvent = null;
            DisplayText2DEvent = null;
            DisplayText3DEvent = null;

            foreach (ObjType item in Enum.GetValues(typeof(ObjType)))
            {
                var pres = project.CreateModelObjectsPresentor(item);
                SetVBObjectAttribute(pres, "координаты");
            }

            DisplayObjects();
        }        
    }
}
