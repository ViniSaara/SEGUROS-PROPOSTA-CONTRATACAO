using Contratacao.Application.Services;
using Contratacao.Domain.Ports;
using Contratacao.Domain.Services;
using Contratacao.Infra.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Contratação API",
        Version = "v1",
        Description = "Exemplo de API com Swagger no ASP.NET Core"
    });
});

builder.Services.AddScoped<IContratacaoService, ContratacaoService>();
builder.Services.AddScoped<IGerenciamentoFilaService, GerenciamentoFilaService>();
builder.Services.AddHttpClient<IContratacaoExternaService, ContratacaoExternaService>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contratação API v1");
        c.RoutePrefix = string.Empty; // Abre no root: http://localhost:5000/
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
