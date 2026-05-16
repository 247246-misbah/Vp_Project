using Microsoft.EntityFrameworkCore;
using Misbah_VisualProgramming_Project.Data;
using Misbah_VisualProgramming_Project.Services;
using Misbah_VisualProgramming_Project.Components; // Ensure this namespace is present

var builder = WebApplication.CreateBuilder(args);

// 1. Connection String Setup (XAMPP MySQL)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Server=localhost;Database=cafe_management;User=root;Password=;";

var serverVersion = new MySqlServerVersion(new Version(8, 0, 30));

// 2. Register DbContext and DbContextFactory
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

// 5. THE STRICT FIX: Maps directly to App.razor instead of non-existent _Host page
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();