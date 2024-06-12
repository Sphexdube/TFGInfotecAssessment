using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using TFGInfotecAbstractions.Interfaces;
using TFGInfotecAbstractions.Models;

namespace TFGInfotecApi.Controllers
{
	/// <summary>
	/// Controller for managing dishes.
	/// </summary>
	[ApiController]
	[Route("dishes")]
	public class DishesController : ControllerBase
	{
		private readonly IDishManager _dishManager;

		public DishesController(IDishManager dishManager)
		{
			_dishManager = dishManager;
		}

		/// <summary>
		/// Gets a list of all dishes.
		/// </summary>
		/// <returns>A list of dish names.</returns>
		[HttpGet]
		[Route("products")]
		public async Task<IActionResult> GetAllDishesAsync(CancellationToken cancellationToken)
		{
			var result = await _dishManager.GetAllDishesAsync(cancellationToken);

			return Ok(result);
		}

		// <summary>
		/// Gets a specific dish by Id.
		/// </summary>
		/// <param name="productId">The ID of the dish.</param>
		/// <returns>The name of the dish.</returns>
		[HttpGet]
		[Route("product/{productId:int}")]
		public async Task<ActionResult<Dish>> GetDishByIdAsync(
			[FromRoute][Required] int productId,
			CancellationToken cancellationToken)
		{
			var result = await _dishManager.GetDishByIdAsync(productId, cancellationToken);

			if (result == null)
			{
				return NotFound();
			}

			return Ok(result);
		}

		/// <summary>
		/// Creates a new dish.
		/// </summary>
		/// <param name="request">The dish to create.</param>
		[HttpPost]
		[Route("products")]
		public async Task<IActionResult> CreateDishAsync(
			[FromBody][BindRequired] Dish dish,
			CancellationToken cancellationToken)
		{
			var createdDish = await _dishManager.CreateDishAsync(dish, cancellationToken);
			return CreatedAtAction(nameof(GetDishByIdAsync), new { productId = createdDish.Id }, createdDish);
		}

		/// <summary>
		/// Updates an existing dish.
		/// </summary>
		/// <param name="productId">The ID of the dish to delete.</param>
		/// <param name="request">The updated dish.</param>
		[HttpPut("product/{productId:int}")]
		public async Task<IActionResult> UpdateDrinkAsync(
			[FromRoute][Required] int productId,
			[FromBody][BindRequired] Dish dish,
			CancellationToken cancellationToken)
		{
			if (productId != dish.Id)
			{
				return BadRequest("ProductId in URL does not match the Id in the request body.");
			}

			var updatedDish = await _dishManager.UpdateDishAsync(dish, cancellationToken);

			if (updatedDish == null)
			{
				return NotFound();
			}

			return NoContent();
		}

		/// <summary>
		/// Deletes a specific dish by ID.
		/// </summary>
		/// <param name="productId">The ID of the dish to delete.</param>
		[HttpDelete("product/{productId:int}")]
		public async Task<IActionResult> DeleteDishAsync(
			[FromRoute][Required] int productId,
			CancellationToken cancellationToken)
		{
			var result = await _dishManager.DeleteDishAsync(productId, cancellationToken);

			if (!result)
			{
				return NotFound();
			}

			return NoContent();
		}
	}
}
