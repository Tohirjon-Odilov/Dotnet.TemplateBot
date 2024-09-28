using Telegram.Bot.Types.ReplyMarkups;

namespace TestInsight.Utils
{
    public static class ReplyKeyboardHelper
    {
        public static ReplyKeyboardMarkup CreateReplyKeyboard()
        {
            var replyKeyboard = new ReplyKeyboardMarkup(new[]
            {
                new KeyboardButton[] { "Tugma 1", "Tugma 2" }, // Bitta qatorda ikkita tugma
                new KeyboardButton[] { "Tugma 3" } // Yana bitta qatorda bitta tugma
            })
            {
                ResizeKeyboard = true, // Tugmalarni ekran o'lchamiga moslashtirish
                OneTimeKeyboard = true // Tugmalar bir marta bosilgandan keyin yo'qoladi
            };

            return replyKeyboard;
        }
    }
}