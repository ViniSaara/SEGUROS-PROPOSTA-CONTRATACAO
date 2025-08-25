using System;
using DataBase.Api;
using DataBase.Api.Entities;
using DataBase.Api.Mappers;
using DataBase.Api.Repositories;
using DataBase.Api.Services;
using DataBase.Api.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Database API",
        Version = "v1",
        Description = "Exemplo de API com Swagger no ASP.NET Core"
    });
});

builder.Services.AddTransient<ContratacaoRepository>();
builder.Services.AddTransient<ContratacaoService>();

builder.Services.AddScoped<PropostaRepository>();
builder.Services.AddScoped<PropostaService>();

builder.Services.AddHostedService<RabbitMqConsumerService>();

builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Database API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
