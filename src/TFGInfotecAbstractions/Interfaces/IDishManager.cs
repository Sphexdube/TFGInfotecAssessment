namespace TFGInfotecAbstractions.Interfaces
{
	public interface IDishManager
	{
		Task<Dish> GetDishByIdAsync(int id);

		Task<IEnumerable<Dish>> GetDishesAsync();

		Task<IEnumerable<Dish>> GetDishesAsync(string search);

		Task<Dish> CreateDishAsync(Dish dish);

		Task<List<DishReview>> GetReviewsForDish(int dishId);

		Task<DishReview> AddReviewForDish(DishReview dishReview);
	}
}