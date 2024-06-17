namespace TFGInfotecAbstractions.Interfaces.Services
{
	public interface IUserService<T> where T : BaseUser
    {
        Task<T> CreateAccount(T user);

		Task<T> GetByEmail(string email);
	}
}
