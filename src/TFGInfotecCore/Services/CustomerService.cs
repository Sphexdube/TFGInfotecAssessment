using System.Linq.Expressions;

namespace TFGInfotecCore.Services
{
	public class CustomerService : ICustomerService
	{
		private readonly IRepository<Customer> _customerRepository;

        public CustomerService(IRepository<Customer> customerRepository)
        {
			_customerRepository = customerRepository;
		}

        public async Task<Customer> CreateAccount(Customer user)
		{
			Customer newCustomer = await _customerRepository.Add(user);
			return newCustomer;
		}

		public async Task<Customer> GetByEmail(string email)
		{
			Expression<Func<Customer, bool>> filterExpression = e => e!.User!.Account!.Email!.Equals(email);

			IQueryable<Customer> filter(IQueryable<Customer> e) => e.Where(filterExpression);

			Customer? customer = await _customerRepository.GetOne(filter);
			return customer!;
		}
	}
}
