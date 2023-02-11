using linkshortner_mvc_net.Entities;
using Microsoft.EntityFrameworkCore;

namespace linkshortner_mvc_net.Interfaces;

public interface IDataContext
{
    public DbSet<User> LinkshortnerUsers { get; set; }
    public DbSet<Url> LinkshortnerUrls { get; set; }
}