using ABet.Models;
using ABet.Settings;
using Microsoft.EntityFrameworkCore;
using NLog.Extensions.Logging;

NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

/*
 * ��� ������ DEB-������ ������������ �������:
 * dotnet msbuild /t:CreateDeb /p:PackageDir=debian /p:WarningLevel=0
 */
// ���������� �������� ���� ������
using (var db = new DB())
{
    db.Database.Migrate();
    log.Info("���� ������ ����������������");
}

var builder = WebApplication.CreateBuilder(args);

// ��������� �������
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

// Add services to the container.
builder.Services.AddControllersWithViews();

// �������� ���� ������ ��� �������� ������������ (DI) � �����������
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




