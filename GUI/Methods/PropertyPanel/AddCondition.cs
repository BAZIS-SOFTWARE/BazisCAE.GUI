using BazisGUI.Extensions;
using BazisGUI.Properties;
using BazisGUI.PropertiesPanel;
using Geometry;
using Model;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using Project.Tasks;
using Project.Tasks.Materials;
using System;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BazisGUI
{
    public partial class BaseForm
    {
      
        private void PrepareDataForCreateVolumeMaterial(string materialName, string groupName, string start, string stop, out IGroup group, out float _start, out float _stop)
        {
            var valid = float.TryParse(start, out _start) & 
                float.TryParse(stop, out _stop) & 
                project.MaterialsDB.Select(k => k.Key).Contains(materialName);

            group = project.GetModelGroup(groupName);
            if (!valid)
                throw new ArgumentException(Resources.InvalidCommandException);
        }

        private void PrepareDataForCreateBeamMaterial(string materialName, string groupName, string diametr, string start, string stop, out IGroup group, out float _diametr, out float _start, out float _stop)
        {
            var valid = float.TryParse(start, out _start) &
                float.TryParse(stop, out _stop) &
                float.TryParse(diametr, out _diametr) &
                project.MaterialsDB.Select(k => k.Key).Contains(materialName);

            group = project.GetModelGroup(groupName);
            if (!valid)
                throw new ArgumentException(Resources.InvalidCommandException);
        }

        private void CheckMatsAndFuncs()
        {
            var matDB = project.MaterialsDB;
            if (matDB == null)
                throw new Exception(Resources.DataBase_Materials_MissingException);
            if (matDB.Count == 0)
                throw new Exception(Resources.DataBase_Materials_NoDataException);

            var funDB = project.FunctionsDB;
            if (funDB == null)
                throw new Exception(Resources.DataBase_Functions_MissingException);
            if (funDB.Count == 0)
                throw new Exception(Resources.DataBase_Functions_NoDataException);
        }

        private ICondData CreateMaterial(PropertyChangedEventArgs obj, IGroup _objectsGr)
        {
            if (project.ProjectType == TaskType.Linear)
                return new BeamMatData(1,project.MaterialsDB.First().Value, _objectsGr, 0, 1);
            else if (project.ProjectType == TaskType.Plain)
                return new PlateMatData(project.MaterialsDB.First().Value, _objectsGr, 0, 1);
            else if (project.ProjectType == TaskType.AxiPlain)
            {
                if (_objectsGr.ObjType == ObjType.Элемент1D)
                    return new PlateMatData(project.MaterialsDB.First().Value, _objectsGr, 0, 1);
                else
                    return new MatData(project.MaterialsDB.First().Value, _objectsGr, 0, 1);
            }
            else if(project.ProjectType == TaskType.Volume)
                return new MatData(project.MaterialsDB.First().Value, _objectsGr, 0, 1);
            else
            {
                if (_objectsGr.ObjType == ObjType.Элемент1D)
                    return new BeamMatData(1,project.MaterialsDB.First().Value, _objectsGr, 0, 1);
                else if (_objectsGr.ObjType == ObjType.Элемент2D)
                    return new PlateMatData(project.MaterialsDB.First().Value, _objectsGr, 0, 1);
                else
                    return new MatData(project.MaterialsDB.First().Value, _objectsGr, 0, 1);
            }
        }   
    }
}
