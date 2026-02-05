using BossTodoMvc.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using BossTodoMvc.Application.Interfaces;
using BossTodoMvc.Infrastructure.Repositories;
using BossTodoMvc.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext to DI Container (CORE STEP)
// DI wiring
builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString =
        builder.Configuration.GetConnectionString("Postgres")
        ?? Environment.GetEnvironmentVariable("DATABASE_URL");

    if (string.IsNullOrWhiteSpace(connectionString))
        throw new InvalidOperationException("DATABASE_URL is not set.");

    options.UseNpgsql(connectionString);
});


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<TodoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

//app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
