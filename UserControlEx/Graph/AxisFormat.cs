using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControlsEx.Graph
{
    public enum TextFormat
    {
        normal,
        exponential
    }

    public enum StepFormat
    {
        redular,
        logarithmic
    }
    public class AxisFormat
    {
        public string NumberOfSingsStr 
        { 
            get 
            {
                var str = string.Empty;
                for (int k = 0; k < NumberOfSings; k++)
                    str += "#";
                return str;
            } 
        }
        public int NumberOfSings { get; set; } = 2;

        public StepFormat StepFormat { get; set; } = StepFormat.redular;

        public TextFormat TextFormat { get; set; } = TextFormat.normal;
    }
}
