using ASP_NET_12.Data;
using ASP_NET_12.DTOs.Auth;
using ASP_NET_12.Models;
using ASP_NET_12.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<ToDoContext>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
        new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ClockSkew = TimeSpan.Zero,
            ValidIssuer = "https://localhost:5012",
            ValidAudience = "https://localhost:5012",
            IssuerSigningKey
            = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Supper pupper mupper hard secure Key"))
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CanTest", policy =>
    {
        policy.RequireAuthenticatedUser();
        //policy.RequireClaim("CanTest");
        policy.Requirements.Add(new CanTestRequirment());
    });
});

builder.Services.AddSwaggerGen(setup =>
{
    setup.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "ToDo",
            Version = "ver. 2"
        });
    var filePath = Path.Combine(AppContext.BaseDirectory, "Documentation.xml");
    setup.IncludeXmlComments(filePath);
    setup.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\""
    });
    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        }, new string[]{}
        }
    });

});


builder.Services.AddScoped<IToDoService, ToDoService>();

builder.Services.AddDbContext<ToDoContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("TODO_DBContext"));
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
