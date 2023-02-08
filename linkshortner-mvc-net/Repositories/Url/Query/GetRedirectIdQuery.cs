using MediatR;

namespace linkshortner_mvc_net.Repositories.App.Query;

public class GetRedirectIdQuery : IRequest<string>
{
    public string reqID { get; set; }
}