using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using TFGInfotecAbstractions.Interfaces;
using TFGInfotecAbstractions.Models;

namespace TFGInfotecApi.Controllers
{
	// <summary>
	/// Controller for managing drinks.
	/// </summary>
	[ApiController]
	[Route("drinks")]
	public class DrinksController : Controller
	{
		private readonly IDrinkManager _drinkManager;

		public DrinksController(IDrinkManager drinkManager)
		{
			_drinkManager = drinkManager;
		}

		/// <summary>
		/// Gets a list of all drinks.
		/// </summary>
		/// <returns>A list of drink names.</returns>
		[HttpGet]
		[Route("products")]
		public async Task<IActionResult> GetAllDrinksAsync(CancellationToken cancellationToken)
		{
			var result = await _drinkManager.GetAllDrinksAsync(cancellationToken);

			return Ok(result);
		}

		// <summary>
		/// Gets a specific drink by Id.
		/// </summary>
		/// <param name="productId">The ID of the drink.</param>
		/// <returns>The name of the dish.</returns>
		[HttpGet]
		[Route("product/{productId:int}")]
		public async Task<ActionResult<Drink>> GetDrinkByIdAsync(
			[FromRoute][Required] int productId,
			CancellationToken cancellationToken)
		{
			var result = await _drinkManager.GetDrinkByIdAsync(productId, cancellationToken);

			if (result == null)
			{
				return NotFound();
			}

			return Ok(result);
		}

		/// <summary>
		/// Creates a new drink.
		/// </summary>
		/// <param name="request">The drink to create.</param>
		[HttpPost]
		[Route("product")]
		public async Task<IActionResult> CreateDrinkAsync(
			[FromBody] Drink drink,
			CancellationToken cancellationToken)
		{
			var createdDrink = await _drinkManager.CreateDrinkAsync(drink, cancellationToken);
			return CreatedAtAction(nameof(GetDrinkByIdAsync), new { productId = createdDrink.Id }, createdDrink);
		}

		/// <summary>
		/// Updates an existing drink.
		/// </summary>
		/// <param name="productId">The ID of the drink to delete.</param>
		/// <param name="request">The updated drink.</param>
		[HttpPut("product/{productId:int}")]
		public async Task<IActionResult> UpdateDrinkAsync(
			[FromRoute][Required] int productId,
			[FromBody][BindRequired] Drink drink,
			CancellationToken cancellationToken)
		{
			if (productId != drink.Id)
			{
				return BadRequest("ProductId in URL does not match the Id in the request body.");
			}

			var updatedDrink = await _drinkManager.UpdateDrinkAsync(drink, cancellationToken);

			if (updatedDrink == null)
			{
				return NotFound();
			}

			return NoContent();
		}

		/// <summary>
		/// Deletes a specific drink by ID.
		/// </summary>
		/// <param name="productId">The ID of the drink to delete.</param>
		[HttpDelete("product/{productId:int}")]
		public async Task<IActionResult> DeleteDrinkAsync(
			[FromRoute][Required] int productId,
			CancellationToken cancellationToken)
		{
			var result = await _drinkManager.DeleteDrinkAsync(productId, cancellationToken);

			if (!result)
			{
				return NotFound();
			}

			return NoContent();
		}
	}
}
