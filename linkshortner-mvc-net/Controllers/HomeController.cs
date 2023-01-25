using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using linkshortner_mvc_net.Models;

namespace linkshortner_mvc_net.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    
}