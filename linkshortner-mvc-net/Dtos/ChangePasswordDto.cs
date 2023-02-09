namespace linkshortner_mvc_net.Dtos;

public class ChangePasswordDto
{
    public string currentPassword { get; set; }
    public string newPassword { get; set; }
    public string newPasswordConfirmation { get; set; }
}