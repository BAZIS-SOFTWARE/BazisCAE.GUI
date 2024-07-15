using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseModule.ControlsLib
{
    public partial class ToolStripEx : ToolStrip
    {
        public Color FrameColor 
        { 
            get
            {
                return BaseToolStrRender.FrameColor;
            }

            set
            {
                BaseToolStrRender.FrameColor = value;
            }
        }
        public Color TopColor
        {
            get
            {
                return BaseToolStrRender.TopColor;
            }

            set
            {
                BaseToolStrRender.TopColor = value;
            }
        }
        public Color BottomColor
        {
            get
            {
                return BaseToolStrRender.BottomColor;
            }

            set
            {
                BaseToolStrRender.BottomColor = value;
            }
        }
        public Color ItemPressColor
        {
            get
            {
                return BaseToolStrRender.ItemPressColor;
            }

            set
            {
                BaseToolStrRender.ItemPressColor = value;
            }
        }
        public Color ItemSelectColor
        {
            get
            {
                return BaseToolStrRender.ItemSelectColor;
            }

            set
            {
                BaseToolStrRender.ItemSelectColor = value;
            }
        }
        public Color ItemBackGroundColor
        {
            get
            {
                return BaseToolStrRender.ItemBackGroundColor;
            }

            set
            {
                BaseToolStrRender.ItemBackGroundColor = value;
            }
        }

        public Point IconLocation
        {
            get
            {
                return BaseToolStrRender.IconLocation;
            }

            set
            {
                BaseToolStrRender.IconLocation = value;
            }
        }

        public int SplitButtonWidth 
        { 
            get
            {
                return BaseToolStrRender.SplitButtonWidth;
            }
            set
            {
                BaseToolStrRender.SplitButtonWidth = value;
            }
        }

        public int TextBoxHeight
        {
            get
            {
                return BaseToolStrRender.TextBoxHeight;
            }
            set
            {
                BaseToolStrRender.TextBoxHeight = value;
            }
        }

        public int SplitButtonTriangleSize
        {
            get
            {
                return BaseToolStrRender.SplitButtonTriangleSize;
            }
            set
            {
                BaseToolStrRender.SplitButtonTriangleSize = value;
            }
        }

        BaseToolStrRender BaseToolStrRender { get; set; } = new BaseToolStrRender();
        public ToolStripEx()
        {
            InitializeComponent();
            Renderer = BaseToolStrRender;
        }
    }
}
