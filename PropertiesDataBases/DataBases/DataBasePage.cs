using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using PropertiesCalculator.Interfaces;
using UserControlsEx;
using UserControlsEx.Graph;

namespace PropertiesDataBases.DataBases
{
    public partial class DataBasePage : UserControl
    {
        public event Action LoadEvent;
        public event Action<string> SaveEvent;
        /// <summary>
        /// DataExtension
        /// </summary>
        public string DataExtension { get; set; }
        /// <summary>
        /// Loader
        /// </summary>
        public ILoader Loader;
        /// <summary>
        /// Saver
        /// </summary>
        public ISaver Saver;

        /// <summary>
        /// HeadColor
        /// </summary>
        public Color HeadColor { get; set; } = Color.Silver;

        /// <summary>
        /// TreeView
        /// </summary>
        /// 
        internal TreeView TreeView
        {
            get
            {
                return treeView;
            }
        }

        public DataGridView DataGridView
        {
            get
            {
                return dataGridView;
            }
        }

        public GraphContainer GraphContainer
        {
            get
            {
                return graphContainer;
            }
        }

        public static void SearchControls<T>(Control ctrl, List<T> controls) where T : Control
        {
            // Работаем только с элементами искомого типа   
            if (ctrl.GetType() == typeof(T))
            {
                controls.Add((T)ctrl);
            }
            // Проходим через элементы рекурсивно,   
            // чтобы не пропустить элементы,   
            //которые находятся в контейнерах   
            foreach (Control ctrlChild in ctrl.Controls)
            {
                SearchControls(ctrlChild, controls);
            }
        }

        public bool LabelEditFlag { get; set; }
        public DataGridViewCell EditCell { get; private set; }
        public object OldCellValue { get; private set; }
        public object NewCellValue { get; private set; }

        public DataBasePage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// OpenFileDB_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void OpenFileDB_Click(object sender, EventArgs e)
        {
            LoadEvent?.Invoke();
        }

        public virtual void ConvertToDictionary(DataSet dataSet)
        {
            throw new Exception("Метод не реализован!");
        }

        public virtual DataSet ConvertToDataSet()
        {
            throw new Exception("Метод не реализован!");
        }

        public List<GraphData> SetGraphData(DataTable table, string header, Color color, string xUnit, string yUnit)
        {

            var grDataRange = new List<GraphData>();

            if (table.Columns[0].DataType != typeof(string))
                for (int i = 1; i < table.Columns.Count; i++)
                {
                    var points = new List<GraphPoint>();

                    for (int j = 0; j < table.Rows.Count; j++)
                    {
                        var x = Convert.ToSingle(table.Rows[j][0]);
                        var y = Convert.ToSingle(table.Rows[j][i]);

                        points.Add(new GraphPoint(x, y));
                    }

                    if (points.Count != 0)
                    {
                        var grData = new GraphData($"{header}_{table.Columns[i].ColumnName}", color, xUnit, yUnit, points.ToArray());
                        grData.ValueFlag = true;
                        grDataRange.Add(grData);
                    }
                }
            return grDataRange;
        }
        /// <summary>
        /// SafeFileButton_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SafeFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = ".jsf";

            var filter = "(*.jsf)|*.jsf";
            saveFile.Filter = filter;

            if (saveFile.ShowDialog() == DialogResult.OK && saveFile.FileName.Length > 0)
                SaveEvent?.Invoke(saveFile.FileName);
            //lblPath.Text = $@"{DbPath}\{DbName}";
        }
        /// <summary>
        /// AddBranchButton_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        public virtual void AddBranchButton_Click(object sender, EventArgs e)
        {
            throw new Exception("Метод не реализован!");
        }
        /// <summary>
        /// DelBrachButton_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        public virtual void DelBrachButton_Click(object sender, EventArgs e)
        {
            throw new Exception("Метод не реализован!");
        }
        /// <summary>
        /// AddNewRowButton_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        public virtual void AddNewRowButton_Click(object sender, EventArgs e)
        {
            throw new Exception("Метод не реализован!");
        }


        public virtual void DelAllRowsButton_Click(object sender, EventArgs e)
        {
            throw new Exception("Метод не реализован!");
        }

        public virtual void TreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            throw new Exception("Метод не реализован!");
        }

        public virtual void DataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            throw new Exception("Метод не реализован!");
        }

        private void TreeView_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (!LabelEditFlag)
                e.CancelEdit = true;
        }

        private void dataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            EditCell = dataGridView[e.ColumnIndex, e.RowIndex];
            OldCellValue = dataGridView[e.ColumnIndex, e.RowIndex].Value;
        }
        /// <summary>
        /// DataGridView_CellEndEdit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void DataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            NewCellValue = dataGridView[e.ColumnIndex, e.RowIndex].Value;
        }

        public virtual void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            throw new Exception("Метод не реализован!");
        }

        public virtual void Resort_Click(object sender, EventArgs e)
        {
            throw new Exception("Метод не реализован!");
        }

        public DataTable Resort(DataTable dt, string colName, string direction)
        {
            DataTable dtOut = null;
            dt.DefaultView.Sort = colName + " " + direction;
            dtOut = dt.DefaultView.ToTable();
            return dtOut;
        }

        public virtual void AddDB_Click(object sender, EventArgs e)
        {
            LoadEvent?.Invoke();
        }

        public virtual void CreateCopy_Click(object sender, EventArgs e)
        {
            throw new Exception("Метод не реализован!");
        }

        private void treePanel_Paint(object sender, PaintEventArgs e)
        {
            var loc_y = toolStripContainer2.Location.Y;

            ComponentsPainter.PaintGradientRectangle(e.Graphics, new Point(0, 0), Width, loc_y, HeadColor, HeadColor);

            var locRect = new Point(Width - 15, loc_y / 2 - 4);
            ComponentsPainter.PaintCloseRectangle(e.Graphics, locRect);

            e.Graphics.DrawString("Список", Font, new SolidBrush(System.Drawing.Color.Black), 15, 0);
        }

        private void dataPanel_Paint(object sender, PaintEventArgs e)
        {
            var loc_y = toolStripContainer1.Location.Y;

            ComponentsPainter.PaintGradientRectangle(e.Graphics, new Point(0, 0), Width, loc_y, HeadColor, HeadColor);

            var locRect = new Point(Width - 15, loc_y / 2 - 4);
            ComponentsPainter.PaintCloseRectangle(e.Graphics, locRect);

            e.Graphics.DrawString("Данные", Font, new SolidBrush(System.Drawing.Color.Black), 15, 0);
        }

        private void graphPanel_Paint(object sender, PaintEventArgs e)
        {
            var loc_y = graphContainer.Location.Y;

            ComponentsPainter.PaintGradientRectangle(e.Graphics, new Point(0, 0), Width, loc_y, HeadColor, HeadColor);

            var locRect = new Point(Width - 15, loc_y / 2 - 4);
            ComponentsPainter.PaintCloseRectangle(e.Graphics, locRect);

            e.Graphics.DrawString("График", Font, new SolidBrush(System.Drawing.Color.Black), 15, 0);
        }

        public virtual void treeView_MouseDown(object sender, MouseEventArgs e)
        {
            throw new Exception("Метод не реализован!");
        }
    }
}
