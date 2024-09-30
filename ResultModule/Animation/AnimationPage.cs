using BaseModule.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace ResultModule.Animation
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

        Dictionary<string, List<float>> resItems;

        //public bool MakeGifAnimation { get; private set; } = false;

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
            cmbResultNames.Text = "выберите результаты...";
            cmbResultNames.Items.Clear();
            resItems.Clear();
            richTextBox.Clear();
        }    
        
        public void ShowResultsTimeSteps(string resName)
        {
            if(resItems.ContainsKey(resName))
            {
                playerPanel.Enabled = true;

                var times = resItems[resName];

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
                cmbResultNames.Text = resName;
                SelectResultsEvent?.Invoke(resName);
            }
        }

        private void cmbResultNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowResultsTimeSteps(cmbResultNames.SelectedItem.ToString());
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
            try
            {
                var delay = int.Parse(txbDelayTime.Text);
                var times = richTextBox.Lines.Select(x => float.Parse(x)).ToArray();
                var scaleFactor = int.Parse(txbScale.Text);
                CreateGIFAnimationEvent(this, new CreateAnimationEventArgs(cmbResultNames.SelectedItem.ToString(), times, scaleFactor, chbDelTempScrs.Checked, delay));
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

            var times = resItems[cmbResultNames.SelectedItem.ToString()];
            
            ShowResultEvent(this, new ShowResultEventArgs(cmbResultNames.SelectedItem.ToString(), times[(int)arg2], scaleFactor));

            //if (MakeGifAnimation)
            //    SaveScreenShotEvent($@"screenShot_{arg2}");
        }

        private void playerControl_StartCheckingEvent(object obj)
        {
            //PlayResults(false);
            player.SpeedValue = int.Parse(txbDelayTime.Text);

            var times = resItems[cmbResultNames.SelectedItem.ToString()];

            if (times.Count() > 1)
                player.StopValue = times.Count() - 1;
            else if (times.Count() == 1)
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
