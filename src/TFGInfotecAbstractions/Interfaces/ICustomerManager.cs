namespace TFGInfotecAbstractions.Interfaces
{
	public interface ICustomerManager
	{
		Task<List<T>> SearchItems<T>(string query, string type) where T : class, IMenuItem;
		Task<T> GetItemById<T>(int id, string type) where T : class;
		Task<bool> UpdateItemRating<T>(int id, int rating, string type) where T : class, IMenuItem;
	}
}
