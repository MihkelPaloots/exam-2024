using System.Diagnostics;
using App.Contracts.DAL;
using App.Domain.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

[Authorize(Roles = "Admin, VenueOwner")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IAppUnitOfWork _bll;
    
    private readonly UserManager<AppUser> _userManager;

    public HomeController(ILogger<HomeController> logger, IAppUnitOfWork bll, UserManager<AppUser> userManager)
    {
        _logger = logger;
        _bll = bll;
        _userManager = userManager;
    }

    
    public IActionResult Index()
    {
        return View();
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    public IActionResult SetLanguage(string culture, string returnUrl)
    {
        // set cookie
        Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(
                new RequestCulture(culture)
            ),
            new CookieOptions()
            {
                Expires = DateTimeOffset.UtcNow.AddYears(1)
            }
        );
        return LocalRedirect(returnUrl);
    }
}