using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using linkshortner_mvc_net.Models;
using linkshortner_mvc_net.Repositories.App.Query;
using MediatR;

namespace linkshortner_mvc_net.Controllers;

public class HomeController : Controller
{
    private readonly ISender _mediatr;

    public HomeController(ISender mediatr)
    {
        _mediatr = mediatr;
    }
    
    [Route("/{redirectID?}")]
    public async Task<IActionResult> Index()
    {
        var redirectId = Request.Path.Value.Split("/")[1];
        
        if (!string.IsNullOrEmpty(redirectId))
        {
            string originUrl;
            originUrl = await _mediatr.Send(new GetRedirectIdQuery{reqID = redirectId});
            return Redirect(originUrl);
        }

        if (User.Identity.IsAuthenticated)
            return RedirectToAction("Index", "App");

        return View();
    }
}