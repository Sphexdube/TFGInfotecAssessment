namespace TFGInfotecAbstractions.Models
{
	public class Drink : TrackedEntity
	{
		[Required]
		public required string Name { get; set; }

		[Required]
		public required string Description { get; set; }

		[Required]
		[Range(0, 1)]
		public float Rating { get; set; } = 0;

		[Required]
		[Column(TypeName = "Decimal(18,2)")]
		public double Price { get; set; }

		public Image Image { get; set; }
	}
}