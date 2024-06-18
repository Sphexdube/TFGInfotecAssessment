namespace TFGInfotecAbstractions.Interfaces
{
	public interface IDrinkManager
	{
		/// <summary>
		/// Gets a list of drinks asynchronously.
		/// </summary>
		/// <returns>A list of drinks.</returns>
		Task<IEnumerable<Drink>> GetDrinksAsync();

		/// <summary>
		/// Gets a list of drinks based on a search term asynchronously.
		/// </summary>
		/// <param name="search">The search term.</param>
		/// <returns>A list of drinks matching the search term.</returns>
		Task<IEnumerable<Drink>> GetDrinksAsync(string search);

		/// <summary>
		/// Creates a new drink asynchronously.
		/// </summary>
		/// <param name="drink">The drink to create.</param>
		/// <returns>The created drink.</returns>
		Task<Drink> CreateDrinkAsync(Drink drink);

		/// <summary>
		/// Gets a drink by its ID asynchronously.
		/// </summary>
		/// <param name="drinkId">The ID of the drink.</param>
		/// <returns>The drink with the specified ID.</returns>
		Task<Drink> GetDrinkByIdAsync(int drinkId);

		/// <summary>
		/// Updates a drink asynchronously.
		/// </summary>
		/// <param name="drink">The drink to update.</param>
		/// <returns>The updated drink.</returns>
		Task<Drink> UpdateDrinkAsync(Drink drink);

		/// <summary>
		/// Deletes a drink asynchronously.
		/// </summary>
		/// <param name="drinkId">The ID of the drink to delete.</param>
		/// <returns>A boolean indicating whether the drink was deleted.</returns>
		Task<bool> DeleteDrinkAsync(int drinkId);

		/// <summary>
		/// Gets reviews for a specific drink asynchronously.
		/// </summary>
		/// <param name="drinkId">The ID of the drink.</param>
		/// <returns>A list of drink reviews.</returns>
		Task<IEnumerable<DrinkReview>> GetReviewsForDrinkAsync(int drinkId);

		/// <summary>
		/// Adds a review for a specific drink asynchronously.
		/// </summary>
		/// <param name="drinkReview">The drink review to add.</param>
		/// <returns>The added drink review.</returns>
		Task<DrinkReview> AddReviewForDrinkAsync(DrinkReview drinkReview);
	}
}