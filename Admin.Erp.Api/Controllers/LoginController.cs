using Admin.Erp.Application.Dtos.Logins;
using Admin.Erp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Erp.Api.Controllers;

[ApiController]
[Route("login")]
public class LoginController : ControllerBase
{
    private readonly ILoginService _loginService;

    public LoginController(ILoginService loginService)
    {
        _loginService = loginService;
    }

    [HttpPost("usuario")]
    public async Task<IActionResult> LoginAsync(LoginDto loginDto)
    {
        var result = await _loginService.LoginAsync(loginDto);  
        return Ok(result);
    }
}
