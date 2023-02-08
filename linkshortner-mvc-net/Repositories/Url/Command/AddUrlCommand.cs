using linkshortner_mvc_net.Dtos;
using MediatR;

namespace linkshortner_mvc_net.Repositories.Url.Command;

public class AddUrlCommand : IRequest
{
    public AddLinkDto reqUrl { get; set; }
}