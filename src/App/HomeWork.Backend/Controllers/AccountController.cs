using HomeWork.Core.AuthServices;
using HomeWork.Service.Models.AuthModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork.Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class AccountController : ControllerBase
{
    private readonly IAuthService _authService;

    public AccountController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponse>> Login (LoginModel model)
    {
        return Ok(await _authService.Login(model));
    }


    [HttpPost("register")]
    public async Task<ActionResult<LoginResponse>> Register(RegisterModel model)
    {
        return Ok(await _authService.Register(model));
    }
}
