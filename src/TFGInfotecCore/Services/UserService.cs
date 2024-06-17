namespace TFGInfotecCore.Services
{
	public class UserService<T> : IUserService<T> where T : BaseUser
	{
		private readonly IRepository<T> _userRepository;

		public UserService(IRepository<T> userRepository)
        {
			_userRepository = userRepository;
		}

        public async Task<T> CreateAccount(T user)
		{
			T newUser = await _userRepository.Add(user);
			return newUser;
		}

		public async Task<T> GetByEmail(string email)
		{
			Expression<Func<T, bool>> filterExpression = e => e!.User!.Account!.Email!.Equals(email);

			IQueryable<T> filter(IQueryable<T> e) => e.Where(filterExpression);
			IIncludableQueryable<T, object> include(IQueryable<T> e) => e.Include(e => e.User!).ThenInclude(e => e.Account!);

			T? user = await _userRepository.GetOne(filter, include);
			return user;
		}
	}
}
