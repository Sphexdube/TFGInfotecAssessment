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
			return _dishService.CreateDishAsync(dish);
		}

		public Task<DishReview> AddReviewForDishAsync(DishReview dishReview)
		{
			return _dishService.AddReviewForDish(dishReview);
		}

		public Task<Dish> GetDishByIdAsync(int id)
		{
			return _dishService.GetDishByIdAsync(id);
		}

		public Task<IEnumerable<Dish>> GetDishesAsync()
		{
			return _dishService.GetAllDishesAsync();
		}

		public Task<IEnumerable<Dish>> GetDishesAsync(string search)
		{
			return _dishService.SearchDishes(search);
		}

		public Task<IEnumerable<DishReview>> GetReviewsForDishAsync(int dishId)
		{
			return _dishService.GetReviewsForDishAsync(dishId);
		}

		public Task<Dish> UpdateDishAsync(Dish dish)
		{
			return _dishService.UpdateDishAsync(dish);
		}

		public Task<bool> DeleteDishAsync(int dishId)
		{
			return _dishService.DeleteDishAsync(dishId);
		}
	}
}
