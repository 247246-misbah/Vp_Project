using Microsoft.EntityFrameworkCore;
using Misbah_VisualProgramming_Project.Data;
using Misbah_VisualProgramming_Project.Services;
using Misbah_VisualProgramming_Project.Components;

var builder = WebApplication.CreateBuilder(args);

// 1. SERVICES CONFIGURATION (Yahan .AddInteractiveServerComponents lagta hai)
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<HardwareService>();
builder.Services.AddScoped<CafeService>();

// 2. DATABASE CONFIGURATION
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Server=localhost;Database=cafe_management;User=root;Password=;";

var serverVersion = new MySqlServerVersion(new Version(8, 0, 30));

builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseMySql(connectionString, serverVersion),
    ServiceLifetime.Singleton);

var app = builder.Build();

// 3. HTTP PIPELINE
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// 4. ROUTING PIPELINE (Yahan .AddInteractiveServerRenderMode lagta hai!)
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();