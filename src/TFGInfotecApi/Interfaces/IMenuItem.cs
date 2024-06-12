namespace TFGInfotecApi.Interfaces
{
	public interface IMenuItem
	{
		string Name { get; set; }
		string Description { get; set; }
		int Rating { get; set; }
		public double Price { get; set; }
		public string Image { get; set; }
	}
}
