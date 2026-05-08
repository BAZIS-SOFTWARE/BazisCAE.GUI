using BazisGUI.Extensions;
using BazisGUI.Properties;
using BazisGUI.PropertiesPanel;
using Geometry;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using Project.Tasks;
using Project.Tasks.Materials;
using System;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
      
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
                return new BeamMatData(project.MaterialsDB.First().Value, _objectsGr, 0, 1);
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
                    return new BeamMatData(project.MaterialsDB.First().Value, _objectsGr, 0, 1);
                else if (_objectsGr.ObjType == ObjType.Элемент2D)
                    return new PlateMatData(project.MaterialsDB.First().Value, _objectsGr, 0, 1);
                else
                    return new MatData(project.MaterialsDB.First().Value, _objectsGr, 0, 1);
            }
        }   
    }
}
