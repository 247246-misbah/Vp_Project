using Misbah_VisualProgramming_Project.Components;
using Misbah_VisualProgramming_Project.Data;
using Misbah_VisualProgramming_Project.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// 1. Corrected: Register Custom Database Context Factory (MySQL via XAMPP connection pipeline)
builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

// 2. Fallback registration for standard scoped context requests
builder.Services.AddScoped(p =>
    p.GetRequiredService<IDbContextFactory<AppDbContext>>().CreateDbContext());

// Register Application Infrastructure Dependency Injection Nodes
builder.Services.AddScoped<CafeService>();
builder.Services.AddScoped<HardwareService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();