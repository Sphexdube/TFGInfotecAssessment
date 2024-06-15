﻿using TFGInfotecAbstractions.Models;

namespace TFGInfotecCore.Managers
{
	public class DishService : IDishService
	{
		private readonly IRepository<Dish> _dishRepository;
		private readonly IRepository<DishReview> _dishRatingRepository;

		public DishService(
			IRepository<Dish> dishRepository, 
			IRepository<DishReview> dishRatingRepository)
		{
			_dishRepository = dishRepository;
			_dishRatingRepository = dishRatingRepository;
		}

		public async Task<DishReview> AddReviewForDish(DishReview dishReview)
		{
			dishReview.Rating /= 5;
			dishReview = await _dishRatingRepository.Add(dishReview);

			Expression<Func<DishReview, bool>> filterExpression = e => e.DishId == dishReview.DishId;
			IQueryable<DishReview> filter(IQueryable<DishReview> e) => e.Where(filterExpression);
			List<DishReview> dishReviews = await _dishRatingRepository.Get(filter);

			Dish dish = await _dishRepository.GetByID(dishReview.DishId);
			dish.Rating = dishReviews.Average(e => e.Rating);
			dish = await _dishRepository.Update(dish);

			return dishReview;
		}

		public async Task<Dish> CreateDishAsync(Dish dish)
		{
			return await _dishRepository.Update(dish);
		}

		public async Task<IEnumerable<Dish>> GetAllDishesAsync(bool menuItems)
		{
			Expression<Func<Dish, bool>> filterExpression = e => e.IsMenuItem;

			IIncludableQueryable<Dish, object> include(IQueryable<Dish> e) =>
				e.Include(e => e.Image);

			IQueryable<Dish> filter(IQueryable<Dish> e) => e.Where(filterExpression);

			List<Dish> dishes = await _dishRepository.Get(filter, null, include);
			return dishes;
		}


		public async Task<Dish> GetDishByIdAsync(int dishId, bool menuItems = true)
		{
			Expression<Func<Dish, bool>> filterExpression = e => e.Id == dishId;

			IQueryable<Dish> filter(IQueryable<Dish> e) => e.Where(filterExpression);
			IIncludableQueryable<Dish, object> include(IQueryable<Dish> e) =>
				e.Include(e => e.Image);

			Dish dish = await _dishRepository.GetOne(filter, include);
			return dish;
		}

		public async Task<List<DishReview>> GetReviewsForDish(int dishId)
		{
			Expression<Func<DishReview, bool>> filterExpression = e => e.DishId == dishId;

			IQueryable<DishReview> filter(IQueryable<DishReview> e) => e.Where(filterExpression);
			IIncludableQueryable<DishReview, object> include(IQueryable<DishReview> e) => e.Include(e => e.Customer).ThenInclude(e => e!.User)!;

			List<DishReview> dishReview = await _dishRatingRepository.Get(filter: filter, include: include);
			return dishReview;
		}

		public async Task<IEnumerable<Dish>> SearchDishes(string search, bool menuItems)
		{
			if (string.IsNullOrEmpty(search)) return await GetAllDishes();
			Expression<Func<Dish, bool>> filterExpression = e => e.Name.Contains(search) && e.IsMenuItem;

			IIncludableQueryable<Dish, object> include(IQueryable<Dish> e) =>
				e.Include(e => e.Image);

			IQueryable<Dish> filter(IQueryable<Dish> e) => e.Where(filterExpression);
			List<Dish> dishes = await _dishRepository.Get(filter, null, include);
			return dishes;
		}

		private async Task<IEnumerable<Dish>> GetAllDishes()
		{
			IIncludableQueryable<Dish, object> include(IQueryable<Dish> e) =>
			e.Include(e => e.Image);

			List<Dish> recipes = await _dishRepository.Get(null, null, include);
			return recipes;
		}
	}
}