using linkshortner_mvc_net.Entities.Common;

namespace linkshortner_mvc_net.Entities;

public class User : BaseEntity
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public virtual List<Url> Urls { get; set; }
}