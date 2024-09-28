using Telegram.Bot;
using Telegram.Bot.Types;

namespace TestInsight.Commands;

public static class HelpCommand
{
    public static async Task HelpCommandHandler(
        ITelegramBotClient botClient,
        Update update,
        CancellationToken cancellationToken)
    {

        await botClient.SendTextMessageAsync(
            chatId: update.Message!.Chat.Id,
            text: "Yordam",
            cancellationToken: cancellationToken);
    }
}