using System;
using System.Linq;
using Model.Interfaces;
using System.Drawing;
using BazisGUI.Console;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void BeamConnection(BeamConnectionEventArgs beamConnectionEventArgs)
        {
            // TO DO это пока прототип метода сшивки. Далее добавить асинхронные операции 
            // для выбора групп узлов
            var mGr = beamConnectionEventArgs.Master;
            var sGr = beamConnectionEventArgs.Slave;
            var r = beamConnectionEventArgs.Radius;
            var max = beamConnectionEventArgs.MaxBeams;

            project.ConnectByBeams(mGr, sGr, r, max);

            var beams = project.GetModelSetsInfo(ObjType.Элемент1D).Last();

            if (beams.NumberOfObjects > 0)
            {
                var pre = project.CreateModelObjectsPresentor(beams);
                var vbo = CreateVBObject(pre);
                VBOController.AddVbo(vbo);
                DisplayObjects();

                PresentMeshData();
            }
            Invoke(new Action(() => { console.PrintInfo($"{Localization.Localization.GetStringResourceByName("BeamConnection.BeamConnection.ObjectsCreated.Message")} {beams.ObjType}", Color.Black); }));
        }
    }
}
