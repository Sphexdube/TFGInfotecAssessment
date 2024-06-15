namespace TFGInfotecAbstractions.Interfaces
{
	public interface IAccountManager
	{
		Task<Customer> CreateAccount(User user);
		Task<string> SignIn(string email, string password);
	}
}
