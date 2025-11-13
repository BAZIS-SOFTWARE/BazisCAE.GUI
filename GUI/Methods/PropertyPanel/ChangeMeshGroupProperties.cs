using BaseModule.Extensions;
using BaseModule.PropertiesPanel;
using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
using Project.Interfaces.Tasks;
using Project.Tasks.Materials;
using Project.Tasks;
using System.Drawing;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void ChangeMeshGroupProperties(PropertyChangedEventArgs obj, int index)
        {
            var grName = navigator.SelectedNode.Text.Split(' ')[0];
            var _objectsGr = project.GetModelGroup(index);
            if (obj.Header == "Имя")
                _objectsGr.Name = obj.NewValue.ToString();


            //TODO добавить создание условий

            else if(obj.Header == "Создать условие")
            {
                ICondData cond;
                CheckMatsAndFuncs();
                if (obj.NewValue == DataKind.Материал.ToString())
                {
                    if(project.ProjectType == TaskType.Linear)
                        cond = new BeamMatData(project.MaterialsDB.First().Value, _objectsGr, 0, 1);
                    else if(project.ProjectType == TaskType.Plain)
                        cond = new PlateMatData(project.MaterialsDB.First().Value, _objectsGr, 0, 1);
                    else if (project.ProjectType == TaskType.AxiPlain |
                        project.ProjectType == TaskType.Volume)
                    {
                        cond = new MatData(project.MaterialsDB.First().Value, _objectsGr, 0, 1);
                    }
                    else
                    {
                        if(_objectsGr.ObjType == ObjType.Элемент1D)
                            cond = new BeamMatData(project.MaterialsDB.First().Value, _objectsGr, 0, 1);
                        else if (_objectsGr.ObjType == ObjType.Элемент2D)
                            cond = new PlateMatData(project.MaterialsDB.First().Value, _objectsGr, 0, 1);
                        else
                            cond = new MatData(project.MaterialsDB.First().Value, _objectsGr, 0, 1);
                    }
                    project.TaskData.Add(cond);
                    PresentCondDataOnTree();
                }      
            }    
        }
    }
}
