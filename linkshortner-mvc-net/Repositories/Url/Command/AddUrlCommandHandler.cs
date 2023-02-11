using linkshortner_mvc_net.Data;
using linkshortner_mvc_net.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace linkshortner_mvc_net.Repositories.Url.Command;

public class AddUrlCommandHandler : AsyncRequestHandler<AddUrlCommand>
{
    private readonly DataContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AddUrlCommandHandler(
        DataContext context,
        IHttpContextAccessor httpContextAccessor
    )
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    protected override async Task Handle(AddUrlCommand request, CancellationToken cancellationToken)
    {
        var reqUrl = request.reqUrl;

        // Get current user
        var currentUserId = _httpContextAccessor.HttpContext.User.Identity.Name;
        var currentUser = await _context.LinkshortnerUsers.FirstOrDefaultAsync(x => x.Id.ToString() == currentUserId);

        var checkUrlExist = await _context.LinkshortnerUrls.FirstOrDefaultAsync(x => x.RedirectUrl == reqUrl.RedirectUrl);

        if (checkUrlExist is not null)
            throw new RedirectIdAlreadyExistException("The redirect url is already taken.");

        var newLink = new Entities.Url()
        {
            Id = Guid.NewGuid(),
            OriginUrl = reqUrl.OriginUrl.ToLower().Contains("https://") ||
                        reqUrl.OriginUrl.ToLower().Contains("http://")
                ? reqUrl.OriginUrl
                : $"https://{reqUrl.OriginUrl}",
            RedirectUrl = reqUrl.RedirectUrl,
            CreatedAt = DateTime.Now,
            RedirectCount = 0,
            User = currentUser
        };

        await _context.LinkshortnerUrls.AddAsync(newLink);
        await _context.SaveChangesAsync();
    }
}