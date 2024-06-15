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
			throw new NotImplementedException();
		}

		public async Task<DrinkReview> AddReviewForDrink(DrinkReview drinkReview)
		{
			return await _drinkService.AddReviewForDrink(drinkReview);
		}

		public async Task<Drink> GetDrinkByIdAsync(int id)
		{
			return await _drinkService.GetDrinkByIdAsync(id, true);
		}

		public async Task<IEnumerable<Drink>> GetDrinksAsync()
		{
			return await _drinkService.GetAllDrinksAsync(true);
		}

		public async Task<IEnumerable<Drink>> GetDrinksAsync(string search)
		{
			return await _drinkService.SearchDrinks(search, true);
		}

		public async Task<List<DrinkReview>> GetReviewsForDrink(int drinkId)
		{
			return await _drinkService.GetReviewsForDrink(drinkId);
		}
	}
}