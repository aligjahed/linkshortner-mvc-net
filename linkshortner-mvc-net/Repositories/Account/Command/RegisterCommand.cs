using System.Security.Claims;
using linkshortner_mvc_net.Dtos;
using MediatR;

namespace linkshortner_mvc_net.Repositories.Account.Command;

public class RegisterCommand : IRequest
{
    public RegisterDto registerData { get; set; }
}