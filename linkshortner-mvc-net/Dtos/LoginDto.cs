namespace linkshortner_mvc_net.Dtos;

public record LoginDto
{
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string Password { get; set; }

    public bool IsLoginMethodEmail { get; set; } = true;   
};