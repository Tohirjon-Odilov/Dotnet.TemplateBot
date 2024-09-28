using Microsoft.EntityFrameworkCore;
using Serilog;
using Telegram.Bot;
using TestInsight.Bot;
using TestInsight.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;


namespace TestInsight.Utils
{
    public static class StartupExtensions
    {
        #region Service'larni sozlash (Telegram bot, Serilog, DbContext)
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Serilogni sozlash
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()  // Default log darajasi
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)  // Microsoft loglarini Warning ga o'rnatish
                .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)  // EF loglarini o'chirish yoki Warning
                .WriteTo.Console(
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
                    theme: AnsiConsoleTheme.Code
                    )  // Konsolga yozish
                .WriteTo.File("wwwroot/logs/log-.txt", rollingInterval: RollingInterval.Day)  // Faylga yozish
                .CreateLogger();

            
            services.AddSingleton<LoggingService>();
            services.AddSingleton<MessageService>();
            services.AddSingleton<UpdateHandler>();
            services.AddScoped<UserService>();

            // PostgreSQL ulanishini sozlash
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            // Telegram botni sozlash
            services.AddSingleton<ITelegramBotClient>(provider =>
            {
                var token = configuration["BotConfiguration:BotToken"];
                return new TelegramBotClient(token);
            });

            // Bot xizmatlari
            services.AddSingleton<BotService>();

            // Controller'larni sozlash
            services.AddControllers();
        }
        #endregion
        #region DbContext uchun migration'larni avtomatik qo'llash
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
            }
        }
        #endregion
        #region Botni polling bilan ishga tushirish
        public static void StartBotPolling(this IApplicationBuilder app)
        {
            var botService = app.ApplicationServices.GetRequiredService<BotService>();
            botService.StartPolling();
        }
        #endregion
        #region Middleware konfiguratsiyasi (HTTP, tarmoq va boshqalar)
        public static void ConfigureMiddleware(this IApplicationBuilder app)
        {
            // app.UseHttpsRedirection();
            // app.UseAuthorization();

            // Routingni qo'shish
            // app.UseRouting();

            // Endpoints (controller'larni xaritalash)
            // app.UseEndpoints(endpoints =>
            // {
                // endpoints.MapControllers();  // Controller'larni xaritalash
            // });
        }
        #endregion
    }
}
