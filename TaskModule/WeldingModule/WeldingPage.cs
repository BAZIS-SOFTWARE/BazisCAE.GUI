using System.Windows.Forms;
using ModelInterfaces;
using ProjectInterfaces.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace TaskModule.WeldingModule
{
    public partial class WeldingPage : TaskPage
    {
        public WeldingPage()
        {
            InitializeComponent();
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
                Text = "Дуговая сварка",
                CheckOnClick = true
            };

            ToolStripMenuItem lazerWeldingMenuItem = new ToolStripMenuItem()
            {
                Name = "lazerWelding",
                Text = "Лазерная сварка",
                CheckOnClick = true
            };

            ToolStripMenuItem fsWeldingMenuItem = new ToolStripMenuItem()
            {
                Name = "FSWelding",
                Text = "Сварка трением с перемешиванием",
                CheckOnClick = true
            };


            taskMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            arcWeldingMenuItem,lazerWeldingMenuItem,fsWeldingMenuItem
            });

            

            arcWeldingMenuItem.Click += (ar1, ar2) => {
                var taskAdv = new WeldingAdvisor() 
                { 
                    Dock = DockStyle.Fill,
                    Name = arcWeldingMenuItem.Name,
                    Text = arcWeldingMenuItem.Text
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
                    Name = lazerWeldingMenuItem.Name,
                    Text = lazerWeldingMenuItem.Text
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
                    Name = fsWeldingMenuItem.Name,
                    Text = fsWeldingMenuItem.Text
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
            try
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
            catch (System.Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }

        }
    }
}
