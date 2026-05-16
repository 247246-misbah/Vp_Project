using Microsoft.EntityFrameworkCore;
using Misbah_VisualProgramming_Project.Data;
using Misbah_VisualProgramming_Project.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Database Connections Infrastructure (MySQL via XAMPP)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Server=localhost;Database=cafe_management;Uid=root;Pwd=;";

var serverVersion = new MySqlServerVersion(new Version(8, 0, 30));

// Core Service registration
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, serverVersion));

// THE CRITICAL FIX: Registers the database factory that HardwareService is searching for
builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseMySql(connectionString, serverVersion));

// 2. Core Application Domain Services Registration
builder.Services.AddScoped<CafeService>();
builder.Services.AddSingleton<HardwareService>();

// 3. Blazor Interactive Architecture Configuration
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

// Absolute explicit component routing declaration
app.MapRazorComponents<Misbah_VisualProgramming_Project.Components.App>()
    .AddInteractiveServerComponents();

app.Run();