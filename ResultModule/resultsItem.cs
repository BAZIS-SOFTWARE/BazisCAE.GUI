using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultModule
{
    public class resultsItem
    {
        public resultsItem(string resKind,float firstTime, float lastTime)
        {
            ResKind = resKind;
            FirstTime = firstTime;
            LastTime = lastTime;
        }

        public string ResKind { get; private set; }
        public float FirstTime { get; }
        public float LastTime { get; }

        public override string ToString()
        {
            return $"{ResKind} {FirstTime} {LastTime}";
        }
    }
}
