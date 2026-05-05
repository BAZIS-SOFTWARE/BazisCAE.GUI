using BazisGUI.PropertiesPanel;
using Project.Interfaces.Tasks;
using Project.Tasks;
using System;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void ChangeMeshGroupProperties(PropertyChangedEventArgs obj, int index)
        {
            var grName = navigator.SelectedNode.Text.Split(' ')[0];
            var _objectsGr = project.GetModelGroup(index);
            var key = Enum.Parse<GroupPropertyKeys>(obj.Key);

            switch (key)
            {
                case GroupPropertyKeys.Name:
                    _objectsGr.Name = obj.NewValue.ToString();
                    OnGroupRenamed?.Invoke(_objectsGr.ObjType, _objectsGr.Number, obj.NewValue);
                    break;

                case GroupPropertyKeys.CreateCond:

                    ICondData cond;
                    CheckMatsAndFuncs();

                    if (obj.NewValue == DataKind.Материал.ToString())
                        cond = CreateMaterial(obj, _objectsGr);

                    else if (obj.NewValue == DataKind.Нагрев.ToString())
                        cond = new HeatData(_objectsGr, 0, 1);

                    else if (obj.NewValue == DataKind.Среда.ToString())
                        cond = new MediaData(_objectsGr, 0, 1);

                    else if (obj.NewValue == DataKind.Закрепление.ToString())
                        cond = new ClampData(_objectsGr, 0, 1);

                    else
                        cond = new LoadData(_objectsGr, 0, 1);

                    project.AddTaskData(cond);
                    PresentCondDataOnTree();
                    break;
            }
        }
    }
}
