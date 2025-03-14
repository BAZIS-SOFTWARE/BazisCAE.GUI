using System;
using BaseModule.PropertiesPanel;
using System.Collections.Generic;
using Model.Interfaces.ObjectsCollections;
using System.Windows.Forms;
using BaseModule.Navigator;
using UserControlsEx;


namespace BazisGUI.PropertiesPanel
{
    public class PropertyPanelProvider
    {
        public event Action<DrowPropertyOnPanelEventArgs> Out;
        public event Action<ISetInfo, TreeNode> OnUpdateNavigator;

        private ISetInfo _selectedObj;
        private TreeNode _selectedNode;

        public void DrawPropertyOnPanel(ISetInfo obj, TreeNode selectedNode) //создание коллекции RowProperty и отправка внутри EventArgs (DrowPropertyOnPanelEventArgs) в PropertyPanel.DataGridView
        {
            _selectedObj = obj;
            _selectedNode = selectedNode;
            List<RowProperty> list = new List<RowProperty>()
            {
                new RowProperty("Имя" ,obj.Name, (cell) =>
                {
                    return cell.Value;
                }),
                new RowProperty("Цвет",obj.Color.Name, (cell) =>
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
                }),

                new RowProperty("Представление", obj.ViewMode, (cell) =>
                {
                    DataGridViewComboBoxCell comboBoxCell = new DataGridViewComboBoxCell();
                    foreach (var value in Enum.GetValues(typeof(ViewMode)))
                    {
                        comboBoxCell.Items.Add(value);
                    }
                    comboBoxCell.Value = obj.ViewMode;
                    cell.DataGridView.Rows[cell.RowIndex].Cells[cell.ColumnIndex] = comboBoxCell;

                    return obj.ViewMode;
                })
                //new RowProperty("Представление",obj.ViewMode, () => { }),
                //new RowProperty("Тип",obj.ObjType, () => { })
            };
            Out(new DrowPropertyOnPanelEventArgs(list));
        }

        public bool ValidationData (string header, object oldValue, object newValue )
        {
            if (newValue.ToString() == string.Empty ||newValue.ToString().Contains(" ") == true)
            {
                MessageBox.Show("Имя не должно содержать пробелов или быть пустой", "FormatException", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else if (e.Header == "Представление") _selectedObj.SetViewMode(ViewMode.Line);
                OnUpdateNavigator?.Invoke(_selectedObj, _selectedNode);
        }
    }
}
