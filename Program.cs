using Microsoft.EntityFrameworkCore;
using Misbah_VisualProgramming_Project.Data;
using Misbah_VisualProgramming_Project.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Connection String Setup (XAMPP MySQL)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Server=localhost;Database=cafe_management;User=root;Password=;";

var serverVersion = new MySqlServerVersion(new Version(8, 0, 30));

// 2. Register DbContext AND DbContextFactory properly
builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseMySql(connectionString, serverVersion));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, serverVersion));

// 3. Register Core Application Services
builder.Services.AddScoped<CafeService>();
builder.Services.AddSingleton<HardwareService>();

// 4. Blazor Server Classic Pipeline Setup
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();