using linkshortner_mvc_net.Data;
using linkshortner_mvc_net.Entities;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace linkshortner_mvc_net.Repositories.Account.Command;

public class LogoutCommandHandler : AsyncRequestHandler<LogoutCommand>
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LogoutCommandHandler(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }


    protected override async Task Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        await _httpContextAccessor.HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);
    }
}