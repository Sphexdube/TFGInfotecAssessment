namespace TFGInfotecApi.Controllers
{
	[ApiController]
	[Route("api/[controller]"), Authorize]
	public class DishController : ControllerBase
	{
		private readonly IDishManager _dishManager;

		/// <inheritdoc />
		public DishController(IDishManager dishManager)
		{
			_dishManager = dishManager;
		}

		/// <inheritdoc cref="IDishManager.GetDishesAsync(string)" />
		[HttpGet(nameof(Search)), Authorize]
		public async Task<ActionResult<IEnumerable<Dish>>> Search(string? search)
		{
			string? userId = GetUserId();
			if (userId == null) return BadRequest("Could not find user!");

			return string.IsNullOrEmpty(search) || string.IsNullOrWhiteSpace(search)
				? Ok(await _dishManager.GetDishesAsync())
				: Ok(await _dishManager.GetDishesAsync(search));
		}

		/// <inheritdoc cref="IDishManager.CreateDishAsync" />
		[HttpPost(nameof(AddDish)), Authorize]
		public async Task<ActionResult<Dish>> AddDish(Dish dish)
		{
			string? userId = GetUserId();
			if (userId == null) return BadRequest("Could not find user!");

			return Ok(await _dishManager.CreateDishAsync(dish));
		}

		/// <inheritdoc cref="IDishManager.GetDishByIdAsync" />
		[HttpGet("{dishId}"), Authorize]
		public async Task<ActionResult<Dish>> Details(int dishId)
		{
			string? userId = GetUserId();
			if (userId == null) return BadRequest("Could not find user!");

			return Ok(await _dishManager.GetDishByIdAsync(dishId));
		}

		/// <inheritdoc cref="IDishManager.UpdateDishAsync" />
		[HttpPatch(nameof(Update)), Authorize]
		public async Task<ActionResult<Dish>> Update(Dish dish)
		{
			string? userId = GetUserId();
			if (userId == null) return BadRequest("Could not find user!");

			return Ok(await _dishManager.UpdateDishAsync(dish));
		}

		/// <inheritdoc cref="IDishManager.DeleteDishAsync" />
		[HttpDelete(nameof(Delete)), Authorize]
		public async Task<ActionResult<bool>> Delete(int dishId)
		{
			string? userId = GetUserId();
			if (userId == null) return BadRequest("Could not find user!");

			var dish = await _dishManager.GetDishByIdAsync(dishId);
			if (dish == null) return BadRequest("Could not find dish!");

			bool dishDeleted = await _dishManager.DeleteDishAsync(dishId);
			return dishDeleted ? Ok(dishDeleted) : BadRequest(dishDeleted);
		}

		/// <inheritdoc cref="IDishManager.GetReviewsForDishAsync" />
		[HttpGet("Reviews/{dishId}"), Authorize]
		public async Task<ActionResult<List<DishReview>>> Reviews(int dishId)
		{
			string? userId = GetUserId();
			if (userId == null) return BadRequest("Could not find user!");

			return Ok(await _dishManager.GetReviewsForDishAsync(dishId));
		}

		/// <inheritdoc cref="IDishManager.AddReviewForDishAsync" />
		[HttpPost(nameof(Review)), Authorize]
		public async Task<ActionResult<DishReview>> Review(DishReview dishReview)
		{
			string? userId = GetUserId();
			if (userId == null) return BadRequest("Could not find user!");

			return Ok(await _dishManager.AddReviewForDishAsync(dishReview));
		}

		private string? GetUserId()
		{
			return User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
		}
	}
}