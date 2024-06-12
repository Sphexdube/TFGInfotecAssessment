using Microsoft.EntityFrameworkCore;
using TFGInfotecAbstractions.Interfaces;
using TFGInfotecAbstractions.Models;
using TFGInfotecInfrastructure.DataSource;

namespace TFGInfotecCore.Managers
{
	public class UserManager : IUserManager
	{
		private readonly DatabaseContext _dbContext;

		public UserManager(DatabaseContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<User> CreateUserAsync(User user, CancellationToken cancellationToken)
		{
			_dbContext.Users.Add(user);
			await _dbContext.SaveChangesAsync(cancellationToken);
			return user;
		}

		public async Task<User> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
		{
			return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
		}
	}
}
