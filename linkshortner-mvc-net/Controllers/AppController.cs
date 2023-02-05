using System.Security.Policy;
using linkshortner_mvc_net.Models;
using linkshortner_mvc_net.Repositories.App.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace linkshortner_mvc_net.Controllers;

[Authorize]
public class AppController : Controller
{
    private readonly ISender _mediatr;
    private readonly ILogger _logger;

    public AppController(
        ISender mediatr,
        ILogger<AppController> logger)
    {
        _mediatr = mediatr;
        _logger = logger;
    }
    
    public async Task<IActionResult> Index()
    {
        var viewModel = new AppViewModel();
        
        viewModel.Urls = await _mediatr.Send(new GetAllUrlsQuery());
        
        return View(viewModel);
    }

    public IActionResult Profile()
    {
        return View();
    }

    public IActionResult RemoveUrl(string urlId)
    {
        throw new NotImplementedException();
    }
}