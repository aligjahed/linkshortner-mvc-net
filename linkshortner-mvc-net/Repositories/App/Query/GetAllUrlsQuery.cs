using linkshortner_mvc_net.Entities;
using MediatR;

namespace linkshortner_mvc_net.Repositories.App.Query;

public class GetAllUrlsQuery : IRequest<List<Url>>
{
}