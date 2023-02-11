using linkshortner_mvc_net.Data;
using linkshortner_mvc_net.Entities;
using linkshortner_mvc_net.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace linkshortner_mvc_net.Repositories.Account.Command;

public class ChangePasswordCommandHandler : AsyncRequestHandler<ChangePasswordCommand>
{
    private readonly DataContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly PasswordHasher<User> _passwordHasher;

    public ChangePasswordCommandHandler(
        DataContext context,
        IHttpContextAccessor httpContextAccessor,
        PasswordHasher<User> passwordHasher)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
        _passwordHasher = passwordHasher;
    }

    protected override async Task Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var currentUserId = _httpContextAccessor.HttpContext.User.Identity.Name;
        var currentUser = await _context.LinkshortnerUsers.FirstOrDefaultAsync(x => x.Id.ToString() == currentUserId);

        var checkPassword = _passwordHasher.VerifyHashedPassword(currentUser, currentUser.PasswordHash,
            request.ChangePasswordData.currentPassword);

        if (checkPassword == PasswordVerificationResult.Failed)
            throw new WrongCredentialsException("Your provided credentials are wrong");

        var newPasswordHash = _passwordHasher.HashPassword(currentUser, request.ChangePasswordData.newPassword);

        currentUser.PasswordHash = newPasswordHash;
        
        _context.Update(currentUser);
        await _context.SaveChangesAsync();
    }
}