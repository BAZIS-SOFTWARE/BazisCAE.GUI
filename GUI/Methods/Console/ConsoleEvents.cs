using BazisGUI.Console.Events;
using BazisGUI.Console;
using System;
using System.Linq;
using BazisGUI.Utilities;
using Model.Interfaces;
using Geometry;
using System.Drawing;
using Model.Interfaces.MeshObjects;
using Model.Utilities;
using System.Collections.Generic;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void console_CreateMesh2DPoligonEvent(object arg1, CreateMesh2DPoligonEventArgs arg2)
        {
            project.CreateQuadMeshOnPoligon(new List<Point2D>() { arg2.p1, arg2.p2, arg2.p3, arg2.p4 }, arg2.NumberOfElems);
            PresentMeshData();
            PresentModelObjectsForSelection();

            var set = project.GetModelSetsInfo(ObjType.Элемент2D).Last();
            var pres = project.CreateModelObjectsPresentor(set);
            var vbo = CreateVBObject(pres);

            VBOController.AddVbo(vbo);
            DisplayObjects();
        }
        public async void console_InEvent(object arg1, EventArgs arg2)
        {
            try
            {
                if (arg2 is FindObjectEventArgs findObjectEventArgs)
                {
                    Invoke(new Action(() =>
                    {
                        var obj = project.GetAllModelObjects().
                        FirstOrDefault(x => x.ObjType == findObjectEventArgs.ObjType & x.Number == findObjectEventArgs.Number);

                        if (obj != null)
                        {
                            foreach (var item in project.GetModelSetsInfo(findObjectEventArgs.ObjType))
                                item.SetViewState(false);
                            obj.ViewState = true;

                            var set = project.GetModelSetInfo(findObjectEventArgs.ObjType, ((int)findObjectEventArgs.Number));
                            var pres = project.CreateModelObjectsPresentor(set);
                            var vbo = CreateVBObject(pres);

                            ClearAllDataOnScene();

                            VBOController.AddVbo(vbo);
                            DisplayObjects();
                        }
                        else
                            console.PrintInfo(Localization.Localization.GetStringResourceByName("ConsoleEvents.ConsoleInEvent.ObjectNotFound.Message"), Color.Orange);
                    }));
                }

                else if(arg2 is NodesShiftCoordinateEventArgs eventArgs)
                {
                    console_NodesShiftCoordinate();
                }


                else if (arg2 is ModelFindCoincidentsNodesEventArgs coincidentNodesEventArgs)
                {
                    FindCoincidentNodes(coincidentNodesEventArgs.Distance);
                }
                else if(arg2 is FindVolElemsEventArgs findVolElemsArgs)
                {
                    var e3ds = project.GetAllModelElements().
                        Where(x => x.ObjType == ObjType.Элемент3D).
                        Select(x => (IElement3D)x);
                    
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
                    Invoke(new Action(() => { console.PrintInfo($"{Localization.Localization.GetStringResourceByName("ConsoleEvents.ConsoleInEvent.ObjectFound.Message_Part1")} {findElmems.Count()} {Localization.Localization.GetStringResourceByName("ConsoleEvents.ConsoleInEvents.VolumeElements.Message")}", Color.Black); }));
                }
                else if (arg2 is BeamConnectionEventArgs beamConnectionEventArgs)
                {
                    BeamConnection(beamConnectionEventArgs);
                }
                else if(arg2 is SetElementLevelEventArgs setElementLevelEventArgs)
                {
                    foreach (var item in project.GetAllModelElements().
                            Where(x => x.ObjType == setElementLevelEventArgs.ObjType))
                    {
                        item.Level = setElementLevelEventArgs.Level;
                    }

                        
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

        private void console_ModelShiftCoordinateEvent(object arg1, BazisGUI.Console.Events.ModelShiftCoordinateEventArgs arg2)
        {
            project.MoveMesh(ObjType.Узел, new Point3D(arg2.X, arg2.Y, arg2.Z));

            DisplayGeometryObjectEvent = null;
            DisplayText2DEvent = null;

            foreach (var set in project.GetAllModelSetsInfo())
            {
                var pres = project.CreateModelObjectsPresentor(set);
                SetVBObjectAttribute(pres, "координаты");
            }

            DisplayObjects();
        }

        private void console_ModelRotateEvent(object arg1, ModelRotateEventArgs arg2)
        {
            var axis = new Point3D(arg2.Axis.X, arg2.Axis.Y, arg2.Axis.Z);
            project.RotateMesh(ObjType.Узел, axis, arg2.Angle);

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
