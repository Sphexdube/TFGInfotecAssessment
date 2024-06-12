using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TFGInfotecAbstractions.Interfaces;
using TFGInfotecAbstractions.Models;
using TFGInfotecInfrastructure.DataSource;

namespace TFGInfotecCore.Managers
{
	/// <inheritdoc cref="IDrinkManager"/>
	public class DrinkManager : IDrinkManager
	{
		private readonly DatabaseContext _dbContext;
		private readonly ILogger<DrinkManager> _logger;

		public DrinkManager(DatabaseContext dbContext, ILogger<DrinkManager> logger)
		{
			_dbContext = dbContext;
			_logger = logger;
		}

		public async Task<Drink> CreateDrinkAsync(Drink drink, CancellationToken cancellationToken)
		{
			try
			{
				_dbContext.Drinks.Add(drink);
				await _dbContext.SaveChangesAsync(cancellationToken);
				return drink;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while creating a drink.");
				throw;
			}
		}

		public async Task<bool> DeleteDrinkAsync(int id, CancellationToken cancellationToken)
		{
			try
			{
				var drink = await _dbContext.Drinks.FindAsync(new object[] { id }, cancellationToken);
				if (drink == null)
					return false;

				_dbContext.Drinks.Remove(drink);
				await _dbContext.SaveChangesAsync(cancellationToken);
				return true;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"An error occurred while deleting the drink with ID: {id}.");
				throw;
			}
		}

		public async Task<IEnumerable<Drink>> GetAllDrinksAsync(CancellationToken cancellationToken)
		{
			try
			{
				return await _dbContext.Drinks.ToListAsync(cancellationToken);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while fetching all drinks.");
				throw;
			}
		}

		public async Task<Drink?> GetDrinkByIdAsync(int id, CancellationToken cancellationToken)
		{
			try
			{
				return await _dbContext.Drinks.FindAsync(new object[] { id }, cancellationToken);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"An error occurred while fetching the drink with ID: {id}.");
				throw;
			}
		}

		public async Task<Drink?> UpdateDrinkAsync(Drink drink, CancellationToken cancellationToken)
		{
			try
			{
				var existingDrink = await _dbContext.Drinks.FindAsync(new object[] { drink.Id }, cancellationToken);
				if (existingDrink == null)
					return null;

				existingDrink.Name = drink.Name;
				existingDrink.Description = drink.Description;
				existingDrink.Rating = drink.Rating;

				await _dbContext.SaveChangesAsync(cancellationToken);
				return existingDrink;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"An error occurred while updating the drink with ID: {drink.Id}.");
				throw;
			}
		}
	}
}

