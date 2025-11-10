using BazisGUI.Scene.Interfaces;
using System;
using Tao.OpenGl;
using Geometry;
using System.Drawing;
using MathNet.Numerics.LinearAlgebra;
using BaseModule.Results.GraphCreation;
using ResultDB.IO;
using System.Windows.Forms;
using BazisGUI.Utilities;
using Model.Interfaces;
using System.Collections.Generic;
using UserControlsEx.Graph;
using System.Threading.Tasks;
using System.Linq;
using Model;
using ResultDB;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using BaseModule.Results.Animation;
using BazisGUI.Navigator;
using Gif.Components;
using System.IO;
using BaseModule;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void создатьАнимациюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var btn = sender as ToolStripMenuItem;
                if (btn.Checked)
                {

                    var form = new Form()
                    {
                        Name = "animationForm",
                        Text = "Анимация",
                        Icon = this.Icon,
                        ShowIcon = true,
                        Owner = Application.OpenForms[0],
                        TopMost = true
                    };

                    form.FormClosed += (s1, s2) =>
                    {
                        btn.Checked = false;
                        DisplayGeometryObjectEvent = null;
                        DisplayText3DEvent = null;
                        DisplayObjects();
                    };

                    var animationControl = new AnimationPage() { Dock = DockStyle.Fill };
                    animationControl.CreateGIFAnimationEvent += (arg1, arg2) => { CreateGIFAnimation(arg2); };
                    
                    form.ClientSize = animationControl.Size;
                    form.Controls.Add(animationControl);

                    form.Show();
                    var location = PointToScreen(scene.Location);
                    form.Location = location;
                }
                else
                {
                    var forms = Application.OpenForms.Cast<Form>().ToList();
                    var form = forms.Find(x => x.Name == "animationForm");
                    if (form != null)
                    {
                        form.Close();
                        btn.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        public async void CreateGIFAnimation(CreateAnimationEventArgs args)
        {
            try
            {
                //выбрать узел в дереве асинхронно
                await SelectContainerAsync(@"Выберите результат и нажмите на клавишу ""E"" для подтверждения");

                if (navigator.SelectedNode.Name != NodeName.результат.ToString())
                    throw new Exception("Выберите результат в разделе результаты");

                var selNode = navigator.SelectedNode;
                var resName = selNode.Text;


                var outputFilePath = $@"{WorkingDir}\results.gif";

                AnimatedGifEncoder e = new AnimatedGifEncoder();

                e.Start(outputFilePath);
                e.SetDelay(args.DelayTime);
                //-1:no repeat,0:always repeat
                e.SetRepeat(0);

                var loader = new LoadResultsFileDB();

                var tables = new List<string>();
                navigator.TrySearchNodes(NodeName.результаты.ToString(), out List<TreeNode> nodes);
                foreach (TreeNode item in nodes[0].Nodes)
                    tables.Add(item.Text);

                //TODO сформировать серию изображений и сдеть GIF
                // выполнить все асинхронно
   
                var list = new List<float>();

                foreach (TreeNode item in navigator.SelectedNode.Nodes)
                    list.Add(float.Parse(item.Text));


                for (int i = 0; i < list.Count; i++)
                {
                    var result = loader.GetResult(ResultDbPath, tables, list[i]); //resultData.FindByTime(args.ResltsKind, args.Times[i]);
                    //var resName = navigator.SelectedNode.Text;
                    ShowResults(result, resName);
                    var image = $@"screenShot_{list[i]}";
                    var imagePath = $@"{WorkingDir}\{image}.bmp";
                    CreateScreenShot(imagePath);

                    using (var stream = new FileStream(imagePath, FileMode.Open))
                    {
                        var bmpImage = Image.FromStream(stream);

                        //var bmpImage = Image.FromFile(imagesPaths[i]);
                        e.AddFrame(bmpImage);
                        var total = ((i + 1) / (float)list.Count * 100).ToString("#.##");
                        console.PrintInfo($@"Создание GIF анимации {total}%", Color.Black);
                    }
                    File.Delete(imagePath);
                }
                e.Finish();
                console.PrintInfo("GIF анимация создана", Color.Green);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
    }
}
