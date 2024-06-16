namespace TFGInfotecAbstractions.Interfaces.Services
{
	public interface IDishService
	{
		Task<Dish> GetDishByIdAsync(int id);

		Task<IEnumerable<Dish>> GetAllDishesAsync();

		Task<IEnumerable<Dish>> SearchDishes(string search);

		Task<Dish> CreateDishAsync(Dish dish);

		Task<IEnumerable<DishReview>> GetReviewsForDishAsync(int dishId);

		Task<DishReview> AddReviewForDish(DishReview dishReview);

		Task<Dish> UpdateDishAsync(Dish dish);

		Task<bool> DeleteDishAsync(int dishId);
	}
}
