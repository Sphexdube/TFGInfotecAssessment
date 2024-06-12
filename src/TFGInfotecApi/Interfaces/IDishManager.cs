using TFGInfotecApi.Models;

namespace TFGInfotecApi.Interfaces
{
	public interface IDishManager
	{
		/// <summary>
		/// Gets a list of all Dishes.
		/// </summary>
		/// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
		/// <returns>A task that represents the asynchronous operation. The task result contains a list of Dishes.</returns>
		Task<IEnumerable<Dish>> GetAllDishesAsync(CancellationToken cancellationToken);

		/// <summary>
		/// Gets a specific dish by ID.
		/// </summary>
		/// <param name="id">The ID of the dish.</param>
		/// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
		/// <returns>A task that represents the asynchronous operation. The task result contains the dish with the specified ID.</returns>
		Task<Dish> GetDishByIdAsync(int id, CancellationToken cancellationToken);

		/// <summary>
		/// Creates a new Dish.
		/// </summary>
		/// <param name="Dish">The Dish to create.</param>
		/// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
		/// <returns>A task that represents the asynchronous operation. The task result contains the created dish.</returns>
		Task<Dish> CreateDishAsync(Dish dish, CancellationToken cancellationToken);

		/// <summary>
		/// Updates an existing Dish.
		/// </summary>
		/// <param name="Dish">The updated dish.</param>
		/// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
		/// <returns>A task that represents the asynchronous operation. The task result contains the updated dish.</returns>
		Task<Dish> UpdateDishAsync(Dish dish, CancellationToken cancellationToken);

		/// <summary>
		/// Deletes a specific dish by ID.
		/// </summary>
		/// <param name="id">The ID of the dish to delete.</param>
		/// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
		/// <returns>A task that represents the asynchronous operation. The task result is true if the dish was successfully deleted, otherwise false.</returns>
		Task<bool> DeleteDishAsync(int id, CancellationToken cancellationToken);
	}
}
