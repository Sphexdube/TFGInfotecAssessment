namespace TFGInfotecAbstractions.Interfaces
{
    public interface IDrinkService
	{
		Task<Drink> GetDrinkByIdAsync(int id);

		Task<IEnumerable<Drink>> GetAllDrinksAsync();

		Task<IEnumerable<Drink>> SearchDrinks(string search);

		Task<Drink> CreateDrinkAsync(Drink drink);

		Task<IEnumerable<DrinkReview>> GetReviewsForDrink(int drinkId);

		Task<DrinkReview> AddReviewForDrink(DrinkReview drinkReview);

		Task<bool> DeleteDrinkAsync(int drinkId);

		Task<Drink> UpdateDrinkAsync(Drink drink);
	}
}
