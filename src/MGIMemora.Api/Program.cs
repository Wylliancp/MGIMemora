using MGIMemora.Application.Handlers;
using MGIMemora.Domain.Repositories;
using MGIMemora.Infrastructure.Context;
using MGIMemora.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Context
builder.Services.AddDbContext<MGIContext>(opt => opt.UseInMemoryDatabase("database"));
//IOC
builder.Services.AddTransient<PrivatePensionCommandHandler>();
builder.Services.AddTransient<PrivatePensionQueryHandler>();

builder.Services.AddTransient<IPrivatePensionRepository,PrivatePensionRepository>();
//

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
