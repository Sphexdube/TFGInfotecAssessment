using Microsoft.EntityFrameworkCore;
using TFGInfotecApi.DataSource;
using TFGInfotecApi.Interfaces;
using TFGInfotecApi.Models;

namespace TFGInfotecApi.Managers
{
	public class DishManager : IDishManager
	{
		private readonly DatabaseContext _dbContext;

		public DishManager(DatabaseContext dbContext)
		{
			_dbContext = dbContext;
		}

		/// <inheritdoc cref="IDishManager.CreateDishAsync"/>
		public async Task<Dish> CreateDishAsync(Dish dish, CancellationToken cancellationToken)
		{
			_dbContext.Dishes.Add(dish);
			await _dbContext.SaveChangesAsync(cancellationToken);
			return dish;
		}

		/// <inheritdoc cref="IDishManager.DeleteDishAsync"/>
		public async Task<bool> DeleteDishAsync(int id, CancellationToken cancellationToken)
		{
			var dish = await _dbContext.Dishes.FindAsync([id], cancellationToken);
			if (dish == null)
				return false;

			_dbContext.Dishes.Remove(dish);
			await _dbContext.SaveChangesAsync(cancellationToken);
			return true;
		}

		/// <inheritdoc cref="IDishManager.GetAllDishesAsync"/>
		public async Task<IEnumerable<Dish>> GetAllDishesAsync(CancellationToken cancellationToken)
		{
			return await _dbContext.Dishes.ToListAsync(cancellationToken); ;
		}

		/// <inheritdoc cref="IDishManager.GetDishByIdAsync"/>
		public async Task<Dish?> GetDishByIdAsync(int id, CancellationToken cancellationToken)
		{
			return await _dbContext.Dishes.FindAsync([id], cancellationToken);
		}

		/// <inheritdoc cref="IDishManager.UpdateDishAsync"/>
		public async Task<Dish?> UpdateDishAsync(Dish dish, CancellationToken cancellationToken)
		{
			var existingDish = await _dbContext.Dishes.FindAsync([dish.Id], cancellationToken);
			if (existingDish == null)
				return null;

			existingDish.Name = dish.Name;
			existingDish.Description = dish.Description;
			existingDish.Rating = dish.Rating;

			await _dbContext.SaveChangesAsync(cancellationToken);
			return existingDish;
		}
	}
}
