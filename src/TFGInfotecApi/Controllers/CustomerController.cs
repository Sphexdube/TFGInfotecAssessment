using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TFGInfotecApi.Interfaces;
using TFGInfotecApi.Managers;

namespace TFGInfotecApi.Controllers
{
	/// <summary>
	/// Controller for customer interactions with dishes and drinks.
	/// </summary>
	[ApiController]
	[Route("customer")]
	public class CustomerController : Controller
	{
		private readonly CustomerManager _customerManager;

		public CustomerController(CustomerManager customerManager)
		{
			_customerManager = customerManager;
		}

		/// <summary>
		/// Searches for dishes and drinks by name or description.
		/// </summary>
		/// <param name="query">The search term.</param>
		/// <returns>A list of matching dishes and drinks.</returns>
		[HttpGet]
		[Route("products/search")]
		public async Task<IActionResult> SearchItems([FromQuery] string query, string type)
		{
			if (type == "drink" || type == "dish")
			{
				var items = await _customerManager.SearchItems<IMenuItem>(query, type);
				return Ok(items);
			}
			else
			{
				return BadRequest("Invalid type specified. Use 'drink' or 'dish'.");
			}
		}

		// <summary>
		/// Gets the details of a specific drink by Id.
		/// </summary>
		/// <param name="id">The ID of the drink.</param>
		/// <returns>The details of the drink.</returns>
		[HttpGet]
		[Route("drink/{productId:int}")]
		public string GetDrink([FromRoute][Required] int productId)
		{
			return "value";
		}

		// <summary>
		/// Gets the details of a specific dish by Id.
		/// </summary>
		/// <param name="id">The ID of the dish.</param>
		/// <returns>The details of the dish.</returns>
		[HttpGet]
		[Route("product/{productId:int}")]
		public async Task<IActionResult> GetItem([FromRoute][Required] int productId, string type)
		{
			if (type == "drink" || type == "dish")
			{
				var item = await _customerManager.GetItemById<IMenuItem>(productId, type);
				if (item == null)
				{
					return NotFound();
				}
				return Ok(item);
			}
			else
			{
				return BadRequest("Invalid type specified. Use 'drink' or 'dish'.");
			}
		}

		/// <summary>
		/// Rates a specific dish or drink by Id.
		/// </summary>
		/// <param name="id">The ID of the dish or drink.</param>
		/// <param name="rating">The rating value (1 to 5).</param>
		/// <returns>An IActionResult.</returns>
		[HttpPost("rate/product/{productId:int}")]
		public async Task<IActionResult> RateDishOrDink([FromRoute][Required] int productId, string type, [FromBody][Range(1, 5)] int rating)
		{
			if (type == "drink" || type == "dish")
			{
				var success = await _customerManager.UpdateItemRating<IMenuItem>(productId, rating, type);
				if (success)
				{
					return NoContent();
				}
				else
				{
					return NotFound();
				}
			}
			else
			{
				return BadRequest("Invalid type specified. Use 'drink' or 'dish'.");
			}
		}
	}
}
