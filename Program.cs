using Microsoft.EntityFrameworkCore;
using Misbah_VisualProgramming_Project.Data;
using Misbah_VisualProgramming_Project.Services;
using Misbah_VisualProgramming_Project.Components; // Crucial namespace for App.razor

var builder = WebApplication.CreateBuilder(args);

// 1. Connection String Setup (XAMPP MySQL)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Server=localhost;Database=cafe_management;Uid=root;Pwd=;";

var serverVersion = new MySqlServerVersion(new Version(8, 0, 30));

// 2. Register ONLY the DbContextFactory cleanly with Singleton lifetime alignment
builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseMySql(connectionString, serverVersion),
    ServiceLifetime.Singleton);

// 3. Register Core Application Services
builder.Services.AddScoped<CafeService>();
builder.Services.AddSingleton<HardwareService>();

// 4. Register Razor Components for Modern Interactive Server Rendering
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// 5. 100% CORRECT ROUTING: Points directly to App.razor component pipeline instead of non-existent _Host page
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();