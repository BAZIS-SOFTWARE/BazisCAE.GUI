using BazisGUI.Masters.Interfaces;
using MasterInterface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI.Masters.Handlers
{
    public class PreparedConditionsHandler<T> : IMasterInterfaceHandler<T> where T : IPreparedDataLoader
    {
        public Action<string[]> SetPreparedData;
        public PreparedConditionsHandler(Action<string[]> setPreparedData) 
        {
            SetPreparedData = setPreparedData;
        }

        public void Handle(T instance)
        {
            SetPreparedData += instance.SetDataFromConditionsStrings;
        }
    }
}
