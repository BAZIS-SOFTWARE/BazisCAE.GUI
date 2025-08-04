using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BaseModule.Results.Animation;
using BazisGUI.Scene;
using BazisGUI.Utilities;
using Gif.Components;
using GmshApi;
using Model.GeometryObjects;
using Model.Interfaces;
using Model.Interfaces.ObjectsFinders;
using Model.MeshObjects;
using OperationalController.GmshController;
using Project.Results;
using Project.Results.IO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public void CreateGIFAnimation(CreateAnimationEventArgs args)
        {
            try
            {
                var outputFilePath = $@"{project.Path}\results.gif";

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


                for (int i = 0; i < args.Times.Length; i++)
                {
                    var result = loader.GetResult(ResultDbPath, tables, args.Times[i]); //resultData.FindByTime(args.ResltsKind, args.Times[i]);
                    var resName = navigator.SelectedNode.Text;
                    ShowResults(result, resName);
                    var image = $@"screenShot_{args.Times[i]}";
                    var imagePath = $@"{project.Path}\{image}.bmp";
                    CreateScreenShot(imagePath);

                    using (var stream = new FileStream(imagePath, FileMode.Open))
                    {
                        var bmpImage = Image.FromStream(stream);

                        //var bmpImage = Image.FromFile(imagesPaths[i]);
                        e.AddFrame(bmpImage);
                        var total = ((i + 1) / (float)args.Times.Length * 100).ToString("#.##");
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
