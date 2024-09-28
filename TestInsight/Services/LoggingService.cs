using Serilog;

namespace TestInsight.Services
{
    public class LoggingService
    {
        private readonly Serilog.ILogger _logger;

        public LoggingService()
        {
            // Log konfiguratsiyasi: wwwroot/logs papkasiga loglar tushadi
            _logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("wwwroot/logs/log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        // Oddiy log yozish
        public void LogInformation(string message)
        {
            _logger.Information(message);
        }

        // Xatoliklarni loglash
        public void LogError(string message, Exception ex)
        {
            _logger.Error(ex, message);
        }
    }
}