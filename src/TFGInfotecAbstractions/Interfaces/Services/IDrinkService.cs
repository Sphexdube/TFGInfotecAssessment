namespace TFGInfotecAbstractions.Interfaces
{
	public interface IDrinkService
	{
		Task<Drink> GetDrinkByIdAsync(int id, bool menuItems = true);

		Task<IEnumerable<Drink>> GetAllDrinksAsync(bool menuItems);

		Task<IEnumerable<Drink>> SearchDrinks(string search, bool menuItems);

		Task<Drink> CreateDrinkAsync(Drink drink);

		Task<List<DrinkReview>> GetReviewsForDrink(int drinkId);

		Task<DrinkReview> AddReviewForDrink(DrinkReview drinkReview);
	}
}
