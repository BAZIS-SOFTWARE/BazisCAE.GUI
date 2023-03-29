
using System.Net;

namespace ConnectionController
{
    public class LicenseToken
    {
        public string Request { get; set; } = "";
        public string Answer { get; set; } = "";
        public IPAddress IPAddress { get; set; }
        public int Port { get; set; }
    }
}
