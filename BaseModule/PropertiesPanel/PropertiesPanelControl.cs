using System.Collections.Generic;
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
            //List<RowProperty> dat1 = new List<RowProperty>
            //{

            //};
            dataGridView1.DataSource = e;
        }
    }
}
