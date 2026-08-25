using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using BazisGUI.AvaloniaUI.Clip.ViewModels;
using System;

namespace BazisGUI.AvaloniaUI.Clip.Views
{
    /// <summary>
    /// Окно «Скрыть плоскостью». Содержит только поведение окна (перетаскивание,
    /// закрытие и drag-изменение значений D/толщины); вся логика — в
    /// <see cref="ClipViewModel"/>.
    /// </summary>
    public partial class ClipWindow : Window
    {
        private bool isDragging;
        private bool draggingThickness;
        private double dragStartX;

        public ClipWindow()
        {
            InitializeComponent();

            // Поля D и толщины изменяются перетаскиванием (как в WinForms): зажали кнопку
            // мыши в поле и потянули — значение меняется в зависимости от направления.
            // Подписываемся с handledEventsToo=true в туннельной фазе, чтобы перехватывать
            // события указателя, которые TextBox помечает как обработанные
            // (установка каретки / выделение текста).
            foreach (var box in new Control[] { ThicknessInput, OffsetDInput })
            {
                box.AddHandler(InputElement.PointerPressedEvent, OnInputPointerPressed, RoutingStrategies.Tunnel, true);
                box.AddHandler(InputElement.PointerMovedEvent, OnInputPointerMoved, RoutingStrategies.Tunnel, true);
                box.AddHandler(InputElement.PointerReleasedEvent, OnInputPointerReleased, RoutingStrategies.Tunnel, true);
            }
        }

        private void OnTitleBarPointerPressed(object sender, PointerPressedEventArgs e)
        {
            if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
                BeginMoveDrag(e);
        }

        private void OnCloseClick(object sender, RoutedEventArgs e) => Close();

        private void OnInputPointerPressed(object sender, PointerPressedEventArgs e)
        {
            var control = sender as Control;
            if (control == null || !e.GetCurrentPoint(control).Properties.IsLeftButtonPressed)
                return;

            isDragging = true;
            draggingThickness = ReferenceEquals(control, ThicknessInput);
            dragStartX = e.GetPosition(control).X;
            e.Pointer.Capture(control);
            e.Handled = true;
        }

        private void OnInputPointerMoved(object sender, PointerEventArgs e)
        {
            if (!isDragging || DataContext is not ClipViewModel viewModel)
                return;

            var control = sender as Control;
            if (control == null)
                return;

            var x = e.GetPosition(control).X;
            var delta = Math.Sign(x - dragStartX) * viewModel.DeltaD;
            dragStartX = x;

            if (draggingThickness)
                viewModel.AdjustThickness(delta);
            else
                viewModel.AdjustOffset(delta);

            e.Handled = true;
        }

        private void OnInputPointerReleased(object sender, PointerReleasedEventArgs e)
        {
            if (!isDragging)
                return;

            isDragging = false;
            e.Pointer.Capture(null);
            e.Handled = true;
        }
    }
}
