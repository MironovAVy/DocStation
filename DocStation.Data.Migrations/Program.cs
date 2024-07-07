using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DocStation.Data.Models;
using Microsoft.Extensions.Configuration;

namespace DocStation.Data.Migrations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
			using (var scope = host.Services.CreateScope())
			{
				var db = scope.ServiceProvider.GetRequiredService<ModelsDBContecx>();
				Console.WriteLine($"ConnectionString = \"{db.Database.GetConnectionString()}\"");
				Console.WriteLine("Migrations started");
				db.Database.Migrate();
				Console.WriteLine("Migrations completed");
			}

			host.Run();
        }


        public static IHostBuilder CreateHostBuilder(string[] args) {
            var builder = Host.CreateDefaultBuilder(args);
			return builder
				.ConfigureServices((hostContext, services) =>
                {
                    var connectionString = hostContext.Configuration.GetValue<string>("ConnectionString");

                    services.AddDbContext<ModelsDBContecx>(options =>
                    {
                        options.UseSqlServer(connectionString);
                    });
                });
        }
    }
}

