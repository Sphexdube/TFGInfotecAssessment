namespace TFGInfotecApi.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static void GetServices(this IServiceCollection services)
		{
			services.AddScoped<IDishManager, DishManager>();
			services.AddScoped<IDrinkManager, DrinkManager>();
			services.AddScoped<IAccountManager, AccountManager>();

			services.AddScoped<IDishService, DishService>();
			services.AddScoped<IDrinkService, DrinkService>();
			services.AddScoped<ICustomerService, CustomerService>();

			services.AddScoped<IRepository<Account>, Repository<Account>>();
			services.AddScoped<IRepository<Customer>, Repository<Customer>>();
			services.AddScoped<IRepository<Dish>, Repository<Dish>>();
			services.AddScoped<IRepository<DishReview>, Repository<DishReview>>();
			services.AddScoped<IRepository<Drink>, Repository<Drink>>();
			services.AddScoped<IRepository<DrinkReview>, Repository<DrinkReview>>();

			services.AddScoped<IUserService<Customer>, UserService<Customer>>();
		}

		public static void AddDatabaseContext(this IServiceCollection services)
		{
			var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
			var dbName = Environment.GetEnvironmentVariable("DB_NAME");
			var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
			var connectionString = $"Data Source={dbHost};Initial Catalog={dbName}; User ID=sa;Password={dbPassword};TrustServerCertificate=true";

			var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
			optionsBuilder.UseSqlServer(connectionString).LogTo(Console.WriteLine, LogLevel.Information);

			services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString).LogTo(Console.WriteLine, LogLevel.Information));
		}
	}
}
