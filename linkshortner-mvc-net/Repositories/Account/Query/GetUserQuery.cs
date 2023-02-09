using linkshortner_mvc_net.Entities;
using MediatR;

namespace linkshortner_mvc_net.Repositories.Account.Query;

public class GetUserQuery : IRequest<User>
{
}