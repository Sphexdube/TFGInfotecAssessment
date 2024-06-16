namespace TFGInfotecApi.Controllers
{
	[ApiController]
	[Route("api/[controller]"), Authorize]
	public class DrinkController : ControllerBase
	{
		private readonly IDrinkManager _drinkManager;

		public DrinkController(IDrinkManager drinkManager)
		{
			_drinkManager = drinkManager;
		}

		[HttpGet(nameof(Search))]
		public async Task<ActionResult<IEnumerable<Drink>>> Search(string? search)
		{
			string? userId = GetUserId();
			if (userId == null) return BadRequest("Could not find user!");

			return string.IsNullOrEmpty(search) || string.IsNullOrWhiteSpace(search)
				? Ok(await _drinkManager.GetDrinksAsync())
				: Ok(await _drinkManager.GetDrinksAsync(search));
		}

		[HttpPost(nameof(AddDrink)), Authorize]
		public async Task<ActionResult<Dish>> AddDrink(Drink drink)
		{
			string? userId = GetUserId();
			if (userId == null) return BadRequest("Could not find user!");

			return Ok(await _drinkManager.CreateDrinkAsync(drink));
		}

		[HttpGet("{drinkId}")]
		public async Task<ActionResult<Drink>> Details(int drinkId)
		{
			string? userId = GetUserId();
			if (userId == null) return BadRequest("Could not find user!");

			return Ok(await _drinkManager.GetDrinkByIdAsync(drinkId));
		}

		[HttpPatch(nameof(Update))]
		public async Task<ActionResult<Drink>> Update(Drink drink)
		{
			string? userId = GetUserId();
			if (userId == null) return BadRequest("Could not find user!");

			return Ok(await _drinkManager.UpdateDrinkAsync(drink));
		}

		[HttpDelete(nameof(Delete))]
		public async Task<ActionResult<bool>> Delete(int drinkId)
		{
			string? userId = GetUserId();
			if (userId == null) return BadRequest("Could not find user!");

			var dish = await _drinkManager.GetDrinkByIdAsync(drinkId);
			if (dish == null) return BadRequest("Could not find dish!");

			bool drinkDeleted = await _drinkManager.DeleteDrinkAsync(drinkId);
			return drinkDeleted ? Ok(drinkDeleted) : BadRequest(drinkDeleted);
		}

		[HttpGet("Reviews/{drinkId}")]
		public async Task<ActionResult<List<DrinkReview>>> Reviews(int drinkId)
		{
			string? userId = GetUserId();
			if (userId == null) return BadRequest("Could not find user!");

			return Ok(await _drinkManager.GetReviewsForDrinkAsync(drinkId));
		}

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