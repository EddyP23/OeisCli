using System;

namespace OeisCli.Exceptions
{
    public class NetworkErrorException: Exception
    {
        public NetworkErrorException(string msg): base(msg) { }
        public NetworkErrorException(string msg, Exception e) : base(msg, e) { }
    }
}
