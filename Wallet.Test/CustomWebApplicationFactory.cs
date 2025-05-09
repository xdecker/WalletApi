using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.Extensions.DependencyInjection;

using Wallet.Infrastructure;
using Microsoft.AspNetCore.Authentication;

namespace Wallet.Test
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Eliminar el ApplicationDbContext real si existe
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
                if (descriptor is not null)
                    services.Remove(descriptor);

                //para metodos autenticados
                services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = "Fake";
                    options.DefaultChallengeScheme = "Fake";
                })
            .AddScheme<AuthenticationSchemeOptions, FakeAuthHandler>("Fake", options => { });

                
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("TestDb"));

                
                var sp = services.BuildServiceProvider();
                using var scope = sp.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                db.Database.EnsureCreated();
            });

            return base.CreateHost(builder);
        }
    }
}
