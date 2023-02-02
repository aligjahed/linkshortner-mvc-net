using linkshortner_mvc_net.Dtos;

namespace linkshortner_mvc_net.Models;

public class LoginViewModel
{
    public LoginDto Account { get; set; } = new LoginDto();
    public string Message { get; set; } = "";
    public string MessageType { get; set; } = "error";
}