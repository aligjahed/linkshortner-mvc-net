using System.Security.Claims;
using linkshortner_mvc_net.Dtos;
using linkshortner_mvc_net.Exceptions;
using linkshortner_mvc_net.Models;
using linkshortner_mvc_net.Repositories.Account.Command;
using linkshortner_mvc_net.Repositories.Account.Query;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace linkshortner_mvc_net.Controllers;

public class AccountController : Controller
{
    private readonly ISender _mediatr;

    public AccountController(ISender mediatr)
    {
        _mediatr = mediatr;
    }

    [HttpGet]
    public IActionResult Login(string? message, string? messageType)
    {
        var viewData = new LoginViewModel();

        viewData.Message = message ?? "";
        viewData.MessageType = messageType ?? "error";

        return View(viewData);
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginData)
    {
        await _mediatr.Send(new LoginQuery { loginData = loginData.Account });

        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public async Task<IActionResult> Register(string? message, string? messageType)
    {
        var viewData = new RegisterViewModel();

        viewData.Message = message ?? "";
        viewData.MessageType = messageType ?? "error";

        return View(viewData);
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel registerData)
    {
        if (!registerData.PasswordConfirmation.Equals(registerData.Account.Password))
        {
            throw new PasswordsDoNotMatchException("Password and Confirm password do not match");
        }

        await _mediatr.Send(new RegisterCommand { registerData = registerData.Account });

        return RedirectToAction("Login", "Account",
            new { message = "Account created Successfully. Please login", messageType = "success" });
    }

    public async Task<IActionResult> Logout()
    {
        await _mediatr.Send(new LogoutCommand());
        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public async Task<IActionResult> ChangePassword(ProfileViewModel profileViewModel)
    {
        var changePasswordDto = profileViewModel.ChangePasswordData;

        if (changePasswordDto.newPassword != changePasswordDto.newPasswordConfirmation)
            throw new PasswordsDoNotMatchException("Entered password do not match");

        await _mediatr.Send(new ChangePasswordCommand() { ChangePasswordData = changePasswordDto });

        return RedirectToAction("Profile", "App",
            new { message = "Password Changed successfully", messageType = "success" });
    }
}