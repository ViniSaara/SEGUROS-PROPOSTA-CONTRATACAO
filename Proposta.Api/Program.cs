using Microsoft.OpenApi.Models;
using Proposta.Api.Mappers;
using Proposta.Application.Services;
using Proposta.Domain.Ports;
using Proposta.Domain.Services;
using Proposta.Infra.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Proposta API",
        Version = "v1",
        Description = "Exemplo de API com Swagger no ASP.NET Core"
    });
});

builder.Services.AddScoped<IPropostaService, PropostaService>();
builder.Services.AddScoped<IGerenciamentoFilaService, GerenciamentoFilaService>();
builder.Services.AddHttpClient<IPropostaExternaService, PropostaExternaService>();

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
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Proposta API v1");
        c.RoutePrefix = string.Empty; // Abre no root: http://localhost:5000/
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
