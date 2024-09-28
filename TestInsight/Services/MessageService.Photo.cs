using Telegram.Bot;
using Telegram.Bot.Types;

namespace TestInsight.Services;

public partial class MessageService
{
    public async Task Photo(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Message is not { Photo: { } } message)
        {
            return;
        }

        await botClient.SendTextMessageAsync(
            chatId: update.Message.Chat.Id,
            text: "Rasm yuborildi!",
            cancellationToken: cancellationToken
        );
    }
}