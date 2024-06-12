using Microsoft.EntityFrameworkCore;
using TFGInfotecAbstractions.Interfaces;
using TFGInfotecAbstractions.Models;
using TFGInfotecInfrastructure.DataSource;

namespace TFGInfotecCore.Managers
{
	public class CustomerManager
	{
		private readonly DatabaseContext _dbContext;

		public CustomerManager(DatabaseContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<List<T>> SearchItems<T>(string query, string type) where T : class, IMenuItem
		{
			var dbSet = GetDbSet<T>(type);
			if (dbSet == null)
				return null;

			return await dbSet
				.Where(i => i.Name.Contains(query) || i.Description.Contains(query))
				.ToListAsync();
		}

		public async Task<T> GetItemById<T>(int id, string type) where T : class
		{
			var dbSet = GetDbSet<T>(type);
			return dbSet == null ? null : await dbSet.FindAsync(id);
		}

		public async Task<bool> UpdateItemRating<T>(int id, int rating, string type) where T : class, IMenuItem
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
