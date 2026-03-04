using MasterInterface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI.Masters.Interfaces
{
    public interface IMasterInterfaceHandler<T> where T : IMasterInterface
    {
        public void Handle(T instance);
    }
}
