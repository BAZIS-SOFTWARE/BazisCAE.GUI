using BazisGUI.Masters.Interfaces;
using MasterInterface;
using MasterInterface.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI.Masters.Handlers
{
    public class MasterHandler<T> : IMasterInterfaceHandler<T> where T : IBaseMasterInterface
    {
        public Action UpdatedScene;
        public Action<string, Color> PrintedInfo;
        public Action<string[]> GeneratedConditions;
        
        public MasterHandler(Action updatedScene, Action<string, Color> printedInfo, Action<string[]> generatedConditions)
        {
            UpdatedScene = updatedScene;
            PrintedInfo = printedInfo;
            GeneratedConditions = generatedConditions;
        }

        public void Handle(T Instance)
        {
            if (Instance == null)
                throw new ArgumentNullException($"Объект класса {typeof(T)} не определен до обработки");

            Instance.GenerateConditionsEvent += GeneratedConditions;
            Instance.PrintInfoEvent += PrintedInfo;
            Instance.UpdateSceneEvent += UpdatedScene;
        }
    }
}
