﻿namespace TFGInfotecCore.Managers
{
	public class DrinkService : IDrinkService
	{
		private readonly IRepository<Drink> _drinkRepository;
		private readonly IRepository<DrinkReview> _drinkRatingRepository;

		public DrinkService(
			IRepository<Drink> drinkRepository,
			IRepository<DrinkReview> drinkRatingRepository)
		{
			_drinkRepository = drinkRepository;
			_drinkRatingRepository = drinkRatingRepository;
		}

		public async Task<Drink> CreateDrinkAsync(Drink drink)
		{
			return await _drinkRepository.Update(drink);
		}

		public async Task<DrinkReview> AddReviewForDrink(DrinkReview drinkReview)
		{
			drinkReview.Rating /= 5;
			drinkReview = await _drinkRatingRepository.Add(drinkReview);

			Expression<Func<DrinkReview, bool>> filterExpression = e => e.DrinkId == drinkReview.DrinkId;
			IQueryable<DrinkReview> filter(IQueryable<DrinkReview> e) => e.Where(filterExpression);
			List<DrinkReview> drinkReviews = await _drinkRatingRepository.Get(filter);

			Drink drink = await _drinkRepository.GetByID(drinkReview.DrinkId);
			drink.Rating = drinkReviews.Average(e => e.Rating);
			drink = await _drinkRepository.Update(drink);

			return drinkReview;
		}

		public async Task<IEnumerable<Drink>> GetAllDrinksAsync(bool menuItems)
		{
			Expression<Func<Drink, bool>> filterExpression = e => e.IsMenuItem;

			IIncludableQueryable<Drink, object> include(IQueryable<Drink> e) =>
				e.Include(e => e.Image);

			IQueryable<Drink> filter(IQueryable<Drink> e) => e.Where(filterExpression);

			List<Drink> drinks = await _drinkRepository.Get(filter, null, include);
			return drinks;
		}

		public async Task<Drink> GetDrinkByIdAsync(int drinkId, bool menuItems = true)
		{
			Expression<Func<Drink, bool>> filterExpression = e => e.Id == drinkId;

			IQueryable<Drink> filter(IQueryable<Drink> e) => e.Where(filterExpression);
			IIncludableQueryable<Drink, object> include(IQueryable<Drink> e) =>
				e.Include(e => e.Image);

			Drink drink = await _drinkRepository.GetOne(filter, include);
			return drink;
		}

		public async Task<List<DrinkReview>> GetReviewsForDrink(int drinkId)
		{
			Expression<Func<DrinkReview, bool>> filterExpression = e => e.DrinkId == drinkId;

			IQueryable<DrinkReview> filter(IQueryable<DrinkReview> e) => e.Where(filterExpression);
			IIncludableQueryable<DrinkReview, object> include(IQueryable<DrinkReview> e) => e.Include(e => e.Customer).ThenInclude(e => e!.User)!;

			List<DrinkReview> drinkReviews = await _drinkRatingRepository.Get(filter: filter, include: include);
			return drinkReviews;
		}

		public async Task<IEnumerable<Drink>> SearchDrinks(string search, bool menuItems)
		{
			if (string.IsNullOrEmpty(search)) return await GetAllDrinks();
			Expression<Func<Drink, bool>> filterExpression = e => e.Name.Contains(search) && e.IsMenuItem;

			IIncludableQueryable<Drink, object> include(IQueryable<Drink> e) =>
				e.Include(e => e.Image);

			IQueryable<Drink> filter(IQueryable<Drink> e) => e.Where(filterExpression);
			List<Drink> drinks = await _drinkRepository.Get(filter, null, include);
			return drinks;
		}

		private async Task<IEnumerable<Drink>> GetAllDrinks()
		{
			IIncludableQueryable<Drink, object> include(IQueryable<Drink> e) =>
				e.Include(e => e.Image);

			List<Drink> drinks = await _drinkRepository.Get(null, null, include);
			return drinks;
		}
	}
}