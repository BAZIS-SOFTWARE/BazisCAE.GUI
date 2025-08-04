using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Reflection.Emit;

namespace BaseModule.Player
{
    public enum CheckState : int { start, pause, continuation };
    public partial class PlayerControl: UserControl
    {
        System.Windows.Forms.Timer timer;

        

        [Category("Colors")]
        public Color TextValueColor
        {
            get { return colorSlider.TextValueColor; }
            set { colorSlider.TextValueColor = value; }
        }
        public Color SliderBarInnerColor
        {
            get { return colorSlider.BarInnerColor; }
            set { colorSlider.BarInnerColor = value; }
        }
        [Category("Colors")]
        public Color SliderBarOuterColor
        {
            get { return colorSlider.BarOuterColor; }
            set { colorSlider.BarOuterColor = value; }
        }

        [Category("Colors")]
        public Color SliderElapsedInnerColor
        {
            get { return colorSlider.ElapsedInnerColor; }
            set { colorSlider.ElapsedInnerColor = value; }
        }

        [Category("Colors")]
        public Color SliderElapsedOuterColor
        {
            get { return colorSlider.ElapsedOuterColor; }
            set { colorSlider.ElapsedOuterColor = value; }
        }

        [Category("General")]
        public bool ShowTextValue 
        {
            get { return colorSlider.ShowTextValue; } 
            set { colorSlider.ShowTextValue = value; }
        }

        [Category("General")]
        public CheckState CheckState { get; set; }

        public event Action<object, int> CheckingEvent;
        public event Action<object> StopCheckingEvent;
        public event Action<object> StartCheckingEvent;
        public event Action<object> PauseCheckingEvent;

        [Category("General")]
        public int CurrentValue 
        {
            get { return colorSlider.Value; }
            set { colorSlider.Value = value; }
        }

        [Category("General")]
        public int StartValue
        {
            get { return colorSlider.Minimum; }
            set { colorSlider.Minimum = value; }
        }
        [Category("General")]
        public int StopValue 
        { 
            get { return colorSlider.Maximum; }
            set { colorSlider.Maximum = value; } 
        }

        [Category("General")]
        public int SpeedValue { get; set; } = 500;

        public PlayerControl()
        {
            InitializeComponent();
            timer = new System.Windows.Forms.Timer();
            timer.Tick += new System.EventHandler(Timer_Tick);
        }

        public virtual void StopChecking_Click(object sender, EventArgs e)
        {
            StopChecking();

            StopCheckingEvent?.Invoke(this);
        }

        public void StopChecking()
        {
            timer.Stop();
            timer.Enabled = false;

            CheckState = CheckState.start;
            CurrentValue = StartValue;
            SetCheckButtonState();
        }

        public virtual void StartChecking_Click(object sender, EventArgs e)
        {

            if (CheckState == CheckState.pause)
            {
                CheckState = CheckState.continuation;
                timer.Stop();
                SetCheckButtonState();

                PauseCheckingEvent?.Invoke(this);
            }
            else if (CheckState == CheckState.start)
            {
                CheckState = CheckState.pause;

                timer.Enabled = true;
                timer.Interval = SpeedValue;

                StartCheckingEvent?.Invoke(this);
                Thread.Sleep(100);

                SetCheckButtonState();
                timer.Start();
            }
            else
            {
                CheckState = CheckState.pause;

                timer.Start();
                SetCheckButtonState();
            }

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (CurrentValue == StopValue)
            {
                timer.Stop();
                timer.Enabled = false;

                CheckState = CheckState.start;
                CurrentValue = StartValue;
                SetCheckButtonState();

                StopCheckingEvent?.Invoke(this);
            }
            else
            {
                CheckingEvent?.Invoke(this, CurrentValue);
                Thread.Sleep(100);
                CurrentValue ++;
            }

        }

        private void SetCheckButtonState()
        {
            if (CheckState == CheckState.start)
            {
                btnCheckDinamic.Image = BaseModule.Properties.Resources.StartCheck;
            }
            else if (CheckState == CheckState.pause)
            {
                btnCheckDinamic.Image = BaseModule.Properties.Resources.Pause.ToBitmap();
            }
            else
            {
                btnCheckDinamic.Image = BaseModule.Properties.Resources.StartCheck;
            }
        }
    }
}
