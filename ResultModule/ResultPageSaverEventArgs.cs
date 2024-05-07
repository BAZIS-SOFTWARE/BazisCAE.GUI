using ProjectInterfaces.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultModule
{
    public class ResultPageSaverEventArgs : EventArgs
    {
        public ResultPage ResultPage { get; set; }
        public string ExportFormat { get; set; }
        public IEnumerable<IResultFigure2D> Figures { get; set; }
        public string Path { get; set; }

        public ResultPageSaverEventArgs(ResultPage resultPage, string exportFormat, IEnumerable<IResultFigure2D> figures, string path)
        {
            ResultPage = resultPage;
            ExportFormat = exportFormat;
            Figures = figures;
            Path = path;
        }
    }
}
