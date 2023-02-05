using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using linkshortner_mvc_net.Models;

namespace linkshortner_mvc_net.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        if (User.Identity.IsAuthenticated)
            return RedirectToAction("Index", "App");
        
        return View();
    }
}