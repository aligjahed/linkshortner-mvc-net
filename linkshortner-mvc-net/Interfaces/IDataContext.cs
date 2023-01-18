using linkshortner_mvc_net.Entities;
using Microsoft.EntityFrameworkCore;

namespace linkshortner_mvc_net.Interfaces;

public interface IDataContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Url> Urls { get; set; }
}