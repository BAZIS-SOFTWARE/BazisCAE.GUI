using BaseModule.Interfaces;
using BaseModule.Navigator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

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

            dataGridView1.CellBeginEdit += DataGridView1_CellBeginEdit; //Для сохранения старого значения
            dataGridView1.CellEndEdit += DataGridView1_CellEndEdit_Validation;
        }

        public void HandleDraw(DrowPropertyOnPanelEventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
            dataGridView1.DataSource = e.Properties.ToList();
        }

        private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                _oldValue = dataGridView1.Rows[e.RowIndex].Cells[1].Value;
            }

            var properties = dataGridView1.DataSource as List<RowProperty>;
            if (properties == null || e.RowIndex >= properties.Count) return;

            var property = properties[e.RowIndex];
            object newValue = property.UpdateValue(dataGridView1.Rows[e.RowIndex].Cells[1]); //Start UpdateValue (Delegate)

            if(!Equals(newValue, property.Value)) //Если UpdateValue изменил данные, записываем их
            {
                property.Value = newValue;
                dataGridView1.Rows[e.RowIndex].Cells[1].Value = newValue;
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Передача данных для валидации в PropertyPanelProvider
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView1_CellEndEdit_Validation(object sender, DataGridViewCellEventArgs e)
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
            if (newValue != _oldValue) CellValueChanged(sender, e);
        }
        
        public void CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                var header = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                var newValue = dataGridView1.Rows[e.RowIndex].Cells[1].Value;
                OnPropertyUpdate?.Invoke(new PropertyChangedEventArgs(header, newValue, _oldValue));
            }
        }
    }
}
