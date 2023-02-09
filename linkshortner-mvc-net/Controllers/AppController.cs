using System.Security.Policy;
using linkshortner_mvc_net.Dtos;
using linkshortner_mvc_net.Models;
using linkshortner_mvc_net.Repositories.Account.Query;
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
    
    [Route("/App")]
    public async Task<IActionResult> Index()
    {
        var viewModel = new AppViewModel();
        
        viewModel.Urls = await _mediatr.Send(new GetAllUrlsQuery());
        
        return View(viewModel);
    }
    
    
    public async Task<IActionResult> Profile(string message , string messageType)
    {
        var viewModel = new ProfileViewModel();
        var currentUser = await _mediatr.Send(new GetUserQuery());

        viewModel.User = new UserProfileDto()
        {
            Email = currentUser.Email,
            Username = currentUser.Username,
            CreatedAt = currentUser.CreatedAt
        };

        viewModel.Message = message ?? "";
        viewModel.MessageType = messageType ?? "";
        
        return View(viewModel);
    }
}