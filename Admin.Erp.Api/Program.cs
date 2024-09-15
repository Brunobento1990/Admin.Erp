using Admin.Erp.IoC.Context;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.InjectContext("User ID=postgres; Password=1234; Host=localhost; Port=4449; Database=admin-erp-hml-1; Pooling=true;");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
