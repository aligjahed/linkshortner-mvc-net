using linkshortner_mvc_net.Entities;
using linkshortner_mvc_net.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace linkshortner_mvc_net.Data;

public class DataContext : DbContext, IDataContext
{
    public DataContext() : base()
    {
    }


    public DbSet<User> LinkshortnerUsers { get; set; }
    public DbSet<Url> LinkshortnerUrls { get; set; }
}