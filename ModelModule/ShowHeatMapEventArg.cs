using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelModule
{
    /// <summary>
    /// Событие для считывания минимального, максимального числа точек трансфиниции кривой
    /// </summary>
    public class ShowHeatMapEventArg : EventArgs
    {
        Dictionary<int, int> curveDict;

        public int Max {  get { return curveDict.Max(x => x.Value); } }
        public int Min { get { return curveDict.Min(x => x.Value); } }
        public ShowHeatMapEventArg(Dictionary<int, int> curveDict) 
        {
            this.curveDict = curveDict.OrderBy(v => v.Value)
                                      .ToDictionary(k => k.Key, v => v.Value);
        }

        public ICollection Keys { get { return curveDict.Keys; } }
        public ICollection Values { get { return curveDict.Values; } }
    }
}
