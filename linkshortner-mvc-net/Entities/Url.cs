using linkshortner_mvc_net.Entities.Common;

namespace linkshortner_mvc_net.Entities;

public class Url : BaseEntity
{
    public string OriginUrl { get; set; }
    public string RedirectUrl { get; set; }
    public int RedirectCount { get; set; }
    public virtual User User { get; set; }
}