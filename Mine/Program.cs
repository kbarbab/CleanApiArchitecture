using Microsoft.EntityFrameworkCore;
using Mine.Application.Contracts.Authorization;
using Mine.Application.Contracts.Persistence.XMiner;
using Mine.Application.Contracts.Services.XMiner;
using Mine.Application.Services;
using Mine.Application.Services.Interfaces;
using Mine.Infrastructure.Data;
using Mine.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json") // Add appsettings.json file
            .Build();

builder.Services.AddScoped<IXMinerRepository, XMinerRepository>();
builder.Services.AddScoped<IXMinerService, XMinerService>();
builder.Services.AddScoped<IXMoveRepository, XMoveRepository>();
builder.Services.AddScoped<IXMoveService, XMoveService>();
builder.Services.AddScoped<IUserAccessor, UserAccessor>();

builder.Services.AddDbContext<MineDbContext>(options =>
        options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<MineDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MineDbContext>();
    db.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
