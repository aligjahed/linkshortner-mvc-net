using linkshortner_mvc_net.Data;
using linkshortner_mvc_net.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace linkshortner_mvc_net.Repositories.App.Query;

public class GetAllUrlsQueryHandler : IRequestHandler<GetAllUrlsQuery, List<Url>>
{
    private readonly DataContext _context;
    private readonly IHttpContextAccessor _httpcontextAccessor;

    public GetAllUrlsQueryHandler(
        DataContext context,
        IHttpContextAccessor httpContextAccessor
    )
    {
        _context = context;
        _httpcontextAccessor = httpContextAccessor;
    }

    public async Task<List<Url>> Handle(GetAllUrlsQuery request, CancellationToken cancellationToken)
    {
        var currentUser = _httpcontextAccessor.HttpContext.User.Identity.Name;

        var user = await _context.Users
            .Include(x => x.Urls)
            .FirstOrDefaultAsync(x => x.Id.ToString() == currentUser);

        for (int i = 0; i < 50; i++)
        {
            user.Urls.Add(new Url
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                OriginUrl = "google.com",
                RedirectUrl = "test",
                RedirectCount = 800,
                User = user
            });
        }

        return user.Urls;
    }
}