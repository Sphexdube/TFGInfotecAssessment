﻿namespace TFGInfotecAbstractions.Models
{
	public sealed class Account : Entity
	{
		[Required]
		[EmailAddress(ErrorMessage = "Please enter a valid email")]
		public string? Email { get; set; }

		[Required]
		[MinLength(8, ErrorMessage = "Password must be at least of length 8")]
		public string? Password { get; set; }

		[Required]
		public Role Role { get; set; }
	}

	public enum Role
	{
		[Display(Name = "Customer")]
		Customer,
		[Display(Name = "Admin")]
		Admin
	}
}
