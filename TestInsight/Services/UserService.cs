using TestInsight.Models;

namespace TestInsight.Services
{
    public class UserService
    {
        public Task<UserModel> GetUserByIdAsync(long telegramId)
        {
            // DB dan foydalanuvchini olish lozim (hozircha mock qilinadi)
            return Task.FromResult(new UserModel
            {
                Id = telegramId,
                Username = "testuser"
            });
        }
    }
}