using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Threading;
using System;
using System.Data;
using System.Globalization;

namespace BazisAvaloniaGUI.Databases;

internal sealed class DataGridViewCellEventArgs(int column, int row) : EventArgs
{
    public int ColumnIndex { get; } = column;
    public int RowIndex { get; } = row;
}
internal sealed class TableCell(DataTableEditor editor, int row, int column)
{
    public object Value { get => editor.DataSource.Rows[row][column]; set => editor.DataSource.Rows[row][column] = value; }
    public DataColumn OwningColumn => editor.DataSource.Columns[column];
}
internal sealed class TableRow(DataTableEditor editor, int row)
{
    public DataTableEditor DataGridView => editor;
    public TableCell[] Cells { get; } = GetCells(editor, row);
    private static TableCell[] GetCells(DataTableEditor editor, int row)
    {
        var cells = new TableCell[editor.DataSource.Columns.Count];
        for (var i = 0; i < cells.Length; i++) cells[i] = new TableCell(editor, row, i);
        return cells;
    }
}
internal sealed class DataGridViewRowCancelEventArgs(TableRow row) : EventArgs
{
    public TableRow Row { get; } = row;
    public bool Cancel { get; set; }
}

// DataTable remains the single editable source, including structure-driven column changes.
internal sealed class DataTableEditor : UserControl
{
    private DataTable table;
    private bool refreshPending;
    private bool committing;
    private readonly ScrollViewer scroll = new() { HorizontalScrollBarVisibility = Avalonia.Controls.Primitives.ScrollBarVisibility.Auto };
    public event EventHandler<DataGridViewCellEventArgs> CellBeginEdit;
    public event EventHandler<DataGridViewCellEventArgs> CellEndEdit;
    public event EventHandler<DataGridViewRowCancelEventArgs> UserDeletingRow;
    public event Action<int> ColumnHeaderClick;
    public int SelectedColumn { get; set; } = -1;
    public TableCell this[int column, int row] => new(this, row, column);
    public DataTable DataSource
    {
        get => table;
        set
        {
            if (table != null) { table.RowChanged -= OnChanged; table.RowDeleted -= OnChanged; table.Columns.CollectionChanged -= OnColumnsChanged; }
            table = value;
            if (table != null) { table.RowChanged += OnChanged; table.RowDeleted += OnChanged; table.Columns.CollectionChanged += OnColumnsChanged; }
            Refresh();
        }
    }
    public DataTableEditor() { Content = scroll; }
    private void OnChanged(object sender, DataRowChangeEventArgs e) => ScheduleRefresh();
    private void OnColumnsChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) => ScheduleRefresh();
    private void ScheduleRefresh()
    {
        if (refreshPending) return;
        refreshPending = true;
        Dispatcher.UIThread.Post(() => { refreshPending = false; Refresh(); });
    }
    public void EditValue(int row, int column, object value)
    {
        var e = new DataGridViewCellEventArgs(column, row);
        CellBeginEdit?.Invoke(this, e);
        table.Rows[row][column] = value;
        CellEndEdit?.Invoke(this, e);
        Refresh();
    }
    public void DeleteRow(int row)
    {
        var e = new DataGridViewRowCancelEventArgs(new TableRow(this, row));
        UserDeletingRow?.Invoke(this, e);
        if (!e.Cancel) table.Rows.RemoveAt(row);
        Refresh();
    }
    public void Refresh()
    {
        var grid = new Grid();
        scroll.Content = grid;
        if (table == null) return;
        grid.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Auto));
        for (var col = 0; col < table.Columns.Count; col++) grid.ColumnDefinitions.Add(new ColumnDefinition(new GridLength(130)));
        for (var row = 0; row <= table.Rows.Count; row++) grid.RowDefinitions.Add(new RowDefinition(GridLength.Auto));
        for (var col = 0; col < table.Columns.Count; col++)
        {
            var index = col;
            var header = new Button { Content = table.Columns[col].ColumnName, Padding = new Thickness(4), HorizontalAlignment = HorizontalAlignment.Stretch,
                Background = index == SelectedColumn ? Brushes.Orange : Brush.Parse("#E1E1E1") };
            header.Click += (_, _) => { SelectedColumn = index; ColumnHeaderClick?.Invoke(index); Refresh(); };
            Grid.SetColumn(header, col + 1); grid.Children.Add(header);
        }
        for (var row = 0; row < table.Rows.Count; row++)
        {
            var rowIndex = row;
            var delete = new Button { Content = "×", Padding = new Thickness(4), Name = "DeleteRow" };
            delete.Click += (_, _) => DeleteRow(rowIndex);
            Grid.SetRow(delete, row + 1); grid.Children.Add(delete);
            for (var col = 0; col < table.Columns.Count; col++)
            {
                var columnIndex = col;
                var editor = new TextBox { Text = Convert.ToString(table.Rows[row][col], CultureInfo.CurrentCulture), Height = 20, MinHeight = 20, Padding = new Thickness(2, 0), FontSize = 11 };
                var original = editor.Text;
                void Commit()
                {
                    if (committing || editor.Text == original || rowIndex >= table.Rows.Count) return;
                    try
                    {
                        committing = true;
                        var value = string.IsNullOrEmpty(editor.Text) && table.Columns[columnIndex].DataType != typeof(string)
                            ? DBNull.Value : Convert.ChangeType(editor.Text, table.Columns[columnIndex].DataType, CultureInfo.CurrentCulture);
                        EditValue(rowIndex, columnIndex, value);
                        original = editor.Text;
                    }
                    catch (Exception ex) { editor.Text = Convert.ToString(table.Rows[rowIndex][columnIndex]); _ = MessageBox.Show(this, ex.Message); }
                    finally { committing = false; }
                }
                editor.LostFocus += (_, _) => Commit();
                editor.KeyDown += (_, e) => { if (e.Key == Key.Enter) { Commit(); e.Handled = true; } };
                Grid.SetRow(editor, row + 1); Grid.SetColumn(editor, col + 1); grid.Children.Add(editor);
            }
        }
    }
}
