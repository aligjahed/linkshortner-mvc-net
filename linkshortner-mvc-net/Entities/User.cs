using linkshortner_mvc_net.Entities.Common;

namespace linkshortner_mvc_net.Entities;

public class User : BaseEntity 
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public virtual List<Url> Urls { get; set; }
}