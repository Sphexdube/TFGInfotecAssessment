using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using TFGInfotecAbstractions.Models;

namespace TFGInfotecInfrastructure.DataSource
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options)
			: base(options)
		{
			try
			{
				var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
				if (databaseCreator != null)
				{
					if (!databaseCreator.CanConnect()) databaseCreator.Create();
					if (!databaseCreator.CanConnect()) databaseCreator.CreateTables();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public DbSet<Drink> Drinks { get; set; }
		public DbSet<Dish> Dishes { get; set; }
		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			//modelBuilder.Entity<Drink>().HasKey(d => d.Id);
			//modelBuilder.Entity<Drink>().Property(d => d.Id).ValueGeneratedOnAdd();
			//modelBuilder.Entity<Drink>().HasData(
			//	new Drink() { Id = 1, Name = "Coke ", Description = "330ml", Image = "https://help.rockcontent.com/en/how-to-solve-404-error", Price = 14.99, Rating = 1 },
			//	new Drink() { Id = 2, Name = "Creme Soda ", Description = "330ml", Image = "https://help.rockcontent.com/en/how-to-solve-404-error", Price = 14.99, Rating = 3 });

			//modelBuilder.Entity<Dish>().HasKey(d => d.Id);
			//modelBuilder.Entity<Dish>().Property(d => d.Id).ValueGeneratedOnAdd();
			//modelBuilder.Entity<Dish>().HasData(
			//	new Dish() { Id = 1, Name = "Beef Mince", Description = "Healthy chilli con carne", Image = "https://help.rockcontent.com/en/how-to-solve-404-error", Price = 199.00, Rating = 1 },
			//	new Dish() { Id = 2, Name = "Beef Mince", Description = "Easy Japanese beef mince stir-fry", Image = "https://help.rockcontent.com/en/how-to-solve-404-error", Price = 199.00, Rating = 1 });
		}
	}
}
