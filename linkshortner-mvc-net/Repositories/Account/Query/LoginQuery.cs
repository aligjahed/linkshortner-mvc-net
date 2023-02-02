using System.Security.Claims;
using linkshortner_mvc_net.Dtos;
using MediatR;

namespace linkshortner_mvc_net.Repositories.Account.Query;

public class LoginQuery : IRequest
{
    public LoginDto loginData { get; set; }
}