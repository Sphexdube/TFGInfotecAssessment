namespace TFGInfotecAbstractions.Models
{
	public abstract class TrackedEntity : Entity
	{
		[Required]
		public bool Deleted { get; set; } = false;
	}
}
