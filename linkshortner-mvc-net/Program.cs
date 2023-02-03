using linkshortner_mvc_net;
using linkshortner_mvc_net.Data;
using linkshortner_mvc_net.Middlewares;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// All Services are inside ConfigureServices.cs
builder.Services.AddWebUi();

var app = builder.Build();

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