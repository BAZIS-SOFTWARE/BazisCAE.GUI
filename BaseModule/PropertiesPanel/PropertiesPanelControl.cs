using BaseModule.PinnedControl;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BaseModule.PropertiesPanel
{
    public partial class PropertiesPanelControl : PinnedPage
    {
        public event Action<PropertyChangedEventArgs> PropertyUpdateEvent;
        public event Action<PropertyChangedEventArgs> ReDrawEvent;

        public delegate bool Validator(string header, string value, out string corrected);
        public event Validator ValidateValue;

        private string _oldValue;
        private bool _isValid;
        //private List<RowProperty> _rowProperties;
        //private ComboBox _overlayComboBox = new ComboBox();
        private int _currentComboRowIndex;
        private int _currentComboColumnIndex = 1;
        //private string _enteredValue = string.Empty;

        public PropertiesPanelControl()
        {
            InitializeComponent();
            dataGridView1.DataError += DataGridView1_DataError;

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
                //ReadOnly = false
            });
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridView1.Controls.Add(_overlayComboBox);
            //_overlayComboBox.PreviewKeyDown += _overlayComboBox_PreviewKeyDown;
            //_overlayComboBox.Visible = false;
            //_overlayComboBox.Leave += _overlayComboBox_Leave;
        }

        private void DataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Pfukeirf
        }

        public void ClearTable()
        {
            dataGridView1.Rows.Clear();
        }

        public void DrawTable(List<RowProperty> rows)
        {
            //dataGridView1.DataSource = null;
            //dataGridView1.AutoGenerateColumns = false;
            //dataGridView1.AllowUserToResizeRows = false;
            //dataGridView1.Columns.Clear();
            //dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Rows.Clear();
            // Тут при создании строки таблицы должно происходить автоопределение типа элемента ячейки
            // comboBox,TextBox, CheckBox etc.
            foreach (var prop in rows)// Инициализация строк через RowProperty
            {
                var row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell { Value = prop.Header }); // Имя свойства

                DataGridViewCell cell; // Значение свойства

                if (prop.AvailableValues.Count != 0)
                {
                    var comboCell = new DataGridViewComboBoxCell();
                    comboCell.Items.AddRange(prop.AvailableValues.ToArray());
                    cell = comboCell;
                }

                else
                    cell = new DataGridViewTextBoxCell();

                if (prop.Header == "Цвет")
                    cell.Style.BackColor = (Color)prop.Value;

                cell.Value = prop.Value.ToString();
                cell.Tag = prop.ValidationType.ToString();

                row.Cells.Add(cell);
                cell.ReadOnly = prop.IsReadOnly;

                row.Cells[1].ReadOnly = false;

                dataGridView1.Rows.Add(row);
            }
            //_rowProperties = rows;
        }
        private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                _oldValue = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            // var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            //var property = _rowProperties[e.RowIndex];
            //if (property != null)
            //{
                //StartUpdate(cell);
            //}
        }

        public void CellValueChanged(DataGridViewCell e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                var header = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                var newValue = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                //dataGridView1.Rows.Clear();

                PropertyUpdateEvent?.Invoke(new PropertyChangedEventArgs(header, newValue, _oldValue));
            }
        }

        #region [OverlayComboBox Logic (to be moved) ]
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) return;
            //var property = _rowProperties[e.RowIndex];
            if (dataGridView1[0,e.RowIndex].Value.ToString() == "Цвет")
            {
                ColorDialog colorDialog = new ColorDialog();
                if(colorDialog.ShowDialog() == DialogResult.OK)
                {
                    var color = colorDialog.Color.ToString();
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = color;
                }
            }
            //if (property.AvailableValues.Count == 0) return;
            
            //_overlayComboBox.DropDownStyle = property.IsDropDown ? ComboBoxStyle.DropDown : ComboBoxStyle.DropDownList;
            //var cellRect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            //_overlayComboBox.SetBounds(cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);
            //_overlayComboBox.Items.Clear();
            //_overlayComboBox.Items.AddRange(property.AvailableValues.ToArray());
            //_oldValue = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            //_overlayComboBox.Text = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
            //_currentComboRowIndex = e.RowIndex;
            //_overlayComboBox.Visible = true;
            //_overlayComboBox.BringToFront();
            //_overlayComboBox.Focus();
        }
       
        private void DataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            RepositionComboBox();
        }
        private void RepositionComboBox()
        {
            //if (!_overlayComboBox.Visible || _currentComboRowIndex < 0) return;

            //var rect = dataGridView1.GetCellDisplayRectangle(_currentComboColumnIndex, _currentComboRowIndex, true);
            //_overlayComboBox.SetBounds(rect.X, rect.Y, rect.Width, rect.Height);
        }
        private void _overlayComboBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape)
            {
                dataGridView1.Focus();
            }
        }
        #endregion

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
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
            //var property = _rowProperties[e.RowIndex];
            //if (property != null)
            //{
            CellValueChanged(cell);
        }
    }
}
