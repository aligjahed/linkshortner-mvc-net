using linkshortner_mvc_net.Data;
using linkshortner_mvc_net.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace linkshortner_mvc_net.Repositories.Account.Query;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, User>
{
    private readonly DataContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public GetUserQueryHandler(
        DataContext context,
        IHttpContextAccessor httpContextAccessor
    )
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var currentUserId = _httpContextAccessor.HttpContext.User.Identity.Name;

        var currentUser = await _context.Users
            .FirstAsync(x => x.Id.ToString() == currentUserId);

        return currentUser;
    }
}