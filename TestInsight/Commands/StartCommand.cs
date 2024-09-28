using Telegram.Bot;
using Telegram.Bot.Types;
using TestInsight.Utils;

namespace TestInsight.Commands
{
    public static class StartCommand
    {
        // Correct method signature with 'async' and 'await'
        public static async Task StartCommandHandler(
            ITelegramBotClient botClient, 
            Update update,
            CancellationToken cancellationToken)
        {
            var replyKeyboard = ReplyKeyboardHelper.CreateReplyKeyboard();
            await botClient.SendTextMessageAsync(
                update.Message.Chat.Id, 
                "Start buyrug'i kiritildi, tugmalar ko'rsatilmoqda.", 
                replyMarkup: replyKeyboard, 
                cancellationToken: cancellationToken);
        }
    }
}