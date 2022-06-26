using System.Text;
using Application.Class.BotTelegram;
using Application.Config;
using Application.Controller;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;

namespace Application
{
    public class Game
	{
		public long TotalBytes;
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

			Log.LogApp?.Info("Comunicator start...");
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

          /*  Log.LogApp?.Info($"Connected Port: {port}");
			Log.LogApp?.Info($"Connected Ip: {Cfg.ConfigXml.Ip}");

			//create new TCP server
			var server = new ServerListen(IPAddress.Parse(Cfg.ConfigXml.Ip), port)
			{
				OptionReuseAddress = true
			};
			//Start server
			server.Start();*/

			Log.LogApp?.Trace("Service started successful.");
			//encode for GetEncoding
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

			StartBot();

			Cfg.TimeDelaySendCharacter = 0;
			while (true)
			{
				try
				{
					Thread.Sleep(10000);
					StartClient();
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}

		/*	// Stop the server
			Log.LogApp?.Info("Service stopping...");
			server.Stop();
			Log.LogApp?.Trace("successful.");*/

		}

		private static void StartClient()
		{
			// Connect to a remote device.  
			try
			{
				AccountController controller = new();
				controller.GetAcccounts(0);
				controller.GetDonations(0);
				controller.GetPasswords(0);

                if (Cfg.TimeDelaySendCharacter > 5)
                {
					Cfg.TimeDelaySendCharacter = 0;
					controller.GetPlayers();

                }
				else
					Cfg.TimeDelaySendCharacter++;


			}
			catch (Exception e)
			{
				Log.LogApp?.Trace(e.Message);
			}
		}

		private static async void StartBot()
        {
            
			var bot = new TelegramBotClient(BotConfig.BotToken);

			var me = await bot.GetMeAsync();

			using var cts = new CancellationTokenSource();

			// StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
			var receiverOptions = new ReceiverOptions()
			{
				AllowedUpdates = Array.Empty<UpdateType>(),
				ThrowPendingUpdates = true,
			};

			bot.StartReceiving(updateHandler: UpdateHandlers.HandleUpdateAsync,
							   pollingErrorHandler: UpdateHandlers.PollingErrorHandler,
							   receiverOptions: receiverOptions,
							   cancellationToken: cts.Token);

		
			Log.LogApp?.Trace($"Service Bot @{me.Username}");
		

			// Send cancellation request to stop bot
			//cts.Cancel();
		}


	}
}
