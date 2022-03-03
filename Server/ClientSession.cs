using Application.Config;
using Application.Packet;
using Db.Entities;
using System.Net.Sockets;
using System.Net;
using System.Reflection;
using NetCoreServer;
using Application.Enum;

namespace Application
{
    public class ClientSession : TcpSession
    {
        private Account? Account { get; set; }
        public ClientSession(TcpServer server) : base(server) { }

         public override bool SendAsync(byte[] buffer, long offset, long size)
         {
             // Limit session send buffer to 1 megabyte
             const long limit = 1 * 1024 * 1024;
             long pending = BytesPending + BytesSending;
             if ((pending + size) > limit)
                 return false;
             if (size > (limit - pending))
                 size = limit - pending;

             return base.SendAsync(buffer, offset, size);
         }

        protected override void OnConnected()
        {
            MyServer.Game.ClientSessionAdd(this, Server);

            base.OnConnected();

        }

        protected override void OnConnecting()
        {
            base.OnConnecting();
        }
        protected override void OnDisconnected()
        {

            base.OnDisconnected();
        }

        public override bool Disconnect()
        {
            MyServer.Game.ClientSessionRemove(this);
            return base.Disconnect();
        }

        protected override void OnReceived(byte[] buffer, long offset, long size)
        {
            MyServer.Game.TotalBytes += size;
            try
            {

                if (size <= 0)
                {
                    Close();
                }
                else
                {
                    byte[] rec = buffer;

                   
                    if (size == 4)
                    {
                        return;
                    }
                    else if (size == 120)
                    {
                        rec = rec.Skip(4).ToArray();
                    }

                    if (size < 12)
                    {
                        Close();
                        return;
                    }

                    EncDec.Decrypt(buffer);

                    PacketController packetController = new();

                    packetController.Controller(this, buffer);
                }
            }
            catch (Exception ex)
            {
                Log.LogApp?.Error(ex.Message);
            }


        }

        protected override void OnError(SocketError error)
        {
            Console.WriteLine($"Session caught an error with code {error}");

        }
        public void Send<T>(T o)
        {
            try
            {
                byte[] send = PacketConvert.ToByteArray(o);

                Log.Snd(this, PacketConvert.ToStruct<MsgHeader>(send));

                EncDec.Encrypt(ref send);
              //  Log.LogApp?.Info($"Send Packet Socket[{Id}] Ip[{GetIp()}]");
                SendAsync(send);
            }
            catch (Exception e)
            {
                Log.LogApp?.Error(e.Message);
                throw;
            }

        }


        public void Close()
        {
            Disconnect();

        }

        public static implicit operator ClientSession(List<ClientSession> v)
        {
            throw new NotImplementedException();
        }

        public string GetIp()
        {
            if (Socket.RemoteEndPoint is not IPEndPoint ip)
                return "none";

            return ip.Address.ToString();
        }

        public Account GetAccount()
        {
            if (Account != null)
                return Account;

            return new Account();
        }

        public void SetAccount(Account acc)
        {
            Account = acc;
        }

        public void SendMsg(string msg, EColor color = EColor.None)
        {
            Send(MsgSayColor.New(msg, (uint)color));
        }

        public void SendMsg(string msg)
        {
            Send(MsgClient.New(msg));
        }

        public string GetAttributeName()
        {
            return nameof(Account.Name);
        }
        public string GetAttributeNumeric()
        {
            return nameof(Account.Numeric);
        }

        public void AccountUpdate(string Field, string Value)
        {
            IList<PropertyInfo> properties = typeof(Account).GetProperties().ToList();

            foreach (PropertyInfo prop in properties)
            {
                if (prop.Name == Field)
                {
                    prop.SetValue(Account, Value, null);
                    break;
                }

            }
        }

        public static Account NewAccount()
        {
            Account account = new();
            account.Characters = new List<Character>();
            for (int i = 0; i < 4; i++)
                account.Characters.Add(new Character());
              
            return account;
        }


    }
}
