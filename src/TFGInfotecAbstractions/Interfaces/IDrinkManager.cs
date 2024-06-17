namespace TFGInfotecAbstractions.Interfaces
{
    public interface IDrinkManager
	{
		Task<Drink> GetDrinkByIdAsync(int id);

		Task<IEnumerable<Drink>> GetDrinksAsync();

		Task<IEnumerable<Drink>> GetDrinksAsync(string search);

		Task<Drink> CreateDrinkAsync(Drink drink);

		Task<IEnumerable<DrinkReview>> GetReviewsForDrinkAsync(int drinkId);

		Task<DrinkReview> AddReviewForDrinkAsync(DrinkReview drinkReview);

		Task<Drink> UpdateDrinkAsync(Drink drink);

		Task<bool> DeleteDrinkAsync(int drinkId);
	}
}
