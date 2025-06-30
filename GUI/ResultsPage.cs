using BaseModule.Navigator;
using BaseModule.Results.Animation;
using BaseModule.Results.Export;
using BaseModule.Results.GraphCreation;
using BaseModule.Results.ScaleControl;
using BasicControls.OpenFileDialogEx;
using BazisGUI.Utilities;
using Geometry;
using Gif.Components;
using Model.Interfaces;
using Model.Interfaces.MeshObjects;
using ModelController;
using ModelControllerInterfaces;
using PostProc;
using PostProc.ScenePresenter;
using Project.Interfaces;
using Project.Interfaces.Tasks;
using Project.Results;
using Project.Results.IO;
using Project.Tasks;
using Project.Tasks.Functions;
using Scene;
using Scene.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserControlsEx.Graph;

namespace BazisGUI
{
    enum ResultType { nodes, elements }
    public partial class BaseForm
    {
        
        public event Action<object,string> LoadResultsEvent;
        public event Action<object> RemoveResultsEvent;
        public event Action<object> HideResultsEvent;
        public event Action<object,Result,int> ShowResultsEvent;
        public event Action<object,CreateAnimationEventArgs> CreateGIFAnimationEvent;

     

        

      
    }   
}
