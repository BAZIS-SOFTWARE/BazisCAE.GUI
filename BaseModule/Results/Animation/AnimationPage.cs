using BaseModule.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace BaseModule.Results.Animation
{
    public partial class AnimationPage : UserControl
    {
        public event Action<object, CreateAnimationEventArgs> CreateGIFAnimationEvent;
        public event Action<object, ShowResultEventArgs> ShowResultEvent;
        public event Action<string> SaveScreenShotEvent;
        public event Action<string> SelectResultsEvent;

        public void StopAnimation()
        {
            player.StopChecking();
        }

        public bool IsAnimationStarted
        {
            get
            {
                if (player.CheckState == BaseModule.Player.CheckState.pause)
                    return true;
                else return false;
            }
        }

        public AnimationPage()
        {
            InitializeComponent();
        }

        //public bool MakeGifAnimation { get; private set; } = false;

        public void ClearResultsItems()
        {
            richTextBox.Clear();
        }

        public void ShowResultsTimeSteps(List<float> times)
        {
            if (times.Count() > 1)
                player.StopValue = times.Count() - 1;
            else if (times.Count() == 1)
                player.StartValue = 0;

            richTextBox.Clear();

            for (int i = 0; i < times.Count; i++)
            {
                if (i == times.Count - 1)
                    richTextBox.AppendText($"{times[i]}");
                else
                    richTextBox.AppendText($"{times[i]}\n");
            }
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

                player.CurrentValue = lineIndex;

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
            //richTextBox.Select(startFromIndex, 0);
            //var text = richTextBox.SelectedText;
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
            ShowResultEvent(this, new ShowResultEventArgs(time, scaleFactor));
        }

        private void btnCreateAnimation_Click(object sender, EventArgs e)
        {
            try
            {
                var delay = int.Parse(txbDelayTime.Text);
                var times = richTextBox.Lines.Select(x => float.Parse(x)).ToArray();
                var scaleFactor = int.Parse(txbScale.Text);
                CreateGIFAnimationEvent(this, new CreateAnimationEventArgs(times, scaleFactor, chbDelTempScrs.Checked, delay));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
   
        }

        private void playerControl_CheckingEvent(object arg1, float arg2)
        {
                MarkTimeStep((int)arg2);
                var scaleFactor = int.Parse(txbScale.Text);
            if (richTextBox.SelectedText != string.Empty)
            {
                var time = Convert.ToSingle(richTextBox.SelectedText);
                ShowResultEvent(this, new ShowResultEventArgs(time, scaleFactor));
            }
            else
                player.StopChecking();



            //if (MakeGifAnimation)
            //    SaveScreenShotEvent($@"screenShot_{arg2}");
        }

        private void playerControl_StartCheckingEvent(object obj)
        {
                player.SpeedValue = int.Parse(txbDelayTime.Text);

                if (richTextBox.Lines.Length > 1)
                    player.StopValue = richTextBox.Lines.Length - 1;
                else if (richTextBox.Lines.Length == 1)
                    player.StartValue = 0;
        }

        private void playerControl_StopCheckingEvent(object obj)
        {
            //if (MakeGifAnimation)
            //{
            //    MakeGifAnimation = false;
            //}        
        }
    }
}
