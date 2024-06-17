public sealed class Image : Entity
{
	[Required]
	public required byte[] Data { get; set; }

	[AllowNull]
	public int ItemId { get; set; }
	public string? Type { get; set; }

	[ForeignKey(nameof(ItemId))]
	[JsonIgnore]
	public Drink? Drink { get; set; }

	[ForeignKey(nameof(ItemId))]
	[JsonIgnore]
	public Dish? Dish { get; set; }
}
