
using Application.Config;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;
using  Application.Class.BotTelegram;

namespace Application.Class.BotTelegram
{
    public class UpdateHandlers
    {
        
        public static Task PollingErrorHandler(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Log.LogApp?.Error($"Bot:{ErrorMessage}");
            return Task.CompletedTask;
        }

        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var handler = update.Type switch
            {
                // UpdateType.Unknown:
                // UpdateType.ChannelPost:
                // UpdateType.EditedChannelPost:
                // UpdateType.ShippingQuery:
                // UpdateType.PreCheckoutQuery:
                // UpdateType.Poll:
                UpdateType.Message => BotOnMessageReceived(botClient, update.Message!),
                UpdateType.EditedMessage => BotOnMessageReceived(botClient, update.EditedMessage!),
                UpdateType.CallbackQuery => BotOnCallbackQueryReceived(botClient, update.CallbackQuery!),
                UpdateType.InlineQuery => BotOnInlineQueryReceived(botClient, update.InlineQuery!),
                UpdateType.ChosenInlineResult => BotOnChosenInlineResultReceived(botClient, update.ChosenInlineResult!),
                _ => UnknownUpdateHandlerAsync(botClient, update)
            };

            try
            {
                await handler;
            }
#pragma warning disable CA1031
            catch (Exception exception)
#pragma warning restore CA1031
            {
                await PollingErrorHandler(botClient, exception, cancellationToken);
            }
        }

        private static async Task BotOnMessageReceived(ITelegramBotClient botClient, Message message)
        {
       
            Log.LogApp?.Info($"Bot:Tipo de msg recebida: {message.Type}");
            if (message.Text is not { } messageText)
                return;

            bool isAdm = false;
            foreach (var adm in BotConfig.Admins)
            {
                if (adm == message.From.Id)
                {
                    isAdm = true;
                    break;
                }
            }

            if (!isAdm)
            {
                Cfg.msgBotDonate.Clear();

                _ = botClient.SendTextMessageAsync(
                                   chatId: message!.Chat.Id,
                                   text: "Você não tem permissão para fazer isso\n" +
                                   "entre em contato com o administrador.",
                                   replyMarkup: new ReplyKeyboardRemove());
                return;
            }
            var action = messageText.Split(' ')[0] switch
            {
                "/menu" => SendInlineKeyboard(botClient, message),
                "/keyboard" => SendReplyKeyboard(botClient, message),
                "/remove" => RemoveKeyboard(botClient, message),
                "/logo" => SendFile(botClient, message),
                "/request" => RequestContactAndLocation(botClient, message),
                "/reset" => RequestActionClear(botClient, message),
                "/user" => ActionCommand(botClient, message),
                "/donate" => ActionCommand(botClient, message),
                "/notice" => ActionCommand(botClient, message),
                _ => Usage(botClient, message)
            };
            Message sentMessage = await action;
            Log.LogApp?.Info($"Bot:A mensagem foi enviada com id: {sentMessage.MessageId}");

            // Send inline keyboard
            // You can process responses in BotOnCallbackQueryReceived handler
            static async Task<Message> SendInlineKeyboard(ITelegramBotClient botClient, Message message)
            {
                await botClient.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);

                // Simulate longer running task
                await Task.Delay(500);

                InlineKeyboardMarkup inlineKeyboard = new(
                    new[]
                    {
                    // first row
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Donate", "donate"),
                        InlineKeyboardButton.WithCallbackData("Item", "item"),
                    },
                    // second row
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("MSG", "msg"),
                        InlineKeyboardButton.WithCallbackData("Notice", "notice"),
                    },
                    });

             
                return await botClient.SendTextMessageAsync(chatId: message.Chat.Id,
                                                            text: "Opções",
                                                            replyMarkup: inlineKeyboard);
            }

           
            static async Task<Message> SendReplyKeyboard(ITelegramBotClient botClient, Message message)
            {
                ReplyKeyboardMarkup replyKeyboardMarkup = new(
                    new[]
                    {
                        new KeyboardButton[] { "1.1", "1.2" },
                        new KeyboardButton[] { "2.1", "2.2" },
                    })
                {
                    ResizeKeyboard = true
                };

                return await botClient.SendTextMessageAsync(chatId: message.Chat.Id,
                                                            text: "Opções",
                                                            replyMarkup: replyKeyboardMarkup);
            }

            static async Task<Message> RemoveKeyboard(ITelegramBotClient botClient, Message message)
            {
                return await botClient.SendTextMessageAsync(chatId: message.Chat.Id,
                                                            text: "Removing keyboard",
                                                            replyMarkup: new ReplyKeyboardRemove());
            }

            static async Task<Message> SendFile(ITelegramBotClient botClient, Message message)
            {
                await botClient.SendChatActionAsync(message.Chat.Id, ChatAction.UploadPhoto);

                const string filePath = @"img/default-avatar.png";
                using FileStream fileStream = new(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                var fileName = filePath.Split(Path.DirectorySeparatorChar).Last();

                return await botClient.SendPhotoAsync(chatId: message.Chat.Id,
                                                      photo: new InputOnlineFile(fileStream, fileName),
                                                      caption: "Logo United");
            }

            static async Task<Message> RequestContactAndLocation(ITelegramBotClient botClient, Message message)
            {

                ReplyKeyboardMarkup RequestReplyKeyboard = new(
                    new[]
                    {
                    KeyboardButton.WithRequestLocation("Location"),
                    KeyboardButton.WithRequestContact("Contact"),
                    });

                return await botClient.SendTextMessageAsync(chatId: message.Chat.Id,
                                                            text: "Quem ou onde você está?",
                                                            replyMarkup: RequestReplyKeyboard);
            }

            static async Task<Message> RequestActionClear(ITelegramBotClient botClient, Message message)
            {
                Cfg.msgBotDonate.Clear();
              
                return await botClient.SendTextMessageAsync(chatId: message.Chat.Id,
                                                            text: "Ação anterior cancelada...",
                                                            replyMarkup: new ReplyKeyboardRemove());
            }

            static async Task<Message> Usage(ITelegramBotClient botClient, Message message)
            {
                const string usage = "Comandos:\n" +
                                     "/menu   - exibir menu de opções\n" +
                                     "/logo    - Receber Logo\n" +
                                     "/reset - limpar ultima ação\n" +
                                     "/request  - solicitar local ou contato";

                return await botClient.SendTextMessageAsync(chatId: message.Chat.Id,
                                                            text: usage,
                                                            replyMarkup: new ReplyKeyboardRemove());
            }
        }

        private static async Task<Message> ActionCommand(ITelegramBotClient botClient, Message message)
        {
            Actions actions = new();

            return await actions.GetCommand(botClient, message);

           
        }
        private static  bool CheckStatusMsg(ITelegramBotClient botClient, CallbackQuery callbackQuery)
        {
            Actions actions = new();

            return actions.GetAction(botClient, callbackQuery);
        }

        // Process Inline Keyboard callback data
        private static async Task BotOnCallbackQueryReceived(ITelegramBotClient botClient, CallbackQuery callbackQuery)
        {
            if (CheckStatusMsg(botClient, callbackQuery))
                return;

            await botClient.AnswerCallbackQueryAsync(
                callbackQueryId: callbackQuery.Id,
                text: $"Received {callbackQuery.Data}");

            await botClient.SendTextMessageAsync(
                chatId: callbackQuery.Message!.Chat.Id,
                text: $"Received {callbackQuery.Data}");

         

           
        }

        private static async Task BotOnInlineQueryReceived(ITelegramBotClient botClient, InlineQuery inlineQuery)
        {
            Log.LogApp?.Info($"Bot:Received inline query from: {inlineQuery.From.Id}");

            InlineQueryResult[] results = {
            // displayed result
            new InlineQueryResultArticle(
                id: "1",
                title: "TgBots",
                inputMessageContent: new InputTextMessageContent(
                    "hello"
                )
            )
        };

            await botClient.AnswerInlineQueryAsync(inlineQueryId: inlineQuery.Id,
                                                   results: results,
                                                   isPersonal: true,
                                                   cacheTime: 0);
        }

        private static Task BotOnChosenInlineResultReceived(ITelegramBotClient botClient, ChosenInlineResult chosenInlineResult)
        {
            Log.LogApp?.Info($"Bot:Received inline result: {chosenInlineResult.ResultId}");
            return Task.CompletedTask;
        }

        private static Task UnknownUpdateHandlerAsync(ITelegramBotClient botClient, Update update)
        {
            Log.LogApp?.Info($"Bot:Unknown update type: {update.Type}");
            return Task.CompletedTask;
        }
    }
}
