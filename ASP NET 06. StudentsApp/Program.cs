using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<StudentsAppContext>(options =>
    options.UseSqlServer(
        builder
        .Configuration
        .GetConnectionString("StudentsAppContext"),
        setting=>
        {
            setting.CommandTimeout(30);
            setting.MigrationsHistoryTable("EF_TABLE_MIGRATIONS");
        }));
// Singleton, 

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Students}/{action=Index}/{id?}");

app.Run();
