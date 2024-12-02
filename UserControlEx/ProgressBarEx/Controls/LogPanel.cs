using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyComponents.Windows.Controls.Logging
{
    public partial class LogPanel : UserControl
    {
    	[Category("Buffer")]
    	public event EventHandler TextBoxFull=null;
    
        public LogPanel()
        {
            InitializeComponent();
            textBoxLog.Clear();
        }

        #region New Line After Message
        public bool AddLine = true;
        private bool ClearOnFull = false;
    
       [Category("LogDesign")]
        public bool NewLineAfterMessage
        {
            get
            {
                return AddLine;
            }
            set
            {
                AddLine = true;
            }
        }
        #endregion

        #region Length
       [Category("LogDesign")]
	public int MaxLength
        {
            get
            {
                return textBoxLog.MaxLength;
            }
            set
            {
                textBoxLog.MaxLength = value;
            }
        }

       [Category("LogDesign")]
        public bool AutoClearOnFull
        {
            get
            {
                return ClearOnFull;
            }
            set
            {
                ClearOnFull = value;
            }
        }
        #endregion

        [Category("LogDesign")]
        public string Title
        {
            get
            {
                return labelLog.Text;
            }
            set
            {
                labelLog.Text = value;
                labelLog.Visible=(value!=String.Empty);
            }
        }

        
        #region Logger
        delegate void LogMessageCallback(string Message);

        [System.Diagnostics.DebuggerStepThrough()]
        public void LogMessage(string Message)
        {
            if (Message == "")
                return;
            if (textBoxLog.InvokeRequired)
            {
                LogMessageCallback Temp = new LogMessageCallback(LogMessage);
                textBoxLog.Invoke(Temp, new object[] { Message });
            }
            else
            {
                if (textBoxLog.Text.Length + Message.Length >= textBoxLog.MaxLength)
                {
                    if (TextBoxFull != null)
                        TextBoxFull(this, new EventArgs());
                    if (AutoClearOnFull)
                        textBoxLog.Clear();
                }
                textBoxLog.AppendText(Message);
                if (AddLine)
                    textBoxLog.AppendText(Environment.NewLine);
            }
        }
        #endregion

        #region LogClear
        delegate void LogClearCallback();

        [System.Diagnostics.DebuggerStepThrough()]
        public void LogClear()
        {
            if (textBoxLog.InvokeRequired)
            {
                LogClearCallback Temp = new LogClearCallback(LogClear);
                textBoxLog.Invoke(Temp, null);
            }
            else
            {
                textBoxLog.Clear();
            }
        }
        #endregion
    }
}

