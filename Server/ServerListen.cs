using NetCoreServer;
using System.Net;

namespace Application
{
    class ServerListen : TcpServer
    {
        public ServerListen(IPAddress addres, int port) : base(addres, port) { }

        protected override TcpSession CreateSession()
        { 
            return new ClientSession(this);
        }
    }
}
