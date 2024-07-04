using System;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;

namespace TaskModule.WeldingModule.WeldingTypeControls
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

        public virtual IEnumerable<bool> GetValidatorsResults()
        {
            throw new NotImplementedException("Метод \"GetValidatosResults\" не реализован");
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
            var openForms = Application.OpenForms.Cast<Form>();


            var forms = openForms.Where(x => x.Name.Equals("frmWeldingRegime"));

            if(forms.Count() > 0)
                forms.First().Close();
            else
            {
                var formForPic = new Form() { AutoSize = false, ShowIcon = false};
                formForPic.Name = "frmWeldingRegime";
                formForPic.StartPosition = FormStartPosition.CenterScreen;

                PictureBox pb = new PictureBox()
                {
                    Dock = DockStyle.Fill,
                    Image = image,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = image.Size
                };

                formForPic.ClientSize = pb.Size;
                formForPic.Controls.Add(pb);
                formForPic.TopMost = true;

                formForPic.Show();
            }
        }
    }
}
