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
      

        //private void AddDataLRF(Point3D vec, string dataName, string dataInfo)
        //{
        //    var dataAr = dataInfo.Split(' ');

        //    var lrfStr = dataAr.First(x => x.Contains("LRF"));
        //    var lrfInd = lrfStr.IndexOf("LRF");
        //    var valStr = dataAr[lrfInd + 1];

        //    var val = float.Parse(valStr);
        //    var rVec = vec.Mult(val);

        //    dataAr[lrfInd] = "X";
        //    dataAr[lrfInd] = rVec._x.ToString();

        //    var x_data = project.TaskData.Create(dataName.ToEnum<DataKind>(), string.Join(" ", dataAr), project.ModelData.GroupData);
        //    project.TaskData.Add(x_data);

        //    dataAr[lrfInd] = "Y";
        //    dataAr[lrfInd] = rVec._y.ToString();

        //    var y_data = project.TaskData.Create(dataName.ToEnum<DataKind>(), string.Join(" ", dataAr), project.ModelData.GroupData);
        //    project.TaskData.Add(y_data);

        //    dataAr[lrfInd] = "Z";
        //    dataAr[lrfInd] = rVec._z.ToString();

        //    var z_data = project.TaskData.Create(dataName.ToEnum<DataKind>(), string.Join(" ", dataAr), project.ModelData.GroupData);
        //    project.TaskData.Add(z_data);
        //}
    }
}
