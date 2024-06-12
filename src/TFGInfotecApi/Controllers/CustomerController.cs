using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TFGInfotecAbstractions.Interfaces;
using TFGInfotecCore.Managers;

namespace TFGInfotecApi.Controllers
{
	/// <summary>
	/// Controller for customer interactions with dishes and drinks.
	/// </summary>
	[ApiController]
	[Route("api/customer")]
	public class CustomerController : Controller
	{
		private readonly CustomerManager _customerManager;
		private readonly IDrinkManager _drinkManager;
		private readonly IDishManager _dishManager;

		public CustomerController(CustomerManager customerManager, IDrinkManager drinkManager, IDishManager dishManager)
		{
			_customerManager = customerManager;
			_drinkManager = drinkManager;
			_dishManager = dishManager;
		}

		/// <summary>
		/// Searches for drinks by name or description.
		/// </summary>
		/// <param name="query">The search term.</param>
		/// <returns>A list of matching drinks.</returns>
		[HttpGet]
		[Route("drinks/search")]
		public async Task<IActionResult> SearchDrinks([FromQuery] string query)
		{
			var drinks = await _customerManager.SearchItems<IMenuItem>(query, "drink");
			return Ok(drinks);
		}

		/// <summary>
		/// Searches for dishes by name or description.
		/// </summary>
		/// <param name="query">The search term.</param>
		/// <returns>A list of matching dishes.</returns>
		[HttpGet]
		[Route("dishes/search")]
		public async Task<IActionResult> SearchDishes([FromQuery] string query)
		{
			var dishes = await _customerManager.SearchItems<IMenuItem>(query, "dishes");
			return Ok(dishes);
		}

		/// <summary>
		/// Gets the details of a specific drink by Id.
		/// </summary>
		/// <param name="id">The ID of the drink.</param>
		/// <returns>The details of the drink.</returns>
		[HttpGet]
		[Route("drinks/{id:int}")]
		public async Task<IActionResult> GetDrinkById([FromRoute][Required] int id, CancellationToken cancellationToken)
		{
			var drink = await _drinkManager.GetDrinkByIdAsync(id, cancellationToken);
			if (drink == null)
			{
				return NotFound();
			}
			return Ok(drink);
		}

		/// <summary>
		/// Gets the details of a specific dish by Id.
		/// </summary>
		/// <param name="id">The ID of the dish.</param>
		/// <returns>The details of the dish.</returns>
		[HttpGet]
		[Route("dishes/{id:int}")]
		public async Task<IActionResult> GetDishById([FromRoute][Required] int id, CancellationToken cancellationToken)
		{
			var dish = await _dishManager.GetDishByIdAsync(id, cancellationToken);
			if (dish == null)
			{
				return NotFound();
			}
			return Ok(dish);
		}

		/// <summary>
		/// Rates a specific drink by Id.
		/// </summary>
		/// <param name="id">The ID of the drink.</param>
		/// <param name="rating">The rating value (1 to 5).</param>
		/// <returns>An IActionResult.</returns>
		[HttpPost]
		[Route("drinks/rate/{drinkId:int}")]
		public async Task<IActionResult> RateDrink([FromRoute][Required] int drinkId, [FromBody][Range(1, 5)] int rating)
		{
			var success = await _customerManager.UpdateItemRating<IMenuItem>(drinkId, rating, "drinks");
			if (success)
			{
				return NoContent();
			}
			else
			{
				return NotFound();
			}
		}

		/// <summary>
		/// Rates a specific dish by Id.
		/// </summary>
		/// <param name="id">The ID of the dish.</param>
		/// <param name="rating">The rating value (1 to 5).</param>
		/// <returns>An IActionResult.</returns>
		[HttpPost]
		[Route("dishes/rate/{dishId:int}")]
		public async Task<IActionResult> RateDish([FromRoute][Required] int dishId, [FromBody][Range(1, 5)] int rating)
		{
			var success = await _customerManager.UpdateItemRating<IMenuItem>(dishId, rating, "dish");
			if (success)
			{
				return NoContent();
			}
			else
			{
				return NotFound();
			}
		}
	}
}
