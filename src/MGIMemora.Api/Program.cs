using FluentValidation;
using MGIMemora.Application;
using MGIMemora.Application.Commands.PrivatePension;
using MGIMemora.Application.Commands.User;
using MGIMemora.Application.Handlers.PrivatePension;
using MGIMemora.Application.Handlers.User;
using MGIMemora.Domain.Repositories;
using MGIMemora.Infrastructure.Context;
using MGIMemora.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//configuração para habilitar requisições localhost
builder.Services.AddCors();
// Add services to the container.
builder.Services.AddControllers();
//JWT
// var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("AppSettings").ToString() ?? "Chave");
var key = Encoding.ASCII.GetBytes(Settings.Secret);
            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

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
builder.Services.AddScoped<IValidator<LoginUserCommand>, LoginUserValidator>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//configuração para habilitar requisições localhost - part2
app.UseCors(x => x.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
