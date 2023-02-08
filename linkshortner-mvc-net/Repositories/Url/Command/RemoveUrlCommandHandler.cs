using linkshortner_mvc_net.Data;
using linkshortner_mvc_net.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace linkshortner_mvc_net.Repositories.Url.Command;

public class RemoveUrlCommandHandler : AsyncRequestHandler<RemoveUrlCommand>
{
    private readonly DataContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public RemoveUrlCommandHandler(
        DataContext context,
        IHttpContextAccessor httpContextAccessor
        )
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }
    
    protected override async Task Handle(RemoveUrlCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _httpContextAccessor.HttpContext.User.Identity.Name;
        var reqUrl = await _context.Urls
            .Include(x => x.User)
            .FirstOrDefaultAsync(x => x.Id.ToString() == request.UrlId);

        if (reqUrl is null)
            throw new UrlDoesNotExistException("The requested url does not exist");

        if (currentUser != reqUrl.User.Id.ToString())
            throw new UnauthorizedRequestException("You are not the owner of this url");

        _context.Urls.Remove(reqUrl);
        await _context.SaveChangesAsync();

    }
}