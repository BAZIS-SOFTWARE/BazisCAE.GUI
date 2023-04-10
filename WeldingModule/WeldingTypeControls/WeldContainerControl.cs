using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Functions.Search;
using System.Reflection;

namespace WeldingModule.WeldingTypeControls
{
    public partial class WeldContainerControl : UserControl
    {
        public event Action<object, WeldContainerCntrEventArgs> ChangeDataEvent;

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

        public void CreatePictureBox(string pictureName, Point location)
        {
            var cntrList = new List<PictureBox>();
            RecursiveSearch.AllTypedControls(this, cntrList);

            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream(pictureName);

            if (cntrList.Count == 0)
            {
                var pxb = new PictureBox()
                {
                    Margin = new Padding(0, 10, 0, 10),
                    Name = "pictureBox",
                    SizeMode = PictureBoxSizeMode.AutoSize,
                    BorderStyle = BorderStyle.FixedSingle,
                    Image = new Bitmap(stream)
                };

                location.X -= pxb.Width / 2;
                pxb.Location = location;

                this.Controls.Add(pxb);
                pxb.BringToFront();
            }
            else
            {
                var pxb = cntrList[0] as PictureBox;
                Controls.Remove(pxb);
                //release memory by disposing
                pxb.Dispose();
            }
        }
    }
}
