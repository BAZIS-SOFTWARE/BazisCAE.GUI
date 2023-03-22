using System.Net;

namespace ConnectionController
{
    public class NetToken : LicenseToken
    {
        public IPAddress IPAddress { get;  set; }
        public int Port { get;  set; }
    }
}
