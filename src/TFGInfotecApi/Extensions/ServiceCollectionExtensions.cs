using Microsoft.EntityFrameworkCore;
using TFGInfotecAbstractions.Interfaces;
using TFGInfotecApi.Managers;
using TFGInfotecInfrastructure.DataSource;

namespace TFGInfotecApi.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static void AddManagers(this IServiceCollection services)
		{
			services.AddScoped<IDishManager, DishManager>();
			services.AddScoped<IDrinkManager, DrinkManager>();
		}

		public static void AddDatabaseContext(this IServiceCollection services)
		{
			var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
			var dbName = Environment.GetEnvironmentVariable("DB_NAME");
			var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
			var connectionString = $"Data Source={dbHost};Initial Catalog={dbName}; User ID=sa;Password={dbPassword};TrustServerCertificate=true";

			var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
			optionsBuilder.UseSqlServer(connectionString).LogTo(Console.WriteLine, LogLevel.Information);

			services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString).LogTo(Console.WriteLine, LogLevel.Information));
		}
	}
}
