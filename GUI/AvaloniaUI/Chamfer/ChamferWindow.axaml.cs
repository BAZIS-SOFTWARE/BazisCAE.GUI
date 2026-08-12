using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;

namespace BazisGUI.AvaloniaUI.Chamfer
{
    public partial class ChamferWindow : Window
    {
        public IChamferSelectionService SelectionService { get; }

        public ChamferWindow()
            : this(null)
        {
        }

        public ChamferWindow(IChamferSelectionService selectionService)
        {
            SelectionService = selectionService;
            InitializeComponent();
        }

        private void OnTitleBarPointerPressed(object sender, PointerPressedEventArgs e)
        {
            if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
                BeginMoveDrag(e);
        }

        private void OnCloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OnAngleTabClick(object sender, RoutedEventArgs e)
        {
            SetSelectedTab(useAngle: true);
        }

        private void OnLengthTabClick(object sender, RoutedEventArgs e)
        {
            SetSelectedTab(useAngle: false);
        }

        private void SetSelectedTab(bool useAngle)
        {
            AngleFields.IsVisible = useAngle;
            LengthFields.IsVisible = !useAngle;
            AngleUnderline.IsVisible = useAngle;
            LengthUnderline.IsVisible = !useAngle;
            AngleTabButton.FontWeight = useAngle ? Avalonia.Media.FontWeight.SemiBold : Avalonia.Media.FontWeight.Normal;
            LengthTabButton.FontWeight = useAngle ? Avalonia.Media.FontWeight.Normal : Avalonia.Media.FontWeight.SemiBold;
        }
    }
}
