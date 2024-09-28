using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TestInsight.Commands;

namespace TestInsight.Services
{
    public partial class MessageService
    {
        private readonly LoggingService _loggingService;

        public MessageService(LoggingService loggingService)
        {
            _loggingService = loggingService;
        }
        public async Task Text(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Type != UpdateType.Message || update.Message == null) return;
            
            switch (update.Message.Text)
            {
                case "/start":
                    await StartCommand.StartCommandHandler(botClient, update, cancellationToken);
                    break;
                case "/help":
                    await HelpCommand.HelpCommandHandler(botClient, update, cancellationToken);
                    break;

                case "Salom":
                    await MessageHandler.Salom(botClient, update, cancellationToken);
                    break;
                
                default:
                    if (update.Message.Text!.StartsWith("/"))
                    {
                        await UnknownCommand.UnknownCommandHandler(botClient, update, cancellationToken);
                    };
                    break;
            }
        }
    }
}