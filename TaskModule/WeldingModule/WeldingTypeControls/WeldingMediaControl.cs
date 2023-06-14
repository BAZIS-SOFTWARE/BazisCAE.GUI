using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TaskModule.BasicAdvisorControls.BasicControls;
using TaskModule.BasicAdvisorControls.Interfaces;

namespace TaskModule.WeldingModule.WeldingTypeControls
{
    public partial class WeldingMediaControl : CheckedGridViewAdviserControl, INodesGroupControl, IElmentsGroupsControl, IFunctionsRelatedControl
    {
        //int selectedRowIndex;
        //private string inEventID;

        enum Column : int { plane, node = 0, function, mediaTemp, bodyTemp, startTime, stopTime };

        public WeldingMediaControl()
        {
            InitializeComponent();
            DataName = "Среда";
            
        }

        public override string DataName { get; }

        public void Fill_nGroups(List<string> nGroups)
        {
            cmbNode.Items.Clear();
            foreach (var nGroup in nGroups)
            {
                cmbNode.Items.Add(nGroup);
            }
        }

        public void Fill_eGroups(string taskType, string elemType, List<string> groupNames)
        {
            if (taskType == "Plain" | taskType == "AxiPlain")
            {
                if (elemType == "Элементы1D")
                {
                    cmbEl.Items.Clear();

                    foreach (var eGroup in groupNames)
                        cmbEl.Items.Add(eGroup);
                }
            }
            else
            {
                if (elemType == "Элементы2D")
                {
                    cmbEl.Items.Clear();

                    foreach (var eGroup in groupNames)
                        cmbEl.Items.Add(eGroup);
                }
            }
        }

        public override void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                CurentSelectedRowInfo = AddRowInfo();
                base.AddButton_Click(sender, e);

                btnRefresh.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string AddRowInfo()
        {
            var dataList = new List<string>();

            if (heatFlowRadioButton.Checked)
            {
                dataList.Add(cmbEl.Text);
                dataList.Add(cmbFunc.Text);
                dataList.Add(txbMediaTemp.Text);
                dataList.Add("*");
            }
            else
            {
                dataList.Add(cmbNode.Text);
                dataList.Add("*");
                dataList.Add("*");
                dataList.Add(cmbTermoCycle.Text);
            }

            dataList.Add(txbStartTime.Text);
            dataList.Add(txbStopTime.Text);
            dataList.Add("*");

            return "\"" + string.Join(" ", dataList) + "\"";
        }

        public override void DataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var bodyTemp = dataGridView[(int)Column.bodyTemp, e.RowIndex].Value.ToString();

            if (bodyTemp != "*")
            {
                cmbNode.Text = dataGridView[(int)Column.node, CurentSelectedRowIndex].Value.ToString();
                cmbTermoCycle.Text = dataGridView[(int)Column.bodyTemp, CurentSelectedRowIndex].Value.ToString();
                termoRadioButton.Checked = true;
            }
            else
            {
                cmbEl.Text = dataGridView[(int)Column.plane, CurentSelectedRowIndex].Value.ToString();
                cmbFunc.Text = dataGridView[(int)Column.function, CurentSelectedRowIndex].Value.ToString();
                txbMediaTemp.Text = dataGridView[(int)Column.mediaTemp, CurentSelectedRowIndex].Value.ToString();
                heatFlowRadioButton.Checked = true;
            }

            txbStartTime.Text = dataGridView[(int)Column.startTime, CurentSelectedRowIndex].Value.ToString();
            txbStopTime.Text = dataGridView[(int)Column.stopTime, CurentSelectedRowIndex].Value.ToString();

            btnRefresh.Enabled = true;
        }        

        public void Add_Functions(List<string> functions)
        {
            cmbFunc.Items.Clear();
            cmbTermoCycle.Items.Clear();
            foreach (var function in functions)
            {
                    cmbFunc.Items.Add(function);
                    cmbTermoCycle.Items.Add(function);               
            }
        }     

        private void mediaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            txbMediaTemp.Enabled = true;
            cmbEl.Enabled = true;
            cmbFunc.Enabled = true;

            cmbTermoCycle.Enabled = false;
            cmbNode.Enabled = false;

            btnRefresh.Enabled = false;
        }

        private void termocycleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            txbMediaTemp.Enabled = false;
            cmbEl.Enabled = false;
            cmbFunc.Enabled = false;

            cmbTermoCycle.Enabled = true;
            cmbNode.Enabled = true;

            btnRefresh.Enabled = false;
        }

        public override void RefreshButton_Click(object sender, EventArgs e)
        {
            try
            {
                CurentSelectedRowInfo = AddRowInfo();
                base.RefreshButton_Click(sender, e);
                btnRefresh.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public override void ShowDataButton_Click(object sender, EventArgs e)
        {
            base.ShowDataButton_Click(sender, e);
        }

        public override void HideAllDataButton_Click(object sender, EventArgs e)
        {
            base.HideAllDataButton_Click(sender, e);
        }

        private void txbDraftFunction_Enter(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //StreamReader myStream = new StreamReader(openFileDialog.OpenFile());
                    //var dataReader = new DbDataReader();
                    //var data = dataReader.ReadData(myStream);
                    //myStream.Dispose();


                    //foreach (var func in data.GetFuncdata)
                    //{
                    //    var name = func.Key;
                    //    var actTime = func.Value.Where(x => x[0] == '1').
                    //    Select(p => p.Split(' ')[1]).ToArray();

                    //    var check = false;
                    //    if (heatFlowRadioButton.Checked)
                    //    {
                    //        check = AddNewRow(name, cmbFunc.Text, txbMediaTemp.Text, "*", actTime.First(), actTime.Last());
                    //    }
                    //    else check = AddNewRow(name, "*", "*", cmbTermoCycle.Text, actTime.First(), actTime.Last());

                    //    if (check)
                    //    {
                    //        var ind = dataGridView.RowCount - 1;
                    //        var medData = new MediaData(Get_DataGridFillLine(ind), new ObjColor());
                    //        InEvent(this, new TaskDataEventArgs(DataType.Med, medData,ProjCmd.AddTaskData));
                    //        btnRefresh.Enabled = false;
                    //        Thread.Sleep(100);
                    //    }
                    //    else throw new Exception("Некорректный ввод данных!\nПроверьте файл функции шаблона.");
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                $"Details:\n\n{ex.StackTrace}");
            }
        }

        private void grbTask_Paint(object sender, PaintEventArgs e)
        {
            var grb = (GroupBox)sender;
            var textSize = TextRenderer.MeasureText(grb.Text, this.Font).Width;
            var locRect = new Point(textSize + 5, 3);
            Pen blackPen = new Pen(Color.FromArgb(255, 0, 0, 0), 1);
            var rect = new Rectangle(locRect, new Size(8, 8));

            e.Graphics.DrawRectangle(blackPen, rect);
            if (grb.Height == 17)
            {
                e.Graphics.DrawString("+", Font, new SolidBrush(System.Drawing.Color.Blue), textSize + 4, 0);
            }
            else
            {
                e.Graphics.DrawString("-", Font, new SolidBrush(System.Drawing.Color.Blue), textSize + 6, 0);
            }
        }
        private void grbTask_MouseClick(object sender, MouseEventArgs e)
        {
            var grb = (GroupBox)sender;

            var heigth = 0;
            foreach (Control control in grb.Controls)
            {
                if (control is TextBox txb)
                    heigth = heigth + txb.Size.Height;
                if (control is ComboBox cmb)
                    heigth = heigth + cmb.Size.Height;
            }

            var textSize = TextRenderer.MeasureText(grb.Text, this.Font).Width;
            if (e.Location.X > textSize + 5 & e.Location.X < textSize + 15 && e.Location.Y <= 10)
            {
                if (grb.Height < heigth + 60) grb.Height = heigth + 60;
                else grb.Height = 17;
            }
        }

        public override void DataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            base.DataGridView_UserDeletingRow(sender, e);
        }

        public override void CheckVelocitySlider_Scroll(object sender, ScrollEventArgs e)
        {
            base.CheckVelocitySlider_Scroll(sender, e);
        }

        public override void ClearAllDataButton_Click(object sender, EventArgs e)
        {
            base.ClearAllDataButton_Click(sender, e);
        }

        public override void StartChecking_Click(object sender, EventArgs e)
        {
            base.StartChecking_Click(sender, e);
        }

        public override void StopChecking_Click(object sender, EventArgs e)
        {
            base.StopChecking_Click(sender, e);
        }

        private void dataGridView_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            // Try to sort based on the cells in the current column.
            if (e.Column.Index == (int)Column.startTime | e.Column.Index == (int)Column.stopTime)
            {
                if (float.Parse(e.CellValue1.ToString()) > float.Parse(e.CellValue2.ToString()))
                    e.SortResult = 1;
                else if (float.Parse(e.CellValue1.ToString()) < float.Parse(e.CellValue2.ToString()))
                    e.SortResult = -1;
                else e.SortResult = 0;
            }
            // If the cells are equal, sort based on the ID column.
            //if (e.SortResult == 0 && e.Column.Name != "ID")
            //{
            //    e.SortResult = System.String.Compare(
            //        dataGridView.Rows[e.RowIndex1].Cells["ID"].Value.ToString(),
            //        dataGridView.Rows[e.RowIndex2].Cells["ID"].Value.ToString());
            //}
            e.Handled = true;
        }
    }
}
