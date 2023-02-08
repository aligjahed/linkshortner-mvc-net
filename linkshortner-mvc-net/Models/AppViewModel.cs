using System.Security.Policy;
using linkshortner_mvc_net.Dtos;
using Url = linkshortner_mvc_net.Entities.Url;

namespace linkshortner_mvc_net.Models;

public class AppViewModel
{
    public List<Url> Urls { get; set; }
    public AddLinkDto NewLink { get; set; }
}