using Admin.Erp.Api.Configurations;
using Admin.Erp.Application.Interfaces;
using Admin.Erp.IoC.Application;
using Admin.Erp.IoC.Context;
using Admin.Erp.IoC.Repositories;
using dotenv.net;

var builder = WebApplication.CreateBuilder(args);

DotEnv.Load();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var redisConnection = VariaveisDeAmbiente.GetVariavel("REDIS_URL");
var redisInstanceName = VariaveisDeAmbiente.GetVariavel("INSTANCE_NAME");
var dbConnection = VariaveisDeAmbiente.GetVariavel("STRING_CONNECTION_DB");

builder.Services
    .InjectService()
    .InjectRepositories()
    .InjectCache(redisConnection, redisInstanceName)
    .InjectContext(dbConnection);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

if (VariaveisDeAmbiente.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var service = scope.ServiceProvider.GetRequiredService<IAmbienteDesenvolvimentoService>();
    await service.IniciarAsync();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
