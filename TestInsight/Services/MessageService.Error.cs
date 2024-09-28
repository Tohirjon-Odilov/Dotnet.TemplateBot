using Telegram.Bot;
using Telegram.Bot.Types;

namespace TestInsight.Services;

public partial class MessageService
{
    public async Task Error(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        await botClient.SendTextMessageAsync(
            chatId: update.Message!.Chat.Id,
            "Foydalanuvchi xato qildi",
            cancellationToken: cancellationToken);
    }
}