
using System.Drawing;
using System.Windows.Forms;

namespace BaseModule.ToolStrips
{
    public partial class DisplayToolStrip : ToolStrip
    {
        public DisplayToolStrip()
        {
            InitializeComponent();
        }

        public Image BoundaryContoursImage
        {
            get { return btnBoundaryContours.Image; }
            set { btnBoundaryContours.Image = value; }
        }

        public Image ElementsFramesImage
        {
            get { return btnElementsFrames.Image; }
            set { btnElementsFrames.Image = value; }
        }

        public Image ElementsFramesAndSurfacesImage
        {
            get { return btnElementsFramesAndSurfaces.Image; }
            set { btnElementsFramesAndSurfaces.Image = value; }
        }

        public Image ElementsSurfacesImage
        {
            get { return btnElementsSurfaces.Image; }
            set { btnElementsSurfaces.Image = value; }
        }

        public Image ElementsNormalsImage
        {
            get { return btnElementsNormals.Image; }
            set { btnElementsNormals.Image = value; }
        }

        public Image ShowBasisImage
        {
            get { return btnShowBasis.Image; }
            set { btnShowBasis.Image = value; }
        }

        public Image SurfaceNodesImage
        {
            get { return btnSurfaceNodes.Image; }
            set { btnSurfaceNodes.Image = value; }
        }

        public Image VolumeNodesImage
        {
            get { return btnVolumeNodes.Image; }
            set { btnVolumeNodes.Image = value; }
        }

        public Image TitleInfoImage
        {
            get { return btnTitleInfo.Image; }
            set { btnTitleInfo.Image = value; }
        }
    }
}
