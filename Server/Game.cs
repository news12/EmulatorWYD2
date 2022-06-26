using NetCoreServer;
using Service.Interface;
using System.Net;
using System.Text;
using Application.Config;
using Application.Enum;
using Application.Controller;
using Services.Service;

namespace Application
{
    public class Game
	{
		public  long TotalBytes;
		public  List<ClientSession>? Clients { get; set; }
		public bool Active { get; private set; }
		//public List<Server> Servers { get; private set; }

        // Constructor
        public Game()
		{
		
			var os = Environment.OSVersion;
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
			Cfg.ConfigLoad();
			Active = false;

			int Width = int.Parse(Cfg.ConfigXml.Width);
			int Height = int.Parse(Cfg.ConfigXml.Heigth);

			Console.Title = Cfg.ConfigXml.Title;

			if (os.Platform == PlatformID.Win32NT)
			{
				//Console.Clear();
				//Console.SetBufferSize(Width, Height); 
				Console.SetWindowSize(Width, Height);

			}

			Log.LogApp?.Info("Game start...");
		}


		public Game AddServer(MyServer s, Action<MyServer> a)
		{
			//	this.Servers.Add(s);
			a?.Invoke(s);
			return this;
		}

		public void Run(string[] args)
		{
			int port = int.Parse(Cfg.ConfigXml.Port);
			if (args.Length > 0)
				port = int.Parse(args[0]);
			//int messagesRate = 1000000;
			//int messageSize = 32;

            Log.LogApp?.Info($"Connected Port: {port}");
			Log.LogApp?.Info($"Connected Ip: {Cfg.ConfigXml.Ip}");

			//create new TCP server
			var server = new ServerListen(IPAddress.Parse(Cfg.ConfigXml.Ip), port)
			{
				OptionReuseAddress = true
			};
			//Start server
			server.Start();

			Log.LogApp?.Trace("Service started successful.");
			//encode for GetEncoding
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
			IAccountService accountService = new AccountService();
			AccountController accountController = new(accountService);
			Clients = new List<ClientSession>();

			accountController.UpdateAll();

			Log.LogApp?.Trace("Press ENTER to finish or '!' to restart");

		
			// Perform text input
			for (; ; )
			{
				string line = Console.ReadLine() ?? "";
				if (string.IsNullOrEmpty(line))
					break;

				// Restart the server
				if (line == "!")
				{
					Log.LogApp?.Info("Service restarting...");
					server.Restart();
					Log.LogApp?.Trace("successful...");
					continue;
				}

				// Multicast admin message to all sessions
				//line = "(admin) " + line;
				//server.Multicast(line);
			}

			// Stop the server
			Log.LogApp?.Info("Service stopping...");
			server.Stop();
			Log.LogApp?.Trace("successful.");


		}

		public void ClientSessionAdd(ClientSession session, TcpServer server)
		{
			int maxCLient = 3;
			long sessions = server.ConnectedSessions;
			if (Cfg.ConfigXml.Ip.Equals(session.GetIp()))
			{
				Log.LogApp?.Info($"Login App Socket[{session.Id}] [{session.GetIp()}] connected");
			}
			 if (sessions < maxCLient)
			{
                Clients?.Add(session);
				int sessionId = Clients.FindIndex(c => c.Id == session.Id);
                ClientSession.NewAccount();

				Log.LogApp?.Info($"Client Socket[{session.Id}] [{session.GetIp()}] connected");
			}
			else
			{
				session.Close();
				Log.LogApp?.Warn($"Client Socket[{session.Id}] [{session.GetIp()}] removed, server full");
			}
		}

		public void ClientSessionRemove(ClientSession session)
		{
			try
			{
				if (Log.LogApp == null)
					Cfg.ConfigLoad();

				if (session.GetAccount().Id != 0)
				{
					AccountController accountController = new();
					uint status = accountController.GetStatus(session);

					if (status > (uint)ClientStatus.Connection)
						accountController.SetStatus(session, ClientStatus.Connection);

					if (MyServer.Game.Clients != null)
					{
						MyServer.Game.Clients.Remove(session);
						Log.LogApp?.Info($"Client Socket[{session.Id}] [{session.GetIp()}] Desconnected");
					}
					else
						Log.LogApp?.Info($"Login Socket[{session.Id}] [{session.GetIp()}] Desconnected");

				}
			}
			catch (Exception e)
			{
				Log.LogApp?.Error(e.Message);
				//Console.Write(e.Message);
			}



		}

	}
}
