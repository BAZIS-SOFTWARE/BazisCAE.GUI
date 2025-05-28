using BaseModule.Tasks.BasicAdvisorControls.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BaseModule.Tasks.TasksFromNavigator.Controls
{
    public partial class HeatControlCreator: UserControl
    {
        public event Action<AddDataEventArgs> AddDataEvent;

        public string DataName { get; }
        public HeatControlCreator()
        {
            InitializeComponent();
            DataName = "Нагрев";
            SelectingHeatingSource(this, EventArgs.Empty);
        }
        public void Fill_eGroups(List<string> groupNames)
        {
            cmbEl.Items.Clear();

            foreach (var eGroup in groupNames)
                cmbEl.Items.Add(eGroup);
        }

        public void AddButton_Click()
        {
            if (!IsValidated()) return;
            try
            {
                var rowInfo = CreateRowInfo("*");
                AddDataEvent(new AddDataEventArgs(DataName, rowInfo));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public bool IsValidated()
        {
            var checks = new List<bool>();
            if (rbtARC.Checked)
            {
                checks = new List<bool>()
                {
                    txbCurrent.IsValueValid(),
                    txbVoltage.IsValueValid(),
                    txbWidth.IsValueValid(),
                };
            }

            else if (rbtLW.Checked)
            {
                checks = new List<bool>()
                {
                    txbPower.IsValueValid(),
                    txbDepth.IsValueValid(),
                    txbBaseDiameter.IsValueValid(),
                    txbEndDiameter.IsValueValid(),
                };
            }

            else if (rbtFS.Checked)
            {
                checks = new List<bool>();
                checks.Add(txbRotSpeed.IsValueValid());
                if (rbtPin.Checked)
                {
                    checks.Add(txbPinLenght.IsValueValid());
                    checks.Add(txbPinBottomDiam.IsValueValid());
                    checks.Add(txbPinUpperDiam.IsValueValid());
                    checks.Add(cmbYield.IsValueValid());
                }
                else
                {
                    checks.Add(txbAxisForce.IsValueValid());
                    checks.Add(txbShoulderDiam.IsValueValid());
                    checks.Add(cmbFrictionModule.IsValueValid());
                }
            }
            return checks.All(x => x);
        }

        private void SelectingHeatingSource(object sender, EventArgs e)
        {
            groupBox3.Controls.Clear();

            if (rbtARC.Checked) groupBox3.Controls.Add(tableLayoutPanel3);
            else if (rbtLW.Checked) groupBox3.Controls.Add(tableLayoutPanel2);
            else if (rbtFS.Checked)
            {
                groupBox3.Controls.Add(tableLayoutPanel4);
                SelectingFSWMode(sender, e);
            }
        }

        private void SelectingFSWMode(object sender, EventArgs e)
        {
            if (rbtPin.Checked)
            {
                txbRotSpeed.Enabled = true;
                txbAxisForce.Enabled = false;
                txbShoulderDiam.Enabled = false;
                txbPinLenght.Enabled = true;
                txbPinUpperDiam.Enabled = true;
                txbPinBottomDiam.Enabled = true;
                cmbFrictionModule.Enabled = false;
                cmbYield.Enabled = true;
            }
            if (rbtShoulder.Checked)
            {
                txbRotSpeed.Enabled = true;
                txbAxisForce.Enabled = true;
                txbShoulderDiam.Enabled = true;
                txbPinLenght.Enabled = false;
                txbPinUpperDiam.Enabled = false;
                txbPinBottomDiam.Enabled = false;
                cmbFrictionModule.Enabled = true;
                cmbYield.Enabled = false;
            }
        }
        private string CreateRowInfo(string stopTime)
        {
            var frameFunction = "*";
            if (rbtARC.Checked)
            {
                frameFunction = string.Format($"ARC;{txbCurrent.Text};{txbVoltage.Text};{txbWidth.Text}");
            }
            else if (rbtLW.Checked)
            {
                frameFunction = string.Format($"LW;{txbPower.Text};{txbDepth.Text};{txbBaseDiameter.Text};{txbEndDiameter.Text}");
            }
            else if (rbtLW.Checked)
            {
                frameFunction = string.Format($"LW;{txbPower.Text};{txbDepth.Text};{txbBaseDiameter.Text};{txbEndDiameter.Text}");
            }
            else if (rbtFS.Checked)
            {
                if (rbtPin.Checked)
                {
                    frameFunction = string.Format($"FSWPin;{txbRotSpeed.Text};{txbPinLenght.Text};{txbPinBottomDiam.Text};{txbPinUpperDiam.Text};{cmbYield.Text}");
                }
                else 
                {
                    var lengthDefault = "30";
                    frameFunction = string.Format($"FSWShoulder;{txbAxisForce.Text};{txbRotSpeed.Text};{lengthDefault};{txbShoulderDiam.Text};{txbShoulderDiam.Text};{cmbFrictionModule.Text}");
                }
                
            }
                var taskStr = string.Join(" ", new string[] { "1", "*", frameFunction, cmbEl.Text, stopTime, stopTime });

            return taskStr;
        }
    }
}
