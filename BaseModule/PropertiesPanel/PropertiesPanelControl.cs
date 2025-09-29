using BaseModule.PinnedControl;
using BaseModule.PropertiesPanel.DataGridViewNumericUpDown;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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

        public PropertiesPanelControl()
        {
            InitializeComponent();
            dataGridView1.DataError += DataGridView1_DataError;
            dataGridView1.CurrentCellDirtyStateChanged += DataGridView1_CurrentCellDirtyStateChanged;
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

        private void DataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentCell is DataGridViewCheckBoxCell)
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
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
            dataGridView1.Rows.Clear();
            // Тут при создании строки таблицы должно происходить автоопределение типа элемента ячейки
            // comboBox,TextBox, CheckBox etc.
            foreach (var prop in rows)// Инициализация строк через RowProperty
            {
                var row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell { Value = prop.Header }); // Имя свойства

                DataGridViewCell cell; // Значение свойства

                if(prop.IsCheckable)
                {
                    cell = new DataGridViewCheckBoxCell();
                    cell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    cell.Value = Convert.ToBoolean(prop.Value);
                }

                else if (prop.IsDropDown)
                {
                    var comboCell = new DataGridViewComboBoxCell();
                    comboCell.Items.AddRange(prop.AvailableValues.ToArray());
                    comboCell.Value= prop.Value.ToString();
                    cell = comboCell;
                }

                else if (prop.IsNumericUpDown)
                {
                    var setting = prop.Value as NumericUpDownValue;
                    var numericUpDownCell = new DataGridViewNumericUpDownCell()
                    {
                        Minimum = setting.Minimum,
                        Maximum = setting.Maximum,
                        Increment = setting.Increment,
                        DecimalPlaces = setting.DecimalPlaces,
                    };
                    numericUpDownCell.Value = Convert.ToDecimal(setting.Value);
                    cell = numericUpDownCell;
                }
                else if (prop.Value is DataGridViewButtonCellSet buttonSet)
                {
                    var btnCell = new DataGridViewButtonCell();
                    btnCell.Tag = buttonSet;
                    var setting = prop.Value as DataGridViewButtonCellSet;
                    btnCell.Value = setting.Text;
                    cell = btnCell;
                }
                else
                {
                    cell = new DataGridViewTextBoxCell();
                    cell.Value= prop.Value.ToString() ;
                }
                    

                if (prop.Header == "Цвет")
                    cell.Style.BackColor = (Color)prop.Value;

                //cell.Tag = prop.ValidationType.ToString();

                row.Cells.Add(cell);
                cell.ReadOnly = prop.IsReadOnly;

                row.Cells[1].ReadOnly = false;
                dataGridView1.Rows.Add(row);
            }
        }
        private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                if(dataGridView1.Rows[e.RowIndex].Cells[1].Value != null)
                    _oldValue = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }

        }

        public void CellValueChanged(DataGridViewCell e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                var header = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                var newValue = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                
                if (header == "Цвет")
                {
                    var color = ChangeColorCell(newValue);
                    dataGridView1.Rows[e.RowIndex].Cells[1].Style.BackColor = color;
                }


                PropertyUpdateEvent?.Invoke(new PropertyChangedEventArgs(header, newValue, _oldValue));
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) return;
            if (dataGridView1[0,e.RowIndex].Value.ToString() == "Цвет")
            {
                ColorDialog colorDialog = new ColorDialog();
                if(colorDialog.ShowDialog() == DialogResult.OK)
                {
                    var color = colorDialog.Color.ToString();
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = color;

                    dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[0];
                }
            }


            var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (cell is DataGridViewButtonCell bt)
            {
                var buttonSet = cell.Tag as DataGridViewButtonCellSet;
               
                buttonSet.OnClick?.Invoke(bt);
            }

        }
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
    }
}
