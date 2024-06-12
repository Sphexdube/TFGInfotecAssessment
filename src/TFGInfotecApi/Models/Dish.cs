using System.ComponentModel.DataAnnotations;
using TFGInfotecApi.Interfaces;

namespace TFGInfotecApi.Models
{
	public class Dish : IMenuItem
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string Description { get; set; }

		[Required]
		public int Rating { get; set; }

		public double Price { get; set; }

		public string Image { get; set; }
	}
}


