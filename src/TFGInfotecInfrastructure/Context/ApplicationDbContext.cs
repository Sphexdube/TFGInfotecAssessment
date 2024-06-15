﻿namespace TFGInfotecInfrastructure.Context
{
	public class ApplicationDbContext : DbContext
    {
		public DbSet<User>? User { get; set; }
		public DbSet<Drink>? Drinks { get; set; }
		public DbSet<Dish>? Dishes { get; set; }
		public DbSet<Account>? Account { get; set; }
		public DbSet<Customer>? Customer { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
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

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Account>().ToTable("Account");

			modelBuilder.Entity<User>()
				.HasOne(u => u.Account)
				.WithOne()
				.HasForeignKey<User>(u => u.AccountId)
				.OnDelete(DeleteBehavior.Cascade);
			modelBuilder.Entity<Customer>()
				.HasOne(b => b.User)
				.WithOne()
				.HasForeignKey<Customer>(b => b.UserId)
				.OnDelete(DeleteBehavior.Cascade);
			modelBuilder.Entity<Account>()
				.HasIndex(a => a.Email)
				.IsUnique();

			modelBuilder.Entity<Account>()
			.HasIndex(e => e.Email)
			.IsUnique();
		}
    }
}
