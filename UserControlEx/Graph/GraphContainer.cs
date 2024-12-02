
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace UserControlsEx.Graph
{
    public partial class GraphContainer : UserControl
    {
        private Point iniPos;     
       
        public GraphContainer()
        {
            InitializeComponent();

            graphControl.MouseWheel += Graph_MouseWheel;
        }       

        private void DashPaintButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
            var button = (ToolStripButton)sender;
            if (button.Checked && graphControl != null) graphControl.DashPaintFlag = true;
            else { graphControl.DashPaintFlag = false; }
            graphControl.Invalidate();
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}

        private void LinePaintButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
            var button = (ToolStripButton)sender;
            if (button.Checked) graphControl.LinePaintFlag = true;
            else { graphControl.LinePaintFlag = false; }
            graphControl.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PathThickButton_DropDownOpened(object sender, EventArgs e)
        {
            var rect = new RectangleF(new PointF(0, 0), new SizeF(40, 70));
            btnPathThick.DropDown.Region = new Region(rect);
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
            graphControl.PathThickness = 1.0f;
            graphControl.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                graphControl.PathThickness = 3.0f;
                graphControl.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                graphControl.PathThickness = 5.0f;
                graphControl.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void XMaxTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                bool isInt = float.TryParse(txb_X_Max.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float res);
                if (!isInt)
                {
                    txb_X_Max.Text = "0";
                    throw new Exception("Неправильный формат ввода!");
                }

                var x_max = float.Parse(txb_X_Max.Text, NumberStyles.Float, CultureInfo.InvariantCulture);

                if (graphControl.XAxisFormat.StepFormat == StepFormat.logarithmic)
                    x_max = (float)Math.Log10(x_max);

                if (x_max != graphControl.X_min)
                    graphControl.X_max = x_max;
                else txb_X_Max.Text = graphControl.X_max.ToString();

                graphControl.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void XMinTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                bool isInt = float.TryParse(txb_X_Min.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float res);
                if (!isInt)
                {
                    txb_X_Min.Text = "0";
                    throw new Exception("Неправильный формат ввода!");
                }
                var x_min = float.Parse(txb_X_Min.Text, NumberStyles.Float, CultureInfo.InvariantCulture);

                if (graphControl.XAxisFormat.StepFormat == StepFormat.logarithmic)
                    x_min = (float)Math.Log10(x_min);

                if (x_min != graphControl.X_max)
                    graphControl.X_min = x_min;
                else txb_X_Min.Text = graphControl.X_min.ToString();
                graphControl.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void YMaxTextBox_Leave(object sender, EventArgs e)
        {
            bool isInt = float.TryParse(txb_Y_Max.Text,NumberStyles.Float, CultureInfo.InvariantCulture, out float res);
            if (!isInt)
            {
                txb_Y_Max.Text = "0";
            }

            try
            {
                var y_max = float.Parse(txb_Y_Max.Text, NumberStyles.Float, CultureInfo.InvariantCulture);
                if (y_max != graphControl.Y_min)
                    graphControl.Y_max = y_max;
                else txb_Y_Max.Text = graphControl.Y_max.ToString();
                graphControl.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void YMinTextBox_Leave(object sender, EventArgs e)
        {
            bool isInt = float.TryParse(txb_Y_Min.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float res);
            if (!isInt) { txb_Y_Min.Text = "0"; }

            try
            {
                var y_min = float.Parse(txb_Y_Min.Text, NumberStyles.Float, CultureInfo.InvariantCulture);
                if (y_min != graphControl.Y_max)
                    graphControl.Y_min = y_min;
                else txb_Y_Min.Text = graphControl.Y_min.ToString();
                graphControl.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ValueButton_CheckedChanged(object sender, EventArgs e)
        {
            var button = (ToolStripButton)sender;
            if (button.Checked) graphControl.ValueFlag = true;
            else { graphControl.ValueFlag = false; }
            graphControl.Invalidate();
        }

        public void CreateGraphData(string header, List<GraphData> data, AxisFormat x_axisFormat, AxisFormat y_axisFormat)
        {

            graphControl.Title = header;

            graphControl.ClearData();
            graphControl.AddData(data);

            graphControl.XAxisFormat = x_axisFormat;
            graphControl.YAxisFormat = y_axisFormat;

            if (btnValue.Checked)
                graphControl.ValueFlag = true;
            else graphControl.ValueFlag = false;

            Set_X_Y_Value();

            graphControl.Invalidate();

            showDataSplitButton.DropDownItems.Clear();
            foreach (var dataItem in data)
            {
                var tlsMenuItem = new ToolStripMenuItem(dataItem.Title)
                {
                    Name = dataItem.Title,
                    CheckOnClick = true,
                    Checked = true
                };
                tlsMenuItem.CheckedChanged += TlsMenuItem_CheckedChanged;
                showDataSplitButton.DropDownItems.Add(tlsMenuItem);
            }

            showDataSplitButton.DropDown.Closing += ShowDataSplitButton_Closing;
        }

        private void Set_X_Y_Value()
        {

            if (graphControl.XAxisFormat.StepFormat == StepFormat.logarithmic)
            {
                txb_X_Max.Text = Math.Pow(10, graphControl.X_max).ToString();
                txb_X_Min.Text = Math.Pow(10, graphControl.X_min).ToString();
            }

            else
            {
                txb_X_Max.Text = graphControl.X_max.ToString();
                txb_X_Min.Text = graphControl.X_min.ToString();
            }

            txb_Y_Max.Text = graphControl.Y_max.ToString();
            txb_Y_Min.Text = graphControl.Y_min.ToString();
        }

        private void Graph_MouseMove(object sender, MouseEventArgs e)
        {
            var graph = (GraphControl)sender;
            if (e.Button == MouseButtons.Right)
            {
                var finPos = e.Location;
                var dX = finPos.X - iniPos.X;
                var dY = finPos.Y - iniPos.Y;
                var stepX = (float)dX / graph.Width * graph.X_length;
                var stepY = (float)dY / graph.Height * graph.Y_length;
                
                graph.X_max -= stepX;
                graph.X_min -= stepX;

                graph.Y_max += stepY;
                graph.Y_min += stepY;

                Set_X_Y_Value();
                graph.Invalidate();
            }

            iniPos = e.Location;
        }

        private void Graph_MouseWheel(object sender, MouseEventArgs e)
        {
            var graph = (GraphControl)sender;

            if (Math.Sign(e.Delta) > 0)
            {
                graph.X_max *= 0.9f;
                graph.Y_max *= 0.9f;
            }

            else
            {
                graph.X_max *= 1.1f;
                graph.Y_max *= 1.1f;
            }


            Set_X_Y_Value();
            graph.Invalidate();
        }

        private void TlsMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            var tls = (ToolStripMenuItem)sender;

                var data = graphControl.GetData().Where(x => x.Title == tls.Name) ;

            foreach (var dataItem in data)
                dataItem.IsShown = tls.Checked;

            graphControl.Invalidate();
        }

        private void btnValueToTable_Click(object sender, EventArgs e)
        {
            var bulder = new StringBuilder();

            var length = graphControl.CountRanges();

            foreach (var data in graphControl.GetData())
            {
                foreach (var point in data.GetPoints())
                {
                    var y = point.Y.ToString("0.00");
                    var x = point.X.ToString("0.00");

                    var str = String.Format("\"{0} {1}\"", x,y);
                    bulder.AppendLine(str);
                }
            }
            Clipboard.SetData(DataFormats.Text, (Object)bulder.ToString());
        }

        private void btnFitGraph_Click(object sender, EventArgs e)
        {
            graphControl.Set_Max_Min_X_Y();
            graphControl.Invalidate();
        }

        private void btnTitle_Click(object sender, EventArgs e)
        {
            foreach (var data in graphControl.GetData())
                data.IsTitleShown = btnTitle.Checked;
            graphControl.Invalidate();
        }

        private void ShowDataSplitButton_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
            {
                e.Cancel = true;
            }
        }
    }
}
