using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TFGInfotecAbstractions.Interfaces;
using TFGInfotecAbstractions.Models;
using TFGInfotecInfrastructure.DataSource;

namespace TFGInfotecCore.Managers
{
	public class UserManager : IUserManager
	{
		private readonly DatabaseContext _dbContext;
		private readonly ILogger<UserManager> _logger;

		public UserManager(DatabaseContext dbContext, ILogger<UserManager> logger)
		{
			_dbContext = dbContext;
			_logger = logger;
		}

		public async Task<User> CreateUserAsync(User user, CancellationToken cancellationToken)
		{
			try
			{
				_dbContext.Users.Add(user);
				await _dbContext.SaveChangesAsync(cancellationToken);
				return user;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while creating a user.");
				throw;
			}
		}

		public async Task<User> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
		{
			try
			{
				return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"An error occurred while fetching the user with email: {email}.");
				throw;
			}
		}
	}
}
