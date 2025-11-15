using BaseModule.Extensions;
using BaseModule.PropertiesPanel;
using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
using Project.Interfaces.Tasks;
using Project.Tasks.Materials;
using Project.Tasks;
using System.Drawing;
using System.Linq;
using DocumentFormat.OpenXml.Spreadsheet;

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
                    cond = CreateMaterial(obj, _objectsGr);
                }
                else if (obj.NewValue == DataKind.Нагрев.ToString())
                {
                    cond = new HeatData(_objectsGr, 0, 1);
                }
                else if (obj.NewValue == DataKind.Среда.ToString())
                {
                    cond = new MediaData(_objectsGr, 0, 1);
                }
                else if (obj.NewValue == DataKind.Закрепление.ToString())
                {
                    cond = new ClampData(_objectsGr, 0, 1);
                }
                else
                {
                    cond = new LoadData(_objectsGr, 0, 1);
                }
                
                project.TaskData.Add(cond);
                PresentCondDataOnTree();
            }    
        }
    }
}
