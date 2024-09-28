using Telegram.Bot;
using Telegram.Bot.Types;

namespace TestInsight.Services;

public static class MessageHandler
{
    public static async Task Salom(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        await botClient.SendTextMessageAsync(
            chatId: update.Message!.Chat.Id,
            text: "Assalomu alaykum!",
            cancellationToken: cancellationToken);
    }
}

