using BaseModule.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

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
        private ComboBox _overlayComboBox = new ComboBox();
        private int _currentComboRowIndex;
        private int _currentComboColumnIndex = 1;

        [Category("General")]
        [Description("Set up color gradient")]
        public Color UpColor { get; set; } = Color.Silver;

        [Category("General")]
        [Description("Set down color gradient")]
        public Color DownColor { get; set; } = Color.WhiteSmoke;

        [Category("General")]
        [Description("Set header name")]
        public string HeaderName { get; set; } = "Свойства";

        public PropertiesPanelControl()
        {
            InitializeComponent();
            dataGridView1.DataError += DataGridView1_DataError; //Для обработки ошибки
            dataGridView1.CellBeginEdit += DataGridView1_CellBeginEdit; //Для сохранения старого значения
            dataGridView1.CellEndEdit += DataGridView1_CellEndEdit;
            dataGridView1.CellClick += DataGridView1_CellClick;

            dataGridView1.Controls.Add(_overlayComboBox);
            _overlayComboBox.Visible = false;
            //_overlayComboBox.DropDownStyle = ComboBoxStyle.DropDown;
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

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) return;
            var property = _rowProperties[e.RowIndex];
            if (property.CellType.Name == "DataGridViewTextBoxCell") return;

            if (property.IsDropDown) _overlayComboBox.DropDownStyle = ComboBoxStyle.DropDown;
            else _overlayComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            var cellRect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            _overlayComboBox.SetBounds(cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);
            _overlayComboBox.Items.Clear();
            _overlayComboBox.Items.AddRange(property.AvailableValues.ToArray());
            _oldValue = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            _overlayComboBox.Text = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
            _overlayComboBox.Tag = e.RowIndex;
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
                var cell = dataGridView1.Rows[_currentComboRowIndex].Cells[_currentComboColumnIndex];
                cell.Value = selectedValue;
                //_rowProperties[_currentComboRowIndex].Value = selectedValue; // сохраняем в модель
            }

            dataGridView1.Rows[_currentComboRowIndex].Cells[1].Value = _overlayComboBox.Text;
            var eArgs = new DataGridViewCellEventArgs(_currentComboColumnIndex, _currentComboRowIndex);
            DataGridView1_CellEndEdit(sender, eArgs);
            _overlayComboBox.Visible = false;
            _currentComboRowIndex = -1;
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
    }
}
