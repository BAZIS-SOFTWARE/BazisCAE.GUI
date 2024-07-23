using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlsEx
{
    public partial class ToolStripEx : ToolStrip
    {
        [Category("Color")]
        [Description("Set up color")]
        public Color BackGroundColor
        {
            get
            {
                return BaseToolStrRender.BackGroundColor;
            }

            set
            {
                BaseToolStrRender.BackGroundColor = value;
            }
        }
        [Category("Color")]
        [Description("Set up color")]
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
        [Category("Color")]
        [Description("Set up color")]
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
        [Category("Color")]
        [Description("Set up color")]
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
        [Category("Color")]
        [Description("Set up color")]
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
        [Category("Location")]
        [Description("Set up location")]
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
        [Category("Location")]
        [Description("Set up location")]
        public Point ItemLocation
        {
            get
            {
                return BaseToolStrRender.ItemLocation;
            }

            set
            {
                BaseToolStrRender.ItemLocation = value;
            }
        }
        [Category("Size")]
        [Description("Set up size")]
        public int SplitButtonHeight
        { 
            get
            {
                return BaseToolStrRender.SplitButtonHeight;
            }
            set
            {
                BaseToolStrRender.SplitButtonHeight = value;
            }
        }
        [Category("Size")]
        [Description("Set up size")]
        public int SplitButtonClickWidth
        {
            get
            {
                return BaseToolStrRender.SplitButtonClickWidth;
            }
            set
            {
                BaseToolStrRender.SplitButtonClickWidth = value;
            }
        }
        [Category("Size")]
        [Description("Set up size")]
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
        [Category("Size")]
        [Description("Set up size")]
        public Point ImageRectangleSize
        {
            get
            {
                return BaseToolStrRender.ImageRectangleSize;
            }
            set
            {
                BaseToolStrRender.ImageRectangleSize = value;
            }
        }

        [Category("Size")]
        [Description("Set up size")]
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
        [Category("Frame")]
        [Description("Set up frame")]
        public bool GeneralFrame
        {
            get
            {
                return BaseToolStrRender.GeneralFrame;
            }
            set
            {
                BaseToolStrRender.GeneralFrame = value;
            }
        }

        [Category("Frame")]
        [Description("Set up frame")]
        public bool ItemFrame
        {
            get
            {
                return BaseToolStrRender.ItemFrame;
            }
            set
            {
                BaseToolStrRender.ItemFrame = value;
            }
        }

        [Category("Frame")]
        [Description("Set up frame")]
        public bool TextBoxFrame
        {
            get
            {
                return BaseToolStrRender.TextBoxFrame;
            }
            set
            {
                BaseToolStrRender.TextBoxFrame = value;
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
