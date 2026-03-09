using BazisGUI.PinnedControl;
using BazisGUI.PropertiesPanel.DataGridViewNumericUpDown;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace BazisGUI.PropertiesPanel
{
    public partial class PropertiesPanelControl : PinnedPage
    {
        public event Action<PropertyChangedEventArgs> PropertyUpdateEvent;
        public event Action<PropertyChangedEventArgs> ReDrawEvent;

        public delegate bool Validator(string header, string value, out string corrected);
        public event Validator ValidateValue;

        private string _oldValue;
        private bool _isValid;
        private string objInfo; // возможно костыль, хранит инфо об объекте сво-ва которого представлены
        private int tag; // возможно костыль, хранит инфо об источнике, где были получены сво-ва объекта
        private List<RowProperty> _rows;
        public PropertiesPanelControl()
        {
            InitializeComponent();
            dataGridView1.DataError += DataGridView1_DataError;
            dataGridView1.CurrentCellDirtyStateChanged += DataGridView1_CurrentCellDirtyStateChanged;
            dataGridView1.EditingControlShowing += DataGridView1_EditingControlShowing;
            dataGridView1.CellEndEdit += DataGridView1_CellEndEdit;
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
            });
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// Заполняет таблицу свойствами.
        /// </summary>
        public void DrawTable(List<RowProperty> rows, string objInfo = null, int tag = 0)
        {
            _rows = rows;
            this.objInfo = objInfo;
            this.tag = tag;

            dataGridView1.Rows.Clear();

            foreach (var prop in rows)
            {
                var row = new DataGridViewRow();
                row.DefaultCellStyle.BackColor = prop.Color;

                row.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = prop.Header
                });

                var cell = CreateValueCell(prop);

                cell.Tag = prop.ValidationType.ToString();
                cell.ReadOnly = prop.IsReadOnly;

                row.Cells.Add(cell);

                dataGridView1.Rows.Add(row);
            }
        }

        private DataGridViewCell CreateValueCell(RowProperty prop)
        {
            DataGridViewCell cell;

            switch (prop.Value)
            {
                case bool value:
                    cell = new DataGridViewCheckBoxCell
                    {
                        Value = value
                    };
                    cell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    break;

                case DropDownPropertyValue ddpv:
                    var combo = new DataGridViewComboBoxCell();
                    combo.Items.AddRange(ddpv.AvailableValues.ToArray());
                    combo.Value = ddpv.Value?.ToString();
                    cell = combo;
                    break;

                case NumericUpDownValue nudpv:
                    cell = new DataGridViewNumericUpDownCell
                    {
                        Minimum = nudpv.Minimum,
                        Maximum = nudpv.Maximum,
                        Increment = nudpv.Increment,
                        DecimalPlaces = nudpv.DecimalPlaces,
                        Value = Convert.ToDecimal(nudpv.Value)
                    };
                    break;

                case ButtonPropertyValue bpv:
                    var button = new DataGridViewButtonCell
                    {
                        Value = bpv.Text
                    };
                    button.Style.Tag = bpv;
                    cell = button;
                    break;

                default:
                    cell = new DataGridViewTextBoxCell
                    {
                        Value = prop.Value?.ToString()
                    };
                    break;
            }

            if (prop.Header == "Цвет" && prop.Value is Color color)
                cell.Style.BackColor = color;

            return cell;
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex == 0)
                return;

            var grid = dataGridView1;
            var row = grid.Rows[e.RowIndex];
            var propertyName = row.Cells[0].Value?.ToString();

            string value = GetValueFromDialog(propertyName);

            if (!string.IsNullOrEmpty(value))
            {
                row.Cells[e.ColumnIndex].Value = value;
                grid.CurrentCell = row.Cells[0];
            }

            HandleButtonCellClick(row.Cells[e.ColumnIndex]);
        }

        private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[1].Value != null)
                    _oldValue = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[1] is DataGridViewComboBoxCell)
                SyncDropDownBackingObject(e.RowIndex);
        }

        private void DataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell is DataGridViewCheckBoxCell)
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            else if (dataGridView1.CurrentCell is DataGridViewComboBoxCell)
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void DataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e){ /*Заглушка*/ }

        public void CellValueChanged(DataGridViewCell e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                var header = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                var cellValue = dataGridView1.Rows[e.RowIndex].Cells[1].Value;
                var newValue = cellValue?.ToString() ?? string.Empty;

                if (header == "Цвет")
                {
                    var color = ChangeColorCell(newValue);
                    dataGridView1.Rows[e.RowIndex].Cells[1].Style.BackColor = color;
                }
                var eventArgs = new PropertyChangedEventArgs(header, newValue, _oldValue);
                
                if (objInfo != null)
                    eventArgs.ObjInfo = objInfo;

                eventArgs.Tag = tag;

                PropertyUpdateEvent?.Invoke(eventArgs);
            }
        }

        /// <summary>
        /// Настраивает <see cref="ComboBox"/> редактора для ячейки
        /// <see cref="DataGridViewComboBoxCell"/> и обновляет подписки на события.
        /// </summary>
        private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell is DataGridViewComboBoxCell)
            {
                if (e.Control is ComboBox cb)
                {
                    if(_rows[dataGridView1.CurrentCell.RowIndex].Value is DropDownPropertyValue ddpv)
                        cb.DropDownStyle = ddpv.IsEditable ? ComboBoxStyle.DropDown : ComboBoxStyle.DropDownList;

                    cb.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;
                    cb.Leave -= ComboBox_Leave;

                    cb.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
                    cb.Leave += ComboBox_Leave;
                }
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[1].Tag.ToString() != ValidationType.None.ToString())
            {
                var cellValue = dataGridView1.Rows[e.RowIndex].Cells[1].Value;
                var newValue = cellValue?.ToString() ?? string.Empty;
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
            CellValueChanged(cell);
        }

        private Color ChangeColorCell(string colorName) 
        {
            Color color;
            if (colorName.StartsWith("Color [A="))
            {
                string[] parts = colorName.Trim('C', 'o', 'l', 'r', ' ', '[', ']').Split(',');
                int a = int.Parse(parts[0].Split('=')[1]);
                int r = int.Parse(parts[1].Split('=')[1]);
                int g = int.Parse(parts[2].Split('=')[1]);
                int b = int.Parse(parts[3].Split('=')[1]);
                color = Color.FromArgb(a, r, g, b);
            }
            else
            {
                color = Color.FromName(colorName.Replace("Color [", "").Replace("]", ""));
            }
            return color;
        }

        private string GetValueFromDialog(string propertyName)
        {
            switch (propertyName)
            {
                case "Цвет":
                    using (var dialog = new ColorDialog())
                        return dialog.ShowDialog() == DialogResult.OK ? dialog.Color.ToString() : null;

                case "Файл":
                    using (var dialog = new OpenFileDialog())
                        return dialog.ShowDialog() == DialogResult.OK ? dialog.FileName : null;
            }
            return null;
        }

        private void HandleButtonCellClick(DataGridViewCell cell)
        {
            if (cell is not DataGridViewButtonCell)
                return;

            if (cell.Style.Tag is ButtonPropertyValue buttonSet)
                buttonSet.OnClick?.Invoke();
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e) => SaveComboText(((ComboBox)sender).Text);
        private void ComboBox_Leave(object sender, EventArgs e) => SaveComboText(((ComboBox)sender).Text);

        private void SaveComboText(string text)
        {
            if (dataGridView1.CurrentCell == null) return;

            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            int colIndex = dataGridView1.CurrentCell.ColumnIndex;

            // записываем в ячейку
            dataGridView1[colIndex, rowIndex].Value = text;
        }

        /// <summary>
        /// Синхронизирует текущее текстовое значение ячейки ComboBox в <see cref="dataGridView1"/>
        /// с соответствующим объектом данных <see cref="DropDownPropertyValue"/> в коллекции <see cref="_rows"/>.
        /// </summary>
        private void SyncDropDownBackingObject(int rowIndex)
        {
            if (_rows == null || rowIndex < 0 || rowIndex >= _rows.Count)
                return;

            if (_rows[rowIndex].Value is not DropDownPropertyValue ddpv)
                return;

            var cell = dataGridView1.Rows[rowIndex].Cells[1];
            var newText = cell.Value?.ToString() ?? string.Empty;

            ddpv.Value = newText;

            if (cell is not DataGridViewComboBoxCell comboCell)
                return;

            comboCell.Items.Clear();
            comboCell.Items.AddRange(ddpv.AvailableValues.ToArray());

            if (!string.IsNullOrWhiteSpace(newText) && !ddpv.AvailableValues.Contains(newText))
                comboCell.Items.Add(newText);
        }
    }
}
