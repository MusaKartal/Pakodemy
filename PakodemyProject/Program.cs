using BusinessLayer;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntitiesLayer;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//sqlConnect
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//redis
//IConfiguration configuration = builder.Configuration;
//var multiplexer = ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis"));
//builder.Services.AddSingleton<IConnectionMultiplexer>(multiplexer);
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost";
});

//automapper
builder.Services.AddAutoMapper(typeof(MapperInitilizer));


builder.Services.AddScoped<IHumanService, HumanManager>();
builder.Services.AddScoped<ICacheService, CacheManager>();
builder.Services.AddScoped<IAgifyService, AgifyManager>();
builder.Services.AddScoped<IHumanDal, HumanDal>();



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
