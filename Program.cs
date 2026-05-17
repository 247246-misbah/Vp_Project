using Microsoft.EntityFrameworkCore;
using Misbah_VisualProgramming_Project.Components;
using Misbah_VisualProgramming_Project.Data;
using Misbah_VisualProgramming_Project.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Pomelo MySQL Connection Setup (Aapke XAMPP cafe_management DB ke liye)
var connectionString = "server=127.0.0.1;port=3306;database=cafe_management;user=root;password=;";
builder.Services.AddDbContext<CafeDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Login Service ko register karen
builder.Services.AddScoped<AuthService>();

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

// Agr koi seedha "/" par aaye, use login page par redirect kar do
app.MapGet("/", async context =>
{
    context.Response.Redirect("/login");
    await Task.CompletedTask;
});

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();