using TFGInfotecAbstractions.Models;

namespace TFGInfotecAbstractions.Interfaces
{
	/// <summary>
	/// Interface for managing user-related operations.
	/// </summary>
	public interface IUserManager
	{
		/// <summary>
		/// Creates a new user asynchronously.
		/// </summary>
		/// <param name="user">The user object to create.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <returns>The created user.</returns>
		Task<User> CreateUserAsync(User user, CancellationToken cancellationToken);

		/// <summary>
		/// Retrieves a user by email asynchronously.
		/// </summary>
		/// <param name="email">The email address of the user to retrieve.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <returns>The user with the specified email.</returns>
		Task<User> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
	}
}