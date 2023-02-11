using linkshortner_mvc_net.Data;
using linkshortner_mvc_net.Entities;
using linkshortner_mvc_net.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace linkshortner_mvc_net.Repositories.Account.Command;

public class RegisterCommandHandler : AsyncRequestHandler<RegisterCommand>
{
    private readonly DataContext _context;
    private readonly PasswordHasher<User> _passwordHasher;

    public RegisterCommandHandler(
        DataContext context,
        PasswordHasher<User> passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
    }

    protected override async Task Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var registerReq = request.registerData;

        // Check if user already exist
        var checkUserExistence = await _context.LinkshortnerUsers.FirstOrDefaultAsync(x => x.Email == registerReq.Email);
        if (checkUserExistence is not null)
        {
            throw new UserAlreadyExistException("User with same email already exist.");
        }

        // Check for username availability 
        var checkUsername = await _context.LinkshortnerUsers.FirstOrDefaultAsync(x => x.Username == registerReq.Username);
        if (checkUsername is not null)
        {
            throw new UsernameAlreadyExistException("Username is taken, try another one.");
        }
        
        // Create a new user object with provided email and username
        var newUser = new User
        {
            Id = Guid.NewGuid(),
            Username = registerReq.Username,
            Email = registerReq.Email,
            CreatedAt = DateTime.UtcNow,
        };
        
        // Hash password
        var hashPassword = _passwordHasher.HashPassword(newUser , registerReq.Password);
        newUser.PasswordHash = hashPassword;

        // Add user to database and save
        await _context.LinkshortnerUsers.AddAsync(newUser);
        await _context.SaveChangesAsync();
    }
}