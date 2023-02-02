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

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        base.OnConfiguring(options);

        // var connectionString = _configuration.GetConnectionString("MySQL");
        var connectionString = "Server=localhost;Database=LinkShortner;Port=3306;Uid=aligjahed;Pwd=Ali.1234";
        options
            .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }


    public DbSet<User> Users { get; set; }
    public DbSet<Url> Urls { get; set; }
}