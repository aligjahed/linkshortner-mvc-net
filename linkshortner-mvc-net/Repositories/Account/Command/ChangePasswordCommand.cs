using linkshortner_mvc_net.Dtos;
using MediatR;

namespace linkshortner_mvc_net.Repositories.Account.Command;

public class ChangePasswordCommand : IRequest
{
    public ChangePasswordDto ChangePasswordData { get; set; }
}