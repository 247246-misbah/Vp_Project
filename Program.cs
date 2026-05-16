using Microsoft.EntityFrameworkCore;
using Misbah_VisualProgramming_Project.Data;
using Misbah_VisualProgramming_Project.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Database Configuration Structure (XAMPP MySQL Link)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Server=localhost;Database=cafe_management;Uid=root;Pwd=;";

var serverVersion = new MySqlServerVersion(new Version(8, 0, 30));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, serverVersion));

builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseMySql(connectionString, serverVersion));

// 2. CORE SERVICES REGISTRATION (FIXED: Explicitly mapped for injection)
builder.Services.AddScoped<Misbah_VisualProgramming_Project.Services.CafeService>();
builder.Services.AddSingleton<Misbah_VisualProgramming_Project.Services.HardwareService>();

// 3. Classical Architecture Blazor Component Pipeline
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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();