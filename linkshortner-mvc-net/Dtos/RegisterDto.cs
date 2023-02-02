namespace linkshortner_mvc_net.Dtos;

public record RegisterDto
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}