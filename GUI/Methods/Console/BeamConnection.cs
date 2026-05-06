using BazisGUI.Console;
using BazisGUI.Properties;
using Model.Interfaces;
using System;
using System.Drawing;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void BeamConnection(string _radius, string _maxBeams, string master, string slave)
        {

            if (!double.TryParse(_radius, out double radius))
                throw new ArgumentException(Resources.BeamConnectionEventArgsArgNumExc, nameof(_radius));

            if (!int.TryParse(_maxBeams, out int maxBeams))
                throw new ArgumentException(Resources.BeamConnectionEventArgsArgNumExc, nameof(_maxBeams));

            // TO DO это пока прототип метода сшивки. Далее добавить асинхронные операции 
            // для выбора групп узлов
            project.ConnectByBeams(master, slave, radius, maxBeams);

            var beams = project.GetModelSetsInfo(ObjType.Элемент1D).Last();

            if (beams.NumberOfObjects > 0)
            {
                var pre = project.CreateModelObjectsPresentor(beams);
                var vbo = CreateVBObject(pre);
                VBOController.AddVbo(vbo);
                DisplayObjects();

                PresentMeshData();
            }
            Invoke(new Action(() => { console.PrintInfo($"{Resources.BeamConnection_BeamConnection_ObjectsCreated_Message} {beams.ObjType}", Color.Black); }));
        }
    }
}
