using FluentValidation;
using MGIMemora.Application.Commands.PrivatePension;
using MGIMemora.Application.Commands.User;
using MGIMemora.Application.Handlers.PrivatePension;
using MGIMemora.Application.Handlers.User;
using MGIMemora.Domain.Repositories;
using MGIMemora.Infrastructure.Context;
using MGIMemora.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

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
builder.Services.AddTransient<UserCommandHandler>();
builder.Services.AddTransient<UserQueryHandler>();

builder.Services.AddTransient<IPrivatePensionRepository,PrivatePensionRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

//Validators PrivatePension
builder.Services.AddScoped<IValidator<CreatePrivatePensionCommand>, CreatePrivatePensionValidator>();
builder.Services.AddScoped<IValidator<UpdatePrivatePensionCommand>, UpdatePrivatePensionValidator>();
builder.Services.AddScoped<IValidator<UpdateModalityPrivatePensionCommand>, UpdateModalityPrivatePensionValidator>();
builder.Services.AddScoped<IValidator<DeletePrivatePensionCommand>, DeletePrivatePensionValidator>();
//Validators User
builder.Services.AddScoped<IValidator<CreateUserCommand>, CreateUserValidator>();
builder.Services.AddScoped<IValidator<UpdateEmailUserCommand>, UpdateEmailUserValidator>();
builder.Services.AddScoped<IValidator<UpdateRolesUserCommand>, UpdateRolesUserValidator>();
builder.Services.AddScoped<IValidator<DeleteUserCommand>, DeleteUserValidator>();




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
