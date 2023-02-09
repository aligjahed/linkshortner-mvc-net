using linkshortner_mvc_net.Dtos;
using linkshortner_mvc_net.Entities;

namespace linkshortner_mvc_net.Models;

public class ProfileViewModel
{
    public UserProfileDto User { get; set; }
    public ChangePasswordDto ChangePasswordData { get; set; }
    public string Message { get; set; } = "";
    public string MessageType { get; set; } = "error";
}