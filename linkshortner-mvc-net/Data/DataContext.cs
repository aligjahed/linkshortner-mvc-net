using linkshortner_mvc_net.Entities;
using linkshortner_mvc_net.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace linkshortner_mvc_net.Data;

public class DataContext : DbContext, IDataContext
{
    private readonly IConfiguration _configuration;
    private readonly IWebHostEnvironment _environment;
    private readonly ILogger _logger;

    public DataContext(
        IConfiguration configuration,
        IWebHostEnvironment environment,
        ILogger logger
    ) : base()
    {
        _configuration = configuration;
        _environment = environment;
        _logger = logger;
    }


    public DbSet<User> Users { get; set; }
    public DbSet<Url> Urls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        base.OnConfiguring(options);
        if (_environment.IsDevelopment())
        {
            var connectionString = _configuration.GetConnectionString("MySQL");
            options
                .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}