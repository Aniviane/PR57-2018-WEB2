using Food_Delivery_Core.Data;
using Food_Delivery_Core.Mapping;
using Food_Delivery_Core.Services;
using Food_Delivery_Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;


var builder = WebApplication.CreateBuilder(args);
IConfiguration Config = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserInterface, UserService>();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
