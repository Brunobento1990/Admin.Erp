using Admin.Erp.Api.Configurations;
using Admin.Erp.Api.Middlewares;
using Admin.Erp.Application.Interfaces;
using Admin.Erp.Application.ViewModel;
using Admin.Erp.IoC.Application;
using Admin.Erp.IoC.Context;
using Admin.Erp.IoC.Repositories;
using dotenv.net;

var builder = WebApplication.CreateBuilder(args);

DotEnv.Load();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var keyJwt = VariaveisDeAmbiente.GetVariavel("JWT_KEY");
var issue = VariaveisDeAmbiente.GetVariavel("JWT_ISSUE");
var audience = VariaveisDeAmbiente.GetVariavel("JWT_AUDIENCE");
var expirate = int.Parse(VariaveisDeAmbiente.GetVariavel("JWT_EXPIRATION"));
var redisConnection = VariaveisDeAmbiente.GetVariavel("REDIS_URL");
var redisInstanceName = VariaveisDeAmbiente.GetVariavel("INSTANCE_NAME");
var dbConnection = VariaveisDeAmbiente.GetVariavel("STRING_CONNECTION_DB");

ConfiguracaoDeToken.Configure(keyJwt, issue, audience, expirate);

builder.Services
    .InjectService()
    .InjectRepositories()
    .InjectCache(redisConnection, redisInstanceName)
    .InjectJwt(keyJwt, issue, audience)
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

app.UseMiddleware<AutenticaUsuarioMiddleware>();
app.UseMiddleware<AutenticaAdminMiddleware>();
app.UseMiddleware<AutenticaPerfilUsuarioMiddleware>();

app.MapControllers();

app.Run();
