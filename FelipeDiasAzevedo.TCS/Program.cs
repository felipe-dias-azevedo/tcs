using FelipeDiasAzevedo.TCS.Business.Services;
using FelipeDiasAzevedo.TCS.Infra.Options;
using System.Runtime.InteropServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddOptions<ServicesOptions>()
    .Bind(builder.Configuration.GetSection(nameof(ServicesOptions)))
    .ValidateDataAnnotations()
    .ValidateOnStart();

builder.Services.AddScoped<ISystemService, SystemService>();

if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
{
    builder.Services.AddScoped<IOperationalSystemService, WindowsService>();
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
