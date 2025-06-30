using ABet.Models;
using ABet.Settings;
using Microsoft.EntityFrameworkCore;
using NLog.Extensions.Logging;

NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

/*
 * Для сборки DEB-пакета использовать команду:
 * dotnet msbuild /t:CreateDeb /p:PackageDir=debian /p:WarningLevel=0
 */
// Выполнение миграции базы данных
using (var db = new DB())
{
    db.Database.Migrate();
    log.Info("База данных инициализирована");
}

var builder = WebApplication.CreateBuilder(args);

// Поддержка сеансов
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Контекст базы данных для иньекции зависимостей (DI) в контроллеры
builder.Services.AddDbContext<DB>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();




