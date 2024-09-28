using TestInsight.Utils;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Service'larni sozlash uchun ajratilgan metodlar
builder.Services.ConfigureServices(builder.Configuration);
builder.Host.UseSerilog();

// Application yaratish
var app = builder.Build();

// DbContext va migration'larni sozlash
app.ApplyMigrations();

// Botni polling bilan ishga tushirish
app.StartBotPolling();

// HTTP tarmoq va boshqa asosiy konfiguratsiyalar
app.ConfigureMiddleware();
app.Run();
