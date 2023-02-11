using linkshortner_mvc_net.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace linkshortner_mvc_net.Repositories.App.Query;

public class GetRedirectIdQueryHandler : IRequestHandler<GetRedirectIdQuery , string>
{
    private readonly DataContext _context;
    private readonly IHttpContextAccessor _httpcontextAccessor;

    public GetRedirectIdQueryHandler(
        DataContext context,
        IHttpContextAccessor httpContextAccessor
    )
    {
        _context = context;
        _httpcontextAccessor = httpContextAccessor;
    }
    
    public async Task<string> Handle(GetRedirectIdQuery request, CancellationToken cancellationToken)
    {
        var reqUrl = await _context.LinkshortnerUrls
            .FirstAsync(x => x.RedirectUrl == request.reqID);

        reqUrl.RedirectCount += 1;
        await _context.SaveChangesAsync();

        return reqUrl.OriginUrl;
    }
}