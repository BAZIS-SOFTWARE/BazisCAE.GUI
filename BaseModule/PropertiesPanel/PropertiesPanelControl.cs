using BaseModule.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UserControlsEx;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BaseModule.PropertiesPanel
{
    public partial class PropertiesPanelControl : UserControl, IPinnedControl
    {
        public event Action<PropertyChangedEventArgs> OnPropertyUpdate;

        public delegate bool Validator(string header, string value, out string corrected);
        public event Validator ValidateValue;
        public event Action ControlCollapseEvent;
        public event Action ControlUnpinnedEvent;

        private string _oldValue;
        private bool _isValid;
        private List<RowProperty> _rowProperties;
        private System.Windows.Forms.ComboBox _overlayComboBox = new System.Windows.Forms.ComboBox();
        private int _currentComboRowIndex;
        private int _currentComboColumnIndex = 1;
        private string _enteredValue = string.Empty;

        [Category("General")]
        [Description("Set up color gradient")]
        public Color UpColor { get; set; } = Color.WhiteSmoke;

        [Category("General")]
        [Description("Set down color gradient")]
        public Color DownColor { get; set; } = Color.WhiteSmoke;

        [Category("General")]
        [Description("Set header name")]
        public string HeaderName { get; set; } = "Свойства";

        [Category("General")]
        [Description("Set color text")]
        public Color TextColor { get; set; } = Color.Black;

        public PropertiesPanelControl()
        {
            InitializeComponent();
            dataGridView1.DataError += DataGridView1_DataError; //Для обработки ошибки
            dataGridView1.CellBeginEdit += DataGridView1_CellBeginEdit; //Для сохранения старого значения
            dataGridView1.CellEndEdit += DataGridView1_CellEndEdit;
            dataGridView1.CellClick += DataGridView1_CellClick;
            dataGridView1.Scroll += DataGridView1_Scroll;

            dataGridView1.Controls.Add(_overlayComboBox);
            _overlayComboBox.PreviewKeyDown += _overlayComboBox_PreviewKeyDown;
            _overlayComboBox.Visible = false;
            _overlayComboBox.Leave += _overlayComboBox_Leave;
        }
        public void DrawTable(DrowPropertyOnPanelEventArgs e)
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

            foreach (var prop in e.Properties)// Инициализация строк через RowProperty
            {
                var row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell { Value = prop.Header }); // Имя свойства

                var cell = prop.Initialization();// Создаем ячейку нужного типа через Initialization
                cell.Value = prop.Value.ToString();
                row.Cells.Add(cell);
                cell.ReadOnly = prop.IsReadOnly;
                cell.Tag = prop.ValidationType.ToString();

                dataGridView1.Rows.Add(row);
            }
            _rowProperties = e.Properties.ToList();
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
                OnPropertyUpdate?.Invoke(new PropertyChangedEventArgs(header, newValue, _oldValue));
            }
        }
        private void StartUpdate(RowProperty property, DataGridViewCell cell)
        {
            var newValue = property.Update(cell);
            if (!Equals(newValue, property.Value) && newValue != _oldValue)
            {
                property.Value = newValue;
                dataGridView1.Rows[cell.RowIndex].Cells[1].Value = property.Value;
                CellValueChanged(cell);
                if (newValue is System.Drawing.Color a)
                    dataGridView1.Rows[cell.RowIndex].Cells[1].Value = a.Name;
            }
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

        private void PropertyPanel_Paint(object sender, PaintEventArgs e)
        {
            var loc_y = dataGridView1.Location.Y;

            ComponentsPainter.PaintGradientRectangle(e.Graphics, new Point(0, 0), Width, loc_y, UpColor, DownColor);

            var locRect = new Point(Width - 15, loc_y / 2 - 4);
            ComponentsPainter.PaintCloseRectangle(e.Graphics, locRect);

            e.Graphics.DrawString(HeaderName, ComponentsPainter.Font, new SolidBrush(TextColor), 15, 0);
        }

        private void grbNavigator_Resize(object sender, EventArgs e)
        {
            tableLayoutPanel1.Invalidate();
        }

        #region [OverlayComboBox Logic (to be moved) ]
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) return;
            var property = _rowProperties[e.RowIndex];
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
