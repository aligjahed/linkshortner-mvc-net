using System.Diagnostics;
using linkshortner_mvc_net.Exceptions;
using Microsoft.AspNetCore.Mvc;
using linkshortner_mvc_net.Models;

namespace linkshortner_mvc_net.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult TestError()
    {
        throw new UserNotFoundException();
    }
}