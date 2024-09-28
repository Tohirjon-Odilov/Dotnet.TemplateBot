using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
}

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public long TelegramId { get; set; }
}