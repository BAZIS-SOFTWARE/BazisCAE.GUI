using System;


namespace BaseModule.Tasks.BasicAdvisorControls.Events
{
    public class DeleteAllDataEventArgs : EventArgs
    {
        public DeleteAllDataEventArgs(string dataName)
        {
            DataName = dataName;
        }

        public string DataName { get; }
    }
}
