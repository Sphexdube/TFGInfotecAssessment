﻿namespace TFGInfotecAbstractions.Models
{
	public abstract class Entity
	{
		[Key]
		public virtual int Id { get; set; }
	}
}
