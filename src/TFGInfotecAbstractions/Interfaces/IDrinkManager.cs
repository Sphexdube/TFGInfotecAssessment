﻿namespace TFGInfotecAbstractions.Interfaces
{
	public interface IDrinkManager
	{
		Task<Drink> GetDrinkByIdAsync(int id);

		Task<IEnumerable<Drink>> GetDrinksAsync();

		Task<IEnumerable<Drink>> GetDrinksAsync(string search);

		Task<Drink> CreateDrinkAsync(Drink drink);

		Task<List<DrinkReview>> GetReviewsForDrink(int drinkId);

		Task<DrinkReview> AddReviewForDrink(DrinkReview drinkReview);
	}
}
