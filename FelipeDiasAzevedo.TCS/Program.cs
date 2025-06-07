using FelipeDiasAzevedo.TCS.Business.Services;
using FelipeDiasAzevedo.TCS.Infra.Options;
using FelipeDiasAzevedo.TCS.Infra.Repositories.Clipboard;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddOptions<SystemOptions>()
    .Bind(builder.Configuration.GetSection(nameof(SystemOptions)))
    .ValidateDataAnnotations()
    .ValidateOnStart();

builder.Services
    .AddOptions<ArchivesOptions>()
    .Bind(builder.Configuration.GetSection(nameof(ArchivesOptions)))
    .ValidateDataAnnotations()
    .ValidateOnStart();

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlite($"Data Source=tcs.db");
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddScoped<ISystemService, SystemService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IClipboardService, ClipboardService>();

builder.Services.AddScoped<IClipboardRepository, ClipboardRepository>();

if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
{
    builder.Services.AddScoped<IOperationalSystemService, WindowsService>();
}
else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
{
    builder.Services.AddScoped<IOperationalSystemService, MacService>();
}
else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
{
    builder.Services.AddScoped<IOperationalSystemService, LinuxService>();
}

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
