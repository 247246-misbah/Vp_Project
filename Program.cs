using Microsoft.EntityFrameworkCore;
using Misbah_VisualProgramming_Project.Data;
using Misbah_VisualProgramming_Project.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Database Connections Infrastructure (MySQL Setup via XAMPP)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Server=localhost;Database=cafe_management;Uid=root;Pwd=;";

var serverVersion = new MySqlServerVersion(new Version(8, 0, 30));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, serverVersion));

builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseMySql(connectionString, serverVersion));

// 2. Core Application Services Configuration Matrix
builder.Services.AddScoped<CafeService>();
builder.Services.AddSingleton<HardwareService>();

// 3. Register Standard Blazor Razor Components Service
builder.Services.AddServerSideBlazor();
builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAntiforgery();

// FIXED ROUTING PIPELINE: Universal routing engine that eliminates extension compilation bugs
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();