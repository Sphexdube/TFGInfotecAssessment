using TFGInfotecApi.Models;

namespace TFGInfotecApi.Interfaces
{
	public interface IDrinkManager
	{
		/// <summary>
		/// Gets a list of all drinks.
		/// </summary>
		/// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
		/// <returns>A task that represents the asynchronous operation. The task result contains a list of drinks.</returns>
		Task<IEnumerable<Drink>> GetAllDrinksAsync(CancellationToken cancellationToken);

		/// <summary>
		/// Gets a specific drink by ID.
		/// </summary>
		/// <param name="id">The ID of the drink.</param>
		/// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
		/// <returns>A task that represents the asynchronous operation. The task result contains the drink with the specified ID.</returns>
		Task<Drink> GetDrinkByIdAsync(int id, CancellationToken cancellationToken);

		/// <summary>
		/// Creates a new drink.
		/// </summary>
		/// <param name="drink">The drink to create.</param>
		/// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
		/// <returns>A task that represents the asynchronous operation. The task result contains the created drink.</returns>
		Task<Drink> CreateDrinkAsync(Drink drink, CancellationToken cancellationToken);

		/// <summary>
		/// Updates an existing drink.
		/// </summary>
		/// <param name="drink">The updated drink.</param>
		/// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
		/// <returns>A task that represents the asynchronous operation. The task result contains the updated drink.</returns>
		Task<Drink> UpdateDrinkAsync(Drink drink, CancellationToken cancellationToken);

		/// <summary>
		/// Deletes a specific drink by ID.
		/// </summary>
		/// <param name="id">The ID of the drink to delete.</param>
		/// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
		/// <returns>A task that represents the asynchronous operation. The task result is true if the drink was successfully deleted, otherwise false.</returns>
		Task<bool> DeleteDrinkAsync(int id, CancellationToken cancellationToken);
	}
}
