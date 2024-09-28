using Telegram.Bot;
using Telegram.Bot.Types;

namespace TestInsight.Commands;

public static class UnknownCommand
{
    public static async Task UnknownCommandHandler(
        ITelegramBotClient botClient, 
        Update update,
        CancellationToken cancellationToken)
    {
        await botClient.SendTextMessageAsync(
            chatId: update.Message!.Chat.Id,
            text: "Xato buyruq",
            cancellationToken: cancellationToken);
    }
}