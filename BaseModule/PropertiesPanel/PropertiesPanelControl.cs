using BaseModule.PinnedControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BaseModule.PropertiesPanel
{
    public partial class PropertiesPanelControl : PinnedPage
    {
        public event Action<PropertyChangedEventArgs> PropertyUpdateEvent;

        public delegate bool Validator(string header, string value, out string corrected);
        public event Validator ValidateValue;

        private string _oldValue;
        private bool _isValid;
        private List<RowProperty> _rowProperties;
        private ComboBox _overlayComboBox = new ComboBox();
        private int _currentComboRowIndex;
        private int _currentComboColumnIndex = 1;
        private string _enteredValue = string.Empty;

        public PropertiesPanelControl()
        {
            InitializeComponent();

            dataGridView1.Controls.Add(_overlayComboBox);
            _overlayComboBox.PreviewKeyDown += _overlayComboBox_PreviewKeyDown;
            _overlayComboBox.Visible = false;
            _overlayComboBox.Leave += _overlayComboBox_Leave;
        }
        public void DrawTable(List<RowProperty> rows)
        {
            dataGridView1.DataSource = null;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.Columns.Clear();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Header",
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = SystemColors.Control,
                    SelectionBackColor = SystemColors.ControlDark,
                    Padding = new Padding(15, 0, 0, 0)
                },
                ReadOnly = true,
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Value",
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = SystemColors.Control,
                    SelectionBackColor = SystemColors.ControlDark
                },
                ReadOnly = false
            });
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Тут при создании строки таблицы должно происходить автоопределение типа элемента ячейки
            // comboBox,TextBox, CheckBox etc.
            foreach (var prop in rows)// Инициализация строк через RowProperty
            {
                var row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell { Value = prop.Header }); // Имя свойства

                var cell = prop.Initialization;// Создаем ячейку нужного типа через Initialization
                //cell.Value = prop.Value.ToString();
                row.Cells.Add(cell);
                cell.ReadOnly = prop.IsReadOnly;
                cell.Tag = prop.ValidationType.ToString();

                dataGridView1.Rows.Add(row);
            }
            _rowProperties = rows;
        }
        private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                _oldValue = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var property = _rowProperties[e.RowIndex];
            if (property != null && property?.Sequence == SequenceType.Before)
            {
                StartUpdate(property, cell);
            }
        }
        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[1].Tag.ToString() != ValidationType.None.ToString())
            {
                var newValue = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                var tag = dataGridView1.Rows[e.RowIndex].Cells[1].Tag.ToString();
                var corrected = newValue;
                _isValid = ValidateValue?.Invoke(tag, newValue, out corrected) ?? true;

                if (!_isValid)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _oldValue;
                    return;
                }
                if (newValue != corrected) dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = corrected;
            }

            var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var property = _rowProperties[e.RowIndex];
            if (property != null && property.Sequence == SequenceType.After)
            {
               StartUpdate(property, cell);
            }
        }
        public void CellValueChanged(DataGridViewCell e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                var header = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                var newValue = dataGridView1.Rows[e.RowIndex].Cells[1].Value;
                PropertyUpdateEvent?.Invoke(new PropertyChangedEventArgs(header, newValue, _oldValue));
            }
        }
        private void StartUpdate(RowProperty property, DataGridViewCell cell)
        {
            var newValue = property.Initialization.Value;//Update(cell);
            //property.Value = newValue;
            if (newValue is string str)
                dataGridView1.Rows[cell.RowIndex].Cells[1].Value = newValue;

            else if(newValue is Color col)
                dataGridView1.Rows[cell.RowIndex].Cells[1].Value = col.Name;
            CellValueChanged(cell);
            //if (!Equals(newValue, property.Value) && newValue != _oldValue)
            //{
            //    if (property.Value is System.Drawing.Color a)
            //        dataGridView1.Rows[cell.RowIndex].Cells[1].Value = a.Name;
            //}
        }
        /// <summary>
        /// Исключение в DataGridView: System.ArgumentException: 
        /// Недопустимое значение DataGridViewComboBoxCell. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            /*Заглушка*/
        }

        #region [OverlayComboBox Logic (to be moved) ]
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) return;
            var property = _rowProperties[e.RowIndex];
            var h = property.Header;
            if(property.Header == "Цвет")
            {
                ColorDialog colorDialog = new ColorDialog();
                if(colorDialog.ShowDialog() == DialogResult.OK)
                {
                    var color = colorDialog.Color;
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = color;
                }
            }
            if (property.CellType.Name == "DataGridViewTextBoxCell") return;

            _overlayComboBox.DropDownStyle = property.IsDropDown ? ComboBoxStyle.DropDown : ComboBoxStyle.DropDownList;
            var cellRect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            _overlayComboBox.SetBounds(cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);
            _overlayComboBox.Items.Clear();
            _overlayComboBox.Items.AddRange(property.AvailableValues.ToArray());
            _oldValue = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            _overlayComboBox.Text = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
            _currentComboRowIndex = e.RowIndex;
            _overlayComboBox.Visible = true;
            _overlayComboBox.BringToFront();
            _overlayComboBox.Focus();
        }
        private void _overlayComboBox_Leave(object sender, EventArgs e)
        {
            if (_currentComboRowIndex >= 0)
            {
                var selectedValue = _overlayComboBox.Text;
                var cell =(DataGridViewComboBoxCell)dataGridView1.Rows[_currentComboRowIndex].Cells[_currentComboColumnIndex];
                var property = _rowProperties[_currentComboRowIndex];
                if (!property.AvailableValues.Contains(selectedValue))
                {
                    if(selectedValue != _enteredValue && _enteredValue != null)
                    {
                        property.AvailableValues.Remove(_enteredValue);
                    }
                    property.ValidationType = ValidationType.Float;
                    property.AvailableValues.Add(selectedValue);
                    cell.Tag = property.ValidationType.ToString();
                    cell.Items.Add(selectedValue);
                    _enteredValue = selectedValue;
                }
                else 
                {
                    property.ValidationType = ValidationType.None;
                    cell.Tag = property.ValidationType.ToString();
                }
                
                dataGridView1.Rows[_currentComboRowIndex].Cells[1].Value = selectedValue;
                var eArgs = new DataGridViewCellEventArgs(_currentComboColumnIndex, _currentComboRowIndex);
                DataGridView1_CellEndEdit(sender, eArgs);
            }
            _overlayComboBox.Visible = false;
            _currentComboRowIndex = -1;
        }
        private void DataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            RepositionComboBox();
        }
        private void RepositionComboBox()
        {
            if (!_overlayComboBox.Visible || _currentComboRowIndex < 0) return;

            var rect = dataGridView1.GetCellDisplayRectangle(_currentComboColumnIndex, _currentComboRowIndex, true);
            _overlayComboBox.SetBounds(rect.X, rect.Y, rect.Width, rect.Height);
        }
        private void _overlayComboBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape)
            {
                dataGridView1.Focus();
            }
        }
        #endregion
    }
}
