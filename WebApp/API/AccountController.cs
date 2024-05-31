using App.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.API.DTO;

namespace WebApp.API;

[ApiController]
[Route("api/version")]
public class AccountController: ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    private readonly ILogger<AccountController> _logger;


    public AccountController(UserManager<AppUser> userManager, ILogger<AccountController> logger, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _logger = logger;
        _signInManager = signInManager;
    }


    [HttpPost]
    public async Task<ActionResult<string>> Login([FromBody] LoginInfoDto dto)
    {
        var appUser = await _userManager.FindByEmailAsync(dto.Email);
        if (appUser == null)
        {
            _logger.LogWarning(("Login failed: " + dto.Email));
            return NotFound("User/Password error");
        }

        var result = await _signInManager.CheckPasswordSignInAsync(appUser, dto.PassWord, false);
        if (!result.Succeeded)
        {
            _logger.LogWarning(("Login failed: " + dto.Email));
            return NotFound("User/Password error");
        }

        return Ok();
    }
}