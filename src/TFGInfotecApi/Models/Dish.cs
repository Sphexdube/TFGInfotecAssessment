using System.ComponentModel.DataAnnotations;
using TFGInfotecApi.Interfaces;

namespace TFGInfotecApi.Models
{
	public class Dish : IMenuItem
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int Rating { get; set; }
		public double Price { get; set; }
		public string Image { get; set; }
	}
}


