
using Application.Config;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using static Application.Class.BotTelegram.BotConfig;
using Application.Controller;
using Db.Entities;
using Telegram.Bot.Types.Enums;

namespace Application.Class.BotTelegram
{
    public class Actions
    {
       
        private ITelegramBotClient? Bot = null;
        private CallbackQuery? Query = null;
        private Message? Msg = null;
        string ValueCommand = "";
        private MenuOptions Menu = 0;

        private InlineKeyboardMarkup inlineKeyboardCancel = new(
                  new[]
                  {
                    // first row
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Cancelar", "cancel"),

                    },
                  });

        private InlineKeyboardMarkup inlineKeyboardConfirmCancel = new(
                new[]
                {
                    // first row
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Confirmar", "confirm"),
                        InlineKeyboardButton.WithCallbackData("Cancelar", "cancel"),

                    },
                });

       private const string usage = "Comandos:\n" +
                                    "/menu   - exibir menu de opções\n" +
                                    "/logo    - Receber Logo\n" +
                                    "/reset - limpar ultima ação\n" +
                                    "/request  - solicitar local ou contato";


        public async Task<Message> GetCommand(ITelegramBotClient botClient, Message message)
        {
            Bot = botClient;
            Msg = message;
            Cfg.msgBotDonate.TryGetValue(0, out ValueCommand);
            var action = ValueCommand switch
            {
                "UserName" => CommandUser(),
                "DonateValue" => CommandDonateValue(),
                "GetNotice" => CommandSendNotice(),
                _ => NotCommand()
            };

            return await action;
        }
        public bool GetAction(ITelegramBotClient botClient, CallbackQuery callbackQuery)
        {
            Bot = botClient;
            Query = callbackQuery;

            GetMenuOptions();

            if (Menu == MenuOptions.None)
                return false;

            if (Query.Data == "confirm")
            {
                var typeMsg = "";
                Cfg.msgBotDonate.TryGetValue(0, out typeMsg);
                if (typeMsg == null)
                {
                    Bot.SendTextMessageAsync(
                                            chatId: Query.Message!.Chat.Id,
                                            text: "Posso ajudar em Algo?\n" +
                                            usage,
                                            replyMarkup: new ReplyKeyboardRemove()
                                            );
                    return true;
                }
                if (typeMsg.Equals("AdminName"))
                {
                    SendAdminAction();

                    return true;
                }
            }

            if (Cfg.msgBotDonate.ContainsKey((int)Menu))
            {
                string nMsg = "";
                Cfg.msgBotDonate.TryGetValue((int)Menu, out nMsg);

                if (nMsg == null)
                    return false;

                Bot.SendTextMessageAsync(
                   chatId: Query.Message!.Chat.Id,
                   text: $"Já existe uma solicitação de {nMsg} pendente",
                   replyMarkup: new ReplyKeyboardRemove());

            }
            else
            {
              
                Cfg.msgBotDonate.Add((int)Menu, Query.Data);

                SendNewAction();
            }

            return true;
        }

        private async void RequestUserName()
        {

            Cfg.msgBotDonate.TryAdd(0, "UserName");
            await Bot.SendTextMessageAsync(
                    chatId: Query.Message!.Chat.Id,
                    text: "Digite o nome do usuario\n" +
                    "ex: /user acerola",
                    replyMarkup: inlineKeyboardCancel);
        }

        private async Task<Message> CommandSendNotice()
        {
            try
            {
                int SartIndex = 8;
                AccountController controller = new();
                string nNotice = Msg.Text.Substring(SartIndex, Msg.Text.Length - SartIndex);
                
                controller.ImportNotice(nNotice);
                Cfg.msgBotDonate.Clear();

                return await Bot.SendTextMessageAsync(
                   chatId: Msg!.Chat.Id,
                   text: "Noticia Enviada com sucesso!!\n",
                   replyMarkup: new ReplyKeyboardRemove());
            }
            catch (Exception e)
            {
                Cfg.msgBotDonate.Clear();
                return await Bot.SendTextMessageAsync(
                    chatId: Msg!.Chat.Id,
                    text: "Ocorreu o seguinte erro:\n" + 
                    e.Message,
                    replyMarkup: new ReplyKeyboardRemove());
            }
           
           

        }

        private async void GetNotice()
        {

            Cfg.msgBotDonate.TryAdd((int)MenuOptions.Notice, "GetNotice");
            Cfg.msgBotDonate[0] = "GetNotice";

             await Bot.SendTextMessageAsync(
                  chatId: Query.Message!.Chat.Id,
                  text: "Digite a noticia\n" +
                  "ex: /notice msg para todo servido",
                  replyMarkup: inlineKeyboardCancel);
        }

        private async void RequestCancel()
        {
            Cfg.msgBotDonate.Clear();

           await Bot.SendTextMessageAsync(
                   chatId: Query.Message!.Chat.Id,
                   text: "Ação cancelada",
                   replyMarkup: new ReplyKeyboardRemove());
        }

        private void GetMenuOptions()
        {

            switch (Query.Data)
            {
                case "donate":
                    Menu = MenuOptions.Donate;
                    break;
                case "item":
                    Menu = MenuOptions.Item;
                    break;
                case "msg":
                    Menu = MenuOptions.MSG;
                    break;
                case "notice":
                    Menu = MenuOptions.Notice;
                    break;
                case "confirm":
                    Menu = MenuOptions.Confirm;
                    break;
                case "cancel":
                    Menu = MenuOptions.Cancel;
                    break;
                default:
                    break;
            }
        }

        private void SendNewAction()
        {
            switch (Menu)
            {
                case MenuOptions.Donate:
                    RequestUserName();
                    break;
                case MenuOptions.Item:
                    break;
                case MenuOptions.MSG:
                    break;
                case MenuOptions.Notice:
                    GetNotice();
                    break;
                case MenuOptions.UserName:
                    break;
                case MenuOptions.DonateValue:
                    break;
                case MenuOptions.AdminName:
                    break;
                case MenuOptions.Log:
                    break;
                case MenuOptions.Cancel:
                    RequestCancel();
                    break;
                default:
                    break;
            }
        }

        private async Task<Message> CommandUser()
        {
            string[] nMsg = Msg.Text.Split(' ');
            AccountController controller = new();
            Account acc = controller.GetAccount(nMsg[1]);
            string sendMsg = "";

            if (acc == null)
                sendMsg = "Usuário não encontrado";
            else
            {
                Cfg.msgBotDonate[(int)MenuOptions.None] = "DonateValue";
                Cfg.msgBotDonate.Add((int)MenuOptions.UserName, acc.Name); 
                sendMsg = "Insira o Valor do Donate\n" +
                    "ex: /donate 10\n" +
                    $"para [<strong>{acc.Name.ToUpper()}</strong>]";

            }

            return await Bot.SendTextMessageAsync(
                   chatId: Msg!.Chat.Id,
                   text: sendMsg,
                    parseMode: ParseMode.Html,
                   replyMarkup:  inlineKeyboardCancel);
        }

        private async void SendAdminAction()
        {
            try
            {
                AccountController controller = new();
                Cfg.msgBotDonate.TryGetValue((int)MenuOptions.UserName, out string? userName);
                Cfg.msgBotDonate.TryGetValue((int)MenuOptions.DonateValue, out string? valueDonateStr);
                int valueDonate = int.Parse(valueDonateStr);
                Account acc = controller.GetAccount(userName);
                if (acc == null)
                {
                    Cfg.msgBotDonate.Clear();
                    await Bot.SendTextMessageAsync(
                           chatId: Query.Message!.Chat.Id,
                           text: "Ocorreu um erro ao inserir o donate\n" +
                           "Tente novamente mais tarte",
                           replyMarkup: new ReplyKeyboardRemove());

                    Log.LogApp?.Error("Bot:Erro Donate: Conta não encontrada");

                    return;
                }

                DonateGame donate = new();
                donate.SetGameId(acc.Id);
                donate.SetUserId(acc.User_Id);
                donate.SetDonate(valueDonate);
                DateTime theDate = DateTime.Now;
               // theDate.ToString("yyyy-MM-dd H:mm:ss");
                donate.Created_At = theDate;
                controller.CreateDonate(donate);

                Cfg.msgBotDonate.Clear();
                await Bot.SendTextMessageAsync(
                        chatId: Query.Message!.Chat.Id,
                        text: "Donate enviado com sucesso!!!\n" +
                         "Aguarde pelo menos 1 minuto\n" +
                        "para informar ao usuário",
                        replyMarkup: new ReplyKeyboardRemove());

                Log.LogApp?.Info($"Bot:Donate Criado com sucesso Admin[{Query.From.Username}|{Query.From.Id}] User[{acc.Name}] valor[{valueDonate}]");

                _ = LogNews(valueDonate, acc.Name);
            }
            catch (Exception e)
            {
                Cfg.msgBotDonate.Clear();
                await Bot.SendTextMessageAsync(
                        chatId: Query.Message!.Chat.Id,
                        text: "Ocorreu o seguinte erro\n" +
                        e.Message,
                        replyMarkup: new ReplyKeyboardRemove());
            }
          
        }

        private async Task<Message> CommandDonateValue()
        {
            string[] nMsg = Msg.Text.Split(' ');
            string userName = "";
            Cfg.msgBotDonate.TryGetValue((int)MenuOptions.UserName, out userName);
            string sendMsg = "";
            Cfg.msgBotDonate[(int)MenuOptions.None] = "AdminName";
            int nValue = int.Parse(nMsg[1]);
            Cfg.msgBotDonate.Add((int)MenuOptions.DonateValue, nMsg[1]);
            sendMsg = "Confirma o Envio de Donate?\n" +
                $"Valor do Donate [<strong>{nValue:N2}</strong>]\n" +
                $"Conta do Jogo [<strong>{userName.ToUpper()}</strong>]";

            return await Bot.SendTextMessageAsync(
                    chatId: Msg!.Chat.Id,
                    text: sendMsg,
                     parseMode: ParseMode.Html,
                    replyMarkup: inlineKeyboardConfirmCancel);
        }

        private async Task<Message> NotCommand()
        {
            return await Bot.SendTextMessageAsync(
                   chatId: Msg!.Chat.Id,
                   text: "Comando não encontrado.",
                   replyMarkup:  inlineKeyboardCancel); 
        }

        private async Task<Message> LogNews(int donate, string name)
        {
            string log = $"{Query.From.Username} | {Query.From.Id}\n" +
                $"Enviou <strong>{donate}</strong> donate\n" +
                $"para <strong>{name}</strong>";
           return await Bot.SendTextMessageAsync(
                       chatId: 1541778479,
                       text: log,
                        parseMode: ParseMode.Html,
                       replyMarkup: new ReplyKeyboardRemove());
        }

    }
}
