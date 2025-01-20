using ASO_NET_04._Products_MVC.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProductsMVCContext>( options=>
options.UseInMemoryDatabase("productDB"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute( //localhost:5000/controller/action
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}");

app.Run();
