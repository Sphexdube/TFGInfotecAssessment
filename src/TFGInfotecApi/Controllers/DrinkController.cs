using System.Security.Claims;

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

		[HttpPost(nameof(AddDrink)), Authorize]
		public async Task<ActionResult<Dish>> AddDrink(Drink drink)
		{
			string? userId = GetUserId();
			if (userId == null) return BadRequest("Could not find user!");

			return Ok(await _drinkManager.CreateDrinkAsync(drink));
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Drink>>> Index(string? search)
		{
			return string.IsNullOrEmpty(search) || string.IsNullOrWhiteSpace(search)
				? Ok(await _drinkManager.GetDrinksAsync())
				: Ok(await _drinkManager.GetDrinksAsync(search));
		}

		[HttpGet("{drinkId}")]
		public async Task<ActionResult<Drink>> Details(int drinkId)
		{
			return Ok(await _drinkManager.GetDrinkByIdAsync(drinkId));
		}

		[HttpGet("Reviews/{drinkId}")]
		public async Task<ActionResult<List<DrinkReview>>> Reviews(int drinkId)
		{
			return Ok(await _drinkManager.GetReviewsForDrink(drinkId));
		}

		[HttpPost("Review"), Authorize]
		public async Task<ActionResult<DrinkReview>> Review(DrinkReview drinkReview)
		{
			return Ok(await _drinkManager.AddReviewForDrink(drinkReview));
		}

		private string? GetUserId()
		{
			return User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
		}
	}
}