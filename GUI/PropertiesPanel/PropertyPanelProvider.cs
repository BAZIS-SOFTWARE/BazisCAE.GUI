using System;
using BaseModule.PropertiesPanel;
using Model.Interfaces.ObjectsCollections;
using System.Windows.Forms;
using Model.Interfaces;
using BazisGUI.PropertiesPanel.Control;
using Project.Interfaces.Tasks;

namespace BazisGUI.PropertiesPanel
{
    public class PropertyPanelProvider
    {
        public event Action<DrowPropertyOnPanelEventArgs> Out;
        public event Action OnUpdateNavigator;


        private TreeNode _selectedNode;
        private PanelConverter _converter; 

        public void ShowPropertiesPanel<T>(T obj, TreeNode selectedNode) 
        {
            _selectedNode = selectedNode;
            InitializeConverter(obj);
            Out(new DrowPropertyOnPanelEventArgs(_converter.GetRowProperty()));
        }

        private void InitializeConverter<T>(T obj)
        {
            if (obj is ISetInfo setInfo) _converter = new SetInfoControl(setInfo);

            else if (obj is IGroup group) _converter = new GroupControl(group);

            else if (obj is IData data) _converter = new DataControl(data);

            else throw new NotImplementedException("Тип конвертера не определен");
        }

        public bool ValidationData (string header, object oldValue, object newValue )
        {
            if (newValue == null || newValue.ToString().Contains(" "))
            {
                MessageBox.Show("Имя не должно содержать пробелов или быть пустым", "FormatException", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        public void UpdateObjectValue (PropertyChangedEventArgs e)
        {
            _converter.UpdateObject(e);
            OnUpdateNavigator.Invoke();
        }
    }
}

////Mat   - Материал
////Med   - Среда
////Heat  - Нагрев
////Clamp - Закрепление
////Load  - Нагрузка
//var info = obj.GetInfo;
//Debug.WriteLine($"Строка из GetInfo: {info}");
//_selectedValuableData = obj;
//_selectedNode = selectedNode;
//List<RowProperty> list = new List<RowProperty>()
//{
//    new RowProperty("Имя", obj.Name, () => new DataGridViewTextBoxCell(),
//    (cell) =>
//    {
//        return cell.Value;
//    },
//    SequenceType.After),
//};
//Out(new DrowPropertyOnPanelEventArgs(list));