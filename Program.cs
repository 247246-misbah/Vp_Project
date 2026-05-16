using Microsoft.EntityFrameworkCore;
using Misbah_VisualProgramming_Project.Components;
using Misbah_VisualProgramming_Project.Data;
using Misbah_VisualProgramming_Project.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// 1. Database Connection Engine Setup
builder.Services.AddDbContext<CafeDbContext>(options =>
    options.UseSqlite("Data Source=Data/cafecove.db"));

// 2. Strong Binding of Injected Services with Interfaces
builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ISensorService, SensorService>();

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

// Absolute Route Endpoint Target to bypass 404 on Root "/"
app.MapGet("/", async context =>
{
    context.Response.Redirect("/dashboard");
    await Task.CompletedTask;
});

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();