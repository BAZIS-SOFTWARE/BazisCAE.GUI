using BazisGUI.Masters.Actions;
using BazisGUI.Masters.Args;
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
    public class MasterHandler<T, U> : IMasterInterfaceHandler<T, U> 
        where T : IBaseMasterInterface
        where U : MasterAction
    {
        private U action;

        public void SetHandlerAction(U act) => action = act;
        public U GetHandlerAction() => action;

        public void Handle(T instance)
        {
            if (action == null)
                throw new NullReferenceException($"Не определено действие обработчика MasterHandler<{typeof(U)}>");

            if (instance == null)
                throw new ArgumentNullException($"Объект класса {typeof(T)} не определен до обработки");

            instance.GenerateConditionsEvent += (condStrings) => action.GenerateConditionsAction(this, new Args.GenerateConditionsEventArgs(condStrings));
            instance.PrintInfoEvent += (mes, col) => action.PrintInfoAction(this, new PrintInfoEventArgs(mes, col));
            instance.UpdateSceneEvent += () => action.UpdateSceneAction(this, new EventArgs());
        }
    }
}
