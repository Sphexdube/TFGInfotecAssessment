namespace TFGInfotecCore.Managers
{
	public class DishManager : IDishManager
	{
		private readonly IDishService _dishService;

		public DishManager(IDishService dishService)
		{
			_dishService = dishService;
		}

		public Task<Dish> CreateDishAsync(Dish dish)
		{
			throw new NotImplementedException();
		}

		public async Task<DishReview> AddReviewForDish(DishReview dishReview)
		{
			return await _dishService.AddReviewForDish(dishReview);
		}

		public async Task<Dish> GetDishByIdAsync(int id)
		{
			return await _dishService.GetDishByIdAsync(id, true);
		}

		public async Task<IEnumerable<Dish>> GetDishesAsync()
		{
			return await _dishService.GetAllDishesAsync(true);
		}

		public async Task<IEnumerable<Dish>> GetDishesAsync(string search)
		{
			return await _dishService.SearchDishes(search, true);
		}

		public async Task<List<DishReview>> GetReviewsForDish(int dishId)
		{
			return await _dishService.GetReviewsForDish(dishId);
		}
	}
}
