using System.Security.Claims;
using linkshortner_mvc_net.Data;
using linkshortner_mvc_net.Dtos;
using linkshortner_mvc_net.Entities;
using linkshortner_mvc_net.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace linkshortner_mvc_net.Repositories.Account.Query;

public class LoginQueryHandler : AsyncRequestHandler<LoginQuery>
{
    private readonly DataContext _context;
    private readonly PasswordHasher<User> _passwordHasher;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger _logger;

    public LoginQueryHandler(
        DataContext context,
        PasswordHasher<User> passwordHasher,
        IHttpContextAccessor httpContextAccessor,
        ILogger<LoginQueryHandler> logger)
    {
        _context = context;
        _passwordHasher = passwordHasher;
        _httpContextAccessor = httpContextAccessor;
        _logger = logger;
    }


    protected override async Task Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var httpContext = _httpContextAccessor.HttpContext;
        var loginData = request.loginData;

        // Check if a user has already signed in
        if (httpContext.User.Identity.IsAuthenticated)
            throw new UserIsAlreadyLoggedInException("A User is already logged in. Sign out first");

        // Check if a username or email exist
        if (string.IsNullOrEmpty(request.loginData.Email) && string.IsNullOrEmpty(request.loginData.Username))
            throw new NullEmailAndUsernameException("Please provide an email or an username");


        User? reqUser = null;

        // Find user data from database according to login method
        if (loginData.IsLoginMethodEmail)
        {
            reqUser = await _context.LinkshortnerUsers.FirstOrDefaultAsync(x => x.Email == loginData.Email);
        }
        else
        {
            reqUser = await _context.LinkshortnerUsers.FirstOrDefaultAsync(x => x.Username == loginData.Username);
        }

        // Throw exception if user with provided credentials doesn't exist
        if (reqUser is null)
            throw new UserDoesNotExistException("User with provided email or username does not exists.");
        

        // Check hashed password from requested user to provided password
        var passwordVerificationResult =
            _passwordHasher.VerifyHashedPassword(reqUser, reqUser.PasswordHash, loginData.Password);

        if (passwordVerificationResult == PasswordVerificationResult.Failed)
        {
            throw new WrongCredentialsException("Wrong credentials. Check your email/username and password");
        }
        else
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, reqUser.Id.ToString()),
                new Claim(ClaimTypes.GivenName, reqUser.Username),
                new Claim(ClaimTypes.Email, reqUser.Email),
                new Claim("CreatedAt", reqUser.CreatedAt.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var properties = new AuthenticationProperties()
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1)
            };

            // Signin user with provided data
            await httpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties);
        }
    }
}