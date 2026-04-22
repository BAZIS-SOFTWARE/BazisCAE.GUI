using System;
using System.Drawing;
using ResultDB.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using BazisGUI.Animation;
using BazisGUI.Navigator;
using System.IO;

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
                        Text = Localization.Localization.GetStringResourceByName("AnimationForm.Text"),
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
            var outputFilePath = Path.Combine(WorkingDir, "results.gif");
            var stream = new FileStream(outputFilePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
            try
            {
                //выбрать узел в дереве асинхронно
                await SelectContainerAsync(Localization.Localization.GetStringResourceByName("Result.CreateGIFAnimation.SelectContainerAsync.SelectResult.Message"));

                if (navigator.SelectedNode.Name != NodeName.Result.ToString())
                    throw new Exception(Localization.Localization.GetStringResourceByName("Result.CreateGIFAnimation.Exception"));

                var selNode = navigator.SelectedNode;
                var resName = selNode.Text;


                

                //e.Start(outputFilePath);
                //e.SetDelay(args.DelayTime);
                //-1:no repeat,0:always repeat
                //e.SetRepeat(0);

                var loader = new LoadResultsFileDB();

                var tables = new List<string>()
                { ResultType.nodes.ToString() };

                //TODO сформировать серию изображений и сдеть GIF
                // выполнить все асинхронно

                var list = new List<float>();

                foreach (TreeNode item in navigator.SelectedNode.Nodes)
                    list.Add(float.Parse(item.Text));

                //GifImage
                // TODO заменить! Так как сборка неподписана
                var e = new GifWriter(stream);

                for (int i = 0; i < list.Count; i++)
                {
                    var result = loader.GetResult(ResultDbPath, tables, list[i]); //resultData.FindByTime(args.ResltsKind, args.Times[i]);
                    //var resName = navigator.SelectedNode.Text;
                    ShowResults(result, resName);
                    //var image = $@"screenShot_{list[i]}";
                    //var imagePath = $@"{WorkingDir}\{image}.bmp";
                    var image = CreateScreenShot();

                    e.WriteFrame(image, args.DelayTime);

                    //using (var stream = new FileStream(imagePath, FileMode.Open))
                    //{
                    //    var bmpImage = Image.FromStream(stream);

                    //    //var bmpImage = Image.FromFile(imagesPaths[i]);
                    //    e.AddFrame(bmpImage);
                    var total = ((i + 1) / (float)list.Count * 100).ToString("#.##");
                    console.PrintInfo($@"{Localization.Localization.GetStringResourceByName("Result.CreateGIFAnimation.CreateGIFAnimationInfo")} {total}%", Color.Black);
                    //}
                    //File.Delete(imagePath);
                }
                e.Dispose();
                //e.Finish();
                console.PrintInfo(Localization.Localization.GetStringResourceByName("Result.CreateGIFAnimation.AnimationCreated"), Color.Green);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);

            }
            finally
            {
                stream.Dispose();
            }
        }
    }
}
