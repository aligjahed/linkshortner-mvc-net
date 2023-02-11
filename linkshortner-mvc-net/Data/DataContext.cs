using linkshortner_mvc_net.Entities;
using linkshortner_mvc_net.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace linkshortner_mvc_net.Data;

public class DataContext : DbContext, IDataContext
{
    // private readonly IConfiguration _configuration;
    private readonly ILogger _logger;

    public DataContext() : base()
    {
    }

    public DataContext(
        // IConfiguration configuration,
        IWebHostEnvironment environment,
        ILogger logger
    ) : base()
    {
        // _configuration = configuration;
        _logger = logger;
    }
    
    public DbSet<User> LinkshortnerUsers { get; set; }
    public DbSet<Url> LinkshortnerUrls { get; set; }
}