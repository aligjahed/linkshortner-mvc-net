using MediatR;

namespace linkshortner_mvc_net.Repositories.Url.Command;

public class RemoveUrlCommand : IRequest
{
    public string UrlId { get; set; }
}