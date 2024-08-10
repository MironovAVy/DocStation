﻿namespace DocStation.Data.Models
{
	public class TUsers : IEntity
	{
		public int Id { get; set; }

		public string Email { get; set; }

		//Secure Mode
		public string Password { get; set; }

		public string UserName { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public DateTime BirthDate { get; set; }
	}
}
