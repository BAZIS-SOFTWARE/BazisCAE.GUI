using System.Windows.Forms;
using ModelInterfaces;
using ProjectInterfaces.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System;

namespace TaskModule.WeldingModule
{
    public partial class WeldingPage : TaskPage
    {
        public WeldingPage()
        {
            InitializeComponent();
        }

        public WeldingAdvisor CreateWeldingAdvisor(ITaskData taskData, WeldingKind weldingKind)
        {
            var taskAdv = new WeldingAdvisor()
            {
                Dock = DockStyle.Fill,
                Name = "Сварка",
                Text = weldingKind.ToString()
            };
            taskAdv.SetWeldingKind(weldingKind);
            taskAdv.ProcessType = ProcessType.Welding;

            taskAdv.SpecifyWeldingZoneEvent += (ar1,ar2) => 
            { TaskAdv_SpecifyWeldingZone(taskData,ar1,ar2); };

            return taskAdv;
        }

        private async void TaskAdv_SpecifyWeldingZone(ITaskData taskData,string arg1, int arg2)
        {
            try
            {
                await System.Threading.Tasks.Task.Run(() =>
                {
                    var data = (IValuableData)taskData.Find(arg1).ToArray()[arg2];

                    var modelObjects = new List<IModelObject>();
                    var finishTime = data.StopTime - data.StartTime;

                    Invoke(new Action(() =>
                    {
                        BasePage.ConsoleControl.PrintInfo("Уточнение зоны нагрева...", Color.Black);
                    }));

                    for (int i = 0; i <= 100; i++)
                    {
                        var currentTime = i * finishTime / 100.0f;
                        var frame = data.MovedFrame.CalcFrame(currentTime);
                        var resu = data.FrameFunction.GetIntersectedObjects(frame, data.Group.ToList());
                        modelObjects.AddRange(resu);

                        if (i % 10 == 0)
                            Invoke(new Action(() =>
                            {
                                BasePage.ConsoleControl.PrintInfo((i / 100.0f).ToString("P2"), Color.Black);
                            }));
                    }

                    data.Group.Clear();
                    data.Group.AddRange(modelObjects);
                });
            }
            catch (System.Exception ex)
            {
                BasePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }

        }
    }
}
