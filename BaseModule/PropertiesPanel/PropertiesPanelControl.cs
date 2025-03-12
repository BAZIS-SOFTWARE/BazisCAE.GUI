using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using UserControlsEx;

namespace BaseModule.PropertiesPanel
{
    public partial class PropertiesPanelControl: UserControl
    {
        public event Action<PropertyChangedEventArgs> OnPropertyUpdate;
        public event Func<string, object, object, bool> ValidateValue;

        private object _oldValue;
        private bool _isValid;
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
                DefaultCellStyle = new DataGridViewCellStyle{BackColor = SystemColors.Control, SelectionBackColor = SystemColors.ControlDark },
                ReadOnly = true
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                DataPropertyName = "Value",
                DefaultCellStyle = new DataGridViewCellStyle {BackColor = SystemColors.Control, SelectionBackColor = SystemColors.ControlDark },
                ReadOnly = false
            });

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = e.Properties;
        }


        private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if(e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                _oldValue = dataGridView1.Rows[e.RowIndex].Cells[1].Value;
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
            if(newValue != _oldValue) CellValueChanged(sender, e);

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
