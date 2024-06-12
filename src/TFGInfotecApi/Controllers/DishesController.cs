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
	[Route("api/dishes")]
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
		public async Task<IActionResult> GetAllDishesAsync(CancellationToken cancellationToken)
		{
			var result = await _dishManager.GetAllDishesAsync(cancellationToken);
			return Ok(result);
		}

		/// <summary>
		/// Gets a specific dish by Id.
		/// </summary>
		/// <param name="dishId">The ID of the dish.</param>
		/// <returns>The name of the dish.</returns>
		[HttpGet("{dishId:int}")]
		public async Task<ActionResult<Dish>> GetDishByIdAsync([FromRoute][Required] int dishId, CancellationToken cancellationToken)
		{
			var result = await _dishManager.GetDishByIdAsync(dishId, cancellationToken);
			if (result == null)
			{
				return NotFound();
			}
			return Ok(result);
		}

		/// <summary>
		/// Creates a new dish.
		/// </summary>
		/// <param name="dish">The dish to create.</param>
		[HttpPost]
		public async Task<IActionResult> CreateDishAsync([FromBody][BindRequired] Dish dish, CancellationToken cancellationToken)
		{
			var createdDish = await _dishManager.CreateDishAsync(dish, cancellationToken);
			return CreatedAtAction(nameof(GetDishByIdAsync), new { dishId = createdDish.Id }, createdDish);
		}

		/// <summary>
		/// Updates an existing dish.
		/// </summary>
		/// <param name="dishId">The ID of the dish to update.</param>
		/// <param name="dish">The updated dish.</param>
		[HttpPut("{dishId:int}")]
		public async Task<IActionResult> UpdateDishAsync([FromRoute][Required] int dishId, [FromBody][BindRequired] Dish dish, CancellationToken cancellationToken)
		{
			if (dishId != dish.Id)
			{
				return BadRequest("DishId in URL does not match the Id in the request body.");
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
		/// <param name="dishId">The ID of the dish to delete.</param>
		[HttpDelete("{dishId:int}")]
		public async Task<IActionResult> DeleteDishAsync([FromRoute][Required] int dishId, CancellationToken cancellationToken)
		{
			var result = await _dishManager.DeleteDishAsync(dishId, cancellationToken);
			if (!result)
			{
				return NotFound();
			}

			return NoContent();
		}
	}
}
