using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BaseModule.PropertiesPanel
{
    public partial class PropertiesPanelControl: UserControl
    {
        public PropertiesPanelControl()
        {
            InitializeComponent();
        }
        public void HandleDraw(DrowPropertyOnPanelEventArgs e) 
        {
            dataGridView1.DataSource = null;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn 
            {
                DataPropertyName = "Header",
                DefaultCellStyle = new DataGridViewCellStyle {BackColor = SystemColors.Control }
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                DataPropertyName = "Value",
                DefaultCellStyle = new DataGridViewCellStyle { BackColor = SystemColors.Control }
            });

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = e.List;
        }
    }
}