using Admin.Erp.Api.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Erp.Api.Controllers;

[ApiController]
[Route("categorias")]
public class CategoriaController : ControllerBase
{
    [HttpGet("listar")]
    [AutenticaPerfil]
    [AutenticaUsuarioAttibute]
    public IActionResult Listar()
    {
        return Ok();
    }

    [HttpGet("editar")]
    [AutenticaPerfil]
    [AutenticaUsuarioAttibute]
    public IActionResult Editar()
    {
        return Ok();
    }

    [HttpGet("criar")]
    [AutenticaPerfil]
    [AutenticaUsuarioAttibute]
    public IActionResult Criar()
    {
        return Ok();
    }
}
