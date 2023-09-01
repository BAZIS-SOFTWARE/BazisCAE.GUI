using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using Geometry;
using PlayerControl;

namespace ResultModule
{
    public partial class AnimationPage : UserControl
    {
        public event Action<object, CreateAnimationEventArgs> CreateGIFAnimationEvent;
        public event Action<object, ShowResultEventArgs> ShowResultEvent;
        public event Action<string> SaveScreenShotEvent;

        public AnimationPage()
        {
            InitializeComponent();
        }

        Dictionary<string, List<float>> resItems;

        public void SetResultsItems(Dictionary<string, List<float>> resItems)
        {
            foreach (var item in resItems.Keys)
            {
                cmbResultNames.Items.Add(item);
            }

            this.resItems = resItems;
        }

        public void ClearResultsItems()
        {
            cmbResultNames.Items.Clear();
        }

        //private void incrButton_Click(object sender, EventArgs e)
        //{
        //    var val = colorSlider.Value;
        //    var setVal = val + 1;
        //    if (setVal <= colorSlider.Maximum)
        //    {
        //        colorSlider.Value = setVal;
        //        ShowResults(colorSlider.Value);
        //    }
        //}

        //private void decrButton_Click(object sender, EventArgs e)
        //{
        //    var val = colorSlider.Value;
        //    var setVal = val - 1;
        //    if (setVal >= colorSlider.Minimum)
        //    {
        //        colorSlider.Value = setVal;
        //        ShowResults(colorSlider.Value);
        //    }
        //}

        //private void btnMoveToFinish_Click(object sender, EventArgs e)
        //{
        //    colorSlider.Value = colorSlider.Maximum;
        //}

        private void btnPlayResults_Click(object sender, EventArgs e)
        {
            PlayResults(false);
        }

        private void PlayResults(bool makeGifAnimation)
        {
            var timer = new System.Windows.Forms.Timer();

            timer.Interval = int.Parse(txbDelayTime.Text);
            var ind = 0;

            var scaleFactor = int.Parse(txbScale.Text);
            var maxInd = player.StopValue;
            timer.Tick += new EventHandler
                (
                new Action<object, EventArgs>((s, a) =>
                {
                    if (ind > maxInd)
                    {
                        timer.Stop();

                        if (makeGifAnimation)
                            CreateGIFAnimationEvent(this, new CreateAnimationEventArgs(chbDelTempScrs.Checked, timer.Interval));
                    }

                    else
                    {
                        var testArr = richTextBox.Text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                        //playerControl.CheckStartTime = ind;
                        MarkTimeStep(ind);
                        var time = float.Parse(testArr[ind]);
                        ShowResultEvent(this, new ShowResultEventArgs(cmbResultNames.SelectedItem.ToString(), time, scaleFactor));

                        if (makeGifAnimation)
                            SaveScreenShotEvent($@"screenShot_{ind}");
                    }
                    ind++;
                })
                );
            timer.Start();
        }


        //private void btnMoveToStart_Click(object sender, EventArgs e)
        //{
        //    colorSlider.Value = colorSlider.Minimum;
        //}

        private void cmbResultNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            playerPanel.Enabled = true;
            var times = resItems[cmbResultNames.SelectedItem.ToString()];

            richTextBox.Clear();
            if(times.Count() > 1)
                player.StopValue = times.Count() - 1;
            else if(times.Count() == 1)
                player.StartValue = 1;

            player.CurrentValue = 0;
            foreach (var time in times)
                richTextBox.AppendText($"{time}\n");
        }

        private void txbDelayTime_Leave(object sender, EventArgs e)
        {
            int res;

            if(!int.TryParse(txbDelayTime.Text,out res) || int.Parse(txbDelayTime.Text) <= 0)
            {
                txbDelayTime.Text = "100";
                MessageBox.Show("Некорректный ввод!");
            }
        }

        private void richTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                //Получаем индекс нажатого знака
                int charIndex = richTextBox.GetCharIndexFromPosition(e.Location);
                //Получаем номер строки по знаку
                var lineIndex = richTextBox.GetLineFromCharIndex(charIndex);

                //playerControl.CheckCurrentTime = lineIndex;
                //colorSlider.Value = lineIndex;
                ShowResults(lineIndex);

                //Получаем номер индекса, который стоит 1-м в строке

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MarkTimeStep(int lineIndex)
        {
            int startFromIndex = richTextBox.GetFirstCharIndexFromLine(lineIndex);
            //Получаем длину строки
            int lineLength = richTextBox.Lines[lineIndex].Length;

            richTextBox.SelectAll();
            richTextBox.SelectionBackColor = System.Drawing.Color.White;
            //Выделяем текст с первого символа строки до конца строки
            richTextBox.Select(startFromIndex, lineLength);
            //Устанавливаем выделенному тексту оранжевый фон
            richTextBox.SelectionBackColor = System.Drawing.Color.Orange;
            richTextBox.Select(startFromIndex, 0);
        }

        private void ColorSlider_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.NewValue != e.OldValue)
            {
                ShowResults(e.NewValue);
            }
        }

        private void ShowResults(int index)
        {
            MarkTimeStep(index);
            var scaleFactor = int.Parse(txbScale.Text);
            var time = float.Parse(richTextBox.Lines[index]);
            ShowResultEvent(this, new ShowResultEventArgs(cmbResultNames.SelectedItem.ToString(), time, scaleFactor));
        }

        private void btnCreateAnimation_Click(object sender, EventArgs e)
        {
            PlayResults(true);
        }

        internal void Clear()
        {
            playerPanel.Enabled = false;
            richTextBox.Clear();
        }

        private void playerControl_CheckingEvent(object arg1, float arg2)
        {

        }

        private void playerControl_StartCheckingEvent(object obj)
        {
            PlayResults(false);

       //     var gridViewList = new List<DataGridView>();
       //     SearchControls(this, gridViewList);

       //     var checkStopTime = gridViewList[0].Rows.Cast<DataGridViewRow>()
       //.Max(r => Convert.ToSingle(r.Cells["stopColumn"].Value, CultureInfo.InvariantCulture));

       //     var checkStartTime = gridViewList[0].Rows.Cast<DataGridViewRow>()
       //                 .Min(r => Convert.ToSingle(r.Cells["startColumn"].Value, CultureInfo.InvariantCulture));

       //     player.CheckStartTime = checkStartTime;
       //     player.CheckStopTime = checkStopTime;
       //     player.CheckCurrentTime = checkStartTime;
        }

        private void playerControl_StopCheckingEvent(object obj)
        {

        }
    }
}
