using ASP_NET_03._Dependency_injection___services.Data;
using ASP_NET_03._Dependency_injection___services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IProductRepository, InMemoryRepository>();

//builder.Services.Add(new ServiceDescriptor(typeof(IProductRepository), 
//    typeof(InMemoryRepository), ServiceLifetime.Singleton));

//builder.Services.AddSingleton<IProductRepository>(new InMemoryRepository());

builder.Services.AddSingleton<ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
