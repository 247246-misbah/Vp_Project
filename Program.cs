using Microsoft.EntityFrameworkCore;
using Misbah_VisualProgramming_Project.Data;
using Misbah_VisualProgramming_Project.Services;
using Misbah_VisualProgramming_Project.Components;
// Register Hardware Telemetry Service Context
builder.Services.AddScoped<Misbah_VisualProgramming_Project.Services.HardwareService>();

var builder = WebApplication.CreateBuilder(args);

// 1. Connection String Setup (MySQL Database Context)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Server=localhost;Database=cafe_management;User=root;Password=;";

var serverVersion = new MySqlServerVersion(new Version(8, 0, 30));

// 2. DbContext & Service Configuration
builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseMySql(connectionString, serverVersion),
    ServiceLifetime.Singleton);

builder.Services.AddScoped<CafeService>();

// 3. Modern Razor Components Configuration with Interactive Server Support
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

// 4. Strict Pipeline Routing - Explicitly target App component context mapping
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();