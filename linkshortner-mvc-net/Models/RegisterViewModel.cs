using linkshortner_mvc_net.Dtos;

namespace linkshortner_mvc_net.Models;

public class RegisterViewModel
{
    public RegisterDto Account { get; set; } = new RegisterDto();
    public string PasswordConfirmation { get; set; } = "";
    public string Message { get; set; } = "";
    public string MessageType { get; set; } = "error";
}