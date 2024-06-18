namespace TFGInfotecAbstractions.Interfaces
{
	public interface IDishManager
	{
		/// <summary>
		/// Gets a list of dishes asynchronously.
		/// </summary>
		/// <returns>A list of dishes.</returns>
		Task<IEnumerable<Dish>> GetDishesAsync();

		/// <summary>
		/// Gets a list of dishes based on a search term asynchronously.
		/// </summary>
		/// <param name="search">The search term.</param>
		/// <returns>A list of dishes matching the search term.</returns>
		Task<IEnumerable<Dish>> GetDishesAsync(string search);

		/// <summary>
		/// Creates a new dish asynchronously.
		/// </summary>
		/// <param name="dish">The dish to create.</param>
		/// <returns>The created dish.</returns>
		Task<Dish> CreateDishAsync(Dish dish);

		/// <summary>
		/// Gets a dish by its ID asynchronously.
		/// </summary>
		/// <param name="dishId">The ID of the dish.</param>
		/// <returns>The dish with the specified ID.</returns>
		Task<Dish> GetDishByIdAsync(int dishId);

		/// <summary>
		/// Updates a dish asynchronously.
		/// </summary>
		/// <param name="dish">The dish to update.</param>
		/// <returns>The updated dish.</returns>
		Task<Dish> UpdateDishAsync(Dish dish);

		/// <summary>
		/// Deletes a dish asynchronously.
		/// </summary>
		/// <param name="dishId">The ID of the dish to delete.</param>
		/// <returns>A boolean indicating whether the dish was deleted.</returns>
		Task<bool> DeleteDishAsync(int dishId);

		/// <summary>
		/// Gets reviews for a specific dish asynchronously.
		/// </summary>
		/// <param name="dishId">The ID of the dish.</param>
		/// <returns>A list of dish reviews.</returns>
		Task<IEnumerable<DishReview>> GetReviewsForDishAsync(int dishId);

		/// <summary>
		/// Adds a review for a specific dish asynchronously.
		/// </summary>
		/// <param name="dishReview">The dish review to add.</param>
		/// <returns>The added dish review.</returns>
		Task<DishReview> AddReviewForDishAsync(DishReview dishReview);
	}

}