using System.Security.Claims;

namespace TFGInfotecApi.Controllers
{
	[ApiController]
	[Route("api/[controller]"), Authorize]
	public class DishController : ControllerBase
	{
		private readonly IDishManager _dishManager;

		public DishController(IDishManager dishManager)
        {
			_dishManager = dishManager;
		}

		[HttpPost(nameof(AddDish)), Authorize]
		public async Task<ActionResult<Dish>> AddDish(Dish dish)
		{
			string? userId = GetUserId();
			if (userId == null) return BadRequest("Could not find user!");

			return Ok(await _dishManager.CreateDishAsync(dish));
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Dish>>> Index(string? search)
		{
			return string.IsNullOrEmpty(search) || string.IsNullOrWhiteSpace(search)
				? Ok(await _dishManager.GetDishesAsync())
				: Ok(await _dishManager.GetDishesAsync(search));
		}

		[HttpGet(nameof(dishId))]
		public async Task<ActionResult<Dish>> Details(int dishId) 
		{
			return Ok(await _dishManager.GetDishByIdAsync(dishId));
		}

		[HttpGet(nameof(Reviews))]
		public async Task<ActionResult<List<DishReview>>> Reviews(int dishId) 
		{
			return Ok(await _dishManager.GetReviewsForDish(dishId));
		}

		[HttpPost(nameof(Review)), Authorize]
		public async Task<ActionResult<DishReview>> Review(DishReview dishReview) 
		{
			return Ok(await _dishManager.AddReviewForDish(dishReview));
		}

		private string? GetUserId()
		{
			return User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
		}
	}
}
