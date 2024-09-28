using Telegram.Bot;
using Telegram.Bot.Polling;
using TestInsight.Services;
using Microsoft.Extensions.Logging;

namespace TestInsight.Bot
{
    public class BotService
    {
        private readonly ITelegramBotClient _botClient;
        private readonly LoggingService _loggingService;
        private readonly UpdateHandler _updateHandler;

        public BotService(ITelegramBotClient botClient, LoggingService loggingService, UpdateHandler updateHandler)
        {
            _botClient = botClient;
            _loggingService = loggingService;
            _updateHandler = updateHandler;
        }

        // Polling boshlash
        public void StartPolling()
        {
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = Array.Empty<Telegram.Bot.Types.Enums.UpdateType>() // Hamma yangilanishlarni qabul qilish
            };

            _botClient.StartReceiving(
                _updateHandler.HandleUpdateAsync,
                HandlePollingErrorAsync,
                receiverOptions,
                cancellationToken: default
            );

            _loggingService.LogInformation("Bot pollingni boshladi...");
        }

        // Pollingdagi xatolarni qayta ishlash
        private Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            _loggingService.LogError("Polling xatolik yuz berdi", exception);
            return Task.CompletedTask;
        }
    }
}