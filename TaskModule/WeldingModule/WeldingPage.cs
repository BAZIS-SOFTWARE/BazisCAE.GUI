using System;
using System.Windows.Forms;
using TaskModule.BasicTaskAdvisor;
using BaseModule.ToolStrips;
using TaskModule.ToolStrips;
using ModelInterfaces;
using ProjectInterfaces.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace TaskModule.WeldingModule
{
    public partial class WeldingPage : TaskPage
    {
        public WeldingPage()
        {
            InitializeComponent();
        }

        public override void UnCheckToolStripButtons()
        {
            foreach (ToolStripButton item in weldingTaskToolStrip.Items)
                item.Checked = false;
        }

        public override ToolStripMenuItem CreateTasksInterface()
        {
            var taskMenuItem = base.CreateTasksInterface();

            //ToolStripMenuItem weldingMenuItem = new ToolStripMenuItem()
            //{
            //    Name = "Сварка",
            //    Text = "Сварка",
            //    CheckOnClick = true
            //};

            ToolStripMenuItem arcWeldingMenuItem = new ToolStripMenuItem()
            {
                Name = "arcWelding",
                Text = "Дуговая",
                CheckOnClick = true
            };

            ToolStripMenuItem lazerWeldingMenuItem = new ToolStripMenuItem()
            {
                Name = "lazerWelding",
                Text = "Лазерная",
                CheckOnClick = true
            };

            ToolStripMenuItem fsWeldingMenuItem = new ToolStripMenuItem()
            {
                Name = "FSWelding",
                Text = "Трением с перемешиванием",
                CheckOnClick = true
            };


            taskMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            arcWeldingMenuItem,lazerWeldingMenuItem,fsWeldingMenuItem
            });

            

            arcWeldingMenuItem.Click += (ar1, ar2) => {
                var taskAdv = new WeldingAdvisor() 
                { 
                    Dock = DockStyle.Fill,
                    Name = "Дуговая сварка"
                };
                taskAdv.SetWeldingKind(WeldingKind.ARC);

                taskAdv.SpecifyWeldingZoneEvent += TaskAdv_SpecifyWeldingZoneEvent;
                DeleteAdvisor();

                if (arcWeldingMenuItem.Checked)
                        CreateAdvisor(taskAdv);
                else DeleteAdvisor();
            };

            lazerWeldingMenuItem.Click += (ar1, ar2) => {
                var taskAdv = new WeldingAdvisor()
                {
                    Dock = DockStyle.Fill,
                    Name = "Лазерная сварка"
                };
                taskAdv.SetWeldingKind(WeldingKind.Lazer);

                taskAdv.SpecifyWeldingZoneEvent += TaskAdv_SpecifyWeldingZoneEvent;
                DeleteAdvisor();

                if (lazerWeldingMenuItem.Checked)
                        CreateAdvisor(taskAdv);
                else DeleteAdvisor();
            };

            fsWeldingMenuItem.Click += (ar1, ar2) => {
                var taskAdv = new WeldingAdvisor()
                {
                    Dock = DockStyle.Fill,
                    Name = "Сварка трением с перемешиванием"
                };
                taskAdv.SetWeldingKind(WeldingKind.FrictionStearing);

                taskAdv.SpecifyWeldingZoneEvent += TaskAdv_SpecifyWeldingZoneEvent;
                DeleteAdvisor();

                if (fsWeldingMenuItem.Checked)
                        CreateAdvisor(taskAdv);
                else DeleteAdvisor();
            };



            return taskMenuItem;
        }

        private void TaskAdv_SpecifyWeldingZoneEvent(string arg1, int arg2)
        {
            var data = (IValuableData)Project.TaskData.Find(arg1).ToArray()[arg2];

            var modelObjects = new List<IModelObject>();
            var finishTime = data.StopTime - data.StartTime;
            for (int i = 0; i <= finishTime; i++)
            {
                var resu = data.MovedFrameFunction.GetIntersectedObjects(i, data.Group.ToList());
                modelObjects.AddRange(resu);
            }

            data.Group.Clear();
            data.Group.AddRange(modelObjects);
        }
    }
}
