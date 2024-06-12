using Microsoft.AspNetCore.Mvc;
using TFGInfotecAbstractions.Interfaces;
using TFGInfotecAbstractions.Models;

namespace TFGInfotecApi.Controllers
{
	[ApiController]
	[Route("api/user")]
	public class UserController : ControllerBase
	{
		private readonly IUserManager _userManager;

		public UserController(IUserManager userManager)
        {
			_userManager = userManager;
		}


		[HttpPost("register")]
		public async Task<IActionResult> Register(Registration request, CancellationToken cancellationToken)
		{
			if (ModelState.IsValid)
			{
				var existingUser = await _userManager.GetUserByEmailAsync(request.Email, cancellationToken);
				if (existingUser != null)
				{
					return BadRequest("User with this email already exists.");
				}

				var user = new User
				{
					Name = request.Name,
					Email = request.Email,
					Password = request.Password
				};

				await _userManager.CreateUserAsync(user, cancellationToken);

				return Ok("User registered successfully.");
			}
			return BadRequest(ModelState);
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login(Login request, CancellationToken cancellationToken)
		{
			var user = await _userManager.GetUserByEmailAsync(request.Email, cancellationToken);
			if (user == null || user.Password != request.Password)
			{
				return Unauthorized("Invalid email or password.");
			}
			return Ok("Login successful.");
		}
	}
}