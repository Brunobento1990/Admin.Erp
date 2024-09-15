using Admin.Erp.Domain.Entities;
using Admin.Erp.Infrastructure.Context;
using Bogus;
using Bogus.Extensions.Brazil;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using NpgsqlTypes;

namespace Admin.Erp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly AppDbContext _appDbContext;
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, AppDbContext appDbContext)
    {
        _logger = logger;
        _appDbContext = appDbContext;
    }

    [HttpGet("test-add")]
    public async Task<IActionResult> TestAdd()
    {
        try
        {
            for (int i = 0; i < 100000; i++)
            {
                var fake = new Faker();
                var nome = fake.Person.FullName;
                var cpf = fake.Person.Cpf(includeFormatSymbols: false);
                Console.WriteLine($"Criando usuário numero: {i + 1}");
                var searchVector = NpgsqlTsVector.Parse($"{nome} {cpf}");
                var usuario = new Usuario(
                    id: Guid.NewGuid(),
                    criadoEm: DateTime.Now,
                    atualizadoEm: DateTime.Now,
                    empresaId: Guid.NewGuid(),
                    nome: nome,
                    cpf: cpf,
                    dataDeNascimento: null,
                    search: searchVector,
                    senha: cpf);
                await _appDbContext.AddAsync(usuario);
            }

            await _appDbContext.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.InnerException?.Message ?? ex.Message);
        }
    }

    [HttpGet("pesquisar")]
    public async Task<IActionResult> Pesquisar([FromQuery] string search)
    {
        try
        {
            var pesquisa = search.Split(" ")[0];
            var usuarios = await _appDbContext.Usuarios
            .AsNoTracking()
            .Where(p => p.Search.Matches(EF.Functions.ToTsQuery("portuguese", pesquisa)))
            .ToListAsync();

            return Ok(usuarios);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.InnerException?.Message ?? ex.Message);
        }
    }

    [HttpGet("pesquisarlike")]
    public async Task<IActionResult> PesquisarLike([FromQuery] string search)
    {
        try
        {
            var usuarios = await _appDbContext.Usuarios
                .AsNoTracking()
                .Where(x => EF.Functions.ILike(EF.Functions.Unaccent(x.Nome), $"%{search}%") || EF.Functions.ILike(EF.Functions.Unaccent(x.Cpf!), $"%{search}%"))
                .ToListAsync();

            return Ok(usuarios);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.InnerException?.Message ?? ex.Message);
        }
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
