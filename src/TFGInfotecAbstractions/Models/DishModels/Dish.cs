namespace TFGInfotecAbstractions.Models.DishModels
{
    public class Dish : TrackedEntity
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

        [AllowNull]
		public virtual List<Image> Images { get; set; } = new();
	}
}


