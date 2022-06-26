using Application.Config;
using System.Net;

namespace Application.Class
{
    public static class Function
    {
        public static string GetString(byte[] data)
        {
            if (data == null)
            {
                throw new Exception("data == null");
            }

            return Cfg.Encoding.GetString(data).TrimEnd('\0');
        }

        public static string GetIpEndPoint(EndPoint e)
        {
            IPEndPoint ip = e as IPEndPoint;
            return ip.Address.ToString();
        }

        public static string GetBaseLogAccount(object obj)
        {
            var newObj = (SLogAccount)obj;
            string msg = $"A Account[{newObj.Name}]Ip[{GetIpEndPoint(newObj.Ip)}]=> {newObj.Msg} ";
            return msg;
        }

        private struct SLogAccount
        {
            public string Name { get; set; }
            public EndPoint Ip { get; set; }
            public string Msg { get; set; }
        }


      
    }
}
