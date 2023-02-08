using linkshortner_mvc_net.Dtos;
using linkshortner_mvc_net.Entities;
using linkshortner_mvc_net.Models;
using linkshortner_mvc_net.Repositories.Url.Command;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace linkshortner_mvc_net.Controllers;

[Authorize]
public class UrlController : Controller
{
    private readonly ISender _mediatr;

    public UrlController(ISender mediatr)
    {
        _mediatr = mediatr;
    }

    public async Task<IActionResult> Add(AppViewModel appViewModel)
    {
        await _mediatr.Send(new AddUrlCommand { reqUrl = appViewModel.NewLink });
        return RedirectToAction("Index", "App");
    }
    
    
    public async Task<IActionResult> Remove(string urlId)
    {
        await _mediatr.Send(new RemoveUrlCommand{UrlId = urlId});

        return RedirectToAction("Index" , "App");
    }
}