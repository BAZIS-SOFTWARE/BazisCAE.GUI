using BazisGUI.Masters.Actions;
using BazisGUI.Masters.Interfaces;
using MasterInterface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI.Masters.Handlers
{
    public class PreparedConditionsHandler<T, U> : IMasterInterfaceHandler<T, U> 
        where T : IPreparedDataLoader
        where U : PreparedConditionsAction
    {
        private U action;

        public void SetHandlerAction(U act) => action = act;
        public U GetHandlerAction() => action;

        public void Handle(T instance)
        {
            if (action == null)
                throw new NullReferenceException($"Не определено действие обработчика FunctionsHandler<{typeof(U)}>");

            if (instance == null)
                throw new ArgumentNullException($"Объект класса {typeof(T)} не определен до обработки");

            action.PreparedConditionsStringsAction += (args) => instance.SetDataFromConditionsStrings(args.ConditionStrings);
        }
    }
}
