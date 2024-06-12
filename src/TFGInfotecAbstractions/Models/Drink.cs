using System.ComponentModel.DataAnnotations;
using TFGInfotecAbstractions.Interfaces;

namespace TFGInfotecAbstractions.Models
{
	public class Drink : IMenuItem
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string Description { get; set; }

		[Required]
		public double Price { get; set; }

		public string Image { get; set; }

		public int Rating { get; set; }
	}
}
