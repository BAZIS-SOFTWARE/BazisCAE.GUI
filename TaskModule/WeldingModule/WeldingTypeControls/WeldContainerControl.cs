using System;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace TaskModule.WeldingModule.WeldingTypeControls
{
    public partial class WeldContainerControl : UserControl
    {
        public event Action<object, WeldContainerCntrEventArgs> ChangeDataEvent;
        public event Action InfoBoxClickEvent;


        public WeldContainerControl()
        {
            InitializeComponent();
        }

        public virtual string CollectData()
        {
            throw new NotImplementedException("Не реализован метод!");
        }

        public virtual void InputData(string[] inputData)
        {
            throw new NotImplementedException("Не реализован метод!");
        }

        public virtual void AllTextBox_TextChanged(object sender, EventArgs e)
        {
            var sourceData = CollectData();
            ChangeDataEvent(this, new WeldContainerCntrEventArgs(sourceData));
        }

        public void CreatePictureBox(Bitmap image, Point location)
        {
            var picBoxes = Controls.Cast<Control>().
    Where(x => x.GetType() == typeof(PictureBox));

            if (picBoxes.Count() == 0)
            {
                var pxb = new PictureBox()
                {
                    Margin = new Padding(0, 10, 0, 0),
                    Name = "pictureBox",
                    SizeMode = PictureBoxSizeMode.AutoSize,
                    BorderStyle = BorderStyle.FixedSingle,
                    Image = image
                };

                location.X -= pxb.Width / 2;
                pxb.Location = location;

                this.Controls.Add(pxb);
                pxb.BringToFront();
            }
            else
            {
                var pxb = picBoxes.First() as PictureBox;
                Controls.Remove(pxb);
                //release memory by disposing
                pxb.Dispose();
            }

            InfoBoxClickEvent?.Invoke();
        }
    }
}
