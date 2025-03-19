using BaseModule.Interfaces;
using BaseModule.Navigator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BaseModule.PropertiesPanel
{
    public partial class PropertiesPanelControl: UserControl, IPinnedControl
    {
        public event Action<PropertyChangedEventArgs> OnPropertyUpdate;
        public event Func<string, object, object, bool> ValidateValue;
        public event Action ControlCollapseEvent;
        public event Action ControlUnpinnedEvent;

        private object _oldValue;
        private bool _isValid;
        private List<RowProperty> _rowProperties;

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
        }

        public void DrawTable(DrowPropertyOnPanelEventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.AutoGenerateColumns = false;
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
                ReadOnly = true
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

                dataGridView1.Rows.Add(row);
            }
            _rowProperties = e.Properties.ToList();
        }

        private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                _oldValue = dataGridView1.Rows[e.RowIndex].Cells[1].Value;
            }
            var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var property = _rowProperties[e.RowIndex];
            if (property !=null && property.Sequence == SequenceType.Before)
            {
                StartUpdate(property, cell);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            var newValue = dataGridView1.Rows[e.RowIndex].Cells[1].Value;
            if (e.RowIndex == 0 && e.ColumnIndex == 1)
            {
                var header = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                _isValid = ValidateValue?.Invoke(header, _oldValue, newValue) ?? true;

                if (!_isValid)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _oldValue;
                    return;
                }
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
