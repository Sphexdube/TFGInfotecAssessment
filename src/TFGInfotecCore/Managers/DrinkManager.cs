namespace TFGInfotecCore.Managers
{
    public class DrinkManager : IDrinkManager
	{
		private readonly IDrinkService _drinkService;

		public DrinkManager(IDrinkService drinkService)
		{
			_drinkService = drinkService;
		}

		public Task<Drink> CreateDrinkAsync(Drink drink)
		{
			return _drinkService.CreateDrinkAsync(drink);
		}

		public Task<DrinkReview> AddReviewForDrinkAsync(DrinkReview drinkReview)
		{
			return _drinkService.AddReviewForDrink(drinkReview);
		}

		public Task<Drink> GetDrinkByIdAsync(int id)
		{
			return _drinkService.GetDrinkByIdAsync(id);
		}

		public Task<IEnumerable<Drink>> GetDrinksAsync()
		{
			return _drinkService.GetAllDrinksAsync();
		}

		public Task<IEnumerable<Drink>> GetDrinksAsync(string search)
		{
			return _drinkService.SearchDrinks(search);
		}

		public Task<IEnumerable<DrinkReview>> GetReviewsForDrinkAsync(int drinkId)
		{
			return _drinkService.GetReviewsForDrink(drinkId);
		}

		public Task<Drink> UpdateDrinkAsync(Drink drink)
		{
			return _drinkService.UpdateDrinkAsync(drink);
		}

		public Task<bool> DeleteDrinkAsync(int drinkId)
		{
			return _drinkService.DeleteDrinkAsync(drinkId);
		}
	}
}