using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelModule
{
    /// <summary>
    /// Событие для считывания минимального, максимального числа точек разметки кривой
    /// </summary>
    public class ShowHeatMapEventArgs : EventArgs, IEnumerable<KeyValuePair<int,int>>
    {
        Dictionary<int, int> dict;

        public int Max {  get { return dict.Max(x => x.Value); } }
        public int Min { get { return dict.Min(x => x.Value); } }
        public ShowHeatMapEventArgs(Dictionary<int, int> dict) 
        {
            this.dict = dict.OrderBy(v => v.Value)
                                      .ToDictionary(k => k.Key, v => v.Value);
        }

        public ICollection Keys { get { return dict.Keys; } }
        public ICollection Values { get { return dict.Values; } }

        public IEnumerator<KeyValuePair<int, int>> GetEnumerator()
        {
            foreach (var item in dict)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
