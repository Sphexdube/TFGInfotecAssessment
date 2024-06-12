using TFGInfotecApi.Interfaces;
using TFGInfotecApi.Managers;

namespace TFGInfotecApi.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static void AddManagers(this IServiceCollection services)
		{
			services.AddScoped<IDishManager, DishManager>();
			services.AddScoped<IDrinkManager, DrinkManager>();
		}
	}
}
