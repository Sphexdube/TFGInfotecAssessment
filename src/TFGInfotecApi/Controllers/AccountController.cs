namespace TFGInfotecApi.Controllers
{
	/// <summary>
	/// Controller for managing account-related actions such as sign up and sign in.
	/// </summary>
	[ApiController]
	[Route("api/[controller]"), Authorize]
	public class AccountController : ControllerBase
	{
		/// <summary>
		/// Manages account operations.
		/// </summary>
		private readonly IAccountManager _accountManager;

		/// <summary>
		/// Initializes a new instance of the <see cref="AccountController"/> class with the specified account manager.
		/// </summary>
		/// <param name="accountManager">The account manager.</param>
		public AccountController(IAccountManager accountManager)
		{
			_accountManager = accountManager;
		}

		/// <summary>
		/// Creates a new user account.
		/// </summary>
		/// <param name="user">The user details for the account creation.</param>
		/// <returns>A newly created <see cref="Customer"/> object.</returns>
		[HttpPost(nameof(SignUp)), AllowAnonymous]
		public async Task<ActionResult<Customer>> SignUp(User user)
		{
			return Ok(await _accountManager.CreateAccount(user));
		}

		/// <summary>
		/// Authenticates a user and generates a JWT token.
		/// </summary>
		/// <param name="signIn">The sign-in details containing email and password.</param>
		/// <returns>A JWT token if the authentication is successful; otherwise, a bad request.</returns>
		[HttpPost(nameof(SignIn)), AllowAnonymous]
		public async Task<ActionResult<string>> SignIn(SignIn signIn)
		{
			string jwt = await _accountManager.SignIn(signIn.Email, signIn.Password);
			return jwt == null ? BadRequest("Invalid SignIn") : Ok(jwt);
		}
	}
}