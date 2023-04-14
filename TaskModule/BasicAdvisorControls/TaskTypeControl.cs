using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TaskModule.BasicAdvisorControls
{

    public partial class TaskTypeControl : UserControl
    {
        public event Action<object, EventArgs> Select2DPlaneTaskEvent;
        public event Action<object, EventArgs> Select2DAxiTaskEvent;
        public event Action<object, EventArgs> Select3DTaskEvent;

        [Category("Images")]
        [Description("Set images for 2D task")]
        public Image Task2DImage
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }

        [Category("Images")]
        [Description("Set images for 2D axi task")]
        public Image Task2DAxiImage
        {
            get { return pictureBox2.Image; }
            set { pictureBox2.Image = value; }
        }

        [Category("Images")]
        [Description("Set images for 3D task")]
        public Image Task3DImage
        {
            get { return pictureBox3.Image; }
            set { pictureBox3.Image = value; }
        }
        public void SetTaskType(string taskType)
        {
            if (taskType == "Plain")
                rbt2Dplane.Checked = true;
            else if(taskType == "AxiPlain")
                rbt2Daxi.Checked = true;
            else rbt3D.Checked = true;

        }      

        public TaskTypeControl()
        {
            InitializeComponent();
        }

        private void RadioButton_Click(object sender, EventArgs e)
        {
            if (rbt2Dplane.Checked)
                Select2DPlaneTaskEvent(this, new EventArgs());
            else if (rbt2Daxi.Checked)
                Select2DAxiTaskEvent(this, new EventArgs());
            else
                Select3DTaskEvent(this, new EventArgs());
        }
    }


}
