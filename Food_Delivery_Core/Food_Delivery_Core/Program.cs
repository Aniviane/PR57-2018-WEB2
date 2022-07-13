using Food_Delivery_Core.Data;
using Food_Delivery_Core.Mapping;
using Food_Delivery_Core.Services;
using Food_Delivery_Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);
IConfiguration Config = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme { 
    Description = "Standard Authorization header using the Bearer scheme (\"bearer  {token}\")",
    In = ParameterLocation.Header,
    Name = "Authorization",
    Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();

}
);
builder.Services.AddCors(options => options.AddPolicy(name: "FoodDeliveryOrigins", policy =>
{
    policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
}));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}
).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "https://localhost:7036/",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("babababababababababababababababababababababababababababababababab"))
    };
}
);

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUserInterface, UserService>();
builder.Services.AddScoped<IRestaurantInterface, RestaurantService>();
builder.Services.AddScoped<IOrderInterface, OrderService>();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(Config.GetConnectionString("CS")));
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new FoodMapper());
}
);
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("FoodDeliveryOrigins");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
