namespace TFGInfotecApi.Controllers
{
	[ApiController]
	[Route("api/[controller]"), Authorize]
	public class DrinkController : ControllerBase
	{
		private readonly IDrinkManager _drinkManager;

		/// <inheritdoc />
		public DrinkController(IDrinkManager drinkManager)
		{
			_drinkManager = drinkManager;
		}

		/// <inheritdoc cref="IDrinkManager.GetDrinksAsync(string)" />
		[HttpGet(nameof(Search)), Authorize]
		public async Task<ActionResult<IEnumerable<Drink>>> Search(string? search)
		{
			string? userId = GetUserId();
			if (userId == null) return BadRequest("Could not find user!");

			return string.IsNullOrEmpty(search) || string.IsNullOrWhiteSpace(search)
				? Ok(await _drinkManager.GetDrinksAsync())
				: Ok(await _drinkManager.GetDrinksAsync(search));
		}

		/// <inheritdoc cref="IDrinkManager.CreateDrinkAsync" />
		[HttpPost(nameof(AddDrink)), Authorize]
		public async Task<ActionResult<Drink>> AddDrink(Drink drink)
		{
			string? userId = GetUserId();
			if (userId == null) return BadRequest("Could not find user!");

			return Ok(await _drinkManager.CreateDrinkAsync(drink));
		}

		/// <inheritdoc cref="IDrinkManager.GetDrinkByIdAsync" />
		[HttpGet("{drinkId}"), Authorize]
		public async Task<ActionResult<Drink>> Details(int drinkId)
		{
			string? userId = GetUserId();
			if (userId == null) return BadRequest("Could not find user!");

			return Ok(await _drinkManager.GetDrinkByIdAsync(drinkId));
		}

		/// <inheritdoc cref="IDrinkManager.UpdateDrinkAsync" />
		[HttpPatch(nameof(Update)), Authorize]
		public async Task<ActionResult<Drink>> Update(Drink drink)
		{
			string? userId = GetUserId();
			if (userId == null) return BadRequest("Could not find user!");

			return Ok(await _drinkManager.UpdateDrinkAsync(drink));
		}

		/// <inheritdoc cref="IDrinkManager.DeleteDrinkAsync" />
		[HttpDelete(nameof(Delete)), Authorize]
		public async Task<ActionResult<bool>> Delete(int drinkId)
		{
			string? userId = GetUserId();
			if (userId == null) return BadRequest("Could not find user!");

			var drink = await _drinkManager.GetDrinkByIdAsync(drinkId);
			if (drink == null) return BadRequest("Could not find drink!");

			bool drinkDeleted = await _drinkManager.DeleteDrinkAsync(drinkId);
			return drinkDeleted ? Ok(drinkDeleted) : BadRequest(drinkDeleted);
		}

		/// <inheritdoc cref="IDrinkManager.GetReviewsForDrinkAsync" />
		[HttpGet("Reviews/{drinkId}"), Authorize]
		public async Task<ActionResult<List<DrinkReview>>> Reviews(int drinkId)
		{
			string? userId = GetUserId();
			if (userId == null) return BadRequest("Could not find user!");

			return Ok(await _drinkManager.GetReviewsForDrinkAsync(drinkId));
		}

		/// <inheritdoc cref="IDrinkManager.AddReviewForDrinkAsync" />
		[HttpPost("Review"), Authorize]
		public async Task<ActionResult<DrinkReview>> Review(DrinkReview drinkReview)
		{
			string? userId = GetUserId();
			if (userId == null) return BadRequest("Could not find user!");

			return Ok(await _drinkManager.AddReviewForDrinkAsync(drinkReview));
		}

		private string? GetUserId()
		{
			return User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
		}
	}
}