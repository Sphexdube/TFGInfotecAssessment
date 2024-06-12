using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TFGInfotecAbstractions.Interfaces;
using TFGInfotecAbstractions.Models;
using TFGInfotecInfrastructure.DataSource;

namespace TFGInfotecApi.Managers
{
	public class DishManager : IDishManager
	{
		private readonly DatabaseContext _dbContext;
		private readonly ILogger<DishManager> _logger;

		public DishManager(DatabaseContext dbContext, ILogger<DishManager> logger)
		{
			_dbContext = dbContext;
			_logger = logger;
		}

		public async Task<Dish> CreateDishAsync(Dish dish, CancellationToken cancellationToken)
		{
			try
			{
				_dbContext.Dishes.Add(dish);
				await _dbContext.SaveChangesAsync(cancellationToken);
				return dish;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while creating a dish.");
				throw;
			}
		}

		public async Task<bool> DeleteDishAsync(int id, CancellationToken cancellationToken)
		{
			try
			{
				var dish = await _dbContext.Dishes.FindAsync(new object[] { id }, cancellationToken);
				if (dish == null)
					return false;

				_dbContext.Dishes.Remove(dish);
				await _dbContext.SaveChangesAsync(cancellationToken);
				return true;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"An error occurred while deleting the dish with ID: {id}.");
				throw;
			}
		}

		public async Task<IEnumerable<Dish>> GetAllDishesAsync(CancellationToken cancellationToken)
		{
			try
			{
				return await _dbContext.Dishes.ToListAsync(cancellationToken);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while fetching all dishes.");
				throw;
			}
		}

		public async Task<Dish?> GetDishByIdAsync(int id, CancellationToken cancellationToken)
		{
			try
			{
				return await _dbContext.Dishes.FindAsync(new object[] { id }, cancellationToken);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"An error occurred while fetching the dish with ID: {id}.");
				throw;
			}
		}

		public async Task<Dish?> UpdateDishAsync(Dish dish, CancellationToken cancellationToken)
		{
			try
			{
				var existingDish = await _dbContext.Dishes.FindAsync(new object[] { dish.Id }, cancellationToken);
				if (existingDish == null)
					return null;

				existingDish.Name = dish.Name;
				existingDish.Description = dish.Description;
				existingDish.Rating = dish.Rating;

				await _dbContext.SaveChangesAsync(cancellationToken);
				return existingDish;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"An error occurred while updating the dish with ID: {dish.Id}.");
				throw;
			}
		}
	}
}
