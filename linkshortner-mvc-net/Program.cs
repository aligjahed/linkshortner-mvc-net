using linkshortner_mvc_net;
using linkshortner_mvc_net.Data;
using linkshortner_mvc_net.Middlewares;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var logger = LoggerFactory.Create(config =>
{
    config.AddConsole();
}).CreateLogger("Program");

// Add services to the container.
// All Services are inside ConfigureServices.cs
builder.Services.AddWebUi();

logger.LogInformation(builder.Environment.ToString());

if (builder.Environment.IsDevelopment())
{
    var connectionString = "Server=localhost;Database=LinkShortner;Port=3306;Uid=aligjahed;Pwd=Ali.1234";
    var teststtttttttttt = "Server=alfie.iran.liara.ir;Port=30971;Database=heuristic_pare;Uid=root;Pwd=cmnLBrUleo3ORVqGXwTpy49t;";
    builder.Services.AddDbContext<DataContext>(options =>
    {
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    });
}
else
{
    var MYSQLHOST = Environment.GetEnvironmentVariable("HOST");
    var MYSQLPORT = Environment.GetEnvironmentVariable("PORT");
    var MYSQLNAME = Environment.GetEnvironmentVariable("NAME");
    var MYSQLUSERNAME = Environment.GetEnvironmentVariable("USERNAME");
    var MYSQLPASSWORD = Environment.GetEnvironmentVariable("PASS");

    var connectionString =
        $"Server={MYSQLHOST};Port={MYSQLPORT};Database={MYSQLNAME};Uid={MYSQLUSERNAME};Pwd={MYSQLPASSWORD};";

    logger.LogInformation("Logging connection string");
    logger.LogInformation(connectionString);
    
    
    try
    {
        builder.Services.AddDbContext<DataContext>(options =>
        {
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });
    }
    catch (Exception e)
    {
        throw new Exception($"Database Connection With {connectionString} Failed; Exception: {e}");
    }
}

var app = builder.Build();

app.Environment.IsDevelopment();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// apply migrations at runtime
using (var scope = app.Services.CreateScope())
{
    await scope.ServiceProvider.GetService<DataContext>().Database.MigrateAsync();
}

app.Run();