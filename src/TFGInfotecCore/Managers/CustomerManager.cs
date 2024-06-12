using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TFGInfotecAbstractions.Interfaces;
using TFGInfotecAbstractions.Models;
using TFGInfotecInfrastructure.DataSource;

namespace TFGInfotecCore.Managers
{
	public class CustomerManager
	{
		private readonly DatabaseContext _dbContext;
		private readonly ILogger<CustomerManager> _logger;

		public CustomerManager(DatabaseContext dbContext, ILogger<CustomerManager> logger)
		{
			_dbContext = dbContext;
			_logger = logger;
		}

		public async Task<List<T>> SearchItems<T>(string query, string type) where T : class, IMenuItem
		{
			try
			{
				var dbSet = GetDbSet<T>(type);
				if (dbSet == null)
					return null;

				return await dbSet
					.Where(i => i.Name.Contains(query) || i.Description.Contains(query))
					.ToListAsync();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while searching items.");
				throw; // Re-throw the exception for handling at a higher level.
			}
		}

		public async Task<T> GetItemById<T>(int id, string type) where T : class
		{
			try
			{
				var dbSet = GetDbSet<T>(type);
				return dbSet == null ? null : await dbSet.FindAsync(id);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"An error occurred while getting item by ID: {id}.");
				throw;
			}
		}

		public async Task<bool> UpdateItemRating<T>(int id, int rating, string type) where T : class, IMenuItem
		{
			try
			{
				var dbSet = GetDbSet<T>(type);
				if (dbSet == null)
					return false;

				var item = await dbSet.FindAsync(id);
				if (item != null)
				{
					item.Rating = rating;
					_dbContext.Entry(item).State = EntityState.Modified;
					await _dbContext.SaveChangesAsync();
					return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"An error occurred while updating item rating for ID: {id}.");
				throw;
			}
		}

		private DbSet<T> GetDbSet<T>(string type) where T : class
		{
			return type.ToLower() switch
			{
				"drink" => _dbContext.Set<Drink>() as DbSet<T>,
				"dish" => _dbContext.Set<Dish>() as DbSet<T>,
				_ => null
			};
		}
	}
}
