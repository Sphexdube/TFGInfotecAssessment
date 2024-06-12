using Microsoft.EntityFrameworkCore;
using TFGInfotecApi.DataSource;
using TFGInfotecApi.Interfaces;
using TFGInfotecApi.Models;

namespace TFGInfotecApi.Managers
{
	/// <inheritdoc cref="IDrinkManager"/>
	public class DrinkManager : IDrinkManager
	{
		private readonly DatabaseContext _dbContext;

		public DrinkManager(DatabaseContext dbContext)
		{
			_dbContext = dbContext;
		}

		/// <inheritdoc cref="IDrinkManager.CreateDrinkAsync"/>
		public async Task<Drink> CreateDrinkAsync(Drink drink, CancellationToken cancellationToken)
		{
			_dbContext.Drinks.Add(drink);
			await _dbContext.SaveChangesAsync(cancellationToken);
			return drink;
		}

		/// <inheritdoc cref="IDrinkManager.DeleteDrinkAsync"/>
		public async Task<bool> DeleteDrinkAsync(int id, CancellationToken cancellationToken)
		{
			var drink = await _dbContext.Drinks.FindAsync([id], cancellationToken);
			if (drink == null)
				return false;

			_dbContext.Drinks.Remove(drink);
			await _dbContext.SaveChangesAsync(cancellationToken);
			return true;
		}

		/// <inheritdoc cref="IDrinkManager.GetAllDrinksAsync"/>
		public async Task<IEnumerable<Drink>> GetAllDrinksAsync(CancellationToken cancellationToken)
		{
			return await _dbContext.Drinks.ToListAsync(cancellationToken);
		}

		/// <inheritdoc cref="IDrinkManager.GetDrinkByIdAsync"/>
		public async Task<Drink?> GetDrinkByIdAsync(int id, CancellationToken cancellationToken)
		{
			return await _dbContext.Drinks.FindAsync([id], cancellationToken);
		}

		/// <inheritdoc cref="IDrinkManager.UpdateDrinkAsync"/>
		public async Task<Drink?> UpdateDrinkAsync(Drink drink, CancellationToken cancellationToken)
		{
			var existingDrink = await _dbContext.Drinks.FindAsync([drink.Id], cancellationToken);
			if (existingDrink == null)
				return null;

			existingDrink.Name = drink.Name;
			existingDrink.Description = drink.Description;
			existingDrink.Rating = drink.Rating;

			await _dbContext.SaveChangesAsync(cancellationToken);
			return existingDrink;
		}
	}
}

