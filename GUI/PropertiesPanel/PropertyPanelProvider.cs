using System;
using BaseModule.PropertiesPanel;
using System.Collections.Generic;
using Model.Interfaces.ObjectsCollections;
using System.Windows.Forms;
using Model.Interfaces;
using BazisGUI.Utilities;
using System.Drawing;

namespace BazisGUI.PropertiesPanel
{
    public class PropertyPanelProvider
    {
        public event Action<DrowPropertyOnPanelEventArgs> Out;
        public event Action<ISetInfo, TreeNode> OnUpdateObjectNavigator;
        public event Action<IGroup, TreeNode> OnUpdateGroupNavigator;

        private ISetInfo _selectedObj;
        private IGroup _selectedGroup;
        private TreeNode _selectedNode;

        /// <summary>
        /// Метод для отображения свойств объекта на панели, создавая список свойств, которые можно редактировать.
        /// Заполняет список свойств, каждый элемент которого соответствует определенному атрибуту объекта.
        /// Для каждого свойства создается ячейка, которая может быть отредактирована.
        /// </summary>
        /// <param name="obj">Объект, свойства которого будут отображаться на панели.</param>
        /// <param name="selectedNode">Выбранный узел в древовидной структуре, связанный с объектом.</param>
        public void DrawObjectOnPanel(ISetInfo obj, TreeNode selectedNode) //создание коллекции RowProperty и отправка внутри EventArgs (DrowPropertyOnPanelEventArgs) в PropertyPanel.DataGridView
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
                
                new RowProperty("Цвет", obj.Color.Name, () => new DataGridViewTextBoxCell(),
                (cell) =>
                {
                    using (ColorDialog colorDialog = new ColorDialog())
                    {
                        if (colorDialog.ShowDialog() == DialogResult.OK)
                        {
                            return colorDialog.Color;
                        }
                    }
                    return cell.Value;
                }, 
                SequenceType.Before),
               
                new RowProperty("Представление", obj.ViewMode, 
                () => 
                {
                    var comboBoxCell = new DataGridViewComboBoxCell();
                    comboBoxCell.Items.AddRange(Converters.GetEnumNames().ToArray());
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

        /// <summary>
        /// Метод для отображения свойств объекта на панели, создавая список свойств, которые можно редактировать.
        /// Заполняет список свойств, каждый элемент которого соответствует определенному атрибуту объекта.
        /// Для каждого свойства создается ячейка, которая может быть отредактирована.
        /// </summary>
        /// <param name="obj">Объект, свойства которого будут отображаться на панели.</param>
        /// <param name="selectedNode">Выбранный узел в древовидной структуре, связанный с объектом.</param>
        public void DrawGroupOnPanel(IGroup obj, TreeNode selectedNode) //создание коллекции RowProperty и отправка внутри EventArgs (DrowPropertyOnPanelEventArgs) в PropertyPanel.DataGridView
        {
            _selectedGroup = obj;
            _selectedNode = selectedNode;
            List<RowProperty> list = new List<RowProperty>()
            {
                new RowProperty("Имя", obj.Name, () => new DataGridViewTextBoxCell(),
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
            if (newValue == null || newValue.ToString().Contains(" "))
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
            if (_selectedNode?.Parent.Text == "Группы объектов")
            {
                var name = _selectedGroup.Name;
                if (e.Header == "Имя") _selectedGroup.Name = e.NewValue.ToString();

                OnUpdateGroupNavigator?.Invoke(_selectedGroup, _selectedNode);
            }
            else
            {
                var name = _selectedObj.Name;
                if (e.Header == "Имя") _selectedObj.Name = e.NewValue.ToString();
                else if (e.Header == "Цвет") _selectedObj.SetColor((System.Drawing.Color) e.NewValue);
                else if(e.Header == "Представление") _selectedObj.SetViewMode(Converters.StringToEnum(e.NewValue.ToString()));

                OnUpdateObjectNavigator?.Invoke(_selectedObj, _selectedNode);
            }         
        }
    }
}
