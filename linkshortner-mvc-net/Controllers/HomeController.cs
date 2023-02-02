using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using linkshortner_mvc_net.Models;

namespace linkshortner_mvc_net.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        _logger.LogInformation(HttpContext.User.Identity.IsAuthenticated.ToString());
        return View();
    }
}