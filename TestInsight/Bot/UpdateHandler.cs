using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TestInsight.Services;
using Microsoft.Extensions.Logging;

namespace TestInsight.Bot
{
    public class UpdateHandler
    {
        private readonly ITelegramBotClient _botClient;
        private readonly LoggingService _loggingService;
        private readonly MessageService _messageService;

        public UpdateHandler(ITelegramBotClient botClient, LoggingService loggingService, MessageService messageService)
        {
            _botClient = botClient;
            _loggingService = loggingService;
            _messageService = messageService;
        }

        // Yangilanishlarni boshqarish
        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Type != UpdateType.Message || update.Message == null)
            {
                return;
            }

            _loggingService.LogInformation($"Yangilanish turi: {update.Type}");

            switch (update.Message.Type)
            {
                case MessageType.Text:
                    await _messageService.Text(botClient, update, cancellationToken);
                    break;

                case MessageType.Photo:
                   await _messageService.Photo(botClient, update, cancellationToken);
                    break;

                default:
                    await _messageService.Error(botClient, update, cancellationToken);
                    break;
            }
        }

        // Inline tugmalarni boshqarish
        public async Task HandleCallbackQueryAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                await botClient.SendTextMessageAsync(update.CallbackQuery!.Message!.Chat.Id,
                    $"Siz {update.CallbackQuery.Data} tugmasini bosdingiz", cancellationToken: cancellationToken);
            }
        }
    }
}
