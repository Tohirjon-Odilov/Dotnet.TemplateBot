using Telegram.Bot.Types.ReplyMarkups;

namespace TestInsight.Utils
{
    public static class InlineKeyboardHelper
    {
        // Oddiy inline tugmalarni yaratish
        public static InlineKeyboardMarkup CreateInlineKeyboard()
        {
            var inlineKeyboard = new InlineKeyboardMarkup(new[]
            {
                // Bir qatorli ikkita tugma
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Tugma 1", "callback_1"),
                    InlineKeyboardButton.WithCallbackData("Tugma 2", "callback_2")
                },
                // Bitta tugma
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Tugma 3", "callback_3")
                }
            });

            return inlineKeyboard;
        }

        // Link tugmalarini yaratish (boshqa saytlarga havola qilish uchun)
        public static InlineKeyboardMarkup CreateLinkKeyboard()
        {
            var inlineKeyboard = new InlineKeyboardMarkup(new[]
            {
                new[]
                {
                    InlineKeyboardButton.WithUrl("Bizning sayt", "https://example.com")
                }
            });

            return inlineKeyboard;
        }
    }
}