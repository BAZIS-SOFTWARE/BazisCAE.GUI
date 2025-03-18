using System;
using BaseModule.PropertiesPanel;
using System.Collections.Generic;
using Model.Interfaces.ObjectsCollections;
using System.Windows.Forms;
using Model.GroupsData;


namespace BazisGUI.PropertiesPanel
{
    public class PropertyPanelProvider
    {
        public event Action<DrowPropertyOnPanelEventArgs> Out;
        public event Action<ISetInfo, TreeNode> OnUpdateNavigator;

        private ISetInfo _selectedObj;
        private Group _selectedGroup;//только имя

        private TreeNode _selectedNode;

        /// <summary>
        /// Метод для отображения свойств объекта на панели, создавая список свойств, которые можно редактировать.
        /// Заполняет список свойств, каждый элемент которого соответствует определенному атрибуту объекта.
        /// Для каждого свойства создается ячейка, которая может быть отредактирована.
        /// </summary>
        /// <param name="obj">Объект, свойства которого будут отображаться на панели.</param>
        /// <param name="selectedNode">Выбранный узел в древовидной структуре, связанный с объектом.</param>
        public void DrawPropertyOnPanel(ISetInfo obj, TreeNode selectedNode) //создание коллекции RowProperty и отправка внутри EventArgs (DrowPropertyOnPanelEventArgs) в PropertyPanel.DataGridView
        {
            _selectedObj = obj;
            _selectedNode = selectedNode;
            List<RowProperty> list = new List<RowProperty>()
        {
            new RowProperty("Имя", obj.Name, () => new DataGridViewTextBoxCell(),
            (cell) =>
            {
                return cell.Value;
            },
            SequenceType.After),
            new RowProperty("Color", obj.Color.Name, () => new DataGridViewTextBoxCell(),
            (cell) =>
            {
                using (ColorDialog colorDialog = new ColorDialog())
                {
                    if (colorDialog.ShowDialog() == DialogResult.OK)
                    {
                        obj.SetColor(colorDialog.Color);
                        return colorDialog.Color.Name;
                    }
                }
                return cell.Value;
            }, SequenceType.Before),
            new RowProperty("Представление", obj.ViewMode, 
            () => 
            {
                var comboBoxCell = new DataGridViewComboBoxCell();
                comboBoxCell.Items.AddRange(ViewModeConverter.GetEnumNames().ToArray());
                comboBoxCell.Value = obj.ViewMode;
                return comboBoxCell;
            },
            (cell) =>
            {
                return cell.Value;
            },
            SequenceType.After),
        };
            Out(new DrowPropertyOnPanelEventArgs(list));
        }

        public bool ValidationData (string header, object oldValue, object newValue )
        {
            if (newValue.ToString() == string.Empty ||newValue.ToString().Contains(" ") == true)
            {
                MessageBox.Show("Имя не должно содержать пробелов или быть пустым", "FormatException", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            return true;
        }
        /// <summary>
        /// Передает в BasePage.UpdateNavigator измененый объект и его старое имя для изменения данных в навигаторе
        /// </summary>
        /// <param name="e"></param>
        public void ValueChanged (PropertyChangedEventArgs e)
        {
            var name = _selectedObj.Name;
            if (e.Header == "Имя") _selectedObj.Name = e.NewValue.ToString();
            else if (e.Header == "Цвет") _selectedObj.SetColor((System.Drawing.Color)e.NewValue);
            else if (e.Header == "Представление") _selectedObj.SetViewMode(ViewModeConverter.StringToEnum(e.NewValue.ToString()));
            
            OnUpdateNavigator?.Invoke(_selectedObj, _selectedNode);
        }
    }
}
