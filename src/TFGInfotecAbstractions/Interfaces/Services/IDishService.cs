namespace TFGInfotecAbstractions.Interfaces.Services
{
	public interface IDishService
	{
		Task<Dish> GetDishByIdAsync(int id, bool menuItems = true);

		Task<IEnumerable<Dish>> GetAllDishesAsync(bool menuItems);

		Task<IEnumerable<Dish>> SearchDishes(string search, bool menuItems);

		Task<Dish> CreateDishAsync(Dish dish);

		Task<List<DishReview>> GetReviewsForDish(int dishId);

		Task<DishReview> AddReviewForDish(DishReview dishReview);
	}
}
