namespace TFGInfotecAbstractions.Interfaces
{
	public interface IDishManager
	{
		Task<Dish> GetDishByIdAsync(int id);

		Task<IEnumerable<Dish>> GetDishesAsync();

		Task<IEnumerable<Dish>> GetDishesAsync(string search);

		Task<Dish> CreateDishAsync(Dish dish);

		Task<IEnumerable<DishReview>> GetReviewsForDishAsync(int dishId);

		Task<DishReview> AddReviewForDishAsync(DishReview dishReview);

		Task<Dish> UpdateDishAsync(Dish dish);
		
		Task<bool> DeleteDishAsync(int dishId);
	}
}